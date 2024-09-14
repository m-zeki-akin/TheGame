using TheGame.Core.Entities.Buildings;

namespace TheGame.Core.Entities.Requirement;

public class BuildingRequirement
{
    public long Id { get; set; }
    public long BuildingId { get; set; }
    public int BuildingLevel { get; set; }
    public Building Building { get; set; }
}