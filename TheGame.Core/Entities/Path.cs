using TheGame.Core.Shared.ValueObjects;

namespace TheGame.Core.Entities;

public class Path
{
    public ICollection<Location> Destinations { get; set; }
}