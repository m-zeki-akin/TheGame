using MediatR;
using TheGame.Core.Game.Cache;
using TheGame.Core.Game.Entities;
using TheGame.Core.Game.Entities.Buildings;
using TheGame.Core.Game.Entities.Buildings.Buildings;
using TheGame.Core.Game.Events;
using TheGame.Core.Game.Services.Interface;
using TheGame.Core.Helper;

namespace TheGame.Core.Game.Services;

public class PlanetUpdateService(
    IMediator mediator,
    ICacheService<Planet> planetCache,
    ICacheService<PlanetResearch> planetResearchCache,
    ICacheService<PlanetBuilding> planetBuildingsCache,
    ICacheService<PlanetBuildingConstructionItem> planetBuildingConstructionItemCache,
    ICacheService<PlanetBuildingSpaceObjectItem> planetBuildingSpaceObjectItemCache)
    : IPlanetUpdateService
{
    /*
private readonly GameCache<Planet> _planetCache;
private readonly IServiceProvider _serviceProvider;
private readonly PlanetBulkOperationsHelper _planetBulkOperationsHelper = new();

public PlanetUpdateService(IServiceProvider serviceProvider)
{
    _serviceProvider = serviceProvider;
}

public async Task UpdatePlanetsDb(CancellationToken cancellationToken)
{
    using var scope = _serviceProvider.CreateScope();
    var dbContext = scope.ServiceProvider.GetRequiredService<MainDataContext>();

    const int batchSize = 6000;
    long lastProcessedPlanetId = 0;

    while (true)
    {
        var id = lastProcessedPlanetId;
        var allActivePlanetsBatched = await dbContext.Planets
            .Where(p => p.IsActive && p.Id > id)
            .OrderBy(p => p.Id)
            .Take(batchSize)
            .ToListAsync(cancellationToken);

        if (allActivePlanetsBatched.Count == 0)
        {
            break;
        }

        foreach (var planet in allActivePlanetsBatched)
        {
            await AddResourcesFromResourceBuildings(planet);
            await AddResourcesFromDockedFleet(planet);
            await ProduceBuilding(planet, _planetBulkOperationsHelper);
        }

        await _planetBulkOperationsHelper.PerformBulkOperations(dbContext, _planetBulkOperationsHelper,
            cancellationToken);

        lastProcessedPlanetId = allActivePlanetsBatched.Last().Id;
    }
}
*/

    public async Task UpdatePlanets(CancellationToken cancellationToken)
    {
        var planets = planetCache.GetAll().Result;

        foreach (var planet in planets)
        {
            if (planet.IsActive)
            {
                AddResourcesFromResourceBuildings(planet);
                ProduceBuilding(planet);
            }
        }
    }

    private void AddResourcesFromResourceBuildings(Planet planet)
    {
        var storage = planet.StoredResources;

        foreach (var planetBuilding in planet.Buildings)
        {
            if (planetBuilding.Building is ResourceBuilding resourceBuilding)
            {
                storage += resourceBuilding.ResourceProductionsRate;
            }
        }
    }

    private void ProduceBuilding(Planet planet)
    {
        if (planet.ConstructionBuilding.Production.Any())
        {
            for (var i = 0; i < planet.ConstructionBuilding.ProductionSlot; i++)
            {
                var constructionItem = planet.ConstructionBuilding.Production
                    .FirstOrDefault(c => c.Order == i);
                if (constructionItem == null)
                {
                    break;
                }

                constructionItem.CurrentProduction += planet.ConstructionBuilding.WorkRate;

                if (constructionItem.CurrentProduction <
                    constructionItem.PlanetBuilding.Building.ProductionCost)
                {
                    planetBuildingConstructionItemCache.Set(constructionItem.Id, constructionItem);
                }
                else
                {
                    planetBuildingConstructionItemCache.Remove(constructionItem.Id);
                    foreach (var item in planet.ConstructionBuilding.Production)
                    {
                        if (item.Order > constructionItem.Order)
                        {
                            item.Order--;
                            planetBuildingConstructionItemCache.Set(item.Id, item);
                        }
                    }

                    planetBuildingsCache.Set(constructionItem.PlanetBuildingId,
                        constructionItem.PlanetBuilding);

                    var @event = new ConstructionCompletedEvent
                    {
                        PlanetId = planet.Id,
                        BuildingId = constructionItem.PlanetBuilding.BuildingId
                    };
                    mediator.Publish(@event);
                }
            }
        }
    }

    private Task DemolishBuilding(
        PlanetBuilding planetBuilding,
        PlanetBulkOperationsHelper helper)
    {
        if (planetBuilding.Building.Level > 1)
        {
            planetBuilding.BuildingId = (long)planetBuilding.Building.PreviousLevelBuildingId!;
            planetBuilding.Building = planetBuilding.Building.PreviousLevelBuilding!;
            helper.PlanetBuildingsToAdd.Add(planetBuilding);
        }
        else
        {
            helper.PlanetBuildingsToRemove.Add(planetBuilding);
        }

        return Task.CompletedTask;
    }
}