using TheGame.Core.Shared.Enums;

namespace TheGame.Core.Entities;

public class Player
{
    public long Id { get; set; }
    public string Username { get; set; }
    public PlayerType Type { get; set; }
    public DateTime CreatedAt { get; set; }

    public ICollection<PlayerAlliance> Alliances { get; set; }
    public ICollection<PlayerFaction> Factions { get; set; }
    public ICollection<TradePartner> TradePartners { get; set; }
    public ICollection<PlayerPlanet> Planets { get; set; }
    public ICollection<PlayerFleet> Fleets { get; set; }
    public ICollection<PlayerResearch> Researches { get; set; }
    public ICollection<PlayerPlanet> Commanders { get; set; }
}