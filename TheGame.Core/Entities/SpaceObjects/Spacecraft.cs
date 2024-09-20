using TheGame.Core.Entities.SpaceObjects.Components;
using TheGame.Core.Shared.Enums;

namespace TheGame.Core.Entities.SpaceObjects;

public class Spacecraft : SpaceObject
{
    public SpacecraftType Type { get; set; }
    public SpacecraftClass Class { get; set; }
    
    public long EngineId { get; set; }
    public EngineComponent EngineComponent { get; set; }
    public long StorageId { get; set; }
    public StorageComponent StorageComponent { get; set; }
    
    public int Mass { get; set; } // Should be stack with components
    public int DisengageChance { get; set; } // Should be stack with components
    public int ScreenPower { get; set; } // Should be stack with components
    public int CommandPower { get; set; } // Should be stack with components
    public int DetectionRange { get; set; } // Should be stack with components
    public int DetectionPower { get; set; } // Should be stack with components
    public ResourceValue FuelStorage { get; set; } // Should be stack with components
}