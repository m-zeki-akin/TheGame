using TheGame.Core.Entities.Requirement;
using TheGame.Core.Shared.Enums;

namespace TheGame.Core.Entities.SpaceObjects.Components;

public class Component
{
    public long Id { get; set; }
    public string Name { get; set; }
    public long Level { get; set; }
    public long? NextLevelComponentId { get; set; }
    public Component? NextLevelComponent{ get; set; }
    public long? PreviousLevelComponentId { get; set; }
    public Component? PreviousLevelComponent{ get; set; }
    public Size Size { get; set; }
    public long CostId { get; set; }
    public ResourceCost Cost { get; set; }

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