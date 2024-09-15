using MediatR;
using Microsoft.EntityFrameworkCore;
using TheGame.Core.Data;

namespace TheGame.Core.Commands.Handlers;

public class UpdateFleetStateCommandHandler : IRequestHandler<UpdateFleetStateCommand>
{
    private readonly MainDataContext _context;

    public UpdateFleetStateCommandHandler(MainDataContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateFleetStateCommand request, CancellationToken cancellationToken)
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