using System.Diagnostics;
using MediatR;
using Serilog;
using TheGame.Core.Game.Cache;
using TheGame.Core.Game.Entities;
using TheGame.Core.Game.Entities.Buildings;
using TheGame.Core.Game.Entities.Buildings.Buildings;
using TheGame.Core.Game.Events;
using TheGame.Core.Game.Services.Interface;
using TheGame.Core.Game.Shared.Enums;
using TheGame.Core.Game.Shared.ValueObjects;

namespace TheGame.Core.Game.Services;

public class PlanetUpdateService(
    IMediator mediator,
    ICacheService<Planet> planetCache,
    IStaticCacheService<ResourceCost> resourceCostCache
    )
    : IPlanetUpdateService
{
    public async Task UpdateAsync(CancellationToken ct)
    {
        var planets = planetCache.GetAll().Where(p => p.IsActive);

        Stopwatch stopwatch = Stopwatch.StartNew();

        foreach (var planet in planets)
        {
            await Task.WhenAll(
                Task.Run(async () => await ProcessBuildingsAsync(planet), ct),
                Task.Run(async () => await ProcessConstructionsAsync(planet), ct)
            );

        }

        stopwatch.Stop();
        Log.Information("Planet update time: {time}", stopwatch.Elapsed);

        await Task.CompletedTask;
    }

    private async Task ProcessBuildingsAsync(Planet planet)
    {
        var storage = planet.StoredResources;

        foreach (var building in planet.Buildings)
        {
            if (building.Building.ResourceConsumptionsRate != null) // Process building Resource Consumption
            {
                var resourceCost = resourceCostCache.Get(building.Building.ResourceConsumptionsRate!.Id);
                (storage, var negativeResources) = storage - resourceCost!.ResourceValue;
                if (negativeResources.Count > 0)
                {
                    storage += resourceCost.ResourceValue;
                    building.IsEnabled = false;
                }
            }
            
            if (building.Building is ResourceBuilding resourceBuilding) // Process building Resource Generation
            {
                storage += resourceBuilding.ResourceProductionsRate;
            }            
            
            if (building.Building is FactoryBuilding factoryBuilding) // Process building Resource Generation
            {
                var production = factoryBuilding.Productions.FirstOrDefault();

                if (production != null)
                {
                    production.CurrentProduction += factoryBuilding.WorkRate;
                    if (production.CurrentProduction >=
                        production.SpaceObject.ProductionCost)
                    {
                        var @event = new ProductionCompletedEvent
                        {
                            PlanetId = planet.Id,
                            Production = production.SpaceObject,
                        };
                        await mediator.Publish(@event);
                    }
                }
            }
        }
        
        await Task.CompletedTask;
    }

    private async Task ProcessConstructionsAsync(Planet planet)
    {
        var production = planet.ConstructionBuilding.Productions.FirstOrDefault();

        if (production != null)
        {
            production.CurrentProduction += planet.ConstructionBuilding.WorkRate; // TODO add bonuses(research etc...)
            
            if (production.CurrentProduction >=
                production.ProducedBuilding.ProductionCost)
            {
                var @event = new ConstructionCompletedEvent
                {
                    PlanetId = planet.Id,
                    ConstructionItemId = production.Id
                };
                await mediator.Publish(@event);
            }
        }
        
        await Task.CompletedTask;
    }

    private void ProcessBuildingResourceGeneration(PlanetBuilding building, ResourceValue storage)
    {

    }
    
    /*
    for (var i = 0; i < planet.ConstructionFacility.ProductionSlot; i++)
    {
        var constructionItem = planet.ConstructionFacility.Productions
            .FirstOrDefault(c => c.Order == i);
        if (constructionItem != null)
        {
            if (constructionItem.CurrentProduction >=
                constructionItem.ConstructingPlanetBuilding.Building.ProductionCost)
            {
                var @event = new ConstructionCompletedEvent
                {
                    PlanetId = planet.Id,
                    PlanetId = planet.Id,
                    AddedBuildingId = constructionItem.ConstructingPlanetBuildingId,
                    AddedBuilding = constructionItem.ConstructingPlanetBuilding,
                    ReplacedBuildingId = constructionItem.ReplacingPlanetBuildingId,
                    ReplacedBuilding = constructionItem.ReplacingPlanetBuilding
                };
                //TODO add contructed building to planetBuildings cache. remove replaced building from that cache too.
                await mediator.Publish(@event);

                planet.ConstructionFacility.Productions.Remove(constructionItem);
                i--;
            }
        }
        else
        {
            break;
        }
    }


    await Task.CompletedTask;
}
*/
/*
    private Task DemolishBuilding(PlanetBuilding planetBuilding)
    {
        if (planetBuilding.Building.Level > 1)
        {
            var toBuilding = buildingCache.Get((long)planetBuilding.Building.PreviousLevelBuildingId!);
            planetBuilding.BuildingId = toBuilding!.Id;
            planetBuilding.Building = toBuilding;
            planetBuildingsCache.Set(planetBuilding.Id, planetBuilding);
        }
        else
        {
            planetBuildingsCache.Remove(planetBuilding.Id);
        }

        return Task.CompletedTask;
    }
    */ //TODO This is command. use controller
}