using TheGame.Core.Game.Shared.Enums;

namespace TheGame.Core.Game.Entities;

public class Skill
{
    public long Id { get; set; }
    public string Name { get; set; }
    public SkillType SkillType { get; set; }
}