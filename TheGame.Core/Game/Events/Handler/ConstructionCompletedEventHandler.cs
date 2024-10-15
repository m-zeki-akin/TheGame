using MediatR;
using TheGame.Core.Game.Cache.Interfaces;
using TheGame.Core.Game.Entities.Buildings;
using TheGame.Core.Game.Entities.Productions;
using TheGame.Core.Game.Entities.StellarObjects;

namespace TheGame.Core.Game.Events.Handler;

public class ConstructionCompletedEventHandler(
    ICacheService<Planet> planetCache,
    ICacheService<PlanetBuilding> planetBuildingCache,
    ICacheService<BuildingProductionItem> constructionItemCache)
    : INotificationHandler<ConstructionCompletedEvent>
{
    public async Task Handle(ConstructionCompletedEvent @event, CancellationToken cancellationToken)
    {
        var productionItem = constructionItemCache.Get(@event.ConstructionItemId);
        var planet = planetCache.Get(productionItem.ProducedBuilding.PlanetId);

        var producedBuilding = productionItem.ProducedBuilding;
        var replacedBuilding = productionItem.ReplacedBuilding;

        if (replacedBuilding != null)
        {
            replacedBuilding.BuildingId = producedBuilding.BuildingId;
            replacedBuilding.Building = producedBuilding.Building;
        }
        else
        {
            var planetBuilding = new PlanetBuilding
            {
                Id = new Guid(),
                Building = producedBuilding.Building,
                BuildingId = producedBuilding.BuildingId,
                Planet = producedBuilding.Planet,
                PlanetId = producedBuilding.PlanetId,
                IsEnabled = true
            };
            planetBuildingCache.Set(planetBuilding.Id, planetBuilding);

            switch (planetBuilding.Building)
            {
                case ResearchBuilding b:
                    planet.ResearchBuildings.Add(b);
                    break;
                case ResourceBuilding b:
                    planet.ResourceBuildings.Add(b);
                    break;
                case FactoryBuilding b:
                    planet.FactoryBuildings.Add(b);
                    break;
            }
        }

        constructionItemCache.Remove(@event.ConstructionItemId);

        await Task.CompletedTask;
    }
}