namespace TheGame.Core.Entities;

public class ArtificialSpaceObjectCost
{
    public long ArtificialSpaceObjectId { get; set; }
    public ArtificialSpaceObject ArtificialSpaceObject { get; set; }

    public long ResourceId { get; set; }
    public Resource Resource { get; set; }

    public long Quantity { get; set; }
}