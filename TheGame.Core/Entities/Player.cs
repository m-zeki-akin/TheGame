namespace TheGame.Core.Entities;

public class Player
{
    public Guid Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public DateTime CreatedAt { get; set; }

    //public ICollection<Alliance> Alliances { get; set; }
    //public ICollection<TradePartner> TradePartners { get; set; }
    //public ICollection<Planet> Planets { get; set; }
    public ICollection<Fleet> Fleets { get; set; }
    //public ICollection<Building> Buildings { get; set; }
    public ICollection<Resource> Resources { get; set; }
    //public ICollection<Research> Researches { get; set; }
    public ICollection<Commander> Commanders { get; set; }
}