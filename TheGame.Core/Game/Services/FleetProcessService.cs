using TheGame.Core.Game.Cache.Interfaces;
using TheGame.Core.Game.Entities.Fleets;
using TheGame.Core.Game.Services.Interface;
using TheGame.Core.Game.Shared.Enums;

namespace TheGame.Core.Game.Services;

public class FleetProcessService(ICacheService<Fleet> fleetCache)
    : IFleetProcessService
{
    public Task Process()
    {
        var fleets = fleetCache.GetAll();

        foreach (var fleet in fleets)
        {
            switch (fleet.State)
            {
                case FleetState.Navigating:
                    ProcessNavigatingFleet(fleet);
                    break;
                case FleetState.SpaceJumping:
                    // Space jumping logic can be handled here
                    break;
                // Handle other states as needed
            }
        }

        return Task.CompletedTask;
    }

    private void ProcessNavigatingFleet(Fleet fleet)
    {
        var fleetObjective = fleet.FleetMission.FirstOrDefault();
    }
}