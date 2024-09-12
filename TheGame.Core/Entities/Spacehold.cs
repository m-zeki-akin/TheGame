using TheGame.Core.Shared.ValueObjects;

namespace TheGame.Core.Entities;

public class Spacehold : ArtificialSpaceObject
{
    public long PowerGeneratorId { get; set; }
    public PowerGenerator PowerGenerator { get; set; }
    public int DockingCap { get; set; }
    public int DefenceCap { get; set; }
    public int DetectionRange { get; set; }
    public int Level { get; set; }
    public Location Location { get; set; }
    public int CommandPower { get; set; }
    
    public ICollection<Building> Buildings { get; set; }
    public ICollection<DefenceStruct> DefenceStructs { get; set; }
}