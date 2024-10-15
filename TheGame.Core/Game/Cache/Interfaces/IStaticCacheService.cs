namespace TheGame.Core.Game.Cache.Interfaces;

public interface IStaticCacheService<T>
{
    Task SetAll(HashSet<T> values);
    T? Get(Guid key);
    IEnumerable<T> GetAll();
}