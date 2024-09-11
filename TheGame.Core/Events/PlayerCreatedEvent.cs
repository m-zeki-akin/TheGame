using MediatR;

namespace TheGame.Core.Events;

public class PlayerCreatedEvent : INotification
{
    public Guid PlayerId { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public DateTime CreatedAt { get; set; }

    public PlayerCreatedEvent(Guid playerId, string username, string email, DateTime createdAt)
    {
        PlayerId = playerId;
        Username = username;
        Email = email;
        CreatedAt = createdAt;
    }
}