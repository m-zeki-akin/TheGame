using System.Diagnostics;
using Microsoft.Extensions.Hosting;
using Serilog;
using TheGame.Core.Game.Services.Interface;
using TheGame.Core.Game.Shared;

namespace TheGame.Core.Game.Hosts;

public class GameUpdateServiceHost(
    IPlanetProcessService planetProcessService,
    IFleetProcessService fleetProcessService,
    IPlayerProcessService playerProcessService
) : BackgroundService
{
    private const string ClassName = nameof(SnapshotServiceHost);
    private static readonly TimeSpan UpdateInterval = TimeSpan.FromSeconds(GameRules.GameUpdateInterval);

    protected override async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        Log.Information("{Name} is running. {Date}", ClassName, DateTime.UtcNow);
        await DoWorkAsync(cancellationToken);
    }

    private async Task DoWorkAsync(CancellationToken ct)
    {
        Log.Information("{Name} is working. {Date}", ClassName, DateTime.UtcNow);

        while (!ct.IsCancellationRequested)
        {
            var stopwatch = Stopwatch.StartNew();

            await Parallel.ForEachAsync(new HashSet<Task>
                {
                    playerProcessService.Process(), planetProcessService.Process(), fleetProcessService.Process()
                }, new ParallelOptions
                {
                    MaxDegreeOfParallelism = 3, CancellationToken = ct
                },
                async (task, state) => { await task; }
            );

            stopwatch.Stop();

            if (stopwatch.Elapsed > UpdateInterval)
            {
                Log.Error(
                    "Game update took {ElapsedMilliseconds} ms, which is longer than the {IntervalMilliseconds} ms tick interval. Shutting down service.",
                    stopwatch.ElapsedMilliseconds, UpdateInterval.TotalMilliseconds);
                await StopAsync(ct);
            }
            else
            {
                await Task.Delay(UpdateInterval - stopwatch.Elapsed, ct);
            }
        }
    }

    public override async Task StopAsync(CancellationToken cancellationToken)
    {
        Log.Information("{Name} is stopping. {Date}", ClassName, DateTime.UtcNow);
        await base.StopAsync(cancellationToken);
    }
}