using MediatR;

namespace TheGame.Core.Game.Events;

public class FleetDeploymentInitiatedEvent : INotification
{
    public Guid FleetId { get; set; }
}