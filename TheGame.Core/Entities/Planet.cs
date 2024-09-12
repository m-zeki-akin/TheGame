using TheGame.Core.Shared.Enums;
using TheGame.Core.Shared.ValueObjects;

namespace TheGame.Core.Entities;

public class Planet : StellarObject
{
    public int Size { get; set; }
    public int Level  { get; set; } // use terra-forming
    public int Devastation  { get; set; }
    public Coordinates Coordinates  { get; set; }
    public double DistanceFromStar  { get; set; }
    public Climate Climate  { get; set; }
    public PlanetType PlanetType  { get; set; }
    public bool IsCapital  { get; set; }

    public long? OwnerId  { get; set; }
    public Player? Owner  { get; set; }
    
    //TODO
}