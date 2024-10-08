using TheGame.Core.Game.Entities.SpaceObjects;
using TheGame.Core.Game.Shared.Enums;
using TheGame.Core.Game.Shared.ValueObjects;

namespace TheGame.Core.Game.Entities;

public class Fleet
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public FleetType Type { get; set; }
    public FleetState State { get; set; }
    public int DetectionRange { get; set; }
    public int DetectionPower { get; set; }
    public int Morale { get; set; }
    public int Speed { get; set; }
    public int JumpPower { get; set; }
    public ResourceValue Stock { get; set; }
    public ResourceValue MovementResourceCost { get; set; }
    public Location Location { get; set; }

    public Guid? CommanderId { get; set; }
    public Commander? Commander { get; set; }
    public Guid? PlanetId { get; set; }
    public Planet? Planet { get; set; }
    public Guid OwnerId { get; set; }
    public Empire Owner { get; set; }

    public ICollection<FleetObjective?> FleetMission { get; set; }
    public ICollection<SpacecraftGroup> SpacecraftGroups { get; set; }
}