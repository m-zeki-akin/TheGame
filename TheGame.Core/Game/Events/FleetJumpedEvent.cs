using MediatR;

namespace TheGame.Core.Game.Events;

public class FleetJumpedEvent : INotification
{
    public long FleetId { get; set; }
}