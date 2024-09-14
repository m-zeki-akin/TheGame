using TheGame.Core.Entities.SpaceObjects.Components;

namespace TheGame.Core.Entities.SpaceObjects;

public class Spacehold
{
    public long SupportComponentId { get; set; }
    public SupportComponent SupportComponent { get; set; }
    
    public int CommandPower { get; set; }
    public int DefencePower { get; set; }
    public int DetectionRange { get; set; }
    public int DetectionPower { get; set; }
}