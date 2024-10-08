using TheGame.Core.Game.Entities.Buildings;
using TheGame.Core.Game.Entities.Requirements;
using TheGame.Core.Game.Entities.SpaceObjects.Components;
using TheGame.Core.Game.Shared.Enums;
using TheGame.Core.Game.Shared.ValueObjects;

namespace TheGame.Core.Game.Entities.SpaceObjects;

public class SpaceObjectRequirement
{
    public Guid Id { get; set; }
    public Guid SpaceObjectId { get; set; }
    public SpaceObject SpaceObject { get; set; }

    public int PowerCost { get; set; }
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
    public ResearchRequirement? ResearchRequirement1 { get; set; }
    public Guid? ResearchRequirement2Id { get; set; }
    public ResearchRequirement? ResearchRequirement2 { get; set; }
    public Guid? ResearchRequirement3Id { get; set; }
    public ResearchRequirement? ResearchRequirement3 { get; set; }
    public Guid? ResearchRequirement4Id { get; set; }
    public ResearchRequirement? ResearchRequirement4 { get; set; }
    public Guid? ResearchRequirement5Id { get; set; }
    public ResearchRequirement? ResearchRequirement5 { get; set; }
    public Guid? ResearchRequirement6Id { get; set; }
    public ResearchRequirement? ResearchRequirement6 { get; set; }
}