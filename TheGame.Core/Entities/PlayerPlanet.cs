using TheGame.Core.Shared.Enums;

namespace TheGame.Core.Entities;

public class PlayerPlanet
{
    public long PlayerId { get; set; }
    public Player Player  { get; set; }
    
    public long PlanetId { get; set; }
    public Planet Planet { get; set; }
}