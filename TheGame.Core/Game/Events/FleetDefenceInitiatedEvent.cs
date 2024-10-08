using MediatR;

namespace TheGame.Core.Game.Events;

public class FleetDefenceInitiatedEvent : INotification
{
    public Guid FleetId { get; set; }
}