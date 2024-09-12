namespace TheGame.Core.Entities;

public class AuxiliaryAddon
{
    public long Id { get; set; }
    public string Name { get; set; }
    public int Morale { get; set; }
    public int HitPoints { get; set; }
    
    public long ArmourId { get; set; }
    public Armour Armour { get; set; }
    public long ShieldId { get; set; }
    public Shield Shield { get; set; }
    
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
}