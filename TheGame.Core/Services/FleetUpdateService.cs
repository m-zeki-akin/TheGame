using Microsoft.EntityFrameworkCore;
using TheGame.Core.Data;
using TheGame.Core.Entities;
using TheGame.Core.Shared.Enums;
using TheGame.Core.Shared.ValueObjects;

namespace TheGame.Core.Services;

public class FleetUpdateService
{
    private readonly MainDataContext _dbContext;

    public FleetUpdateService(MainDataContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task UpdateFleetsAsync(CancellationToken cancellationToken)
    {
        var fleets = await _dbContext.Fleets
            //.Include(f => f.SpacecraftGroups) // Load related entities if necessary
            .ToListAsync(cancellationToken);

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

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task UpdateNavigatingFleetAsync(Fleet fleet, CancellationToken cancellationToken)
    {
        var currentPosition = fleet.Location;
        var direction = new Vector3D(fleet.Destination.Coordinates.X - currentPosition.Coordinates.X,
            fleet.Destination.Coordinates.Y - currentPosition.Coordinates.Y,
            fleet.Destination.Coordinates.Z - currentPosition.Coordinates.Z);
        var distance = direction.Magnitude;

        if (fleet.Speed < distance)
        {
            // Move fleet towards the destination
            var travelRatio = fleet.Speed / distance;
            var newPosition = new Vector3D(
                currentPosition.Coordinates.X + direction.X * travelRatio,
                currentPosition.Coordinates.Y + direction.Y * travelRatio,
                currentPosition.Coordinates.Z + direction.Z * travelRatio);

            fleet.Location = new Location
            {
                Coordinates = new Coordinates(newPosition.X, newPosition.Y, newPosition.Z),
                Type = currentPosition.Type
            };
        }
        else
        {
            fleet.Location = new Location
            {
                Coordinates = new Coordinates(
                    fleet.Destination.Coordinates.X,
                    fleet.Destination.Coordinates.Y,
                    fleet.Destination.Coordinates.Z),
                Type = fleet.Destination.Type
            };
            fleet.State = FleetState.Docked;
        }

        _dbContext.Update(fleet);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}