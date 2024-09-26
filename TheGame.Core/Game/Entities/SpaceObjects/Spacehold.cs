using TheGame.Core.Game.Entities.SpaceObjects.Components;

namespace TheGame.Core.Game.Entities.SpaceObjects;

public class Spacehold : SpaceObject
{
    public long Level { get; set; }
    public long? NextLevelSpaceholdId { get; set; }
    public Spacehold? NextLevelSpacehold { get; set; }
    public long? PreviousLevelSpaceholdId { get; set; }
    public Spacehold? PreviousLevelSpacehold { get; set; }
    public long SupportComponentId { get; set; }
    public SupportComponent SupportComponent { get; set; }

    public int CommandPower { get; set; }
    public int DefencePower { get; set; }
    public int DetectionRange { get; set; }
    public int DetectionPower { get; set; }
}