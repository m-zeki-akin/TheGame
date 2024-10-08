namespace TheGame.Core.Game.Entities.SpaceObjects;

public class SpaceholdGroup
{
    public Guid Id { get; set; }
    public Guid SpaceholdId { get; set; }
    public Spacehold Spacehold { get; set; }
    public int Quantity { get; set; }

    public Guid PlanetId { get; set; }
    public Planet Planet { get; set; }
}