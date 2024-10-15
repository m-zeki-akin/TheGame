using TheGame.Core.Game.Entities.SpaceObjects.Components;
using TheGame.Core.Game.Shared.Enums;
using TheGame.Core.Game.Shared.ValueObjects;

namespace TheGame.Core.Game.Entities.SpaceObjects;

public class Spacecraft : SpaceObject
{
    public SpacecraftType SpacecraftType { get; set; }
    public SpacecraftClass SpacecraftClass { get; set; }
    
    public Guid AuxiliaryComponentId { get; set; }
    public AuxiliaryComponent AuxiliaryAddon { get; set; }
    public Guid PowerGeneratorComponentId { get; set; }
    public PowerGeneratorComponent PowerGeneratorComponent { get; set; }
    public Guid ArmourComponentId { get; set; }
    public ArmourComponent ArmourComponent { get; set; }
    public Guid ShieldComponentId { get; set; }
    public ShieldComponent ShieldComponent { get; set; }
    public Guid EngineId { get; set; }
    public EngineComponent EngineComponent { get; set; }
    public Guid StorageId { get; set; }
    public StorageComponent StorageComponent { get; set; }
    public int WeaponsComponentSlot { get; set; }
    public ICollection<WeaponComponent> WeaponsComponent { get; set; }
}