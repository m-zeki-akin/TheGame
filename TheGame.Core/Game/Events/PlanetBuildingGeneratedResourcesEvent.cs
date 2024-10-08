using MediatR;

namespace TheGame.Core.Game.Events;

public class PlanetBuildingGeneratedResourcesEvent : INotification
{
    public Guid PlanetId { get; set; }
    public Guid PlanetBuildingId { get; set; }
}