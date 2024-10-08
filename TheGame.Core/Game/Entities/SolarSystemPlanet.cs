namespace TheGame.Core.Game.Entities;

public class SolarSystemPlanet
{
    public Guid SolarSystemId { get; set; }
    public SolarSystem SolarSystem { get; set; }
    public Guid PlanetId { get; set; }
    public SolarSystem Planet { get; set; }
}