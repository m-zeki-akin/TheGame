using MediatR;

namespace TheGame.Core.Events;

public class FleetDefenceInitiatedEvent : INotification
{
    public long FleetId { get; set; }

}