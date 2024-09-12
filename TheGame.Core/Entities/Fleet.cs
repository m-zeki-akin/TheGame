using TheGame.Core.Shared.Enums;
using TheGame.Core.Shared.ValueObjects;

namespace TheGame.Core.Entities;

public class Fleet
{
    public long Id { get; set; }
    public string Name { get; set; }

    public long? CommanderId { get; set; }
    public int LineOfSight { get; set; }
    public int DetectionPower { get; set; }
    public int Morale { get; set; }
    public Commander? Commander { get; set; }
    public Location Location { get; set; }

    public FleetType Type { get; set; }
    public FleetState State { get; set; }

    public ICollection<Spacecraft> Spacecrafts { get; set; }
}