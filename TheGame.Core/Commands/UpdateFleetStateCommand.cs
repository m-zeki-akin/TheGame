using MediatR;
using TheGame.Core.Shared.Enums;
using TheGame.Core.Shared.ValueObjects;

namespace TheGame.Core.Commands;

public class UpdateFleetStateCommand : IRequest
{
    public long FleetId { get; set; }
    public FleetState NewState { get; set; }
    public Location NewLocation { get; set; }
}