using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TheGame.Core.Game.Data;
using TheGame.Core.Game.Entities;
using TheGame.Core.Game.Services.Interface;
using TheGame.Core.Game.Shared.Enums;
using TheGame.Core.Game.Shared.ValueObjects;

namespace TheGame.Core.Game.Services;

public class FleetUpdateService : IFleetUpdateService
{
    private readonly IServiceProvider _serviceProvider;

    public FleetUpdateService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task UpdateFleets(CancellationToken cancellationToken)
    {
        using var scope = _serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<MainDataContext>();

        var fleets = await dbContext.Fleets
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

        await dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task UpdateNavigatingFleetAsync(Fleet fleet, CancellationToken cancellationToken)
    {
        using var scope = _serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<MainDataContext>();

        var currentPosition = fleet.Location;
        var dest = fleet.SubDestination.Destinations.First();
        var direction = new Vector2D(
            dest.Coordinates.X - currentPosition.Coordinates.X,
            dest.Coordinates.Y - currentPosition.Coordinates.Y);

        var distance = direction.Magnitude;

        if (fleet.Speed < distance)
        {
            var travelRatio = fleet.Speed / distance;

            fleet.Location = new Location
            {
                Coordinates = new Coordinates(
                    currentPosition.Coordinates.X + direction.X * travelRatio,
                    currentPosition.Coordinates.Y + direction.Y * travelRatio)
            };
        }
        else
        {
            fleet.Location = new Location
            {
                Coordinates = new Coordinates(
                    dest.Coordinates.X,
                    dest.Coordinates.Y)
            };
            fleet.State = FleetState.Docked;
        }
    }
}