using MediatR;
using TheGame.Core.Game.Cache;
using TheGame.Core.Game.Entities;

namespace TheGame.Core.Game.Events.Handler;

public class FleetUnloadedEventHandler(
    ICacheService<Planet> planetCache,
    ICacheService<Fleet> fleetCache)
    : INotificationHandler<FleetUnloadedEvent>
{
    public Task Handle(FleetUnloadedEvent notification, CancellationToken cancellationToken)
    {
        var planet = planetCache.Get(notification.PlanetId).Result;
        var fleet = fleetCache.Get(notification.FleetId).Result;

        planet.StoredResources += fleet.Stock;

        return Task.CompletedTask;
    }
}