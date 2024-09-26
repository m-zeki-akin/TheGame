using TheGame.Core.Game.Commands;
using TheGame.Core.Game.Entities;
using TheGame.Core.Game.Events.Validators.Interfaces;
using TheGame.Core.Game.Shared;
using TheGame.Core.Game.Shared.ValueObjects;
using TheGame.Core.Shared.Validation;

namespace TheGame.Core.Game.Events.Validators;

public class FleetObjectiveCalculatedEventValidator : IFleetObjectiveCalculatedEventValidator
{
    private readonly GameRules _gameRules;

    public FleetObjectiveCalculatedEventValidator(GameRules gameRules)
    {
        _gameRules = gameRules;
    }

    public ValidationResult Validate(FleetObjectiveSetCommand notification, Fleet fleet, ResourceValue cost,
        HashSet<CalculationResult> calculationResults)
    {
        var validationResult = ValidationResult.Create();

        foreach (var spacecraftGroup in fleet.SpacecraftGroups)
        {
            var result = calculationResults.FirstOrDefault(r => r.SpacecraftGroupId == spacecraftGroup.Id);

            if (result.FuelConsumption.Total() > spacecraftGroup.Spacecraft.Attributes.FuelCapacity)
            {
                var missingFuel = result.FuelConsumption.Total() - spacecraftGroup.Spacecraft.StorageComponent.Capacity;
                validationResult.AddError(
                    $"Spacecraft: {spacecraftGroup.Spacecraft.Name} fuel capacity is not sufficient for objective.",
                    "FuelCapacity",
                    missingFuel
                );
            }

            if (result.DepartTime > _gameRules.FleetPlanetDepartingTimeMax)
            {
                validationResult.AddError(
                    $"Spacecraft: {spacecraftGroup.Spacecraft.Name} planet depart time limit exceeded.",
                    "DepartTime",
                    result.DepartTime
                );
            }

            if (result.TravelTime > _gameRules.FleetTravelTimeMax)
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