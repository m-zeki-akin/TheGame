using TheGame.Core.Shared.ValueObjects;

namespace TheGame.Core.Entities;

public class AdjacentSolarSystemJumpLocation
{
    public long AdjacentSolarSystemId { get; set; }
    public AdjacentSolarSystem AdjacentSolarSystem { get; set; }
    public Location Location { get; set; }
}