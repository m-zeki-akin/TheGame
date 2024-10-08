using TheGame.Core.Game.Entities;

namespace TheGame.Core.Game.Dtos;

public class PlayerDto
{
    public Guid Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public int Type { get; set; }
    public DateTime CreatedAt { get; set; }

    public static PlayerDto ToDto(Empire entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }

        return new PlayerDto
        {
            Id = entity.Id,
            Type = (int)entity.Type,
            Username = entity.Username,
            CreatedAt = entity.CreatedAt
            //TODO
        };
    }
}