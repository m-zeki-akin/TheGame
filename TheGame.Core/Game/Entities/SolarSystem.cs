using TheGame.Core.Game.Shared.ValueObjects;

namespace TheGame.Core.Game.Entities;

public class SolarSystem
{
    public Guid Id { get; set; }
    public Guid StarId { get; set; }
    public Star Star { get; set; }
    public Coordinates Coordinates { get; set; }

    public ICollection<AdjacentSolarSystem> AdjacentSolarSystems { get; set; }
    public ICollection<StellarObject> StellarObjects { get; set; }
}