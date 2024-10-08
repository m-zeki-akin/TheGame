using TheGame.Core.Game.Entities.SpaceObjects.Components;
using TheGame.Core.Game.Shared.Enums;

namespace TheGame.Core.Game.Entities.SpaceObjects;

public class DefencePlatform : SpaceObject
{
    public DefenceType DefenceType { get; set; }
    public Guid AuxiliaryComponentId { get; set; }
    public AuxiliaryComponent AuxiliaryAddon { get; set; }
    public Guid PowerGeneratorComponentId { get; set; }
    public PowerGeneratorComponent PowerGeneratorComponent { get; set; }
    public Guid ArmourComponentId { get; set; }
    public ArmourComponent ArmourComponent { get; set; }
    public Guid ShieldComponentId { get; set; }
    public ShieldComponent ShieldComponent { get; set; }
    public int WeaponsComponentSlot { get; set; }
    public ICollection<WeaponComponent> WeaponsComponent { get; set; }
}