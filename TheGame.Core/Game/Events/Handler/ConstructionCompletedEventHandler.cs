using System.Collections.Concurrent;
using MediatR;
using TheGame.Core.Game.Entities.Buildings;

namespace TheGame.Core.Game.Events.Handler;

public class ConstructionCompletedEventHandler : INotificationHandler<ConstructionCompletedEvent>
{
    private readonly ConcurrentDictionary<long, Building> _buildings;

    public Task Handle(ConstructionCompletedEvent notification, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}