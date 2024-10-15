using MediatR;

namespace TheGame.Core.Game.Events.Handler;

public class ProductionCompletedEventHandler : INotificationHandler<SpaceObjectProductionCompletedEvent>
{
    public Task Handle(SpaceObjectProductionCompletedEvent notification, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}