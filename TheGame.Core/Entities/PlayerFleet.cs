using TheGame.Core.Shared.Enums;

namespace TheGame.Core.Entities;

public class PlayerFleet
{
    public long PlayerId { get; set; }
    public Player Player  { get; set; }
    
    public long FleetId { get; set; }
    public Fleet Fleet { get; set; }
}