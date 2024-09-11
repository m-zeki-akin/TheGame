using TheGame.Core.Entities.Enums;
using TheGame.Core.Entities.ValueObjects;

namespace TheGame.Core.Entities;

public class Fleet
{
    public long Id { get; set; }
    public string Name { get; set; }

    public long? CommanderId { get; set; }
    public Commander? Commander { get; set; }
    public Location Location { get; set; }

    public FleetType Type { get; set; }
    public FleetState State { get; set; }

    public ICollection<Spacecraft> Spacecrafts { get; set; }
}