namespace TheGame.Core.Game.Entities;

public class PlayerFaction
{
    public long PlayerId { get; set; }
    public Player Player { get; set; }

    public long FactionId { get; set; }
    public Faction Faction { get; set; }
}