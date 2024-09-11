using TheGame.Core.Entities;

namespace TheGame.Core.Dtos;

public class PlayerDto
{
    public Guid Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public DateTime CreatedAt { get; set; }

    public static PlayerDto ToDto(Player entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }
        
        return new PlayerDto
        {
            Id = entity.Id,
            Email = entity.Email,
            Username = entity.Username,
            CreatedAt = entity.CreatedAt
        };
    }
}