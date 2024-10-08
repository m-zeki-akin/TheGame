using MediatR;
using TheGame.Core.Game.Entities.SpaceObjects;

namespace TheGame.Core.Game.Events;

public class ProductionCompletedEventHandler : INotificationHandler<ProductionCompletedEvent>
{
    public Task Handle(ProductionCompletedEvent notification, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}