using TheGame.Core.Game.Services.Interface;

namespace TheGame.Core.Game.Services;

public class PlayerProcessService : IPlayerProcessService
{
    public async Task Process()
    {
        await Task.CompletedTask;
    }
}