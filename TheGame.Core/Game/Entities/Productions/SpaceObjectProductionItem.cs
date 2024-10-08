using TheGame.Core.Game.Entities.SpaceObjects;

namespace TheGame.Core.Game.Entities.Buildings.Buildings;

public class SpaceObjectProductionItem
{
    public Guid Id { get; set; }
    public Guid SpaceObjectId { get; set; }
    public SpaceObject SpaceObject { get; set; }
    public int Count { get; set; }
    public int CurrentProduction { get; set; }
}