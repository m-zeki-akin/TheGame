namespace TheGame.Core.Entities.Buildings.ProductionQueue;

public class PlanetBuildingConstructionItem
{
    public long PlanetBuildingId { get; set; } //builder
    public PlanetBuilding PlanetBuilding { get; set; }
    public long BuildingId { get; set; }
    public Building Building { get; set; }
    public int Order { get; set; }
}