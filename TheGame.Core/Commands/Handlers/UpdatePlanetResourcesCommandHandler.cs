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
            .Include(p => p.StoredResources)
            .FirstOrDefaultAsync(p => p.Id == request.PlanetId, cancellationToken);

        if (planet != null)
        {
            planet.StoredResources.Fuel += request.ResourcesToAdd.Fuel;
            planet.StoredResources.Material += request.ResourcesToAdd.Material;
            planet.StoredResources.Energy += request.ResourcesToAdd.Energy;
            planet.StoredResources.Alloy += request.ResourcesToAdd.Alloy;
            planet.StoredResources.Actinium += request.ResourcesToAdd.Actinium;
            planet.StoredResources.Plutonium += request.ResourcesToAdd.Plutonium;
            planet.StoredResources.Polonium += request.ResourcesToAdd.Polonium;
            planet.StoredResources.Technetium += request.ResourcesToAdd.Technetium;

            _context.Planets.Update(planet);
            await _context.SaveChangesAsync(cancellationToken);
        }

        return;
    }
}