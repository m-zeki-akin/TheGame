using TheGame.Core.Game.Entities.Abstract;
using TheGame.Core.Game.Shared.ValueObjects;

namespace TheGame.Core.Game.Entities;

public class ResourceCost : StaticEntity
{
    public ResourceValue ResourceValue { get; set; }
}