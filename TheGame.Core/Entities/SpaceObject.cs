using TheGame.Core.Entities.Enums;

namespace TheGame.Core.Entities;

public abstract class SpaceObject
{
    public long Id { get; set; }
    public string Name { get; set; }
    public SpaceObjectType Type { get; set; }
    public ulong Quantity { get; set; }
    public int Morale { get; set; }
    public int HitPoints { get; set; }
    public int Armour { get; set; }
    public int ArmourQuality { get; set; }
    public int Shield { get; set; }
    public int ShieldQuality { get; set; }
    public int DetectionRange { get; set; }

    public int Firepower { get; set; }
    public int RateOfFire { get; set; }
    public int Range { get; set; }
    public int Evasion { get; set; }
    public int Speed { get; set; }
    public int Accuracy { get; set; }
    public int ScreenPower { get; set; }
    public int CommandPower { get; set; }
    public int ProjectileResistance { get; set; }
    public int EnergyResistance { get; set; }
    public int RepairRate { get; set; }
    public int Storage { get; set; }
    public int DisengageChance { get; set; }

    public ICollection<SpaceObjectCost> Cost { get; set; }
    public ICollection<SpaceObjectWeapon> Weapons { get; set; }
    public ICollection<SpaceObjectAuxiliaryAddon> Auxiliaries { get; set; }
}