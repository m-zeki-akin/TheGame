using Microsoft.EntityFrameworkCore;
using TheGame.Core.Entities;
using TheGame.Core.Entities.Buildings;
using TheGame.Core.Entities.Requirement;
using TheGame.Core.Entities.SpaceObjects;
using TheGame.Core.Entities.SpaceObjects.Components;

namespace TheGame.Core.Data;

public class StaticDataContext : DbContext
{
    public StaticDataContext(DbContextOptions<StaticDataContext> options) : base(options)
    {
    }
    
    
    public DbSet<Research> Researches { get; set; }
    public DbSet<ResourceCost> ResourceCosts { get; set; }
    public DbSet<Skill> Skills { get; set; }
    public DbSet<Trait> Traits { get; set; }
    public DbSet<Faction> Factions { get; set; }
    public DbSet<Alliance> Alliances { get; set; }
    
    public DbSet<BuildingRequirement> BuildingRequirements { get; set; }
    public DbSet<ResourceBuilding> ResourceBuildings { get; set; }
    public DbSet<ResearchBuilding> ResearchBuildings { get; set; }
    public DbSet<SpaceObjectBuilding> FortificationsBuildings { get; set; }
    public DbSet<SpaceObjectBuilding> ShipyardBuildings { get; set; }
    public DbSet<SpaceObjectBuilding> StarsmithBuildings { get; set; }

    public DbSet<ArmourComponent> ArmourComponents { get; set; }
    public DbSet<AuxiliaryComponent> AuxiliaryComponents { get; set; }
    public DbSet<EngineComponent> EngineComponents { get; set; }
    public DbSet<PowerGeneratorComponent> PowerGeneratorComponents { get; set; }
    public DbSet<ProjectileComponent> ProjectileComponents { get; set; }
    public DbSet<ShieldComponent> ShieldComponents { get; set; }
    public DbSet<StorageComponent> StorageComponents { get; set; }
    public DbSet<SupportComponent> SupportComponents { get; set; }
    public DbSet<WeaponComponent> WeaponComponents { get; set; }
    
    public DbSet<DefencePlatform> DefencePlatforms { get; set; }
    public DbSet<Spacecraft> Spacecrafts { get; set; }
    public DbSet<Spacehold> Spaceholds { get; set; }
}