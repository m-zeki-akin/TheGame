using TheGame.Core.Game.Entities.Fleets;

namespace TheGame.Core.Game.Entities.SpaceObjects;

public class SpacecraftGroup
{
    public Guid Id { get; set; }
    public Guid SpacecraftId { get; set; }
    public Spacecraft Spacecraft { get; set; }
    public int Quantity { get; set; }

    public Guid FleetId { get; set; }
    public Fleet Fleet { get; set; }
}