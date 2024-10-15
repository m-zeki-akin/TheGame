using System.Collections.Concurrent;
using EFCore.BulkExtensions;
using TheGame.Core.Game.Cache.Interfaces;
using TheGame.Core.Game.Data;

namespace TheGame.Core.Game.Cache;

public class CacheService<T> : ICacheService<T>, ICacheService where T : class
{
    private readonly ConcurrentDictionary<Guid, T> _cache = new();

    public CacheService()
    {
        CacheServiceRegistry.CacheServices.Add(this);
    }

    public void Set(Guid key, T value)
    {
        if (value == null)
        {
            throw new ArgumentNullException($"Key:{key} Value:{nameof(value)} cannot be null");
        }

        _cache.AddOrUpdate(key, value, (_, _) => value);
        
    }

    public T Get(Guid key)
    {
        if (_cache.TryGetValue(key, out var cacheItem))
        {
            return cacheItem;
        }

        throw new KeyNotFoundException($"{nameof(T)} cached item with ID:\"{key}\" not found");
    }

    public void Remove(Guid key)
    {
        _cache.TryRemove(key, out _);
    }

    public IEnumerable<T> GetAll()
    {
        return _cache.Values;
    }

    public async Task SaveSnapshotAsync(MainDataContext dbContext)
    {
        var items = _cache.Values.ToHashSet();
        if (items.Any())
        {
            await dbContext.BulkInsertAsync(items);
        }
    }
}