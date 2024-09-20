namespace TheGame.Core.Entities.SpaceObjects.Components;

public class EngineComponent: Component
{
    public long Id { get; set; }
    public string Name { get; set; }
    public int PowerCost { get; set; }
    public int PowerRate { get; set; }
    public int JumpPower { get; set; }
    public ResourceValue ConsumptionRate { get; set; }
}