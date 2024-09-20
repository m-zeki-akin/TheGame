using MediatR;

namespace TheGame.Core.Events;

public class FleetMissionCreatedEvent : INotification
{
    public long FleetId { get; set; }
}