using System.ComponentModel.DataAnnotations.Schema;

namespace TheGame.Core.Game.Entities.Empires;

[NotMapped]
public class EmpireTech
{
    public Guid Id { get; set; }
    public Guid EmpireId { get; set; }
    public Empire Empire { get; set; }
    public Guid ResearchId { get; set; }
    public Research Research { get; set; }
}