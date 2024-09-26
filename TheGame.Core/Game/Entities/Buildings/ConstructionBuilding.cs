using TheGame.Core.Game.Entities.Buildings.Buildings;

namespace TheGame.Core.Game.Entities.Buildings;

public class ConstructionBuilding : Building
{
    public int ProductionSlot;
    public int WorkRate;
    public ICollection<PlanetBuildingConstructionItem> Production { get; set; }
}