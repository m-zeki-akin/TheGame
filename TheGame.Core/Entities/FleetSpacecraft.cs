namespace TheGame.Core.Entities;

public class FleetSpacecraft
{
    public long FleetId { get; set; }
    public Fleet Fleet { get; set; }

    public long SpacecraftId { get; set; }
    public Spacecraft Spacecraft { get; set; }

    public ulong Quantity { get; set; }
}