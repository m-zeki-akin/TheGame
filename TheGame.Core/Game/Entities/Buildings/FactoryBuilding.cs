using MediatR;
using TheGame.Core.Game.Entities.Productions;
using TheGame.Core.Game.Entities.SpaceObjects;
using TheGame.Core.Game.Entities.StellarObjects;
using TheGame.Core.Game.Events;

namespace TheGame.Core.Game.Entities.Buildings;

public class FactoryBuilding() : Building
{
    public int WorkRate;
    public SpaceObjectProductionItem Production { get; set; }
    
}