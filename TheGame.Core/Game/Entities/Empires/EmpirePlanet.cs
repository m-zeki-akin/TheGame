using TheGame.Core.Game.Entities.StellarObjects;

namespace TheGame.Core.Game.Entities.Empires;

public class EmpirePlanet : DynamicEntity
{
    public Guid EmpireId { get; set; }
    public Empire Empire { get; set; }

    public Guid PlanetId { get; set; }
    public Planet Planet { get; set; }
}