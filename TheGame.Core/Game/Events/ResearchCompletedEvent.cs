using MediatR;

namespace TheGame.Core.Game.Events;

public class ResearchCompletedEvent : INotification
{
    public Guid EmpireId { get; set; }
    public Guid ResearchId { get; set; }
}