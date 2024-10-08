namespace TheGame.Core.Game.Entities.Buildings.Buildings;

public class BuildingProductionItem
{
    public Guid Id { get; set; }   
    public Guid ProducedBuildingId { get; set; }
    public Building ProducedBuilding { get; set; }    
    public Guid? ReplacedBuildingId { get; set; }
    public Building? ReplacedBuilding { get; set; }    
    public int Order { get; set; }
    public int CurrentProduction { get; set; }
}