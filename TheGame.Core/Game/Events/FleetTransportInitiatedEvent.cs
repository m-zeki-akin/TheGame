using MediatR;

namespace TheGame.Core.Game.Events;

public class FleetTransportInitiatedEvent : INotification
{
    public long FleetId { get; set; }
}