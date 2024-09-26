using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using TheGame.Core.Game.Cache;
using TheGame.Core.Game.Data;
using TheGame.Core.Game.Entities;
using TheGame.Core.Game.Entities.Buildings.Buildings;
using TheGame.Core.Game.Events.Validators;
using TheGame.Core.Game.Events.Validators.Interfaces;
using TheGame.Core.Game.Hubs;
using TheGame.Core.Game.Services;
using TheGame.Core.Game.Services.Interface;
using TheGame.Core.Game.Shared;

var builder = WebApplication.CreateBuilder(args);
var sc = builder.Services;
Log.Logger = new LoggerConfiguration().CreateLogger();

sc.AddControllers();
sc.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
sc.AddSignalR();
sc.AddSingleton<GameRules>();

//Cache
sc.AddSingleton<ICacheService<Planet>, CacheService<Planet>>();
sc.AddSingleton<ICacheService<PlanetBuilding>, CacheService<PlanetBuilding>>();
sc.AddSingleton<ICacheService<PlanetResearch>, CacheService<PlanetResearch>>();
sc.AddSingleton<ICacheService<PlanetBuildingConstructionItem>, CacheService<PlanetBuildingConstructionItem>>();
sc.AddSingleton<ICacheService<PlanetBuildingSpaceObjectItem>, CacheService<PlanetBuildingSpaceObjectItem>>();
sc.AddSingleton<ICacheService<Fleet>, CacheService<Fleet>>();

//Data Context
sc.AddDbContext<StaticDataContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("StaticDbConnection")));
sc.AddDbContext<ReadOnlyReplicaContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("QueryDbConnection")));
sc.AddDbContext<MainDataContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("CommandDbConnection")));

//Validators
sc.AddTransient<IFleetObjectiveCalculatedEventValidator, FleetObjectiveCalculatedEventValidator>();

//Services
sc.AddScoped<IPlanetUpdateService, PlanetUpdateService>();
sc.AddScoped<IFleetUpdateService, FleetUpdateService>();
sc.AddScoped<IFleetObjectiveCalculationService, FleetObjectiveCalculationService>();

//Background Services
sc.AddScoped<SnapshotService>();
sc.AddHostedService(sp => sp.GetRequiredService<SnapshotService>());
sc.AddScoped<GameUpdateService>();
sc.AddHostedService(sp => sp.GetRequiredService<GameUpdateService>());
sc.AddEndpointsApiExplorer();
sc.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyGame API v1"));

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.MapHub<GameHub>("/Hub");

app.UseAuthorization();

app.MapControllers();

app.Run();