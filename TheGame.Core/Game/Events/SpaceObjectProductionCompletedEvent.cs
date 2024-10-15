using MediatR;

namespace TheGame.Core.Game.Events;

public class SpaceObjectProductionCompletedEvent : INotification
{
    public Guid PlanetId { get; set; }
    public Guid SpaceObjectId { get; set; }
}