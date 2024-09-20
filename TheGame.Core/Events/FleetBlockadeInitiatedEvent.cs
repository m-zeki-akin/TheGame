using MediatR;

namespace TheGame.Core.Events;

public class FleetBlockadeInitiatedEvent : INotification
{
    public long FleetId { get; set; }

}