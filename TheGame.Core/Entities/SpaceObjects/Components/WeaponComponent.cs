using TheGame.Core.Shared.Enums;

namespace TheGame.Core.Entities.SpaceObjects.Components;

public class WeaponComponent: Component
{
    public WeaponType Type { get; set; }
    public int PowerCost { get; set; }
    public int Range { get; set; }
    public double RateOfFire { get; set; }
    public int Accuracy { get; set; }
    public int Firepower { get; set; }
    public long ProjectileComponentId { get; set; }
    public ProjectileComponent ProjectileComponent { get; set; }
}