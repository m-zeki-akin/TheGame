using TheGame.Core.Shared.Enums;

namespace TheGame.Core.Entities.Templates;

public class SpacecraftTemplate : ArtificialSpaceObjectTemplate
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
    
    public ICollection<ArtificialSpaceObjectWeapon> Weapons { get; set; }
    public ICollection<ArtificialSpaceObjectAuxiliaryAddon> Auxiliaries { get; set; }
}