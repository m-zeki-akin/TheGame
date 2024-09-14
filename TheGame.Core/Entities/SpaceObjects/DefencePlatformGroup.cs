namespace TheGame.Core.Entities.SpaceObjects;

public class DefencePlatformGroup
{
    public long Id { get; set; }
    public long DefencePlatformId { get; set; }
    public DefencePlatform DefencePlatform { get; set; }
    public int Quantity { get; set; }
    
    public long PlanetId { get; set; }
    public Planet Planet { get; set; }
}