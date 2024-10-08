using TheGame.Core.Game.Entities.Abstract;
using TheGame.Core.Game.Entities.Requirements;
using TheGame.Core.Game.Shared.Enums;

namespace TheGame.Core.Game.Entities.SpaceObjects.Components;

public class Component : SpaceObject
{
    public long Level { get; set; }
    public Size Size { get; set; }
    public ComponentType ComponentType { get; set; }
}