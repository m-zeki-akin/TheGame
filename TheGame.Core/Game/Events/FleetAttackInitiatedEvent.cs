using MediatR;

namespace TheGame.Core.Game.Events;

public class FleetAttackInitiatedEvent : INotification
{
    public long FleetId { get; set; }
}