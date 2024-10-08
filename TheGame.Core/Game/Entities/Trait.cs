using TheGame.Core.Game.Entities.Abstract;
using TheGame.Core.Game.Shared.Enums;
using TheGame.Core.Game.Shared.ValueObjects;

namespace TheGame.Core.Game.Entities;

public class Trait : StaticEntity
{
    public SpaceObjectAttributes Attributes;
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Level { get; set; }
    public TraitType Type { get; set; }
}