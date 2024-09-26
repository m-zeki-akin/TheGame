using MediatR;

namespace TheGame.Core.Game.Events;

public class PlanetBuildingGeneratedResourcesEvent : INotification
{
    public long PlanetId { get; set; }
    public long PlanetBuildingId { get; set; }
}