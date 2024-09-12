namespace TheGame.Core.Entities;

public class Shield
{
    public long Id { get; set; }
    public string Name { get; set; }
    public int Value { get; set; }
    public int Power { get; set; }
    public int RegenerationRate { get; set; }
    public int Quality { get; set; }
    public int ProjectileResistance { get; set; }
    public int EnergyResistance { get; set; }
}