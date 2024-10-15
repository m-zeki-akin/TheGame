using TheGame.Core.Game.Entities.Empires;
using TheGame.Core.Game.Entities.Fleets;
using TheGame.Core.Game.Entities.StellarObjects;

namespace TheGame.Core.Game.Entities;

public class Commander : DynamicEntity
{
    public string Name { get; set; }
    public bool IsActive { get; set; }

    public Guid? FleetId { get; set; }
    public Fleet? Fleet { get; set; }
    public Guid? PlanetId { get; set; }
    public Planet? Planet { get; set; }
    public Guid OwnerId { get; set; }
    public Empire Owner { get; set; }

    public int CommandSkill { get; set; }
    public int AttackSkill { get; set; }
    public int DefenceSkill { get; set; }
    public int ManeuverSkill { get; set; }
    public int LuckSkill { get; set; }

    public ICollection<CommanderTrait>? Traits { get; set; }
}