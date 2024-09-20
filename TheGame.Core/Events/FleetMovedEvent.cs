using MediatR;

namespace TheGame.Core.Events;

public class FleetMovedEvent : INotification
{
    public long FleetId  { get; set; }
}