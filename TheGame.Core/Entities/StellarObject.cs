using TheGame.Core.Shared.ValueObjects;

namespace TheGame.Core.Entities;

public class StellarObject
{
    public long Id { get; set; }
    public string Name { get; set; }
    public Location Location { get; set; }
    public int Size { get; set; }
    public int Level  { get; set; }
}