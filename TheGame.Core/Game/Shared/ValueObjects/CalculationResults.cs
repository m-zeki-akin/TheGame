namespace TheGame.Core.Game.Shared.ValueObjects;

public record struct CalculationResult
{
    public long SpacecraftGroupId { get; set; }
    public long TravelTime { get; set; }
    public ResourceValue FuelConsumption { get; set; }
    public long DepartTime { get; set; }
}