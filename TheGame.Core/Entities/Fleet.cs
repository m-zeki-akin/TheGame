using TheGame.Core.Entities.SpaceObjects;
using TheGame.Core.Shared.Enums;
using TheGame.Core.Shared.ValueObjects;

namespace TheGame.Core.Entities;

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
    public Location Location { get; set; }
    public Location Destination { get; set; }
    
    public long? CommanderId { get; set; }
    public Commander? Commander { get; set; }    
    public long OwnerId { get; set; }
    public Player Owner { get; set; }

    public ICollection<SpacecraftGroup> SpacecraftGroups { get; set; }
}