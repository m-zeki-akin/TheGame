using TheGame.Core.Shared.ValueObjects;

namespace TheGame.Core.Entities;

public class Trait
{
    public long Id { get; set; }
    public string Name { get; set; }
    public int Level { get; set; }
    public Attributes Attributes;
}