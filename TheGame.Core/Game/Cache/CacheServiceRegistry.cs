using TheGame.Core.Game.Cache.Interfaces;

namespace TheGame.Core.Game.Cache;

public static class CacheServiceRegistry
{
    public static readonly HashSet<ICacheService> CacheServices = new();
}