using TheGame.Core.Game.Entities.SpaceObjects;

namespace TheGame.Core.Game.Entities.Buildings.Buildings;

public class PlanetBuildingSpaceObjectItem
{
    public long PlanetBuildingId { get; set; }
    public PlanetBuilding PlanetBuilding { get; set; }
    public long SpaceObjectId { get; set; }
    public SpaceObject SpaceObject { get; set; }
    public int Order { get; set; }
    public int CurrentProduction { get; set; }
    public ReaderWriterLockSlim LockSlim { get; }
}