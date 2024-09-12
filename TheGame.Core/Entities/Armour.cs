namespace TheGame.Core.Entities;

public class Armour
{
    public long Id { get; set; }
    public string Name { get; set; }
    public int Value { get; set; }
    public int Mass { get; set; }
    public int RepairRate { get; set; }
    public int Quality { get; set; }
    public int ProjectileResistance { get; set; }
    public int EnergyResistance { get; set; }
}