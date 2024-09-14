namespace TheGame.Core.Entities.SpaceObjects.Components;

public class StorageComponent
{
    public long Id { get; set; }
    public string Name { get; set; }
    public int Mass { get; set; }
    public long Capacity { get; set; }
    public long Fuel { get; set; }
    public long Material { get; set; }
    public long Alloy { get; set; }
    public long Polonium { get; set; } 
    public long Technetium { get; set; } 
    public long Actinium { get; set; } 
    public long Plutonium { get; set; } 
}