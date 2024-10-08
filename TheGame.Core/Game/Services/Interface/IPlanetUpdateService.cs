namespace TheGame.Core.Game.Services.Interface;

public interface IPlanetUpdateService
{
    Task UpdateAsync(CancellationToken cancellationToken);
}