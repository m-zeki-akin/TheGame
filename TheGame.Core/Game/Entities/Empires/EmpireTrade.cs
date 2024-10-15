using System.ComponentModel.DataAnnotations.Schema;
using TheGame.Core.Game.Entities.Empires;
using TheGame.Core.Game.Entities.Fleets;

namespace TheGame.Core.Game.Entities;

[NotMapped]
public class EmpireTrade
{
    public Guid Id { get; set; }
    public Guid EmpireId { get; set; }
    public Empire Empire { get; set; }
    public Guid PartnerId { get; set; }
    public Empire Partner { get; set; }
    public Guid TradeFleetId { get; set; }
    public Fleet TradeFleet { get; set; }
    public int Value { get; set; }
}