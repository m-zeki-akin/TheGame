using TheGame.Core.Shared.Enums;

namespace TheGame.Core.Entities;

public class TradePartner
{
    public long Id { get; set; }
    public string PlayerId { get; set; }
    public Player Player { get; set; }
    
    public string PartnerId { get; set; }
    public Player Partner { get; set; }
}