namespace TheGame.Core.Entities;

public class SpaceObjectWeapon
{
    public long SpaceElementId { get; set; }
    public SpaceObject SpaceObject { get; set; }

    public long WeaponId { get; set; }
    public Weapon Weapon { get; set; }
}