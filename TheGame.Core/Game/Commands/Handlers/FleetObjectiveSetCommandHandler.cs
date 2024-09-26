using MediatR;
using Serilog;
using TheGame.Core.Game.Cache;
using TheGame.Core.Game.Entities;
using TheGame.Core.Game.Entities.SpaceObjects;
using TheGame.Core.Game.Events.Validators;
using TheGame.Core.Game.Services.Interface;
using TheGame.Core.Game.Shared.Enums;
using TheGame.Core.Game.Shared.ValueObjects;
using TheGame.Core.Shared;

namespace TheGame.Core.Game.Commands.Handlers;

public class FleetObjectiveSetCommandHandler(
    ICacheService<Fleet> fleetCache,
    IFleetObjectiveCalculationService fleetObjectiveCalculationService,
    FleetObjectiveCalculatedEventValidator validator)
    : IRequestHandler<FleetObjectiveSetCommand, Result<FleetObjective>>
{
    public Task<Result<FleetObjective>> Handle(FleetObjectiveSetCommand notification,
        CancellationToken cancellationToken)
    {
        var fleet = fleetCache.Get(notification.FleetId).Result;

        var isDifferentSolarSystem = notification.StartLocation.Location.SolarSystem.Id !=
                                     notification.Destination.Location.SolarSystem.Id;
        var distance = fleetObjectiveCalculationService.CalculateDistance(notification.StartLocation,
            notification.Destination, isDifferentSolarSystem);

        var spacecraftGroups = fleet.SpacecraftGroups.ToHashSet();
        var calculationResults = CalculateForAllSpacecraftGroups(notification, spacecraftGroups, distance,
            isDifferentSolarSystem);

        var totalCost = fleetObjectiveCalculationService.CalculateTotalCost(calculationResults);
        var duration = calculationResults.Min(x => x.TravelTime);
        

        var validation = validator.Validate(notification, fleet, totalCost, calculationResults);
        if (validation.IsFailed) return Task.FromResult(Result<FleetObjective>.Failure(validation));

        var fleetObjective = new FleetObjective
        {
            Type = notification.ObjectiveType,
            PowerUsagePercentage = notification.PowerUsagePercentage,
            Location = notification.Destination.Location,
            IsSpaceJumpRequired = isDifferentSolarSystem,
            Distance = distance,
            Cost = totalCost,
            Duration = duration
        };

        return Task.FromResult(Result<FleetObjective>.Success(fleetObjective));
    }

    private HashSet<CalculationResult> CalculateForAllSpacecraftGroups(
        FleetObjectiveSetCommand notification,
        IEnumerable<SpacecraftGroup> spacecraftGroups,
        long distance,
        bool differentSolarSystem)
    {
        var results = new HashSet<CalculationResult>();

        foreach (var group in spacecraftGroups)
        {
            var spacecraft = group.Spacecraft;
            var rates = PrecomputeRates(notification, spacecraft, differentSolarSystem);

            var planetDepartTime =
                fleetObjectiveCalculationService.CalculatePlanetDepartTime(notification.StartLocation, rates.PowerRate);
            var planetDepartConsumption =
                fleetObjectiveCalculationService.CalculatePlanetDepartConsumption(spacecraft, planetDepartTime);

            var travelTime = fleetObjectiveCalculationService.CalculateTravelTime(distance, rates.PowerRate,
                rates.JumpPower, differentSolarSystem);
            var travelConsumption =
                fleetObjectiveCalculationService.CalculateTravelConsumption(rates.ConsumptionRate, travelTime,
                    differentSolarSystem);

            var totalTravelTime = planetDepartTime + travelTime;
            var totalFuelConsumption = planetDepartConsumption + travelConsumption;

            results.Add(new CalculationResult
            {
                TravelTime = totalTravelTime,
                FuelConsumption = totalFuelConsumption,
                DepartTime = planetDepartTime,
                SpacecraftGroupId = group.Id
            });
        }

        return results;
    }

    private (int PowerRate, int JumpPower, ResourceValue ConsumptionRate) PrecomputeRates(
        FleetObjectiveSetCommand notification, Spacecraft spacecraft, bool differentSolarSystem)
    {
        var powerRate =
            fleetObjectiveCalculationService.CalculatePowerRate(notification.PowerUsagePercentage, spacecraft);
        var jumpPower =
            fleetObjectiveCalculationService.CalculateJumpPower(notification.PowerUsagePercentage, spacecraft);
        var consumptionRate =
            fleetObjectiveCalculationService.CalculateConsumptionRate(notification.PowerUsagePercentage, spacecraft,
                differentSolarSystem);

        return (powerRate, jumpPower, consumptionRate);
    }
}