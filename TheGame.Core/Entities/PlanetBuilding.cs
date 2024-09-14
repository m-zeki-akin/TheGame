using TheGame.Core.Entities.Buildings;

namespace TheGame.Core.Entities;

public class PlanetBuilding
{
    public long PlanetId { get; set; }
    public Planet Planet { get; set; }
    
    public long BuildingId { get; set; }
    public Building Building { get; set; }
}