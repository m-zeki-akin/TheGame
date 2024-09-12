using MediatR;

namespace TheGame.Core.Events;

public class SpaceholdCreatedEvent : INotification
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string PlanetName { get; set; }
    public DateTime CreatedAt { get; set; }
    public long PlayerId { get; set; }

    public SpaceholdCreatedEvent(long id, string name, string planetName, DateTime createdAt, long playerId)
    {
        Id = id;
        Name = name;
        PlanetName = planetName;
        CreatedAt = createdAt;
        PlayerId = playerId;
    }
}