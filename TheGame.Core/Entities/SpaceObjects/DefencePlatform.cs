using TheGame.Core.Shared.Enums;

namespace TheGame.Core.Entities.SpaceObjects;

public class DefencePlatform : SpaceObject
{
    public DefenceType DefenceType { get; set; }
    public int DefencePower { get; set; }
}