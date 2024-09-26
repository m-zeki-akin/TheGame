using TheGame.Core.Game.Shared.ValueObjects;

namespace TheGame.Core.Game.Entities;

public class ResourceCost
{
    public long Id { get; set; }
    public ResourceValue ResourceValue { get; set; }
}