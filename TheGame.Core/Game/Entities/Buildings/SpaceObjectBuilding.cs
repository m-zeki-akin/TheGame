using TheGame.Core.Game.Entities.Buildings.Buildings;

namespace TheGame.Core.Game.Entities.Buildings;

public class SpaceObjectBuilding : Building
{
    public int ProductionSlot;
    public int WorkRate;
    public ICollection<PlanetBuildingSpaceObjectItem>? Production { get; set; }
}