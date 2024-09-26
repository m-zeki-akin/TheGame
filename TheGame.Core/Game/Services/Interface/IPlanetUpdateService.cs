namespace TheGame.Core.Game.Services.Interface;

public interface IPlanetUpdateService
{
    Task UpdatePlanets(CancellationToken cancellationToken);
}