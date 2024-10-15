using TheGame.Core.Game.Data;

namespace TheGame.Core.Game.Cache.Interfaces;

public interface ICacheService<T>
{
    void Set(Guid key, T value);
    T Get(Guid key);
    IEnumerable<T> GetAll();
    void Remove(Guid key);
}

public interface ICacheService
{
    Task SaveSnapshotAsync(MainDataContext dbContext);
}