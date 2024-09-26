namespace TheGame.Core.Game.Entities;

public class Commander
{
    public long Id { get; set; }
    public string Name { get; set; }
    public bool IsActive { get; set; }

    public long? FleetId { get; set; }
    public Fleet? Fleet { get; set; }
    public long? PlanetId { get; set; }
    public Planet? Planet { get; set; }
    public long OwnerId { get; set; }
    public Player Owner { get; set; }

    public int CommandSkill { get; set; }
    public int AttackSkill { get; set; }
    public int DefenceSkill { get; set; }
    public int ManeuverSkill { get; set; }
    public int LuckSkill { get; set; }

    public ICollection<CommanderTrait>? Traits { get; set; }
}