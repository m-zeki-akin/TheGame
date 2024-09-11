namespace TheGame.Core.Entities;

public class SpaceObjectCost
{
    public long SpaceElementId { get; set; }
    public SpaceObject SpaceObject { get; set; }

    public long ResourceId { get; set; }
    public Resource Resource { get; set; }

    public long Quantity { get; set; }
}