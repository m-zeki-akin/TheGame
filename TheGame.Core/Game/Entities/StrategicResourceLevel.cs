using TheGame.Core.Game.Entities.Abstract;

namespace TheGame.Core.Game.Entities;

public class StrategicResourceLevel : StaticEntity
{
    public string Name { get; set; }
    public int Level { get; set; }
    public double Factor { get; set; }
}