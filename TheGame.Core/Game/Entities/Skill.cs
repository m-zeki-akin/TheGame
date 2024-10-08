using TheGame.Core.Game.Entities.Abstract;
using TheGame.Core.Game.Shared.Enums;

namespace TheGame.Core.Game.Entities;

public class Skill : StaticEntity
{
    public string Name { get; set; }
    public SkillType SkillType { get; set; }
}