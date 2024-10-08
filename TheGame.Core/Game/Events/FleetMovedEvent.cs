using MediatR;

namespace TheGame.Core.Game.Events;

public class FleetMovedEvent : INotification
{
    public Guid FleetId { get; set; }
}