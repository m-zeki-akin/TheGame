using MediatR;

namespace TheGame.Core.Events;

public class FleetDepartedEvent : INotification
{
    public long FleetId  { get; set; }
}