using TheGame.Core.Entities.Buildings.ProductionQueue;

namespace TheGame.Core.Entities.Buildings;

public class StarsmithBuilding : Building
{
    public int WorkRate;
    public ICollection<PlanetBuildingSpaceholdItem>? Production { get; set; }
}