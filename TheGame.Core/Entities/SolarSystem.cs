using TheGame.Core.Shared.ValueObjects;

namespace TheGame.Core.Entities;

public class SolarSystem
{
    public long Id { get; set; }
    public long StarId { get; set; }
    public Star Star { get; set; }
    public Coordinates Coordinates { get; set; }
    
    public ICollection<AdjacentSolarSystem> AdjacentSolarSystems { get; set; }
    public ICollection<StellarObject> StellarObjects { get; set; }
    public ICollection<Planet> Planets { get; set; }
}