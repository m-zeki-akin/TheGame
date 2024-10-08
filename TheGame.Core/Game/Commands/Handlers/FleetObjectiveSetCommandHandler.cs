using MediatR;
using TheGame.Core.Game.Cache;
using TheGame.Core.Game.Entities;
using TheGame.Core.Game.Entities.SpaceObjects;
using TheGame.Core.Game.Events.Validators.Interfaces;
using TheGame.Core.Game.Services.Interface;
using TheGame.Core.Game.Shared;
using TheGame.Core.Game.Shared.ValueObjects;
using TheGame.Core.Shared;

namespace TheGame.Core.Game.Commands.Handlers;

public class FleetObjectiveSetCommandHandler(
    ICacheService<Fleet> fleetCache,
    IFleetObjectiveCalculationService fleetObjectiveCalculationService,
    IFleetObjectiveCalculatedEventValidator validator)
    : IRequestHandler<FleetObjectiveSetCommand, Result<FleetObjective>>
{
    public Task<Result<FleetObjective>> Handle(FleetObjectiveSetCommand notification,
        CancellationToken cancellationToken)
    {
        var fleet = fleetCache.Get(notification.FleetId);

        if (fleet == null)
        {
            throw new KeyNotFoundException($"Fleet with id {notification.FleetId} not found");
        }

        var isDifferentSolarSystem = notification.StartLocation.Location.SolarSystem.Id !=
                                     notification.Destination.Location.SolarSystem.Id;
        var distance = fleetObjectiveCalculationService.CalculateDistance(notification.StartLocation,
            notification.Destination, isDifferentSolarSystem);

        var spacecraftGroups = fleet.SpacecraftGroups.ToHashSet();
        var individualResults = CalculateForAllSpacecraftGroupsIndividually(notification, spacecraftGroups, distance,
            isDifferentSolarSystem);
        var results = CalculateForAllSpacecraftGroupsCorrelated(individualResults);

        var totalCost = fleetObjectiveCalculationService.CalculateTotalCost(results);

        var validation = validator.Validate(fleet, totalCost, results);
        if (validation.IsFailed) return Task.FromResult(Result<FleetObjective>.Failure(validation));

        var fleetObjective = new FleetObjective
        {
            Type = notification.ObjectiveType,
            PowerUsagePercentage = notification.PowerUsagePercentage,
            Location = notification.Destination.Location,
            IsSpaceJumpRequired = isDifferentSolarSystem,
            Distance = distance,
            Cost = totalCost,
            Duration = results.First().TravelTime
        };

        return Task.FromResult(Result<FleetObjective>.Success(fleetObjective));
    }
    
    private HashSet<ObjectiveCalculationResult> CalculateForAllSpacecraftGroupsCorrelated(
        HashSet<ObjectiveCalculationResult> results)
    {
        var correlatedResults = new HashSet<ObjectiveCalculationResult>(); 
        
        double duration = results.Max(x => x.TravelTime);
        var departTime = results.Max(x => x.DepartTime);
        // Recalculate each spacecraft group with slowest spacecraft group
        foreach (var result in results)
        {
            if (result.TravelTime < duration)
            {
                var dDuration = result.TravelTime / duration;
                var (fuelConsumption, _) = result.FuelConsumption -
                                           (result.FuelConsumptionRate * Math.Sqrt(dDuration) *
                                            GameRules.FleetFuelConsumptionNormalizerCoefficient);
                result.DepartTime = departTime;
                result.TravelTime = (long)duration;
                correlatedResults.Add(new ObjectiveCalculationResult
                {
                    FuelConsumption = fuelConsumption,
                    DepartTime = departTime,
                    FuelConsumptionRate = result.FuelConsumptionRate,
                    SpacecraftGroupId = result.SpacecraftGroupId,
                    TravelTime = (long)duration
                });
            }
            else
            {
                correlatedResults.Add(new ObjectiveCalculationResult
                {
                    FuelConsumption = result.FuelConsumption,
                    DepartTime = result.DepartTime,
                    FuelConsumptionRate = result.FuelConsumptionRate,
                    SpacecraftGroupId = result.SpacecraftGroupId,
                    TravelTime = result.TravelTime
                });
            }
        }

        return correlatedResults;
    }

    private HashSet<ObjectiveCalculationResult> CalculateForAllSpacecraftGroupsIndividually(
        FleetObjectiveSetCommand notification,
        IEnumerable<SpacecraftGroup> spacecraftGroups,
        long distance,
        bool differentSolarSystem)
    {
        var results = new HashSet<ObjectiveCalculationResult>();

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


            results.Add(new ObjectiveCalculationResult
            {
                TravelTime = totalTravelTime,
                FuelConsumption = totalFuelConsumption,
                FuelConsumptionRate = rates.ConsumptionRate,
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