using System.ComponentModel.DataAnnotations.Schema;
using TheGame.Core.Game.Entities.Abstract;

namespace TheGame.Core.Game.Entities.Requirements;

[NotMapped]
public class ResearchRequirement : StaticEntity
{
    public Guid ResearchId { get; set; }
    public int ResearchLevel { get; set; }
    public Research Research { get; set; }
}