using TheGame.Core.Game.Entities.Buildings;

namespace TheGame.Core.Game.Entities;

public class PlanetBuilding
{
    public Guid Id { get; set; }
    public Guid PlanetId { get; set; }
    public Planet Planet { get; set; }
    public Guid BuildingId { get; set; }
    public Building Building { get; set; }
    public bool IsEnabled { get; set; }
}