namespace TheGame.Core.Game.Services.Interface;

public interface IFleetUpdateService
{
    Task UpdateFleets(CancellationToken cancellationToken);
}