namespace TheGame.Core.Game.Services.Interface;

public class PlayerUpdateService : IPlayerUpdateService
{
    public async Task UpdateAsync(CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
    }
}