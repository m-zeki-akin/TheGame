using MediatR;

namespace TheGame.Core.Events;

public class FleetTransportInitiatedEvent : INotification
{
    public long FleetId { get; set; }

}