namespace TheGame.Core.Entities;

public class CommanderTrait
{
    public long CommanderId { get; set; }
    public Commander Commander { get; set; }

    public long TraitId { get; set; }
    public Trait Trait { get; set; }
}