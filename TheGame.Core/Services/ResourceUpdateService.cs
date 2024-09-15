using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TheGame.Core.Commands;
using TheGame.Core.Data;
using TheGame.Core.Entities;
using TheGame.Core.Entities.Buildings;

namespace TheGame.Core.Services;

public class ResourceUpdateService : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;
    private static readonly TimeSpan UpdateInterval = TimeSpan.FromSeconds(5);

    public ResourceUpdateService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await UpdateAllPlanetResources(stoppingToken);
            await Task.Delay(UpdateInterval, stoppingToken);
        }
    }

    private async Task UpdateAllPlanetResources(CancellationToken cancellationToken)
    {
        using var scope = _serviceProvider.CreateScope();
        var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();

        var dbContext = scope.ServiceProvider.GetRequiredService<MainDataContext>();
        var activePlanets = await dbContext.Planets
            .Include(p => p.Buildings)
            .Where(p => p.IsActive) 
            .ToListAsync(cancellationToken);

        foreach (var planet in activePlanets)
        {
            var totalProducedResources = CalculateTotalProduction(planet.Buildings);
            
            var command = new UpdatePlanetResourcesCommand
            {
                PlanetId = planet.Id,
                ResourcesToAdd = totalProducedResources
            };

            await mediator.Send(command, cancellationToken);
        }
    }

    private ResourceValue CalculateTotalProduction(IEnumerable<PlanetBuilding> planetBuildings)
    {
        var totalResources = new ResourceValue();

        foreach (var planetBuilding in planetBuildings)
        {
            if (planetBuilding.Building is ResourceBuilding resourceBuilding)
            {
                var productionRate = resourceBuilding.ResourceProductionsRate;

                totalResources.Fuel += productionRate.Fuel;
                totalResources.Material += productionRate.Material;
                totalResources.Energy += productionRate.Energy;
                totalResources.Alloy += productionRate.Alloy;
                totalResources.Actinium += productionRate.Actinium;
                totalResources.Plutonium += productionRate.Plutonium;
                totalResources.Polonium += productionRate.Polonium;
                totalResources.Technetium += productionRate.Technetium;
            }
        }

        return totalResources;
    }
}