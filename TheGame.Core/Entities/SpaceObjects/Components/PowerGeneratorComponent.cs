namespace TheGame.Core.Entities.SpaceObjects.Components;

public class PowerGeneratorComponent: Component
{
    public long Id { get; set; }
    public string Name { get; set; }
    public int Value { get; set; }
    public int Mass { get; set; }
}