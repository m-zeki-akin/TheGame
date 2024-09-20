using MediatR;
using TheGame.Core.Cache;
using TheGame.Core.Entities;
using TheGame.Core.Shared.Enums;
using TheGame.Core.Shared.ValueObjects;

namespace TheGame.Core.Events.Handler;

public class FleetArrivedEventHandler(
    IMediator mediator,
    GameCache<Fleet> fleetCache)
    : INotificationHandler<FleetArrivedEvent>
{
    public Task Handle(FleetArrivedEvent notification, CancellationToken cancellationToken)
    {
        Fleet fleet = fleetCache.Get(notification.FleetId)!;

        var mission = fleet.FleetMission.First();
        
        switch (mission.Type)
        {
            case FleetObjectiveType.Attack:
            case FleetObjectiveType.Raid:
            {
                var @event = new FleetAttackInitiatedEvent();
                mediator.Publish(@event, cancellationToken);
                break;
            }
            case FleetObjectiveType.Blockade:
            {
                var @event = new FleetBlockadeInitiatedEvent();
                mediator.Publish(@event);
                break;
            }
            case FleetObjectiveType.Defend:
            {
                var @event = new FleetDefenceInitiatedEvent();
                mediator.Publish(@event);
                break;
            }
            case FleetObjectiveType.Transport:
            {
                var @event = new FleetTransportInitiatedEvent();
                mediator.Publish(@event);
                break;
            }
            case FleetObjectiveType.Deployment:
            {
                var @event = new FleetDeploymentInitiatedEvent();
                mediator.Publish(@event);
                break;
            }
        }
        
        fleet.Location = fleet.FleetMission.First().Destination;

        return Task.CompletedTask;
    }
    
}