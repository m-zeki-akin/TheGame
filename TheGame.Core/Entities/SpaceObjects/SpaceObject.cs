using TheGame.Core.Entities.Buildings;
using TheGame.Core.Entities.Requirement;
using TheGame.Core.Entities.SpaceObjects.Components;
using TheGame.Core.Shared.Enums;

namespace TheGame.Core.Entities.SpaceObjects;

public class SpaceObject
{
    public long Id { get; set; }
    public string Name { get; set; }
    public SpaceObjectType Type { get; set; }
    public long ProductionCost { get; set; }
    public int HitPoints { get; set; } // ortalama
    public int RepairRate { get; set; }
    public int PowerCost { get; set; } // Should be stack with component powercost
    
    public long CostId { get; set; }
    public ResourceCost Cost { get; set; }
    
    public long AuxiliaryComponentId { get; set; }
    public AuxiliaryComponent AuxiliaryAddon { get; set; }
    public long PowerGeneratorComponentId { get; set; }
    public PowerGeneratorComponent PowerGeneratorComponent { get; set; }
    public long ArmourComponentId { get; set; }
    public ArmourComponent ArmourComponent { get; set; }
    public long ShieldComponentId { get; set; }
    public ShieldComponent ShieldComponent { get; set; }    
    public int WeaponsComponentSlot { get; set; }
    public ICollection<WeaponComponent> WeaponsComponent { get; set; }
    
    public long BuildingRequirement1Id { get; set; }
    public BuildingRequirement BuildingRequirement1 { get; set; }
    public long? BuildingRequirement2Id { get; set; }
    public BuildingRequirement? BuildingRequirement2 { get; set; }
    public long? BuildingRequirement3Id { get; set; }
    public BuildingRequirement? BuildingRequirement3 { get; set; }
    public long? BuildingRequirement4Id { get; set; }
    public BuildingRequirement? BuildingRequirement4 { get; set; }
    public long? BuildingRequirement5Id { get; set; }
    public BuildingRequirement? BuildingRequirement5 { get; set; }
    public long? BuildingRequirement6Id { get; set; }
    public BuildingRequirement? BuildingRequirement6 { get; set; }
    
    public long? ResearchRequirement1Id { get; set; }
    public ResearchRequirement? ResearchRequirement1 { get; set; }
    public long? ResearchRequirement2Id { get; set; }
    public ResearchRequirement? ResearchRequirement2 { get; set; }
    public long? ResearchRequirement3Id { get; set; }
    public ResearchRequirement? ResearchRequirement3 { get; set; }
    public long? ResearchRequirement4Id { get; set; }
    public ResearchRequirement? ResearchRequirement4 { get; set; }
    public long? ResearchRequirement5Id { get; set; }
    public ResearchRequirement? ResearchRequirement5 { get; set; }
    public long? ResearchRequirement6Id { get; set; }
    public ResearchRequirement? ResearchRequirement6 { get; set; }

}