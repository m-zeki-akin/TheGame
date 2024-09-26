using TheGame.Core.Game.Shared.Enums;

namespace TheGame.Core.Game.Entities.SpaceObjects;

public class DefencePlatform : SpaceObject
{
    public DefenceType DefenceType { get; set; }
    public int DefencePower { get; set; }
}