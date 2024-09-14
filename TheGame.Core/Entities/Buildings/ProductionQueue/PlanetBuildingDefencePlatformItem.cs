using TheGame.Core.Entities.SpaceObjects;

namespace TheGame.Core.Entities.Buildings.ProductionQueue;

public class PlanetBuildingDefencePlatformItem
{
    public long PlanetBuildingId { get; set; } //builder
    public PlanetBuilding PlanetBuilding { get; set; }
    public long SpaceholdId { get; set; }
    public Spacecraft Spacehold { get; set; }
    public int Order { get; set; }
}