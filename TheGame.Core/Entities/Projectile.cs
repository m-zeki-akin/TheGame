using TheGame.Core.Shared.Enums;

namespace TheGame.Core.Entities;

public class Projectile
{
    public int Id { get; set; }
    public int Name { get; set; }
    public ProjectileType ProjectileType { get; set; }
    public DamageType DamageType { get; set; }
    public int Damage { get; set; }
    public int ShieldPenetration { get; set; }
    public int ArmourPenetration { get; set; }
}