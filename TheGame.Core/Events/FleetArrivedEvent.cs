using MediatR;

namespace TheGame.Core.Events;

public class FleetArrivedEvent : INotification
{
    public long FleetId  { get; set; }
}