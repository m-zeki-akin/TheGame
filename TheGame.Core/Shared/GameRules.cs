using TheGame.Core.Entities;

namespace TheGame.Core.Shared;

public class GameRules
{
    public double InterSpaceDistanceCoefficient  { get; set; }
    public double OuterSpaceDistanceCoefficient  { get; set; }
    public double InterSpaceMovementCostCoefficient  { get; set; }
    public double OuterSpaceMovementCostCoefficient  { get; set; }
    public double PlanetDepartingTimeCoefficient  { get; set; }
    public double PlanetDepartingFuelConsumptionCoefficient  { get; set; }
    public double InterTravelTimeCoefficient  { get; set; }
    public double OuterTravelTimeCoefficient  { get; set; }
    public double InterFuelConsumptionCoefficient  { get; set; }
    public double OuterFuelConsumptionCoefficient  { get; set; }
}