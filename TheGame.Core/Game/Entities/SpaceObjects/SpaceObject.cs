using TheGame.Core.Game.Entities.Requirements;
using TheGame.Core.Game.Entities.SpaceObjects.Components;
using TheGame.Core.Game.Shared.Enums;
using TheGame.Core.Game.Shared.ValueObjects;

namespace TheGame.Core.Game.Entities.SpaceObjects;

public class SpaceObject
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public SpaceObjectType Type { get; set; }
    public Guid ProductionCostId { get; set; }
    public long ProductionCost { get; set; }
    public ResourceValue Cost { get; set; }
    public int HitPoints { get; set; }
    public int Mass { get; set; }
}