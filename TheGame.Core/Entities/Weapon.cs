using TheGame.Core.Entities.Enums;

namespace TheGame.Core.Entities;

public class Weapon
{
    public long Id { get; set; }
    public string Name { get; set; }
    public WeaponType Type { get; set; }
    public int Range { get; set; }
    public double RateOfFire { get; set; }
    public int Accuracy { get; set; }
    public int Quality { get; set; }
    public bool IsHoming { get; set; }
}