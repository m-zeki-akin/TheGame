using MediatR;
using TheGame.Core.Game.Entities;
using TheGame.Core.Game.Shared.Enums;
using TheGame.Core.Shared;

namespace TheGame.Core.Game.Commands;

public class FleetObjectiveSetCommand : IRequest<Result<FleetObjective>>
{
    public Guid FleetId { get; set; }
    public int PowerUsagePercentage { get; set; }
    public StellarObject Destination { get; set; }
    public StellarObject StartLocation { set; get; }
    public bool IsDockedOnStart { set; get; }
    public FleetObjectiveType ObjectiveType { get; set; }
}