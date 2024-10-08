namespace TheGame.Core.Game.Entities;

public class CommanderTrait
{
    public Guid CommanderId { get; set; }
    public Commander Commander { get; set; }

    public Guid TraitId { get; set; }
    public Trait Trait { get; set; }
}