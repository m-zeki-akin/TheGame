using TheGame.Core.Entities.Buildings;
using TheGame.Core.Entities.Buildings.ProductionQueue;

namespace TheGame.Core.Entities;

public class PlanetBuilding
{
    public long Id { get; set; }
    public long PlanetId { get; set; }
    public Planet Planet { get; set; }
    public long BuildingId { get; set; }
    public Building Building { get; set; }
}