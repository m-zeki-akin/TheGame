using MediatR;
using TheGame.Core.Data;
using TheGame.Core.Entities;

namespace TheGame.Core.Commands;

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