﻿using MediatR;

namespace TheGame.Core.Game.Events;

public class FleetBlockadeInitiatedEvent : INotification
{
    public Guid FleetId { get; set; }
}