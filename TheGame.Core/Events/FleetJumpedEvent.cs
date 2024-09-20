using MediatR;

namespace TheGame.Core.Events;

public class FleetJumpedEvent : INotification
{
    public long FleetId  { get; set; }
}