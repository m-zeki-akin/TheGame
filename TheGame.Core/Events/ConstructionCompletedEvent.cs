using MediatR;

namespace TheGame.Core.Events;

public class ConstructionCompletedEvent : INotification
{
    public long PlanetId { get; set; }
    public long BuildingId { get; set; }
}