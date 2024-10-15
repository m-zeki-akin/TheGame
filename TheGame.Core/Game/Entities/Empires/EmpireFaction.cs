namespace TheGame.Core.Game.Entities.Empires;

public class EmpireFaction
{
    public Guid PlayerId { get; set; }
    public Empire Empire { get; set; }

    public Guid FactionId { get; set; }
    public Faction Faction { get; set; }
}