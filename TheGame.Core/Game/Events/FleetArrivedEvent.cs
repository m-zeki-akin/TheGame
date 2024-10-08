using MediatR;

namespace TheGame.Core.Game.Events;

public class FleetArrivedEvent : INotification
{
    public Guid FleetId { get; set; }
}