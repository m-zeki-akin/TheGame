using TheGame.Core.Shared.Enums;

namespace TheGame.Core.Entities;

public class Spacecraft : ArtificialSpaceObject
{
    public SpacecraftType Type { get; set; }
    public SpacecraftClass Class { get; set; }
    
    public long PowerGeneratorId { get; set; }
    public PowerGenerator PowerGenerator { get; set; }
    public long EngineId { get; set; }
    public Engine Engine { get; set; }
    public int Mass { get; set; }
    public int Storage { get; set; }
    public int DisengageChance { get; set; }
    public int ScreenPower { get; set; }
    public int CommandPower { get; set; }
    
    public ICollection<ArtificialSpaceObjectWeapon> Weapons { get; set; }
    public ICollection<ArtificialSpaceObjectAuxiliaryAddon> Auxiliaries { get; set; }
}