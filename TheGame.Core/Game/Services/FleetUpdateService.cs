using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TheGame.Core.Game.Cache;
using TheGame.Core.Game.Data;
using TheGame.Core.Game.Entities;
using TheGame.Core.Game.Services.Interface;
using TheGame.Core.Game.Shared.Enums;
using TheGame.Core.Game.Shared.ValueObjects;

namespace TheGame.Core.Game.Services;

public class FleetUpdateService(ICacheService<Fleet> fleetCache) 
    : IFleetUpdateService
{

    public async Task UpdateAsync(CancellationToken cancellationToken)
    {
        var fleets = fleetCache.GetAll();
        
        foreach (var fleet in fleets)
        {
            switch (fleet.State)
            {
                case FleetState.Navigating:
                    await UpdateNavigatingFleetAsync(fleet, cancellationToken);
                    break;
                case FleetState.SpaceJumping:
                    // Space jumping logic can be handled here
                    break;
                // Handle other states as needed
            }
        }

    }

    private async Task UpdateNavigatingFleetAsync(Fleet fleet, CancellationToken cancellationToken)
    {
        var fleetObjective = fleet.FleetMission.FirstOrDefault();
    }
}