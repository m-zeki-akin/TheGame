using MediatR;

namespace TheGame.Core.Game.Events;

public class FleetDefenceInitiatedEvent : INotification
{
    public long FleetId { get; set; }
}