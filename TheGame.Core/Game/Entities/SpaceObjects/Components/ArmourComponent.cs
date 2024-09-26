namespace TheGame.Core.Game.Entities.SpaceObjects.Components;

public class ArmourComponent : Component
{
    public int Value { get; set; }
    public int Mass { get; set; }
    public int RepairRate { get; set; }
    public int ProjectileResistance { get; set; }
    public int EnergyResistance { get; set; }
}