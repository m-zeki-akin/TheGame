using TheGame.Core.Game.Entities.SpaceObjects;

namespace TheGame.Core.Game.Entities.Fleets;

public class FleetSpacecraftGroup
{
    public Guid FleetId { get; set; }
    public Fleet Fleet { get; set; }
    public Guid SpacecraftGroupId { get; set; }
    public SpacecraftGroup SpacecraftGroup { get; set; }
}