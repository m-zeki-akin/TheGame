namespace TheGame.Core.Game.Entities.SpaceObjects.Components;

public class StorageComponent
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Mass { get; set; }
    public long Capacity { get; set; }
}