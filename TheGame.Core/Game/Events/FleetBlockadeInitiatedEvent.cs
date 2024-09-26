using MediatR;

namespace TheGame.Core.Game.Events;

public class FleetBlockadeInitiatedEvent : INotification
{
    public long FleetId { get; set; }
}