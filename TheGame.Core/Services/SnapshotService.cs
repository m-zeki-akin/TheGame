using EFCore.BulkExtensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TheGame.Core.Cache;
using TheGame.Core.Data;
using TheGame.Core.Entities;

namespace TheGame.Core.Services;

public class SnapshotService : BackgroundService
{
    private readonly ILogger _logger;
    private readonly GameCache<Planet> _planetCache;
    private readonly GameCache<Fleet> _fleetCache;
    private readonly MainDataContext _dbContext;
    private readonly CancellationTokenSource _shutdownTokenSource;

    public SnapshotService(ILogger logger, GameCache<Planet> planetCache, GameCache<Fleet> fleetCache,
        MainDataContext dbContext)
    {
        _planetCache = planetCache;
        _fleetCache = fleetCache;
        _dbContext = dbContext;
        _logger = logger;
        _shutdownTokenSource = new CancellationTokenSource();
    }

    protected override async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Starting snapshot service.");

        var cct = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, _shutdownTokenSource.Token).Token;

        _ = Task.Run(() =>
        {
            while (!cct.IsCancellationRequested)
            {
                _ = Task.WhenAll(
                    SaveSnapshotAsync(),
                    Task.Run(() => _logger.LogInformation("Executing 10-minute snapshot."), cct),
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
                    Task.Run(() => _logger.LogInformation("Executing daily snapshot."), cct),
                    Task.Delay(TimeSpan.FromDays(1), cct)
                );
            }
        }, cct);

    }

    private async Task SaveSnapshotAsync()
    {
        _ = Task.WhenAll(
            _dbContext.BulkInsertAsync(_planetCache.GetAll()),
            _dbContext.BulkInsertAsync(_fleetCache.GetAll())
        );

        await _dbContext.SaveChangesAsync();
    }
    
    public async Task CancelAsync()
    {
        await _shutdownTokenSource.CancelAsync();
    }
}