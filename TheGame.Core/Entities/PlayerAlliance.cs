using TheGame.Core.Shared.Enums;

namespace TheGame.Core.Entities;

public class PlayerAlliance
{
    public long PlayerId { get; set; }
    public Player Player  { get; set; }
    
    public long AllianceId { get; set; }
    public Alliance Alliance { get; set; }
}