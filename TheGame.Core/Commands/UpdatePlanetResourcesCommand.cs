using MediatR;
using TheGame.Core.Entities;

namespace TheGame.Core.Commands;

public class UpdatePlanetResourcesCommand : IRequest
{
    public long PlanetId { get; set; }
    public ResourceValue ResourcesToAdd { get; set; }
}