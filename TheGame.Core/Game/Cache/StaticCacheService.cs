using System.Collections.Concurrent;
using EFCore.BulkExtensions;
using TheGame.Core.Game.Data;
using TheGame.Core.Game.Entities.Abstract;
using TheGame.Core.Game.Entities.Buildings;

namespace TheGame.Core.Game.Cache;

public class StaticCacheService<T> : IStaticCacheService<T> where T : StaticEntity
{
    private readonly ConcurrentDictionary<Guid, T> _cache = new();

    public async Task SetAll(HashSet<T> values)
    {
        foreach (var value in values)
        {
            _cache.TryAdd(value.Id, value);
        }

        await Task.CompletedTask;
    }

    public T? Get(Guid key)
    {
        _cache.TryGetValue(key, out var cacheItem);

        return cacheItem;
    }

    public IEnumerable<T> GetAll()
    {
        return _cache.Values.ToHashSet();
    }

}