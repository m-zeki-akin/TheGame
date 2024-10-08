using MediatR;
using TheGame.Core.Game.Cache;
using TheGame.Core.Game.Entities;
using TheGame.Core.Game.Entities.Buildings;

namespace TheGame.Core.Game.Events.Handler;

public class PlanetBuildingGeneratedResourcesEventHandler(
    ICacheService<Planet> planetCache)
    : INotificationHandler<PlanetBuildingGeneratedResourcesEvent>
{
    public Task Handle(PlanetBuildingGeneratedResourcesEvent notification, CancellationToken cancellationToken)
    {
        var planet = planetCache.Get(notification.PlanetId);

        var planetBuilding = (ResourceBuilding)planet.Buildings
            .First(b => b.Id == notification.PlanetBuildingId).Building;

        var generated = planetBuilding.ResourceProductionsRate;

        planet.StoredResources += generated;

        return Task.CompletedTask;
    }
}