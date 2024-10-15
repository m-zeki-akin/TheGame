using Microsoft.AspNetCore.SignalR;
using TheGame.Core.Game.Entities;
using TheGame.Core.Game.Entities.Empires;
using TheGame.Core.Game.Entities.Fleets;
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
            var player = GetPlayerByConnectionId(connectionId); 

            var planet = player?.Planets.FirstOrDefault()?.Planet;
            if (planet?.StoredResources != null)
            {
                var resource = planet.StoredResources;
                await UpdateResource(connectionId, resource);
            }
        }
    }

    private async void SendFleetUpdate(object? state)
    {
        foreach (var connectionId in PlayerFleetTimers.Keys)
        {
            var player = GetPlayerByConnectionId(connectionId);
            var fleets = player?.Fleets.Select(pf => pf.Fleet).ToList(); 
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

    private Empire? GetPlayerByConnectionId(string connectionId)
    {
       
        return null;
    }
}