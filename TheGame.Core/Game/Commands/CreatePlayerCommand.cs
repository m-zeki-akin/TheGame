using MediatR;
using TheGame.Core.Game.Entities;
using TheGame.Core.Game.Entities.Empires;
using TheGame.Core.Game.Shared.Enums;

namespace TheGame.Core.Game.Commands;

public class CreatePlayerCommand : IRequest<Guid>
{
    public string Email { get; set; }
    public string Username { get; set; }
    public Guid EmpireId { get; set; }
    public Empire Empire { get; set; }
}