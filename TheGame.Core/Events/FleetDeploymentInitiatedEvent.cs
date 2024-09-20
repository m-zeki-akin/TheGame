using MediatR;

namespace TheGame.Core.Events;

public class FleetDeploymentInitiatedEvent : INotification
{
    public long FleetId { get; set; }

}