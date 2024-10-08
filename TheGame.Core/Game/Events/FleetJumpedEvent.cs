using MediatR;

namespace TheGame.Core.Game.Events;

public class FleetJumpedEvent : INotification
{
    public Guid FleetId { get; set; }
}