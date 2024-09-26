namespace TheGame.Core.Game.Entities.Requirements;

public class ResearchRequirement
{
    public long Id { get; set; }
    public long ResearchId { get; set; }
    public int ResearchLevel { get; set; }
    public Research Research { get; set; }
}