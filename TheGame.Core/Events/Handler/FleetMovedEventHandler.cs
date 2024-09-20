using MediatR;
using TheGame.Core.Cache;
using TheGame.Core.Entities;
using TheGame.Core.Shared.ValueObjects;

namespace TheGame.Core.Events.Handler;

public class FleetMovedEventHandler(
    GameCache<Fleet> fleetCache,
    IMediator mediator
)
    : INotificationHandler<FleetMovedEvent>
{
    public Task Handle(FleetMovedEvent notification, CancellationToken cancellationToken)
    {
        Fleet fleet = fleetCache.Get(notification.FleetId)!;
        var dest = fleet.SubDestination.Destinations.First();

        var directionVector = new Vector2D(
            dest.Coordinates.X - fleet.Location.Coordinates.X,
            dest.Coordinates.Y - fleet.Location.Coordinates.Y);

        var speedMagnitude = (double)fleet.Speed / 100000;
        if (speedMagnitude < directionVector.Magnitude)
        {
            var travelRatio = speedMagnitude / directionVector.Magnitude;

            fleet.Location.Coordinates.X += fleet.Location.Coordinates.X + directionVector.X * travelRatio;
            fleet.Location.Coordinates.Y += fleet.Location.Coordinates.X + directionVector.X * travelRatio;
            
            var timeToArrive = directionVector.Magnitude / speedMagnitude;
        }
        else
        {
            var @event = new FleetArrivedEvent
            {
                FleetId = fleet.Id
            };
            
            _ = mediator.Publish(@event, cancellationToken);
        }

        return Task.CompletedTask;
    }
}