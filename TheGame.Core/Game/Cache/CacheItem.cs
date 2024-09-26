namespace TheGame.Core.Game.Cache;

public class CacheItem<T>(T value)
{
    public T Value { get; set; } = value;
    public ReaderWriterLockSlim LockSlim { get; } = new();
    public Queue<TaskCompletionSource<T>> TaskQueue { get; } = new();
}