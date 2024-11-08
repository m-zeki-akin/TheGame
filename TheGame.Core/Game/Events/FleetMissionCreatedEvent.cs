﻿using MediatR;

namespace TheGame.Core.Game.Events;

public class FleetMissionCreatedEvent : INotification
{
    public Guid FleetId { get; set; }
}