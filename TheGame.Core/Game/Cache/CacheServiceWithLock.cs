using System.Collections.Concurrent;
using EFCore.BulkExtensions;
using TheGame.Core.Game.Cache.Interfaces;
using TheGame.Core.Game.Data;

namespace TheGame.Core.Game.Cache;

public class CacheServiceWithLock<T> : ICacheServiceWithLock<T>, ICacheServiceWithLock where T : class
{
    public static class CacheServiceWithLockRegistry
    {
        public static readonly HashSet<ICacheServiceWithLock> CacheServices = new();
    }
    
    private readonly ConcurrentDictionary<Guid, CacheItem> _cache = new();

    public CacheServiceWithLock()
    {
        CacheServiceWithLockRegistry.CacheServices.Add(this);
    }

    private class CacheItem(T value)
    {
        public T Value { get; } = value;
        public ReaderWriterLockSlim LockSlim { get; } = new();
        public Queue<TaskCompletionSource<T>> TaskQueue { get; } = new();
    }

    public async Task Set(Guid key, T value)
    {
        if (value == null)
        {
            throw new ArgumentNullException($"Key:{key} Value:{nameof(value)} cannot be null");
        }

        var taskCompletionSource = new TaskCompletionSource<T>();

        var cacheItem = new CacheItem(value);
        
        EnqueueTask(cacheItem, taskCompletionSource, () => { taskCompletionSource.SetResult(value); });

        await taskCompletionSource.Task;
    }

    public async Task<T?> Get(Guid key)
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

    public T? FastGet(Guid key)
    {
        if(_cache.TryGetValue(key, out var cacheItem))
        {
            return cacheItem.Value;
        }

        return null;
    }

    public void Remove(Guid key)
    {
        if (_cache.TryRemove(key, out var cacheItem))
        {
            CancelQueuedTasks(cacheItem);
        }
    }

    public async Task<IEnumerable<T>> GetAll()
    {
        return await Task.FromResult(_cache.Values.Select(cacheItem => cacheItem.Value));
    }

    public async Task SaveSnapshotAsync(MainDataContext dbContext)
    {
        var items = _cache.Values.Select(c => c.Value).ToHashSet();
        if (items.Any())
        {
            await dbContext.BulkInsertAsync(items);
        }
    }

    private void EnqueueTask(CacheItem cacheItem, TaskCompletionSource<T> taskCompletionSource, Action action)
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

    private void CancelQueuedTasks(CacheItem cacheItem)
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