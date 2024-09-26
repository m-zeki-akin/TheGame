using EFCore.BulkExtensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using TheGame.Core.Game.Cache;
using TheGame.Core.Game.Data;
using TheGame.Core.Game.Entities;

namespace TheGame.Core.Game.Services;

public class SnapshotService : BackgroundService
{
    private readonly MainDataContext _dbContext;
    private readonly ICacheService<Fleet> _fleetCache;
    private readonly ICacheService<Planet> _planetCache;
    private readonly CancellationTokenSource _shutdownTokenSource;

    public SnapshotService(ICacheService<Planet> planetCache, ICacheService<Fleet> fleetCache,
        MainDataContext dbContext)
    {
        _planetCache = planetCache;
        _fleetCache = fleetCache;
        _dbContext = dbContext;
        _shutdownTokenSource = new CancellationTokenSource();
    }

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
        _ = Task.WhenAll(
            _dbContext.BulkInsertAsync(_planetCache.GetAll().Result),
            _dbContext.BulkInsertAsync(_fleetCache.GetAll().Result)
        );

        await _dbContext.SaveChangesAsync();
    }

    public async Task CancelAsync()
    {
        await _shutdownTokenSource.CancelAsync();
    }
}