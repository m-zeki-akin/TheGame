using TheGame.Core.Game.Entities.Empires;

namespace TheGame.Core.Game.Entities;

public class Faction : DynamicEntity
{
    public string Name { get; set; }

    public ICollection<Empire> Players { get; set; }
}