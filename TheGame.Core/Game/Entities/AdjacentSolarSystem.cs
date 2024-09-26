using TheGame.Core.Game.Shared.ValueObjects;

namespace TheGame.Core.Game.Entities;

public class AdjacentSolarSystem
{
    public long FromId { get; set; }
    public Location From { get; set; }
    public long ToId { get; set; }
    public Location To { get; set; }
    public Location JumpLocation { get; set; }
}