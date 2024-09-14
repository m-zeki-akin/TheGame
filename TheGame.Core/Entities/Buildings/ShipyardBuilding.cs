using TheGame.Core.Entities.Buildings.ProductionQueue;

namespace TheGame.Core.Entities.Buildings;

public class ShipyardBuilding : Building
{
    public int WorkRate;
    public ICollection<PlanetBuildingSpacecraftItem>? Production { get; set; }
}