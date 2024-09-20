using System.Collections.Concurrent;

namespace TheGame.Core.Cache;

public class GameCache<T>
{
    private readonly ConcurrentDictionary<long, T> _cache = new();

    public T? Get(long id)
    {
        return _cache.TryGetValue(id, out var value) ? value : default;
    }

    public void AddOrUpdate(long id, T entity)
    {
        _cache.AddOrUpdate(id, entity, (_, _) => entity);
    }

    public IEnumerable<T> GetAll() => _cache.Values;
    
    public void Remove(long id)
    {
        _cache.Remove(id, out _);
    } 

    public void Clear() => _cache.Clear();
}