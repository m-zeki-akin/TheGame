using System.Collections.Concurrent;

namespace TheGame.Core.Game.Cache;

public interface IStaticCacheService<T>
{
    Task SetAll(HashSet<T> values);
    T? Get(Guid key);
    IEnumerable<T> GetAll();
}