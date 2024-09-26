using TheGame.Core.Game.Shared.Enums;
using TheGame.Core.Game.Shared.ValueObjects;

namespace TheGame.Core.Game.Entities.Buildings;

public class ResourceBuilding : Building
{
    public ResourceBuildingType? ResourceBuildingType { get; set; }
    public int? ResourceProductionsId { get; set; }
    public ResourceValue ResourceProductionsRate { get; set; }
}