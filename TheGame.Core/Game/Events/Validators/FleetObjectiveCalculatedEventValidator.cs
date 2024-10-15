using TheGame.Core.Game.Commands;
using TheGame.Core.Game.Entities;
using TheGame.Core.Game.Entities.Fleets;
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

            if (result.FuelConsumption.Total() > spacecraftGroup.Spacecraft.StorageComponent.Capacity)
            {
                var missingFuel = result.FuelConsumption.Total() - spacecraftGroup.Spacecraft.StorageComponent.Capacity;
                validationResult.AddError(
                    $"Spacecraft: {spacecraftGroup.Spacecraft.Name} fuel capacity is not sufficient for objective.",
                    "FuelCapacity",
                    missingFuel
                );
            }
        }

        var commonResult = calculationResults.First();
        
        if (commonResult.DepartTime > GameRules.FleetPlanetDepartingTimeMax)
        {
            validationResult.AddError(
                $"Fleets: {fleet.Name} planet depart time limit exceeded.",
                "DepartTime",
                commonResult.DepartTime
            );
        }

        if (commonResult.TravelTime > GameRules.FleetTravelTimeMax)
        {
            validationResult.AddError(
                $"Fleets: {fleet.Name} travel time limit exceeded.",
                "TravelTime",
                commonResult.TravelTime
            );
        }

        if (fleet.Planet!.StoredResources < cost)
        {
            var missingResources = cost - fleet.Planet!.StoredResources;
            validationResult.AddError(
                $"Objective costs {cost} resources. Need more of those resources:{missingResources.Item2} values: {missingResources.Item1}.",
                "Resources",
                missingResources
            );
        }

        return validationResult;
    }
}