using TheGame.Core.Entities.Enums;
using TheGame.Core.Entities.ValueObjects;

namespace TheGame.Core.Entities;

public class DefenceStruct : SpaceObject
{
    public int DefencePower { get; set; }
    public DefenceType DefenceType { get; set; }

    public long LocationId { get; set; }
    public Location Location { get; set; }
}