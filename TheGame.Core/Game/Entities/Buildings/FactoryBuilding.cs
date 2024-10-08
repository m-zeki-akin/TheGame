using TheGame.Core.Game.Entities.Buildings.Buildings;
using TheGame.Core.Game.Entities.SpaceObjects;

namespace TheGame.Core.Game.Entities.Buildings;

public class FactoryBuilding : Building
{
    public int WorkRate;
    public ICollection<SpaceObjectProductionItem> Productions { get; set; }
}