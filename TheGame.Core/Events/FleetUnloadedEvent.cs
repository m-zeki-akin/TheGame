using MediatR;

namespace TheGame.Core.Events;

public class FleetUnloadedEvent : INotification
{
    public long FleetId { get; set; }
    public long PlanetId { get; set; }
}