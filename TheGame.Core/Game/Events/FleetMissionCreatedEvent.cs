using MediatR;

namespace TheGame.Core.Game.Events;

public class FleetMissionCreatedEvent : INotification
{
    public long FleetId { get; set; }
}