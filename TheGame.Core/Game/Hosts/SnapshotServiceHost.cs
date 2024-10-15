using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using TheGame.Core.Game.Services;
using TheGame.Core.Game.Services.Interface;

namespace TheGame.Core.Game.Hosts;

public class SnapshotServiceHost(ISnapshotService snapshotService) : BackgroundService
{
    private static readonly TimeSpan SnapshotInterval = TimeSpan.FromMinutes(10);
    private static readonly TimeSpan DailySnapshotInterval = TimeSpan.FromDays(1);

    protected override async Task ExecuteAsync(CancellationToken ct)
    {
        Log.Information("Snapshot Service is starting. {Date}", DateTime.UtcNow);

        _ = Task.Run(() => ExecuteSnapshotAsync(SnapshotInterval, "10-minute", ct), ct);

        _ = Task.Run(() => ExecuteSnapshotAsync(DailySnapshotInterval, "daily", ct), ct);

        await Task.CompletedTask;
    }

    private async Task ExecuteSnapshotAsync(TimeSpan interval, string snapshotType, CancellationToken ct)
    {
        while (!ct.IsCancellationRequested)
        {
            var saveSnapshotTask = snapshotService.SaveSnapshotAsync();
            var logTask = Task.Run(() =>
                Log.Information("Snapshot Service executing {SnapshotType} snapshot. {Date}",
                    snapshotType, DateTime.UtcNow), ct);
            var delayTask = Task.Delay(interval, ct);

            await Task.WhenAll(saveSnapshotTask, logTask, delayTask);
        }
    }

    public override async Task StopAsync(CancellationToken ct)
    {
        Log.Information("Snapshot Service is stopping. {Date}", DateTime.UtcNow);
        await base.StopAsync(ct);
    }
}