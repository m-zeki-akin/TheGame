namespace TheGame.Core.Game.Events;

public class FleetMissionSuccessful
{
    public Guid FleetId { get; set; }
    public Guid MissionId { get; set; }
}