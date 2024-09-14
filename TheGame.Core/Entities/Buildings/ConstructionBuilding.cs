using TheGame.Core.Entities.Buildings.ProductionQueue;

namespace TheGame.Core.Entities.Buildings;

public class ConstructionBuilding : Building
{
    public int WorkRate;
    public ICollection<PlanetBuildingConstructionItem>? Production { get; set; }
}