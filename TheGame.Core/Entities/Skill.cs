using TheGame.Core.Shared.Enums;

namespace TheGame.Core.Entities;

public class Skill
{
    public long Id { get; set; }
    public string Name { get; set; }
    public SkillType SkillType { get; set; }
}