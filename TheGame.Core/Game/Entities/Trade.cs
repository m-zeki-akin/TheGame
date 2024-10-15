using TheGame.Core.Game.Shared.Enums;

namespace TheGame.Core.Game.Entities;

public class Trade : DynamicEntity
{
    public Guid Id { get; set; }
    public TradeType Type { get; set; }
    public int Value { get; set; }
}