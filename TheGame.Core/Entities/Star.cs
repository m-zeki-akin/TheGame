using TheGame.Core.Shared.ValueObjects;

namespace TheGame.Core.Entities;

public class Star : StellarObject
{
    public int Size { get; set; }
    public int Level  { get; set; }
    public Coordinates Coordinates  { get; set; }
}