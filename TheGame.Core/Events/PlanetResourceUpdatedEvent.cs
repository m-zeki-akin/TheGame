using MediatR;
using TheGame.Core.Entities;

namespace TheGame.Core.Events;

public class PlanetResourceUpdatedEvent : INotification
{
    public long PlanetId { get; set; }
    public ResourceValue UpdatedResources { get; set; }
}