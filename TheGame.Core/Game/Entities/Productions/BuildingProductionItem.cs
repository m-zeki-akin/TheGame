using MediatR;
using TheGame.Core.Game.Entities.StellarObjects;
using TheGame.Core.Game.Events;
using TheGame.Core.Game.Shared;

namespace TheGame.Core.Game.Entities.Productions;

public class BuildingProductionItem
{
    public Guid Id { get; set; }   
    public Guid ProducedBuildingId { get; set; }
    public PlanetBuilding ProducedBuilding { get; set; }    
    public Guid? ReplacedBuildingId { get; set; }
    public PlanetBuilding? ReplacedBuilding { get; set; }    
    public int Workforce { get; set; }
    public int CurrentProduction { get; set; }

}