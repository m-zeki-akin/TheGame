namespace TheGame.Core.Game.Cache;

public static class CacheServiceRegistry
{
    public static readonly HashSet<ICacheService> CacheServices = new();

    public static void RegisterCache<T>(CacheService<T> cacheService) where T : class
    {
        CacheServices.Add(cacheService);
    }
}