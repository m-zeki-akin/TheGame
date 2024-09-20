﻿using TheGame.Core.Shared.Enums;
using TheGame.Core.Shared.ValueObjects;

namespace TheGame.Core.Entities;

public class FleetObjective
{
    public long Id { get; set; }
    public Location Location { get; set; }
    public long Distance { get; set; }
    public long Duration { get; set; } // seconds
    public int PowerUsagePercentage { get; set; }
    public ResourceValue Cost { get; set; }
    public bool IsSpaceJumpRequired { get; set; }
    public FleetObjectiveType Type { get; set; }
}