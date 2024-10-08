using System.ComponentModel;
using TheGame.Core.Game.Entities.Buildings;
using TheGame.Core.Game.Entities.Buildings.Buildings;
using TheGame.Core.Game.Entities.SpaceObjects;
using TheGame.Core.Game.Shared.Enums;
using TheGame.Core.Game.Shared.ValueObjects;

namespace TheGame.Core.Game.Entities;

public class Planet : StellarObject
{
    public PlanetType PlanetType { get; set; }
    public bool IsActive { get; set; }
    public bool IsUnderAttack { get; set; }
    public int Devastation { get; set; }
    public Climate Climate { get; set; }
    public bool IsCapital { get; set; }
    public StrategicResourceType? StrategicResourceType { get; set; }
    public ResourceValue StoredResources { get; set; }

    public Guid? StrategicResourceLevelId { get; set; }
    public StrategicResourceLevel? StrategicResourceLevel { get; set; }

    public Guid? OwnerId { get; set; }
    public Empire? Owner { get; set; }

    public Guid? SpaceholdGroupId { get; set; }
    public SpaceholdGroup? SpaceholdGroup { get; set; }

    // resources
    public int? StrategicResourceVein { get; set; }
    public int MineralVein { get; set; }
    public int ExtractionField { get; set; }
    
    // buildings
    public Guid? ConstructionBuildingId { get; set; }
    public ConstructionBuilding ConstructionBuilding { get; set; }
    public ICollection<PlanetBuilding> Buildings { get; set; }
    public ICollection<Component> Inventory { get; set; }
}