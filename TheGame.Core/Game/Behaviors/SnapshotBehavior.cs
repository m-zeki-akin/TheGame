using MediatR;
using TheGame.Core.Game.Services;

namespace TheGame.Core.Game;


public class SnapshotBlockingBehavior<TRequest, TResponse>(SnapshotService snapshotService)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (request is ISnapshotBlockingRequest)
        {
            await snapshotService.WaitForSnapshotToCompleteAsync();
        }

        return await next();
    }
}