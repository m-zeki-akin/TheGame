namespace TheGame.Core.Game.Shared.ValueObjects;

public class ObjectiveCalculationResult
{
    public Guid SpacecraftGroupId { get; set; }
    public long TravelTime { get; set; }
    public ResourceValue FuelConsumption { get; set; }
    public ResourceValue FuelConsumptionRate { get; set; }
    public long DepartTime { get; set; }
}