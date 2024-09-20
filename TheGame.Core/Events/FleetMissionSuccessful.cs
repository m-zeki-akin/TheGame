namespace TheGame.Core.Events;

public class FleetMissionSuccessful
{
    public long FleetId { get; set; }
    public long MissionId { get; set; }
}