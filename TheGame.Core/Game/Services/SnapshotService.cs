using Microsoft.Extensions.Hosting;
using Serilog;
using TheGame.Core.Game.Cache;
using TheGame.Core.Game.Data;

namespace TheGame.Core.Game.Services;

public class SnapshotService(MainDataContext dbContext) : BackgroundService
{
    private readonly CancellationTokenSource _shutdownTokenSource = new();

    protected override async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        Log.Information("Starting snapshot service.");

        var cct = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, _shutdownTokenSource.Token).Token;

        _ = Task.Run(() =>
        {
            while (!cct.IsCancellationRequested)
            {
                _ = Task.WhenAll(
                    SaveSnapshotAsync(),
                    Task.Run(() => Log.Information("Executing 10-minute snapshot."), cct),
                    Task.Delay(TimeSpan.FromMinutes(10), cct)
                );
            }
        }, cct);

        _ = Task.Run(() =>
        {
            while (!cct.IsCancellationRequested)
            {
                _ = Task.WhenAll(
                    SaveSnapshotAsync(),
                    Task.Run(() => Log.Information("Executing daily snapshot."), cct),
                    Task.Delay(TimeSpan.FromDays(1), cct)
                );
            }
        }, cct);
    }

    private async Task SaveSnapshotAsync()
    {
        var saveTasks = new HashSet<Task>(CacheServiceRegistry.CacheServices.Count);
        foreach (var cacheService in CacheServiceRegistry.CacheServices)
        {
            saveTasks.Add(cacheService.SaveSnapshotAsync(dbContext));
        }

        await Task.WhenAll(saveTasks);

        await dbContext.SaveChangesAsync(); // Commit changes to the database
    }

    public async Task CancelAsync()
    {
        await _shutdownTokenSource.CancelAsync();
    }
}