using TheGame.Core.Game.Entities.SpaceObjects;

namespace TheGame.Core.Game.Entities;

public class FleetSpacecraftGroup
{
    public long FleetId { get; set; }
    public Fleet Fleet { get; set; }
    public long SpacecraftGroupId { get; set; }
    public SpacecraftGroup SpacecraftGroup { get; set; }
}