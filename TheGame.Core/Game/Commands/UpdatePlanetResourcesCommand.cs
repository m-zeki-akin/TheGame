using MediatR;
using TheGame.Core.Game.Shared.ValueObjects;

namespace TheGame.Core.Game.Commands;

public class UpdatePlanetResourcesCommand : IRequest
{
    public Guid PlanetId { get; set; }
    public ResourceValue ResourcesToAdd { get; set; }
}