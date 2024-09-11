using MediatR;
using Microsoft.Extensions.Logging;
using TheGame.Core.Events;

namespace TheGame.Core.Consumers;

public class PlayerCreatedEventConsumer : INotificationHandler<PlayerCreatedEvent>
{
    private readonly ILogger<PlayerCreatedEventConsumer> _logger;

    public PlayerCreatedEventConsumer(ILogger<PlayerCreatedEventConsumer> logger)
    {
        _logger = logger;
    }

    public Task Handle(PlayerCreatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Player Created: {PlayerEventUsername} ({PlayerEventPlayerId})",
            notification.Username, notification.PlayerId);
        return Task.CompletedTask;
    }
}