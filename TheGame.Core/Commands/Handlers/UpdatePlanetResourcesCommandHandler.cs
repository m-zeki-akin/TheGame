using MediatR;
using Microsoft.EntityFrameworkCore;
using TheGame.Core.Data;

namespace TheGame.Core.Commands.Handlers;

public class UpdatePlanetResourcesCommandHandler : IRequestHandler<UpdatePlanetResourcesCommand>
{
    private readonly MainDataContext _context;

    public UpdatePlanetResourcesCommandHandler(MainDataContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdatePlanetResourcesCommand request, CancellationToken cancellationToken)
    {
        var planet = await _context.Planets
            .FirstOrDefaultAsync(p => p.Id == request.PlanetId, cancellationToken);

        if (planet != null)
        {
            planet.StoredResources += request.ResourcesToAdd;

            _context.Planets.Update(planet);
            await _context.SaveChangesAsync(cancellationToken);
        }

        return;
    }
}