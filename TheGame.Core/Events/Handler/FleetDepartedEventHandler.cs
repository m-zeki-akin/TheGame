using MediatR;
using TheGame.Core.Cache;
using TheGame.Core.Entities;
using TheGame.Core.Shared.ValueObjects;

namespace TheGame.Core.Events.Handler;

public class FleetDepartedEventHandler(
    GameCache<Fleet> fleetCache,
    IMediator mediator
)
    : INotificationHandler<FleetDepartedEvent>
{
    public Task Handle(FleetDepartedEvent notification, CancellationToken cancellationToken)
    {
        Fleet fleet = fleetCache.Get(notification.FleetId)!;
        var mission = fleet.FleetMission.First();

        var directionVector = new Vector2D(
            mission.Destination.Coordinates.X - fleet.Location.Coordinates.X,
            mission.Destination.Coordinates.Y - fleet.Location.Coordinates.Y);

        var speedMagnitude = (double)fleet.Speed / 100000;
        /*
        if (speedMagnitude < directionVector.Magnitude)
        {
            var travelRatio = speedMagnitude / directionVector.Magnitude;

            fleet.Location.Coordinates.X += fleet.Location.Coordinates.X + directionVector.X * travelRatio;
            fleet.Location.Coordinates.Y += fleet.Location.Coordinates.X + directionVector.X * travelRatio;
            

        }
        else
        {
            var @event = new FleetArrivedEvent
            {
                FleetId = fleet.Id
            };
            
            _ = mediator.Publish(@event, cancellationToken);
        }
        */
        
        mission.Distance = (int)(directionVector.Magnitude * 100000);

        return fleet.FleetMission.First().;

        return Task.CompletedTask;
    }
}