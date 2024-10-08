using MediatR;
using TheGame.Core.Game.Shared.ValueObjects;

namespace TheGame.Core.Game.Events;

public class PlanetResourceUpdatedEvent : INotification
{
    public Guid PlanetId { get; set; }
    public ResourceValue UpdatedResources { get; set; }
}