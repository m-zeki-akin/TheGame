namespace TheGame.Core.Entities;

public class DefenceStructWeapon
{
    public long DefenceStructId { get; set; }
    public DefenceStruct DefenceStruct { get; set; }

    public long WeaponId { get; set; }
    public Weapon Weapon { get; set; }
}