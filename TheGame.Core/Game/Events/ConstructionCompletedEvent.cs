using MediatR;
using TheGame.Core.Game.Entities;
using TheGame.Core.Game.Entities.Buildings;

namespace TheGame.Core.Game.Events;

public class ConstructionCompletedEvent : INotification
{
    public Guid ConstructionItemId { get; set; }
}