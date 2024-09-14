using TheGame.Core.Entities.Buildings;
using TheGame.Core.Entities.SpaceObjects;
using TheGame.Core.Shared.Enums;
using TheGame.Core.Shared.ValueObjects;

namespace TheGame.Core.Entities;

public class Planet : StellarObject
{
    public int Size { get; set; }
    public PlanetType PlanetType  { get; set; }
    public int Level  { get; set; } // use terra-forming
    public int Devastation  { get; set; }
    public Location Location  { get; set; }
    public Climate Climate  { get; set; }
    public bool IsCapital  { get; set; }
    public StrategicResourceType? StrategicResourceType  { get; set; }
    public int? StrategicResourceLevel  { get; set; }
    public ResourceValue StoredResources  { get; set; }

    public long? OwnerId  { get; set; }
    public Player? Owner  { get; set; }
    
    public long? SpaceholdGroupId  { get; set; }
    public SpaceholdGroup? SpaceholdGroup  { get; set; }
    
    public int? StrategicResourceVein   { get; set; }
    public int MineralVein { get; set; }
    public int ExtractionField   { get; set; }
    
    public int DistrictCap   { get; set; }
    public int ResearchDistrict   { get; set; }
    public int IndustrialDistrict   { get; set; } // depot, refinery, purifier
    public int FacilitiesDistrict   { get; set; } // construction facility
    
    public long ConstructionBuildingId  { get; set; }
    public PlanetBuilding ConstructionBuilding  { get; set; }
    public ICollection<PlanetBuilding> Buildings  { get; set; }
}