using MediatR;
using TheGame.Core.Game.Shared.Enums;
using TheGame.Core.Game.Shared.ValueObjects;

namespace TheGame.Core.Game.Commands;

public class UpdateFleetsCommand : IRequest
{
    public long FleetId { get; set; }
    public FleetState NewState { get; set; }
    public Location NewLocation { get; set; }
}