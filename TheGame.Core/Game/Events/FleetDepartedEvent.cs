using MediatR;

namespace TheGame.Core.Game.Events;

public class FleetDepartedEvent : INotification
{
    public long FleetId { get; set; }
}