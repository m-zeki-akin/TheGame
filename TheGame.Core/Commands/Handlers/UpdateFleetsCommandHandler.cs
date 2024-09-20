using MediatR;
using Microsoft.EntityFrameworkCore;
using TheGame.Core.Data;

namespace TheGame.Core.Commands.Handlers;

public class UpdateFleetsCommandHandler : IRequestHandler<UpdateFleetsCommand>
{
    private readonly MainDataContext _context;

    public UpdateFleetsCommandHandler(MainDataContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateFleetsCommand request, CancellationToken cancellationToken)
    {
        var fleet = await _context.Fleets
            .FirstOrDefaultAsync(f => f.Id == request.FleetId, cancellationToken);

        if (fleet != null)
        {
            fleet.State = request.NewState;
            fleet.Location = request.NewLocation;

            _context.Fleets.Update(fleet);
            await _context.SaveChangesAsync(cancellationToken);
        }

        return;
    }
}