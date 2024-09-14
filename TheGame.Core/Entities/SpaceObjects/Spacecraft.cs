using TheGame.Core.Entities.SpaceObjects.Components;
using TheGame.Core.Shared.Enums;

namespace TheGame.Core.Entities.SpaceObjects;

public class Spacecraft
{
    public SpacecraftType Type { get; set; }
    public SpacecraftClass Class { get; set; }
    
    public long EngineId { get; set; }
    public EngineComponent EngineComponent { get; set; }
    public long StorageId { get; set; }
    public StorageComponent StorageComponent { get; set; }
    
    public int Mass { get; set; }
    public int DisengageChance { get; set; }
    public int ScreenPower { get; set; }
    public int CommandPower { get; set; }
    public int DetectionRange { get; set; }
    public int DetectionPower { get; set; }
}