namespace TheGame.Core.Entities.Buildings.ProductionQueue;

public class PlanetBuildingConstructionItem
{
    public long Id { get; set; }
    public long PlanetBuildingId { get; set; }
    public PlanetBuilding PlanetBuilding { get; set; }
    public int Order { get; set; }
    public int CurrentProduction { get; set; }
}