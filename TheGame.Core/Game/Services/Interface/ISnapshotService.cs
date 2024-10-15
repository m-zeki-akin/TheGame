namespace TheGame.Core.Game.Services.Interface;

public interface ISnapshotService
{
    public Task SaveSnapshotAsync();
    
    public Task WaitForSnapshotToCompleteAsync();
    
}