using MediatR;
using TheGame.Core.Game.Entities.SpaceObjects;

namespace TheGame.Core.Game.Events;

public class ProductionCompletedEvent : INotification
{
    public Guid PlanetId { get; set; }
    public SpaceObject Production { get; set; }
}