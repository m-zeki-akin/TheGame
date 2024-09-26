using System.Collections.Concurrent;
using EFCore.BulkExtensions;
using TheGame.Core.Game.Data;

namespace TheGame.Core.Game.Cache;

public class CacheService<T> : ICacheService<T>, ICacheService where T : class
{
    private readonly ConcurrentDictionary<long, CacheItem<T>> _cache = new();

    public Task Set(long key, T value)
    {
        if (value == null)
        {
            throw new ArgumentNullException($"Key:{key} Value:{nameof(value)} cannot be null");
        }

        var taskCompletionSource = new TaskCompletionSource<T>();

        var cacheItem = new CacheItem<T>(value);

        EnqueueTask(cacheItem, taskCompletionSource, () => { taskCompletionSource.SetResult(value); });

        return Task.CompletedTask;
    }

    public async Task<T> Get(long key)
    {
        var taskCompletionSource = new TaskCompletionSource<T>();

        if (_cache.TryGetValue(key, out var cacheItem))
        {
            EnqueueTask(cacheItem, taskCompletionSource, () => { taskCompletionSource.SetResult(cacheItem.Value); });
        }
        else
        {
            taskCompletionSource.SetResult(default!);
        }

        return await taskCompletionSource.Task;
    }

    public Task Remove(long key)
    {
        if (_cache.TryRemove(key, out var cacheItem))
        {
            CancelQueuedTasks(cacheItem);
        }

        return Task.CompletedTask;
    }

    public Task<IEnumerable<T>> GetAll()
    {
        return Task.FromResult(_cache.Values.Select(cacheItem => cacheItem.Value));
    }
    
    async Task ICacheService.SaveSnapshotAsync(MainDataContext dbContext)
    {
        var items = _cache.Values.Select(c => c.Value).ToHashSet();
        if (items.Any())
        {
            await dbContext.BulkInsertAsync(items);
        }
    }

    private void EnqueueTask(CacheItem<T> cacheItem, TaskCompletionSource<T> taskCompletionSource, Action action)
    {
        cacheItem.TaskQueue.Enqueue(taskCompletionSource);

        if (cacheItem.TaskQueue.Count == 1)
        {
            cacheItem.LockSlim.EnterWriteLock();
            try
            {
                action();
            }
            finally
            {
                cacheItem.LockSlim.ExitWriteLock();
                cacheItem.TaskQueue.Dequeue();

                if (cacheItem.TaskQueue.Count > 0)
                {
                    var nextTask = cacheItem.TaskQueue.Peek();
                    nextTask.SetResult(cacheItem.Value);
                }
            }
        }
    }

    private void CancelQueuedTasks(CacheItem<T> cacheItem)
    {
        cacheItem.LockSlim.EnterWriteLock();
        try
        {
            while (cacheItem.TaskQueue.Count > 0)
            {
                var taskToCancel = cacheItem.TaskQueue.Dequeue();
                taskToCancel.SetResult(default!);
            }
        }
        finally
        {
            cacheItem.LockSlim.ExitWriteLock();
        }
    }
}