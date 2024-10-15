namespace TheGame.Core.Game.Entities.StellarObjects;

public class PlanetResearch
{
    public Guid Id { get; set; }
    public Guid PlanetId { get; set; }
    public Planet Planet { get; set; }

    public Guid ResearchId { get; set; }
    public int ResearchLevel { get; set; }
    public Research Research { get; set; }

    public int Value { get; set; }
}