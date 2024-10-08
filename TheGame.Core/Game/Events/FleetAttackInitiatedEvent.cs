using MediatR;

namespace TheGame.Core.Game.Events;

public class FleetAttackInitiatedEvent : INotification
{
    public Guid FleetId { get; set; }
}