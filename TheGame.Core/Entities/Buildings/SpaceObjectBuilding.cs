using TheGame.Core.Entities.Buildings.ProductionQueue;

namespace TheGame.Core.Entities.Buildings;

public class SpaceObjectBuilding : Building
{
    public int WorkRate;
    public int ProductionSlot;
    public ICollection<PlanetBuildingSpaceObjectItem>? Production { get; set; }
}