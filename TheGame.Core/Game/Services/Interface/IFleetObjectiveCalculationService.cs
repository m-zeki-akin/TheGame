using TheGame.Core.Game.Entities;
using TheGame.Core.Game.Entities.SpaceObjects;
using TheGame.Core.Game.Shared.ValueObjects;

namespace TheGame.Core.Game.Services.Interface;

public interface IFleetObjectiveCalculationService
{
    ResourceValue CalculateTotalCost(IEnumerable<ObjectiveCalculationResult> results);

    long CalculateDistance(StellarObject startLocation, StellarObject destinationLocation, bool differentSolarSystem);

    int CalculatePowerRate(int powerUsagePercentage, Spacecraft spacecraft);

    int CalculateJumpPower(int powerUsagePercentage, Spacecraft spacecraft);

    ResourceValue CalculateConsumptionRate(int powerUsagePercentage, Spacecraft spacecraft, bool differentSolarSystem);

    long CalculatePlanetDepartTime(StellarObject startLocation, int powerRate);

    ResourceValue CalculatePlanetDepartConsumption(Spacecraft spacecraft, long planetDepartTime);

    long CalculateTravelTime(long distance, int powerRate, int jumpPower, bool differentSolarSystem);

    ResourceValue CalculateTravelConsumption(ResourceValue consumptionRate, long travelTime, bool differentSolarSystem);
}