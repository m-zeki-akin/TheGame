using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TheGame.Core.Services.Interface;

namespace TheGame.Core.Services;

public class GameUpdateService : BackgroundService
{
    private readonly ILogger<FleetUpdateService> _logger;
    private readonly TimeSpan _updateInterval = TimeSpan.FromSeconds(1);
    private readonly IPlanetUpdateService _planetUpdateService;
    private readonly IFleetUpdateService _fleetUpdateService;
    private readonly CancellationTokenSource _shutdownTokenSource;

    public GameUpdateService(
        ILogger<FleetUpdateService> logger,
        IPlanetUpdateService planetUpdateService,
        IFleetUpdateService fleetUpdateService, 
        CancellationTokenSource shutdownTokenSource)
    {
        _logger = logger;
        _planetUpdateService = planetUpdateService;
        _fleetUpdateService = fleetUpdateService;
        _shutdownTokenSource = shutdownTokenSource;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            var updatePlanetsTask = _planetUpdateService.UpdatePlanets(stoppingToken);
            var updateFleetsTask = _fleetUpdateService.UpdateFleets(stoppingToken);
            
            await Task.WhenAll(Task.Delay(_updateInterval, stoppingToken), updatePlanetsTask, updateFleetsTask);
        }
    }
    
    public async Task CancelAsync()
    {
        await _shutdownTokenSource.CancelAsync();
    }
}