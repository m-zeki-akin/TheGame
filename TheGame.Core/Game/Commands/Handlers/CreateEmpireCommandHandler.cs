using MediatR;
using TheGame.Core.Game.Cache;
using TheGame.Core.Game.Data;
using TheGame.Core.Game.Entities;
using TheGame.Core.Game.Shared.Enums;

namespace TheGame.Core.Game.Commands.Handlers;

public class CreateEmpireCommandHandler(
    MainDataContext context,
    CacheService<Empire> empireCache,
    CacheService<Planet> planetCache)
    : IRequestHandler<CreateEmpireCommand, Guid>
{

    public async Task<Guid> Handle(CreateEmpireCommand request, CancellationToken cancellationToken)
    {
        var empire = new Empire
        {
            Id = Guid.NewGuid(),
            Alliances = new HashSet<EmpireAlliance>(),
            Commanders = new HashSet<EmpireCommander>(),
            Factions = new HashSet<EmpireFaction>(),
            Fleets = new HashSet<EmpireFleet>(),
            Planets = new HashSet<EmpirePlanet>(),
            Researches = new HashSet<EmpireResearch>(),
            Type = request.EmpireType,
            Leader = request.Player,
            CreatedAt = DateTime.UtcNow,
            TradePartners = new HashSet<TradePartner>(),
        };
        
        // TODO: Find planet from known galaxy and add capital planet to new player
        
        var empireEntity = await context.Players.AddAsync(empire, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        
        empireCache.Set(empireEntity.Entity.Id, empire);
        // TODO: Set capital planet to planet cache
        
        return empire.Id;
    }
}