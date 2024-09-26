using TheGame.Core.Game.Entities;
using TheGame.Core.Game.Entities.SpaceObjects;
using TheGame.Core.Game.Services.Interface;
using TheGame.Core.Game.Shared;
using TheGame.Core.Game.Shared.ValueObjects;

namespace TheGame.Core.Game.Services;

public class FleetObjectiveCalculationService(GameRules gameRules) : IFleetObjectiveCalculationService
{
    public ResourceValue CalculateTotalCost(IEnumerable<CalculationResult> results)
    {
        var totalCost = new ResourceValue();
        foreach (var result in results)
        {
            totalCost += result.FuelConsumption;
        }

        return totalCost;
    }

    public long CalculateDistance(StellarObject startLocation, StellarObject destinationLocation,
        bool differentSolarSystem)
    {
        var distanceCoefficient = differentSolarSystem
            ? gameRules.OuterSpaceDistanceCoefficient
            : gameRules.InterSpaceDistanceCoefficient;

        var directionVector = new Vector2D(
            (differentSolarSystem
                ? destinationLocation.Location.SolarSystem.Coordinates.X
                : destinationLocation.Location.Coordinates.X) -
            (differentSolarSystem
                ? startLocation.Location.SolarSystem.Coordinates.X
                : startLocation.Location.Coordinates.X),
            (differentSolarSystem
                ? destinationLocation.Location.SolarSystem.Coordinates.Y
                : destinationLocation.Location.Coordinates.Y) -
            (differentSolarSystem
                ? startLocation.Location.SolarSystem.Coordinates.Y
                : startLocation.Location.Coordinates.Y)
        );

        return (long)(directionVector.Magnitude * distanceCoefficient);
    }

    public int CalculatePowerRate(int powerUsagePercentage, Spacecraft spacecraft)
    {
        return spacecraft.EngineComponent.PowerRate * powerUsagePercentage / 100;
    }

    public int CalculateJumpPower(int powerUsagePercentage, Spacecraft spacecraft)
    {
        return spacecraft.EngineComponent.JumpPower * powerUsagePercentage / 100;
    }

    public ResourceValue CalculateConsumptionRate(int powerUsagePercentage, Spacecraft spacecraft,
        bool differentSolarSystem)
    {
        return spacecraft.EngineComponent.ConsumptionRate *
               powerUsagePercentage *
               powerUsagePercentage *
               (differentSolarSystem
                   ? gameRules.FleetOuterSpaceMovementCostCoefficient
                   : gameRules.FleetInterSpaceMovementCostCoefficient);
    }

    public long CalculatePlanetDepartTime(StellarObject startLocation, int powerRate)
    {
        return (long)(startLocation.Size * gameRules.FleetPlanetDepartingTimeCoefficient / powerRate);
    }

    public ResourceValue CalculatePlanetDepartConsumption(Spacecraft spacecraft, long planetDepartTime)
    {
        return spacecraft.EngineComponent.ConsumptionRate * planetDepartTime *
               gameRules.FleetPlanetDepartingFuelConsumptionCoefficient;
    }

    public long CalculateTravelTime(long distance, int powerRate, int jumpPower, bool differentSolarSystem)
    {
        return (long)(differentSolarSystem
            ? distance / powerRate * gameRules.FleetOuterTravelTimeCoefficient
            : distance / jumpPower * gameRules.FleetInterTravelTimeCoefficient);
    }

    public ResourceValue CalculateTravelConsumption(ResourceValue consumptionRate, long travelTime,
        bool differentSolarSystem)
    {
        return differentSolarSystem
            ? consumptionRate * travelTime * gameRules.FleetOuterFuelConsumptionCoefficient
            : consumptionRate * travelTime * gameRules.FleetInterFuelConsumptionCoefficient;
    }
}