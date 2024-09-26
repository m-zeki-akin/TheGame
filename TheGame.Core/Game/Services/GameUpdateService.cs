using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TheGame.Core.Game.Services.Interface;

namespace TheGame.Core.Game.Services;

public class GameUpdateService : BackgroundService
{
    private readonly IFleetUpdateService _fleetUpdateService;
    private readonly IPlanetUpdateService _planetUpdateService;
    private readonly TimeSpan _updateInterval = TimeSpan.FromSeconds(1);

    public GameUpdateService(
        IPlanetUpdateService planetUpdateService,
        IFleetUpdateService fleetUpdateService)
    {
        _planetUpdateService = planetUpdateService;
        _fleetUpdateService = fleetUpdateService;
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

}