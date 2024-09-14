using TheGame.Core.Entities.SpaceObjects;
using TheGame.Core.Shared.Enums;
using TheGame.Core.Shared.ValueObjects;

namespace TheGame.Core.Entities;

public class FleetSpacecraftGroup
{
    public long FleetId { get; set; }
    public Fleet Fleet { get; set; }
    public long SpacecraftGroupId { get; set; }
    public SpacecraftGroup SpacecraftGroup { get; set; }
}