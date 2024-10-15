using Force.DeepCloner;
using Microsoft.Extensions.Hosting;
using Serilog;
using TheGame.Core.Game.Cache;
using TheGame.Core.Game.Data;
using TheGame.Core.Game.Services.Interface;

namespace TheGame.Core.Game.Services;

public class SnapshotService(MainDataContext dbContext) : ISnapshotService
{
    private static readonly SemaphoreSlim SnapshotLock = new(2, 2);
    
    public async Task SaveSnapshotAsync()
    {
        await SnapshotLock.WaitAsync();
        try
        {
            await Parallel.ForEachAsync(CacheServiceRegistry.CacheServices, async (cacheService, f) =>
            {
                await cacheService.SaveSnapshotAsync(dbContext);
                Log.Information("Saved snapshot to {CacheService}", cacheService.GetType().Name);
            });
        }
        finally
        {
            SnapshotLock.Release();
        }
        
        await dbContext.SaveChangesAsync();
    }
    
    public async Task WaitForSnapshotToCompleteAsync()
    {
        if (SnapshotLock.CurrentCount > 0)
        {
            return;
        }
        await SnapshotLock.WaitAsync();
        SnapshotLock.Release();
    }
}