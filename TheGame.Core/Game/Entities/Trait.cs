using TheGame.Core.Game.Shared.Enums;
using TheGame.Core.Game.Shared.ValueObjects;

namespace TheGame.Core.Game.Entities;

public class Trait
{
    public Attributes Attributes;
    public long Id { get; set; }
    public string Name { get; set; }
    public int Level { get; set; }
    public TraitType Type { get; set; }
}