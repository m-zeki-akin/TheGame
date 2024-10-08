namespace TheGame.Core.Game.Shared;

public class GameRules
{
    public static readonly int GameUpdateInterval = 1;
    public static readonly double InterSpaceDistanceCoefficient = 1.0;
    public static readonly double OuterSpaceDistanceCoefficient = 1.0;
    public static readonly double FleetInterSpaceMovementCostCoefficient = 1.0;
    public static readonly double FleetOuterSpaceMovementCostCoefficient = 1.0;
    public static readonly double FleetPlanetDepartingTimeCoefficient = 1.0;
    public static readonly double FleetPlanetDepartingFuelConsumptionCoefficient = 1.0;
    public static readonly double FleetInterTravelTimeCoefficient = 1.0;
    public static readonly double FleetOuterTravelTimeCoefficient = 1.0;
    public static readonly double FleetInterFuelConsumptionCoefficient = 1.0;
    public static readonly double FleetOuterFuelConsumptionCoefficient = 1.0;
    public static readonly long FleetPlanetDepartingTimeMax = 900; // 15 mins
    public static readonly long FleetTravelTimeMax = 1296000; // 15 days
    public static readonly double FleetFuelConsumptionNormalizerCoefficient = 1.0; // 15 days
    public static readonly double FleetTravelTimeNormalizerCoefficient = 1.0; // 15 days
}