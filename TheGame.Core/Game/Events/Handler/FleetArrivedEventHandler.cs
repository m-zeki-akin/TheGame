using MediatR;
using TheGame.Core.Game.Cache;
using TheGame.Core.Game.Entities;
using TheGame.Core.Game.Shared.Enums;

namespace TheGame.Core.Game.Events.Handler;

public class FleetArrivedEventHandler(
    IMediator mediator,
    ICacheService<Fleet> fleetCache)
    : INotificationHandler<FleetArrivedEvent>
{
    public Task Handle(FleetArrivedEvent notification, CancellationToken cancellationToken)
    {
        var fleet = fleetCache.Get(notification.FleetId).Result;

        var mission = fleet.FleetMission.First();

        switch (mission!.Type)
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

        fleet.Location = fleet.FleetMission.First()!.Location;

        return Task.CompletedTask;
    }
}