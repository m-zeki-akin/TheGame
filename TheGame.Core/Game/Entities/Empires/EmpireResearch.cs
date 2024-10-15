using System.ComponentModel.DataAnnotations.Schema;
using MediatR;
using TheGame.Core.Game.Events;

namespace TheGame.Core.Game.Entities.Empires;

[NotMapped]
public class EmpireResearch
{
    public Guid Id { get; set; }
    public Guid ResearchId { get; set; }
    public Research Research { get; set; }
    public Guid EmpireId { get; set; }
    public Empire Empire { get; set; }
    public int Value { get; set; }
}