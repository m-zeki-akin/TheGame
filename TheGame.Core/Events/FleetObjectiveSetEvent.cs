using MediatR;
using TheGame.Core.Entities;
using TheGame.Core.Shared.Enums;
using TheGame.Core.Shared.ValueObjects;

namespace TheGame.Core.Events;

public class FleetObjectiveSetEvent : INotification
{
    public long FleetId { get; set; }
    public int PowerUsagePercentage { get; set; }
    public StellarObject Destination { get; set; }
    public StellarObject StartLocation { set; get; }
    public bool IsDockedOnStart { set; get; }
    public FleetObjectiveType ObjectiveType { get; set; }
}