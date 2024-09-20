namespace TheGame.Core.Entities.SpaceObjects.Components;

public class StorageComponent
{
    public long Id { get; set; }
    public string Name { get; set; }
    public int Mass { get; set; }
    public long Capacity { get; set; }
}