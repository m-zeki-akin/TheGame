namespace TheGame.Core.Game.Entities;

public class EmpirePlanet
{
    public Guid PlayerId { get; set; }
    public Empire Empire { get; set; }

    public Guid PlanetId { get; set; }
    public Planet Planet { get; set; }
}