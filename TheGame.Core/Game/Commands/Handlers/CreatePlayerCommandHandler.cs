using MediatR;
using TheGame.Core.Game.Data;
using TheGame.Core.Game.Entities;

namespace TheGame.Core.Game.Commands.Handlers;

public class CreatePlayerCommandHandler : IRequestHandler<CreatePlayerCommand, long>
{
    private readonly MainDataContext _context;

    public CreatePlayerCommandHandler(MainDataContext context)
    {
        _context = context;
    }

    public async Task<long> Handle(CreatePlayerCommand request, CancellationToken cancellationToken)
    {
        var player = new Player
        {
            //TODO
        };

        await _context.Players.AddAsync(player, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return player.Id;
    }
}