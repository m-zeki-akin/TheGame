namespace TheGame.Core.Game.Events;

public class FleetMissionSuccessful
{
    public long FleetId { get; set; }
    public long MissionId { get; set; }
}