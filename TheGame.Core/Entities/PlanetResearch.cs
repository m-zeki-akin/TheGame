namespace TheGame.Core.Entities;

public class PlanetResearch
{
    public long PlanetId { get; set; }
    public Planet Planet  { get; set; }
    
    public long ResearchId { get; set; }
    public int ResearchLevel { get; set; }
    public Research Research { get; set; }
    
    public int Value { get; set; }
}