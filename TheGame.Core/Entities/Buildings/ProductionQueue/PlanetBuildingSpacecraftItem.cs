using TheGame.Core.Entities.SpaceObjects;

namespace TheGame.Core.Entities.Buildings.ProductionQueue;

public class PlanetBuildingSpacecraftItem
{
    public long PlanetBuildingId { get; set; } //builder
    public PlanetBuilding PlanetBuilding { get; set; }
    public long SpacecraftId { get; set; }
    public Spacecraft Spacecraft { get; set; }
    public int Order { get; set; }
}