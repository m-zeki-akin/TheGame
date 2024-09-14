using TheGame.Core.Entities.SpaceObjects.Components;
using TheGame.Core.Shared.Enums;

namespace TheGame.Core.Entities.SpaceObjects.Templates;

public class DefencePlatformTemplate
{
    public long Id { get; set; }
    public string Name { get; set; }
    public int HitPoints { get; set; } // ortalama
    public int RepairRate { get; set; }
    public int PowerCost { get; set; }
    
    public long CostId { get; set; }
    public ResourceValue ResourceValue { get; set; }
    public long ArmourComponentId { get; set; }
    public ArmourComponent ArmourComponent { get; set; }
    public int ArmourComponentCount { get; set; }
    public long ShieldComponentId { get; set; }
    public ShieldComponent ShieldComponent { get; set; }
    public int ShieldComponentCount { get; set; }
    public long WeaponsComponentId { get; set; }
    public WeaponComponent WeaponsComponent { get; set; }
    public int WeaponComponentCount { get; set; }
    public long AuxiliaryComponentId { get; set; }
    public AuxiliaryComponent AuxiliaryAddon { get; set; }
    public long PowerGeneratorComponentId { get; set; }
    public PowerGeneratorComponent PowerGeneratorComponent { get; set; }
    public long StorageId { get; set; }
    public StorageComponent StorageComponent { get; set; }
    
    public int DefencePower { get; set; }
    public DefenceType DefenceType { get; set; }
}