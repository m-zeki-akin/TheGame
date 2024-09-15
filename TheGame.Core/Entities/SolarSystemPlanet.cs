namespace TheGame.Core.Entities;

public class SolarSystemPlanet
{
    public long SolarSystemId { get; set; }
    public SolarSystem SolarSystem { get; set; }
    public long PlanetId { get; set; }
    public SolarSystem Planet { get; set; }
}