namespace TheGame.Core.Entities;

public class ArtificialSpaceObjectWeapon
{
    public long ArtificialSpaceObjectId { get; set; }
    public ArtificialSpaceObject ArtificialSpaceObject { get; set; }

    public long WeaponId { get; set; }
    public Weapon Weapon { get; set; }
}