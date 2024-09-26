using MediatR;

namespace TheGame.Core.Game.Events;

public class FleetArrivedEvent : INotification
{
    public long FleetId { get; set; }
}