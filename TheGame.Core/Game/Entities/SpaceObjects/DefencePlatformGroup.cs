namespace TheGame.Core.Game.Entities.SpaceObjects;

public class DefencePlatformGroup
{
    public Guid Id { get; set; }
    public Guid DefencePlatformId { get; set; }
    public DefencePlatform DefencePlatform { get; set; }
    public int Quantity { get; set; }

    public Guid PlanetId { get; set; }
    public Planet Planet { get; set; }
}