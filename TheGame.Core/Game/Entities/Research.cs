using TheGame.Core.Game.Entities.Abstract;
using TheGame.Core.Game.Shared.Enums;
using TheGame.Core.Game.Shared.ValueObjects;

namespace TheGame.Core.Game.Entities;

public class Research : StaticEntity
{
    public string Name { get; set; }
    public int Level { get; set; }
    public ResearchType Type { get; set; }
    public Guid CostId { get; set; }
    public ResourceCost ResourceCost { get; set; }
    public int ResearchCost { get; set; }
}