namespace TheGame.Core.Game.Entities;

public class PlayerPlanet
{
    public long PlayerId { get; set; }
    public Player Player { get; set; }

    public long PlanetId { get; set; }
    public Planet Planet { get; set; }
}