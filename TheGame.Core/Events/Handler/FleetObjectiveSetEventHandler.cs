using MediatR;
using TheGame.Core.Cache;
using TheGame.Core.Entities;
using TheGame.Core.Entities.SpaceObjects;
using TheGame.Core.Shared;
using TheGame.Core.Shared.ValueObjects;

namespace TheGame.Core.Events.Handler;

public class FleetObjectiveSetEventHandler(
    GameCache<Fleet> fleetCache,
    GameRules gameRules
)
    : INotificationHandler<FleetObjectiveSetEvent>
{
    public Task Handle(FleetObjectiveSetEvent notification, CancellationToken cancellationToken)
    {
        var fleet = fleetCache.Get(notification.FleetId)!;

        var differentSolarSystem = notification.StartLocation.Location.SolarSystem.Id !=
                                   notification.Destination.Location.SolarSystem.Id;

        var distance = CalculateDistance(notification, differentSolarSystem);

        var cost = new ResourceValue();
        long duration = long.MaxValue;
        foreach (var spacecraftGroup in fleet.SpacecraftGroups)
        {
            var spacecraft = spacecraftGroup.Spacecraft;
            var consumptionRate = CalculateConsumptionRate(notification, spacecraft, differentSolarSystem);
            var powerRate = CalculatePowerRate(notification, spacecraft);
            var jumpPower = CalculateJumpPower(notification, spacecraft);

            var planetDepartTime = CalculatePlanetDepartTime(notification, powerRate);
            var planetDepartConsumption = CalculatePlanetDepartConsumption(spacecraft, planetDepartTime);

            var travelTime = CalculateTravelTime(distance, powerRate, jumpPower, differentSolarSystem);
            var travelConsumption = CalculateTravelConsumption( consumptionRate,  travelTime,  differentSolarSystem);

            var totalTravelTime = planetDepartTime + travelTime;
            var totalFuelConsumption = planetDepartConsumption + travelConsumption;

            // Planet depart time  : planetSize * PlanetDepartingTimeCoefficient / powerRate
            // Planet depart consume : consumptionRate * Planet depart time * PlanetDepartingFuelConsumptionCoefficient
            // Travel Time for inter  : distance / powerRate * InterTravelTimeCoefficient
            // Travel Time for outer  : distance / jumpPower * OuterTravelTimeCoefficient
            // Travel Consumption for inter  : travelTime * consumptionRate * InterFuelConsumptionCoefficient
            // Travel Consumption for outer  : travelTime * consumptionRate * OuterFuelConsumptionCoefficient
            // Total Travel Time : Planet depart time + (Travel Time for outer OR Travel Time for inter)
            // Total Consumption : Planet depart consume + (Travel Time for outer OR Travel Time for inter)

            duration = Math.Min(totalTravelTime, duration);
            cost += totalFuelConsumption;
        }

        var objective = new FleetObjective
        {
            Type = notification.ObjectiveType,
            PowerUsagePercentage = notification.PowerUsagePercentage,
            Location = notification.Destination.Location,
            IsSpaceJumpRequired = differentSolarSystem,
            Distance = distance,
            Cost = cost,
            Duration = duration
        };

        fleet.FleetMission.Add(objective);

        return Task.CompletedTask;
    }

    private long CalculateDistance(FleetObjectiveSetEvent notification, bool differentSolarSystem)
    {
        var distanceCoefficient = differentSolarSystem
            ? gameRules.OuterSpaceDistanceCoefficient
            : gameRules.InterSpaceDistanceCoefficient;

        var directionVector = new Vector2D(
            (differentSolarSystem
                ? notification.Destination.Location.SolarSystem.Coordinates.X
                : notification.Destination.Location.Coordinates.X) -
            (differentSolarSystem
                ? notification.StartLocation.Location.SolarSystem.Coordinates.X
                : notification.StartLocation.Location.Coordinates.X),
            (differentSolarSystem
                ? notification.Destination.Location.SolarSystem.Coordinates.Y
                : notification.Destination.Location.Coordinates.Y) -
            (differentSolarSystem
                ? notification.StartLocation.Location.SolarSystem.Coordinates.Y
                : notification.StartLocation.Location.Coordinates.Y)
        );

        return (long)(directionVector.Magnitude * distanceCoefficient);
    }

    private int CalculatePowerRate(FleetObjectiveSetEvent notification, Spacecraft spacecraft)
    {
        return spacecraft.EngineComponent.PowerRate * notification.PowerUsagePercentage / 100;
    }

    private int CalculateJumpPower(FleetObjectiveSetEvent notification, Spacecraft spacecraft)
    {
        return spacecraft.EngineComponent.JumpPower * notification.PowerUsagePercentage / 100;
    }

    private ResourceValue CalculateConsumptionRate(FleetObjectiveSetEvent notification, Spacecraft spacecraft,
        bool differentSolarSystem)
    {
        return spacecraft.EngineComponent.ConsumptionRate *
               notification.PowerUsagePercentage *
               notification.PowerUsagePercentage *
               (differentSolarSystem
                   ? gameRules.OuterSpaceMovementCostCoefficient
                   : gameRules.InterSpaceMovementCostCoefficient);
    }

    private long CalculatePlanetDepartTime(FleetObjectiveSetEvent notification, int powerRate)
    {
        return (long)(notification.StartLocation.Size * gameRules.PlanetDepartingTimeCoefficient / powerRate);
    }

    private ResourceValue CalculatePlanetDepartConsumption(Spacecraft spacecraft, long planetDepartTime)
    {
        return spacecraft.EngineComponent.ConsumptionRate * planetDepartTime *
               gameRules.PlanetDepartingFuelConsumptionCoefficient;
    }

    private long CalculateTravelTime(long distance, int powerRate, int jumpPower, bool differentSolarSystem)
    {
        return (long)(differentSolarSystem
            ? distance / powerRate * gameRules.OuterTravelTimeCoefficient
            : distance / jumpPower * gameRules.InterTravelTimeCoefficient);
    }
    private ResourceValue CalculateTravelConsumption(ResourceValue consumptionRate, long travelTime, bool differentSolarSystem)
    {
        return differentSolarSystem
            ? consumptionRate * travelTime * gameRules.OuterFuelConsumptionCoefficient
            : consumptionRate * travelTime * gameRules.InterFuelConsumptionCoefficient;
    }
}