using TheGame.Core.Entities.SpaceObjects.Components;

namespace TheGame.Core.Entities.SpaceObjects.Templates;

public class SpaceholdTemplate
{
    public long Id { get; set; }
    public string Name { get; set; }
    public int HitPoints { get; set; } // ortalama
    public int RepairRate { get; set; }
    public int PowerCost { get; set; }

    public long ArmourComponentId { get; set; }
    public ArmourComponent ArmourComponent { get; set; }
    public int ArmourComponentCount { get; set; }
    public long ShieldComponentId { get; set; }
    public ShieldComponent ShieldComponent { get; set; }
    public int ShieldComponentCount { get; set; }
    public long WeaponsComponentId { get; set; }
    public WeaponComponent WeaponsComponent { get; set; }
    public int WeaponComponentCount { get; set; }
    public long ImplicitWeaponComponentId { get; set; }
    public WeaponComponent ImplicitWeaponComponent { get; set; }
    public int ImplicitWeaponComponentCount { get; set; }
    public long AuxiliaryComponentId { get; set; }
    public AuxiliaryComponent AuxiliaryAddon { get; set; }
    public long SupportComponentId { get; set; }
    public SupportComponent SupportComponent { get; set; }
    
    public int CommandPower { get; set; }
    public int DefencePower { get; set; }
    public int DetectionRange { get; set; }
    public int DetectionPower { get; set; }
}