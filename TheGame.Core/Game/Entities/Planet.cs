using TheGame.Core.Game.Entities.Buildings;
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

    public long? StrategicResourceLevelId { get; set; }
    public StrategicResourceLevel? StrategicResourceLevel { get; set; }

    public long? OwnerId { get; set; }
    public Player? Owner { get; set; }

    public long? SpaceholdGroupId { get; set; }
    public SpaceholdGroup? SpaceholdGroup { get; set; }

    public int? StrategicResourceVein { get; set; }
    public int MineralVein { get; set; }
    public int ExtractionField { get; set; }

    public int DistrictCap { get; set; }
    public int ResearchDistrict { get; set; }
    public int IndustrialDistrict { get; set; } // depot, refinery, purifier
    public int FacilitiesDistrict { get; set; } // construction facility

    public long ConstructionBuildingId { get; set; }
    public ConstructionBuilding ConstructionBuilding { get; set; }
    public ICollection<PlanetBuilding> Buildings { get; set; }
    public ReaderWriterLockSlim LockSlim { get; }
}