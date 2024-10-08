using TheGame.Core.Game.Shared.ValueObjects;

namespace TheGame.Core.Game.Entities;

public class AdjacentSolarSystem
{
    public Guid FromId { get; set; }
    public Location From { get; set; }
    public Guid ToId { get; set; }
    public Location To { get; set; }
    public Location JumpLocation { get; set; }
}