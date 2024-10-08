using System.Collections.Concurrent;
using MediatR;
using TheGame.Core.Game.Cache;
using TheGame.Core.Game.Entities;
using TheGame.Core.Game.Entities.Buildings;
using TheGame.Core.Game.Entities.Buildings.Buildings;

namespace TheGame.Core.Game.Events.Handler;

public class ConstructionCompletedEventHandler(
    ICacheService<Planet> planetCache,
    ICacheService<PlanetBuilding> planetBuildingCache,
    ICacheService<BuildingProductionItem> constructionItemCache) 
    : INotificationHandler<ConstructionCompletedEvent>
{

    public async Task Handle(ConstructionCompletedEvent @event, CancellationToken cancellationToken)
    {
        var planet = planetCache.Get(@event.PlanetId);
        var productionItem = constructionItemCache.Get(@event.ConstructionItemId);
        
        var producedBuilding = productionItem.ProducedBuilding;
        var replacedBuilding = productionItem.ReplacedBuilding;

        if (replacedBuilding != null)
        {
            var replacedPlanetBuilding = planet.Buildings.First(o=> o.BuildingId == replacedBuilding.Id);
            replacedPlanetBuilding.BuildingId = producedBuilding.Id;
            replacedPlanetBuilding.Building = producedBuilding;
        }
        else
        {
            var planetBuilding = new PlanetBuilding
            {
                Id = new Guid(),
                Building = producedBuilding,
                BuildingId = producedBuilding.Id,
                Planet = planet,
                PlanetId = planet.Id,
                IsEnabled = true
            };
            planetBuildingCache.Set(planetBuilding.Id, planetBuilding);
            planet.Buildings.Add(planetBuilding);
        }

        foreach (var production in planet.ConstructionBuilding.Productions
                     .Where(c => c.Order > productionItem.Order))
        {
            production.Order--;
        }
        
        constructionItemCache.Remove(@event.ConstructionItemId);
        
        await Task.CompletedTask;
    }
}