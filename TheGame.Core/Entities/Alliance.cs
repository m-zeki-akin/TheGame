using TheGame.Core.Shared.Enums;

namespace TheGame.Core.Entities;

public class Alliance
{
    public long Id { get; set; }
    public string Name { get; set; }
    
    public ICollection<Player> Players { get; set; }
}