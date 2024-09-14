namespace TheGame.Core.Entities.SpaceObjects.Components;

public class EngineComponent: Component
{
    public long Id { get; set; }
    public string Name { get; set; }
    public int PowerCost { get; set; }
    public int Speed { get; set; }
    public int Acceleration { get; set; }
}