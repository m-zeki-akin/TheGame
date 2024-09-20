using TheGame.Core.Entities;
using TheGame.Core.Shared.Enums;

namespace TheGame.Core.Shared.ValueObjects;

public class Location
{
    public Coordinates Coordinates { get; set; }
    public SolarSystem SolarSystem { get; set; }
}