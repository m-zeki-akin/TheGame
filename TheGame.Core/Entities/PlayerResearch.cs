namespace TheGame.Core.Entities;

public class PlayerResearch
{
    public long PlayerId { get; set; }
    public Player Player  { get; set; }
    
    public long ResearchId { get; set; }
    public Research Research { get; set; }
    
    public int Value { get; set; }
    public bool IsCompleted { get; set; }
}