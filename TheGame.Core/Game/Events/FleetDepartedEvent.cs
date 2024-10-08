using MediatR;

namespace TheGame.Core.Game.Events;

public class FleetDepartedEvent : INotification
{
    public Guid FleetId { get; set; }
}