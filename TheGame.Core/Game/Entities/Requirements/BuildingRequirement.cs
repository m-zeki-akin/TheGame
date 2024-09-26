using TheGame.Core.Game.Entities.Buildings;

namespace TheGame.Core.Game.Entities.Requirements;

public class BuildingRequirement
{
    public long Id { get; set; }
    public long BuildingId { get; set; }
    public int BuildingLevel { get; set; }
    public Building Building { get; set; }
}