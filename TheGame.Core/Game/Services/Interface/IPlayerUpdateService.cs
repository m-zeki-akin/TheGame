namespace TheGame.Core.Game.Services.Interface;

public interface IPlayerUpdateService
{
    public Task UpdateAsync(CancellationToken cancellationToken);
}