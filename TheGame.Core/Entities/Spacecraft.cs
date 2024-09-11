using TheGame.Core.Entities.Enums;

namespace TheGame.Core.Entities;

public class Spacecraft : SpaceObject
{
    public SpaceshipType Type { get; set; }
    public SpaceshipClass Class { get; set; }

    public long FleetId { get; set; }
    public Fleet Fleet { get; set; }
}