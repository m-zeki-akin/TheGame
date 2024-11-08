﻿using TheGame.Core.Game.Shared.Enums;

namespace TheGame.Core.Game.Entities.SpaceObjects.Components;

public class ProjectileComponent : Component
{
    public ProjectileType ProjectileType { get; set; }
    public DamageType DamageType { get; set; }
    public int Damage { get; set; }
    public int ShieldPenetration { get; set; }
    public int ArmourPenetration { get; set; }
}