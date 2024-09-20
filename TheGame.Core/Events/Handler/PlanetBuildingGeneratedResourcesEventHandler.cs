using System.Collections.Concurrent;
using MediatR;
using TheGame.Core.Cache;
using TheGame.Core.Entities;
using TheGame.Core.Entities.Buildings;

namespace TheGame.Core.Events.Handler;

public class PlanetBuildingGeneratedResourcesEventHandler(
    GameCache<Planet> planetCache)
    : INotificationHandler<PlanetBuildingGeneratedResourcesEvent>
{
    public Task Handle(PlanetBuildingGeneratedResourcesEvent notification, CancellationToken cancellationToken)
    {
        var planet = planetCache.Get(notification.PlanetId);
        
        ResourceBuilding planetBuilding = (ResourceBuilding)planet!.Buildings
            .First(b => b.Id == notification.PlanetBuildingId).Building;

        var generated = planetBuilding.ResourceProductionsRate;

        planet.StoredResources += generated;
        
        return Task.CompletedTask;
    }
}