using TheGame.Core.Game.Commands;
using TheGame.Core.Game.Entities;
using TheGame.Core.Game.Shared.ValueObjects;
using TheGame.Core.Shared.Validation;

namespace TheGame.Core.Game.Events.Validators.Interfaces;

public interface IFleetObjectiveCalculatedEventValidator
{
    ValidationResult Validate(FleetObjectiveSetCommand notification, Fleet fleet, ResourceValue cost,
        HashSet<CalculationResult> calculationResults);
}