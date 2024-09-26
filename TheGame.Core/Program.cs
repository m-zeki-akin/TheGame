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

Log.Logger = new LoggerConfiguration().CreateLogger();
builder.Services.AddControllers();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
builder.Services.AddSignalR();
builder.Services.AddSingleton<GameRules>()

    //Cache
    .AddSingleton<ICacheService<Planet>, CacheService<Planet>>()
    .AddSingleton<ICacheService<PlanetResearch>, CacheService<PlanetResearch>>()
    .AddSingleton<ICacheService<PlanetResearch>, CacheService<PlanetResearch>>()
    .AddSingleton<ICacheService<PlanetBuildingConstructionItem>, CacheService<PlanetBuildingConstructionItem>>()
    .AddSingleton<ICacheService<PlanetBuildingSpaceObjectItem>, CacheService<PlanetBuildingSpaceObjectItem>>()
    .AddSingleton<ICacheService<Fleet>, CacheService<Fleet>>()

    //Data Context
    .AddDbContext<StaticDataContext>(options =>
        options.UseNpgsql(builder.Configuration.GetConnectionString("StaticDbConnection")))
    .AddDbContext<ReadOnlyReplicaContext>(options =>
        options.UseNpgsql(builder.Configuration.GetConnectionString("QueryDbConnection")))
    .AddDbContext<MainDataContext>(options =>
        options.UseNpgsql(builder.Configuration.GetConnectionString("CommandDbConnection")))

    //Validators
    .AddTransient<IFleetObjectiveCalculatedEventValidator, FleetObjectiveCalculatedEventValidator>()

    //Services
    .AddScoped<IPlanetUpdateService, PlanetUpdateService>()
    .AddScoped<IFleetUpdateService, FleetUpdateService>()
    .AddScoped<IFleetObjectiveCalculationService, FleetObjectiveCalculationService>()

    //Background Services
    .AddScoped<SnapshotService>()
    .AddHostedService(sp => sp.GetRequiredService<SnapshotService>())
    .AddScoped<GameUpdateService>()
    .AddHostedService(sp => sp.GetRequiredService<GameUpdateService>())
    .AddEndpointsApiExplorer()
    .AddSwaggerGen();

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