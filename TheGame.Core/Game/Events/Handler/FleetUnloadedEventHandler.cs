using MediatR;
using TheGame.Core.Game.Cache;
using TheGame.Core.Game.Cache.Interfaces;
using TheGame.Core.Game.Entities;
using TheGame.Core.Game.Entities.Fleets;
using TheGame.Core.Game.Entities.StellarObjects;

namespace TheGame.Core.Game.Events.Handler;

public class FleetUnloadedEventHandler(
    ICacheService<Planet> planetCache,
    ICacheService<Fleet> fleetCache)
    : INotificationHandler<FleetUnloadedEvent>
{
    public Task Handle(FleetUnloadedEvent notification, CancellationToken cancellationToken)
    {
        var planet = planetCache.Get(notification.PlanetId);
        var fleet = fleetCache.Get(notification.FleetId);

        planet.StoredResources += fleet.Stock;

        return Task.CompletedTask;
    }
}