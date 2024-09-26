namespace TheGame.Core.Game.Entities;

public class PlayerCommander
{
    public long PlayerId { get; set; }
    public Player Player { get; set; }

    public long CommanderId { get; set; }
    public Commander Commander { get; set; }
}