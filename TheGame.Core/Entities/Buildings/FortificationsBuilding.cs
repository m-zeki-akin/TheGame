using TheGame.Core.Entities.Buildings.ProductionQueue;

namespace TheGame.Core.Entities.Buildings;

public class FortificationsBuilding : Building
{
    public int WorkRate;
    public ICollection<PlanetBuildingDefencePlatformItem>? Production { get; set; }
}