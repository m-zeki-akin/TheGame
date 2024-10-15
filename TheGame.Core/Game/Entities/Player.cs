using TheGame.Core.Game.Entities.Empires;

namespace TheGame.Core.Game.Entities;

public class Player :DynamicEntity
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public Empire Empire { get; set; }
    public bool IsActive { get; set; }
    public long DominationScore { get; set; }
    public long PropertyScore { get; set; }
    public long ScienceScore { get; set; }
    public long TotalScore { get; set; }
}