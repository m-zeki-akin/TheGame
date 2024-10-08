namespace TheGame.Core.Game.Entities;

public class EmpireFleet
{
    public Guid PlayerId { get; set; }
    public Empire Empire { get; set; }

    public Guid FleetId { get; set; }
    public Fleet Fleet { get; set; }
}