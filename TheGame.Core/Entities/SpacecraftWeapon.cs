namespace TheGame.Core.Entities;

public class SpacecraftWeapon
{
    public long SpacecraftId { get; set; }
    public Spacecraft Spacecraft { get; set; }

    public long WeaponId { get; set; }
    public Weapon Weapon { get; set; }
}