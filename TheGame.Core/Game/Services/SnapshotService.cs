using Force.DeepCloner;
using Microsoft.Extensions.Hosting;
using Serilog;
using TheGame.Core.Game.Cache;
using TheGame.Core.Game.Data;

namespace TheGame.Core.Game.Services;

public class SnapshotService(MainDataContext dbContext) : ISnapshotService
{
    private static readonly SemaphoreSlim SnapshotLock = new(2, 2);
    
    public async Task SaveSnapshotAsync()
    {
        await SnapshotLock.WaitAsync();
        try
        {
            var tasks = new HashSet<Task>(CacheServiceRegistry.CacheServices.Count);
            foreach (var cacheService in CacheServiceRegistry.CacheServices)
            {
                tasks.Add(Task.Run(() => cacheService.SaveSnapshotAsync(dbContext)));
            }

            await Task.WhenAll(tasks);
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