using TheGame.Core.Game.Commands;
using TheGame.Core.Game.Entities;
using TheGame.Core.Game.Events.Validators.Interfaces;
using TheGame.Core.Game.Shared;
using TheGame.Core.Game.Shared.ValueObjects;
using TheGame.Core.Shared.Validation;

namespace TheGame.Core.Game.Events.Validators;

public class FleetObjectiveCalculatedEventValidator : IFleetObjectiveCalculatedEventValidator
{
    public ValidationResult Validate(Fleet fleet, ResourceValue cost,
        HashSet<ObjectiveCalculationResult> calculationResults)
    {
        var validationResult = ValidationResult.Create();

        foreach (var spacecraftGroup in fleet.SpacecraftGroups)
        {
            var result = calculationResults.FirstOrDefault(r => r.SpacecraftGroupId == spacecraftGroup.Id);

            if (result == null)
            {
                throw new KeyNotFoundException($"Spacecraft group {spacecraftGroup.Id} not found");
            }

            if (result.FuelConsumption.Total() > spacecraftGroup.Spacecraft.Attributes.FuelCapacity)
            {
                var missingFuel = result.FuelConsumption.Total() - spacecraftGroup.Spacecraft.StorageComponent.Capacity;
                validationResult.AddError(
                    $"Spacecraft: {spacecraftGroup.Spacecraft.Name} fuel capacity is not sufficient for objective.",
                    "FuelCapacity",
                    missingFuel
                );
            }

            if (result.DepartTime > GameRules.FleetPlanetDepartingTimeMax)
            {
                validationResult.AddError(
                    $"Spacecraft: {spacecraftGroup.Spacecraft.Name} planet depart time limit exceeded.",
                    "DepartTime",
                    result.DepartTime
                );
            }

            if (result.TravelTime > GameRules.FleetTravelTimeMax)
            {
                validationResult.AddError(
                    $"Spacecraft: {spacecraftGroup.Spacecraft.Name} travel time limit exceeded.",
                    "TravelTime",
                    result.TravelTime
                );
            }
        }

        if (fleet.Planet!.StoredResources < cost)
        {
            var missingResources = cost - fleet.Planet!.StoredResources;
            validationResult.AddError(
                $"Objective costs {cost} resources. Need {missingResources} more resources.",
                "Resources",
                missingResources
            );
        }

        return validationResult;
    }
}