using TheGame.Core.Shared.Enums;

namespace TheGame.Core.Entities.Buildings;

public class ResourceBuilding : Building
{
    public ResourceBuildingType? ResourceBuildingType { get; set; }
    public int? ResourceProductionsId { get; set; }
    public ResourceValue ResourceProductionsRate { get; set; }
}