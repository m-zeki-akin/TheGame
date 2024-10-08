using MediatR;
using TheGame.Core.Game.Entities;
using TheGame.Core.Game.Shared.Enums;

namespace TheGame.Core.Game.Commands;

public class CreateEmpireCommand : IRequest<Guid>
{
    public Player Player { get; set; }
    public EmpireType EmpireType { get; set; }
}