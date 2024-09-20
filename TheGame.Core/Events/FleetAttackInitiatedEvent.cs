using MediatR;

namespace TheGame.Core.Events;

public class FleetAttackInitiatedEvent : INotification
{
    public long FleetId { get; set; }
}