using MediatR;

namespace TheGame.Core.Game.Events;

public class FleetTransportInitiatedEvent : INotification
{
    public Guid FleetId { get; set; }
}