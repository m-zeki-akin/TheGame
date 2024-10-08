using TheGame.Core.Game.Entities.SpaceObjects.Components;
using TheGame.Core.Game.Shared.Enums;

namespace TheGame.Core.Game.Entities.SpaceObjects.Templates;

public class SpacecraftTemplate
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int HitPoints { get; set; } // ortalama
    public int RepairRate { get; set; }
    public int PowerCost { get; set; }

    public SpacecraftType Type { get; set; }
    public SpacecraftClass Class { get; set; }

    public Guid ArmourComponentId { get; set; }
    public ArmourComponent ArmourComponent { get; set; }
    public int ArmourComponentCount { get; set; }
    public Guid ShieldComponentId { get; set; }
    public ShieldComponent ShieldComponent { get; set; }
    public int ShieldComponentCount { get; set; }
    public Guid WeaponsComponentId { get; set; }
    public WeaponComponent WeaponsComponent { get; set; }
    public int WeaponComponentCount { get; set; }
    public Guid ImplicitWeaponComponentId { get; set; }
    public WeaponComponent ImplicitWeaponComponent { get; set; }
    public int ImplicitWeaponComponentCount { get; set; }
    public Guid AuxiliaryComponentId { get; set; }
    public AuxiliaryComponent AuxiliaryAddon { get; set; }
    public Guid PowerGeneratorComponentId { get; set; }
    public PowerGeneratorComponent PowerGeneratorComponent { get; set; }
    public Guid EngineId { get; set; }
    public EngineComponent EngineComponent { get; set; }
    public Guid StorageId { get; set; }
    public StorageComponent StorageComponent { get; set; }

    public int Mass { get; set; }
    public int DisengageChance { get; set; }
    public int ScreenPower { get; set; }
    public int CommandPower { get; set; }
    public int DetectionRange { get; set; }
    public int DetectionPower { get; set; }
}