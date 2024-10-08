using System.ComponentModel.DataAnnotations.Schema;

namespace TheGame.Core.Game.Entities;

[NotMapped]
public class TradePartner
{
    public Guid Id { get; set; }
    public Guid PlayerId { get; set; }
    public Empire Empire { get; set; }

    public Guid PartnerId { get; set; }
    public Empire Partner { get; set; }
}