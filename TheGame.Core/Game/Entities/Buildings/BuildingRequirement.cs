using TheGame.Core.Game.Entities.Buildings;
using TheGame.Core.Game.Entities.Requirements;

namespace TheGame.Core.Game.Entities.SpaceObjects;

public class BuildingRequirement
{
    public Guid Id { get; set; }
    public Guid BuildingId { get; set; }
    public Building Building { get; set; }

    public Guid CostId { get; set; }
    public ResourceCost Cost { get; set; }

    public Guid? BuildingRequirement1Id { get; set; }
    public Building? BuildingRequirement1 { get; set; }
    public Guid? BuildingRequirement2Id { get; set; }
    public Building? BuildingRequirement2 { get; set; }
    public Guid? BuildingRequirement3Id { get; set; }
    public Building? BuildingRequirement3 { get; set; }
    public Guid? BuildingRequirement4Id { get; set; }
    public Building? BuildingRequirement4 { get; set; }
    public Guid? BuildingRequirement5Id { get; set; }
    public Building? BuildingRequirement5 { get; set; }
    public Guid? BuildingRequirement6Id { get; set; }
    public Building? BuildingRequirement6 { get; set; }

    public Guid? ResearchRequirement1Id { get; set; }
    public Research? ResearchRequirement1 { get; set; }
    public Guid? ResearchRequirement2Id { get; set; }
    public Research? ResearchRequirement2 { get; set; }
    public Guid? ResearchRequirement3Id { get; set; }
    public Research? ResearchRequirement3 { get; set; }
    public Guid? ResearchRequirement4Id { get; set; }
    public Research? ResearchRequirement4 { get; set; }
    public Guid? ResearchRequirement5Id { get; set; }
    public Research? ResearchRequirement5 { get; set; }
    public Guid? ResearchRequirement6Id { get; set; }
    public Research? ResearchRequirement6 { get; set; }
}