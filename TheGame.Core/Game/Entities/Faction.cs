namespace TheGame.Core.Game.Entities;

public class Faction
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public ICollection<Empire> Players { get; set; }
}