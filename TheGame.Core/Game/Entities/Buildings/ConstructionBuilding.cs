using TheGame.Core.Game.Entities.Productions;

namespace TheGame.Core.Game.Entities.Buildings;

public class ConstructionBuilding : Building
{
    public int WorkRate;
    public ICollection<BuildingProductionItem> Productions { get; set; }
}