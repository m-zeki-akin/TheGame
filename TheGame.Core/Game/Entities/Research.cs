using TheGame.Core.Game.Shared.Enums;

namespace TheGame.Core.Game.Entities;

public class Research
{
    public long Id { get; set; }
    public string Name { get; set; }
    public int Level { get; set; }
    public ResearchType Type { get; set; }
    public int Cost { get; set; }
}