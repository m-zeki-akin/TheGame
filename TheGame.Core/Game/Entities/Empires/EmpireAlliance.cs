namespace TheGame.Core.Game.Entities.Empires;

public class EmpireAlliance
{
    public Guid PlayerId { get; set; }
    public Empire Empire { get; set; }

    public Guid AllianceId { get; set; }
    public Alliance Alliance { get; set; }
}