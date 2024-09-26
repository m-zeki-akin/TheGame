namespace TheGame.Core.Game.Entities.SpaceObjects.Components;

public class ShieldComponent : Component
{
    public int Value { get; set; }
    public int PowerCost { get; set; }
    public int RegenerationRate { get; set; }
    public int ProjectileResistance { get; set; }
    public int EnergyResistance { get; set; }
}