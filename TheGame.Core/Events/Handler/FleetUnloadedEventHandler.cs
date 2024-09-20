using MediatR;
using TheGame.Core.Cache;
using TheGame.Core.Entities;

namespace TheGame.Core.Events.Handler;

public class FleetUnloadedEventHandler(
    GameCache<Planet> planetCache,
    GameCache<Fleet> fleetCache)
    : INotificationHandler<FleetUnloadedEvent>
{
    public Task Handle(FleetUnloadedEvent notification, CancellationToken cancellationToken)
    {
        Planet planet = planetCache.Get(notification.PlanetId)!;
        Fleet fleet = fleetCache.Get(notification.FleetId)!;

        planet.StoredResources += fleet.Stock!;

        return Task.CompletedTask;
    }
}