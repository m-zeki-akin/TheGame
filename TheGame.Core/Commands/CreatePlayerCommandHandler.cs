using MediatR;
using TheGame.Core.Data;
using TheGame.Core.Entities;

namespace TheGame.Core.Commands;

public class CreatePlayerCommandHandler : IRequestHandler<CreatePlayerCommand, Guid>
{
    private readonly CommandDbContext _context;
    
    public CreatePlayerCommandHandler(CommandDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreatePlayerCommand request, CancellationToken cancellationToken)
    {
        var player = new Player
        {
            Id = Guid.NewGuid(),
            // TODO
        };
        await _context.Players.AddAsync(player, cancellationToken);
        return player.Id;
    }
}