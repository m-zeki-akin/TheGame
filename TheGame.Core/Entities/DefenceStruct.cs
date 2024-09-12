using TheGame.Core.Shared.Enums;
using TheGame.Core.Shared.ValueObjects;

namespace TheGame.Core.Entities;

public class DefenceStruct : ArtificialSpaceObject
{
    public int DefencePower { get; set; }
    public int DefencePoint { get; set; }
    public int Power { get; set; }
    public DefenceType DefenceType { get; set; }

    public long LocationId { get; set; }
    public Location Location { get; set; }
    
    public ICollection<ArtificialSpaceObjectWeapon> Weapons { get; set; }
}