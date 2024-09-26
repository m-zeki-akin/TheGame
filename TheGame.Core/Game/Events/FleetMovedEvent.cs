using MediatR;

namespace TheGame.Core.Game.Events;

public class FleetMovedEvent : INotification
{
    public long FleetId { get; set; }
}