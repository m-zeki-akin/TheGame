using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using TheGame.Core.Game.Services;

namespace TheGame.Core.Game.Hosts;

public class SnapshotServiceHost(IServiceScopeFactory serviceScopeFactory) : BackgroundService
{
    private const string ClassName = nameof(SnapshotServiceHost);
    private static readonly TimeSpan SnapshotInterval = TimeSpan.FromMinutes(10);
    private static readonly TimeSpan DailySnapshotInterval = TimeSpan.FromDays(1);


    protected override async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        Log.Information("{Name} is running. {Date}", ClassName, DateTime.UtcNow);
        await DoWorkAsync(cancellationToken);
    }

    private async Task DoWorkAsync(CancellationToken cancellationToken)
    {
        Log.Information("{Name} is working. {Date}", ClassName, DateTime.UtcNow);

        using (IServiceScope scope = serviceScopeFactory.CreateScope())
        {
            ISnapshotService snapshotService = scope.ServiceProvider.GetRequiredService<ISnapshotService>();

            await Task.Run(async () =>
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    await Task.WhenAll(
                        snapshotService.SaveSnapshotAsync(),
                        Task.Run(() => Log.Information("{Name} executing 10-minute snapshot. {Date}",
                            ClassName, DateTime.UtcNow), cancellationToken),
                        Task.Delay(SnapshotInterval, cancellationToken)
                    );
                }
            }, cancellationToken);

            await Task.Run(async () =>
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    await Task.WhenAll(
                        snapshotService.SaveSnapshotAsync(),
                        Task.Run(() => Log.Information("{Name} executing daily snapshot. {Date}",
                            ClassName, DateTime.UtcNow), cancellationToken),
                        Task.Delay(DailySnapshotInterval, cancellationToken)
                    );
                }
            }, cancellationToken);
        }
    }

    public override async Task StopAsync(CancellationToken cancellationToken)
    {
        Log.Information("{Name} is stopping. {Date}", ClassName, DateTime.UtcNow);
        await base.StopAsync(cancellationToken);
    }
}