using Microsoft.AspNetCore.SignalR;
using TheGame.Core.Game.Entities;
using TheGame.Core.Game.Shared.ValueObjects;

namespace TheGame.Core.Game.Hubs;

public class GameHub : Hub
{
    private static readonly TimeSpan TickRate = TimeSpan.FromSeconds(5);
    private static readonly Dictionary<string, Timer> PlayerResourceTimers = new();
    private static readonly Dictionary<string, Timer> PlayerFleetTimers = new();

    public override async Task OnConnectedAsync()
    {
        if (!PlayerResourceTimers.ContainsKey(Context.ConnectionId))
        {
            var resourceTimer = new Timer(SendResourceUpdate, Context.ConnectionId, TickRate, TickRate);
            PlayerResourceTimers[Context.ConnectionId] = resourceTimer;
        }

        if (!PlayerFleetTimers.ContainsKey(Context.ConnectionId))
        {
            var fleetTimer = new Timer(SendFleetUpdate, Context.ConnectionId, TickRate, TickRate);
            PlayerFleetTimers[Context.ConnectionId] = fleetTimer;
        }

        await base.OnConnectedAsync();
    }

    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        if (PlayerResourceTimers.TryGetValue(Context.ConnectionId, out var resourceTimer))
        {
            await resourceTimer.DisposeAsync();
            PlayerResourceTimers.Remove(Context.ConnectionId);
        }

        if (PlayerFleetTimers.TryGetValue(Context.ConnectionId, out var fleetTimer))
        {
            await fleetTimer.DisposeAsync();
            PlayerFleetTimers.Remove(Context.ConnectionId);
        }

        await base.OnDisconnectedAsync(exception);
    }

    private async void SendResourceUpdate(object? state)
    {
        foreach (var connectionId in PlayerResourceTimers.Keys)
        {
            var player = GetPlayerByConnectionId(connectionId); // Fetch player

            // Access the first planet associated with the player
            var planet = player?.Planets.FirstOrDefault()?.Planet; // Navigate from PlayerPlanet to Planet

            if (planet?.StoredResources != null)
            {
                var resource = planet.StoredResources; // Access StoredResources from the Planet entity
                await UpdateResource(connectionId, resource);
            }
        }
    }

    private async void SendFleetUpdate(object? state)
    {
        foreach (var connectionId in PlayerFleetTimers.Keys)
        {
            var player = GetPlayerByConnectionId(connectionId); // Fetch player
            var fleets = player?.Fleets.Select(pf => pf.Fleet).ToList(); // Example: Get all fleets
            if (fleets != null)
            {
                foreach (var fleet in fleets)
                {
                    await UpdateFleetState(connectionId, fleet);
                }
            }
        }
    }

    public async Task UpdateResource(string connectionId, ResourceValue resource)
    {
        await Clients.Client(connectionId).SendAsync("ReceiveResourceUpdate", resource);
    }

    public async Task UpdateFleetState(string connectionId, Fleet fleet)
    {
        await Clients.Client(connectionId).SendAsync("ReceiveFleetUpdate", fleet);
    }

    // Placeholder method to fetch the player from the connection ID
    private Player? GetPlayerByConnectionId(string connectionId)
    {
        // Logic to fetch the player (e.g., from your in-memory cache or database)
        return null; // Replace with actual implementation
    }
}