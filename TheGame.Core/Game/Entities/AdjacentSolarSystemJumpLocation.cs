using TheGame.Core.Game.Shared.ValueObjects;

namespace TheGame.Core.Game.Entities;

public class AdjacentSolarSystemJumpLocation
{
    public long AdjacentSolarSystemId { get; set; }
    public AdjacentSolarSystem AdjacentSolarSystem { get; set; }
    public Location Location { get; set; }
}