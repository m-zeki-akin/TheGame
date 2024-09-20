using TheGame.Core.Entities.SpaceObjects;

namespace TheGame.Core.Entities.Buildings.ProductionQueue;

public class PlanetBuildingSpaceObjectItem
{
    public long PlanetBuildingId { get; set; }
    public PlanetBuilding PlanetBuilding { get; set; }
    public long SpaceObjectId { get; set; }
    public SpaceObject SpaceObject { get; set; }
    public int Order { get; set; }
    public int CurrentProduction { get; set; }
}