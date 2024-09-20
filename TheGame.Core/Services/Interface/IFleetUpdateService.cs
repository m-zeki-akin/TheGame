namespace TheGame.Core.Services.Interface;

public interface IFleetUpdateService
{
    Task UpdateFleets(CancellationToken cancellationToken);
}