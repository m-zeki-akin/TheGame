using MediatR;

namespace TheGame.Core.Events;

public class DefenceStructCreatedEvent : INotification
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string PlanetName { get; set; }
    public string? StationName { get; set; }
    public DateTime CreatedAt { get; set; }
    public long PlayerId { get; set; }

    public DefenceStructCreatedEvent(long id, string name, string planetName, string? stationName, DateTime createdAt,
        long playerId)
    {
        Id = id;
        Name = name;
        PlanetName = planetName;
        StationName = stationName;
        CreatedAt = createdAt;
        PlayerId = playerId;
    }
}