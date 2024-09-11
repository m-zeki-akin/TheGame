using MediatR;
using TheGame.Core.Dtos;

namespace TheGame.Core.Queries;

public class GetPlayerByIdQuery : IRequest<PlayerDto?>
{
    public Guid Id { get; set; }
}