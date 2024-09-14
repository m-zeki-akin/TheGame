using TheGame.Core.Shared.Enums;

namespace TheGame.Core.Entities;

public class PlayerFaction
{
    public long PlayerId { get; set; }
    public Player Player  { get; set; }
    
    public long FactionId { get; set; }
    public Faction Faction { get; set; }
}