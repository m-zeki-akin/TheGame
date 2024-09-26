using MediatR;
using TheGame.Core.Game.Dtos;

namespace TheGame.Core.Game.Queries;

public class GetPlayerByIdQuery : IRequest<PlayerDto?>
{
    public Guid Id { get; set; }
}