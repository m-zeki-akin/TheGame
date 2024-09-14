using MediatR;
using TheGame.Core.Data;
using TheGame.Core.Dtos;

namespace TheGame.Core.Queries;

public class GetPlayerByIdQueryHandler : IRequestHandler<GetPlayerByIdQuery, PlayerDto?>
{
    private readonly MainDataContext _context;

    public GetPlayerByIdQueryHandler(MainDataContext context)
    {
        _context = context;
    }

    public async Task<PlayerDto?> Handle(GetPlayerByIdQuery request, CancellationToken cancellationToken)
    {
        var player = await _context.Players.FindAsync(request.Id);
        return PlayerDto.ToDto(player);
    }
}