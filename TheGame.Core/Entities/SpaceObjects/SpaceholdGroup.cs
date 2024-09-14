namespace TheGame.Core.Entities.SpaceObjects;

public class SpaceholdGroup
{
    public long Id { get; set; }
    public long SpaceholdId { get; set; }
    public Spacehold Spacehold { get; set; }
    public int Quantity { get; set; }
    
    public long PlanetId { get; set; }
    public Planet Planet { get; set; }
}