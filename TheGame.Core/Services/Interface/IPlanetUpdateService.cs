namespace TheGame.Core.Services.Interface;

public interface IPlanetUpdateService
{
    Task UpdatePlanets(CancellationToken cancellationToken);
}