using Microsoft.AspNetCore.SignalR;
using TheGame.Core.Entities;

namespace TheGame.Core.Hubs{
    public class GameHub : Hub
    {
        private static readonly TimeSpan TickRate = TimeSpan.FromSeconds(5);
        private static readonly Dictionary<string, Timer> PlayerTimers = new();

        public override async Task OnConnectedAsync()
        {
            if (!PlayerTimers.ContainsKey(Context.ConnectionId))
            {
                var timer = new Timer(SendTickUpdate, Context.ConnectionId, TickRate, TickRate);
                PlayerTimers[Context.ConnectionId] = timer;
            }
            
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            if (PlayerTimers.TryGetValue(Context.ConnectionId, out var timer))
            {
                await timer.DisposeAsync();
                PlayerTimers.Remove(Context.ConnectionId);
            }

            await base.OnDisconnectedAsync(exception);
        }

        private async void SendTickUpdate(object? state)
        {
            var connectionId = (string)state!;
            await Clients.Client(connectionId).SendAsync("ReceiveTickUpdate", "Tick message sent at " + DateTime.Now);
        }

        public async Task UpdateResource(Resource resource, int amount)
        {
            await Clients.All.SendAsync("ReceiveResourceUpdate", resource, amount);
        }

        public async Task TaskComplete(string taskId)
        {
            await Clients.All.SendAsync("ReceiveTaskComplete", taskId);
        }
    }
}