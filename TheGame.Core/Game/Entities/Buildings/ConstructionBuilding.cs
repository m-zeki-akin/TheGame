using TheGame.Core.Game.Entities.Buildings.Buildings;

namespace TheGame.Core.Game.Entities.Buildings;

public class ConstructionBuilding : Building
{
    public int WorkRate;
    public ICollection<BuildingProductionItem> Productions { get; set; }
}