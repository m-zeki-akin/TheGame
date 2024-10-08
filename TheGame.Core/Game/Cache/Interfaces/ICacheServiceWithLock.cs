using TheGame.Core.Game.Data;

namespace TheGame.Core.Game.Cache;

public interface ICacheServiceWithLock<T>
{
    Task Set(Guid key, T value);
    Task<T?> Get(Guid key);
    T? FastGet(Guid key);
    Task<IEnumerable<T>> GetAll();
    void Remove(Guid key);
}

public interface ICacheServiceWithLock
{
    Task SaveSnapshotAsync(MainDataContext dbContext);
}