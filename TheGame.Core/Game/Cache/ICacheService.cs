namespace TheGame.Core.Game.Cache;

public interface ICacheService<T>
{
    Task Set(long key, T value);
    Task<T>? Get(long key);
    Task<IEnumerable<T>> GetAll();
    Task Remove(long key);
}