using TheGame.Core.Game.Entities;

namespace TheGame.Core.Game.Shared.ValueObjects;

public class Location
{
    public Coordinates Coordinates { get; set; }
    public SolarSystem SolarSystem { get; set; }
}