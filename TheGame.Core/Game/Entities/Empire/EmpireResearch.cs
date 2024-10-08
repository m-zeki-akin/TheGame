using System.ComponentModel.DataAnnotations.Schema;

namespace TheGame.Core.Game.Entities;

[NotMapped]
public class EmpireResearch
{
    public Guid PlayerId { get; set; }
    public Empire Empire { get; set; }

    public Guid ResearchId { get; set; }
    public Research Research { get; set; }

    public int Value { get; set; }
    public bool IsCompleted { get; set; }
}