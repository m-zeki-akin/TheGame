namespace TheGame.Core.Game.Entities.Empires;

public class EmpireCommander
{
    public Guid PlayerId { get; set; }
    public Empire Empire { get; set; }

    public Guid CommanderId { get; set; }
    public Commander Commander { get; set; }
}