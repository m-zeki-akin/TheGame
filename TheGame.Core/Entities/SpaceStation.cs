using TheGame.Core.Entities.ValueObjects;

namespace TheGame.Core.Entities;

public class SpaceStation : SpaceObject
{
    public int DockingCap { get; set; }
    public int DefenceCap { get; set; }
    public int Level { get; set; }
    public Location Location { get; set; }
}