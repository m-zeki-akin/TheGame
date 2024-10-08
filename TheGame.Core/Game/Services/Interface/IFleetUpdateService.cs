namespace TheGame.Core.Game.Services.Interface;

public interface IFleetUpdateService
{
    Task UpdateAsync(CancellationToken cancellationToken);
}