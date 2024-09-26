namespace TheGame.Core.Game.Shared;

public class GameRules
{
    public double InterSpaceDistanceCoefficient { get; } = 1.0;
    public double OuterSpaceDistanceCoefficient { get; set; } = 1.0;
    public double FleetInterSpaceMovementCostCoefficient { get; set; } = 1.0;
    public double FleetOuterSpaceMovementCostCoefficient { get; set; } = 1.0;
    public double FleetPlanetDepartingTimeCoefficient { get; set; } = 1.0;
    public double FleetPlanetDepartingFuelConsumptionCoefficient { get; set; } = 1.0;
    public double FleetInterTravelTimeCoefficient { get; set; } = 1.0;
    public double FleetOuterTravelTimeCoefficient { get; set; } = 1.0;
    public double FleetInterFuelConsumptionCoefficient { get; set; } = 1.0;
    public double FleetOuterFuelConsumptionCoefficient { get; set; } = 1.0;
    public long FleetPlanetDepartingTimeMax { get; set; } = 900; // 15 mins
    public long FleetTravelTimeMax { get; set; } = 1296000; // 15 days
}