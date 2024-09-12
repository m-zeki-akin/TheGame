using TheGame.Core.Shared.Enums;
using TheGame.Core.Shared.ValueObjects;

namespace TheGame.Core.Entities;

public abstract class ArtificialSpaceObject
{
    public long Id { get; set; }
    public string Name { get; set; }
    public ArtificialSpaceObjectType Type { get; set; }
    public ulong Quantity { get; set; }
    public int HitPoints { get; set; } // ortalama
    public int RepairRate { get; set; }
    
    public long ArmourId { get; set; }
    public Armour Armour { get; set; }
    public long ShieldId { get; set; }
    public Shield Shield { get; set; }

    public ICollection<ArtificialSpaceObjectCost> Cost { get; set; }
}