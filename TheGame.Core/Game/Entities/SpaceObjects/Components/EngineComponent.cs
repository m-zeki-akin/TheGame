using TheGame.Core.Game.Shared.ValueObjects;

namespace TheGame.Core.Game.Entities.SpaceObjects.Components;

public class EngineComponent : Component
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int PowerCost { get; set; }
    public int PowerRate { get; set; }
    public int JumpPower { get; set; }
    public ResourceValue ConsumptionRate { get; set; }
}