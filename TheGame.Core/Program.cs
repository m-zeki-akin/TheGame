using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TheGame.Core.Cache;
using TheGame.Core.Data;
using TheGame.Core.Entities;
using TheGame.Core.Entities.Buildings.ProductionQueue;
using TheGame.Core.Hubs;
using TheGame.Core.Services;
using TheGame.Core.Services.Interface;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSignalR();

builder.Services.AddControllers();

builder.Services.AddDbContext<StaticDataContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("StaticDbConnection")));

builder.Services.AddDbContext<ReadOnlyReplicaContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("QueryDbConnection")));

builder.Services.AddDbContext<MainDataContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("CommandDbConnection")));

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

builder.Services.AddSingleton<GameCache<Planet>>();
builder.Services.AddSingleton<GameCache<PlanetResearch>>();
builder.Services.AddSingleton<GameCache<PlanetBuilding>>();
builder.Services.AddSingleton<GameCache<PlanetBuildingConstructionItem>>();
builder.Services.AddSingleton<GameCache<PlanetBuildingSpaceObjectItem>>();

builder.Services.AddSingleton<GameCache<Fleet>>();

builder.Services.AddScoped<IPlanetUpdateService, PlanetUpdateService>();
builder.Services.AddScoped<IFleetUpdateService, FleetUpdateService>();

builder.Services.AddHostedService<GameUpdateService>();
builder.Services.AddHostedService<SnapshotService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.MapHub<GameHub>("/gameHub");

app.UseAuthorization();

app.MapControllers();

app.Run();