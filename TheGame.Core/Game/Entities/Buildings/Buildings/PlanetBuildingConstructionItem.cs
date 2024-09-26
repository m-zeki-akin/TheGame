namespace TheGame.Core.Game.Entities.Buildings.Buildings;

public class PlanetBuildingConstructionItem
{
    public long Id { get; set; }
    public long PlanetBuildingId { get; set; }
    public PlanetBuilding PlanetBuilding { get; set; }
    public int Order { get; set; }
    public int CurrentProduction { get; set; }
    public ReaderWriterLockSlim LockSlim { get; }
}