using TheGame.Core.Game.Entities.Abstract;
using TheGame.Core.Game.Entities.Requirements;
using TheGame.Core.Game.Entities.SpaceObjects;
using TheGame.Core.Game.Shared.Enums;

namespace TheGame.Core.Game.Entities.Buildings;

public abstract class Building : StaticEntity
{
    public string Name { get; set; }
    public BuildingType Type { get; set; } // use discriminator for entityframework(tph) NOT tpt
    public BuildingClass Class { get; set; }
    public bool IsActive { get; set; }
    public int Level { get; set; }
    public int? Limit { get; set; }
    public int ProductionCost { get; set; }
    public Guid CostId { get; set; }
    public ResourceCost Cost { get; set; }

    public ICollection<BuildingRequirement> Requirements { get; set; }

    public int? ResourceConsumptionsId { get; set; }
    public ResourceCost? ResourceConsumptionsRate { get; set; }
    
}