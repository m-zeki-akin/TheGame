using TheGame.Core.Entities.Requirement;
using TheGame.Core.Shared.Enums;

namespace TheGame.Core.Entities.Buildings;

public abstract class Building
{
    public long Id { get; set; }
    public string Name { get; set; }
    public BuildingType Type { get; set; }  // use discriminator for entityframework(tph) NOT tpt
    public BuildingClass Class { get; set; }
    public int Level { get; set; }
    public int Limit { get; set; }
    public int ProductionCost { get; set; }
    public bool IsActive { get; set; }
    
    public long CostId { get; set; }
    public ResourceCost Cost{ get; set; }
    public long? NextLevelBuildingId { get; set; }
    public Building? NextLevelBuilding{ get; set; }
    public long? PreviousLevelBuildingId { get; set; }
    public Building? PreviousLevelBuilding{ get; set; }
    
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
    
    public int? ResourceConsumptionsId { get; set; }
    public ResourceCost ResourceConsumptionsRate { get; set; }
}