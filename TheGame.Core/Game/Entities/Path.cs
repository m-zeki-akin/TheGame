using TheGame.Core.Game.Shared.ValueObjects;

namespace TheGame.Core.Game.Entities;

public class Path
{
    public ICollection<Location> Destinations { get; set; }
}