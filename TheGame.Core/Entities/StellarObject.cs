using TheGame.Core.Entities.ValueObjects;

namespace TheGame.Core.Entities;

public class StellarObject
{
    public long Id { get; set; }
    public string Name { get; set; }
    public Location Location { get; set; }
}