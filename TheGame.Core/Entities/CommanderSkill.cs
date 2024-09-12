using TheGame.Core.Shared.Enums;

namespace TheGame.Core.Entities;

public class CommanderSkill
{
    public long CommanderId { get; set; }
    public Commander Commander { get; set; }

    public long SkillId { get; set; }
    public Skill Skill { get; set; }

    public int Value { get; set; }
}