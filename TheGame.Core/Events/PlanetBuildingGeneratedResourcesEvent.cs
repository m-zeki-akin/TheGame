using MediatR;

namespace TheGame.Core.Events;

public class PlanetBuildingGeneratedResourcesEvent : INotification
{
    public long PlanetId { get; set; }
    public long PlanetBuildingId { get; set; }
}