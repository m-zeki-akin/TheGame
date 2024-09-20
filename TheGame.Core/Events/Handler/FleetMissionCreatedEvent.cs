using MediatR;
using TheGame.Core.Cache;
using TheGame.Core.Entities;
using TheGame.Core.Shared;
using TheGame.Core.Shared.ValueObjects;

namespace TheGame.Core.Events.Handler;

public class FleetMissionCreatedEventHandler(
    GameCache<Fleet> fleetCache,
    GameRules gameRules
)
    : INotificationHandler<FleetMissionCreatedEvent>
{
    public Task Handle(FleetMissionCreatedEvent notification, CancellationToken cancellationToken)
    {
        Fleet fleet = fleetCache.Get(notification.FleetId)!;

        var fleetMissions = fleet.FleetMission.ToArray();
        for (int i = 0; i < fleetMissions.Length; i++)
        {
            var previousLocation = (i == 0) 
                ? fleet.Location 
                : fleetMissions[i - 1].Destination;
    
            var currentDestination = fleetMissions[i].Destination;

            if (previousLocation.SolarSystem.Id == currentDestination.SolarSystem.Id)
            {
                var directionVector = new Vector2D(
                    currentDestination.Coordinates.X - previousLocation.Coordinates.X,
                    currentDestination.Coordinates.Y - previousLocation.Coordinates.Y);
                
                fleetMissions[i].Distance = (long)(directionVector.Magnitude * gameRules.InterSpaceDistanceFactor);
                fleetMissions[i].Destination = fleetMissions[i].Distance * gameRules.InterSpaceFuelCostFactor.Fuel;
                fleetMissions[i].Actinium = fleetMissions[i].Distance * gameRules.InterSpaceActiniumCostFactor.Actinium;
            }
            else
            {
                var directionVector = new Vector2D(
                    currentDestination.SolarSystem.Coordinates.X - previousLocation.SolarSystem.Coordinates.X,
                    currentDestination.SolarSystem.Coordinates.Y - previousLocation.SolarSystem.Coordinates.Y);
                
                fleetMissions[i].Distance = (long)(directionVector.Magnitude * gameRules.OuterSpaceDistanceFactor);
                fleetMissions[i].Fuel = fleetMissions[i].Distance * gameRules.InterSpaceFuelCostFactor.Fuel;
                fleetMissions[i].Actinium = fleetMissions[i].Distance * gameRules.InterSpaceActiniumCostFactor.Actinium;
            }
        }

        return Task.CompletedTask;
    }
}