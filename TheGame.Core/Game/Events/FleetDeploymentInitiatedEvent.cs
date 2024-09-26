using MediatR;

namespace TheGame.Core.Game.Events;

public class FleetDeploymentInitiatedEvent : INotification
{
    public long FleetId { get; set; }
}