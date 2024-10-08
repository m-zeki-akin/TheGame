using MediatR;

namespace TheGame.Core.Game.Events;

public class FleetUnloadedEvent : INotification
{
    public Guid FleetId { get; set; }
    public Guid PlanetId { get; set; }
}