using TheGame.Core.Game.Entities.SpaceObjects;
using TheGame.Core.Game.Shared.Enums;
using TheGame.Core.Game.Shared.ValueObjects;

namespace TheGame.Core.Game.Entities;

public class Fleet
{
    public long Id { get; set; }
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
    public Path SubDestination { get; set; }

    public long? CommanderId { get; set; }
    public Commander? Commander { get; set; }
    public long? PlanetId { get; set; }
    public Planet? Planet { get; set; }
    public long OwnerId { get; set; }
    public Player Owner { get; set; }

    public ICollection<FleetObjective?> FleetMission { get; set; }
    public ICollection<SpacecraftGroup> SpacecraftGroups { get; set; }
    public bool IsLocked { get; }
}