using MediatR;
using TheGame.Core.Cache;
using TheGame.Core.Entities;
using TheGame.Core.Shared.ValueObjects;

namespace TheGame.Core.Events.Handler;

public class FleetJumpedEventHandler(
    GameCache<Fleet> fleetCache,
    IMediator mediator
)
    : INotificationHandler<FleetJumpedEvent>
{
    public Task Handle(FleetJumpedEvent notification, CancellationToken cancellationToken)
    {
        Fleet fleet = fleetCache.Get(notification.FleetId)!;
        var dest = fleet.SubDestination.Destinations.First();

        var solarDirectionVector = new Vector2D(
            dest.SolarSystem.Coordinates.X - fleet.Location.SolarSystem.Coordinates.X,
            dest.SolarSystem.Coordinates.Y - fleet.Location.SolarSystem.Coordinates.Y);

        var jumpMagnitude = (double)fleet.JumpPower / 100000;
        if (jumpMagnitude < solarDirectionVector.Magnitude)
        {
            var travelRatio = jumpMagnitude / solarDirectionVector.Magnitude;

            fleet.Location.SolarSystem.Coordinates.X += solarDirectionVector.X * travelRatio;
            fleet.Location.SolarSystem.Coordinates.Y += solarDirectionVector.Y * travelRatio;
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