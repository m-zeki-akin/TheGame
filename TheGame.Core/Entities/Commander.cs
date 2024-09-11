using TheGame.Core.Entities.ValueObjects;

namespace TheGame.Core.Entities;

public class Commander
{
    public long Id { get; set; }
    public string Name { get; set; }
    public bool IsActive { get; set; }
    public int Command { get; set; }
    public int Attack { get; set; }
    public int Defence { get; set; }
    public int Maneuver { get; set; }
    public int Luck { get; set; }

    public long FleetId { get; set; }
    public Fleet Fleet { get; set; }
    public long LocationId { get; set; }
    public Location Location { get; set; }

    public ICollection<Trait> Traits { get; set; }
}