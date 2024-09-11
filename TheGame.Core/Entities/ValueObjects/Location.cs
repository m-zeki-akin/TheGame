using TheGame.Core.Entities.Enums;

namespace TheGame.Core.Entities.ValueObjects;

public class Location
{
    public Coordinates Coordinates { get; set; }
    public LocationType Type { get; set; }
}