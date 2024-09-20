using Microsoft.EntityFrameworkCore;
using TheGame.Core.Entities;
using TheGame.Core.Entities.Buildings.ProductionQueue;

namespace TheGame.Core.Data;

public class MainDataContext : DbContext
{
    public MainDataContext(DbContextOptions<MainDataContext> options) : base(options)
    {
    }

    public DbSet<Commander> Commanders { get; set; }
    public DbSet<CommanderTrait> CommanderTraits { get; set; }
    public DbSet<Fleet> Fleets { get; set; }
    public DbSet<FleetSpacecraftGroup> FleetSpacecraftGroups { get; set; }
    public DbSet<Planet> Planets { get; set; }
    public DbSet<PlanetResearch> PlanetResearches { get; set; }
    public DbSet<PlanetBuilding> PlanetBuildings { get; set; }
    public DbSet<Player> Players { get; set; }
    public DbSet<PlayerAlliance> PlayerAlliances { get; set; }
    public DbSet<PlayerCommander> PlayerCommanders { get; set; }
    public DbSet<PlayerFaction> PlayerFactions { get; set; }
    public DbSet<PlayerFleet> PlayerFleets { get; set; }
    public DbSet<PlayerPlanet> PlayerPlanets { get; set; }
    public DbSet<PlayerResearch> PlayerResearches { get; set; }
    public DbSet<TradePartner> TradePartners { get; set; }
    public DbSet<PlanetBuildingConstructionItem> PlanetBuildingConstructionItems { get; set; }
    public DbSet<PlanetBuildingSpaceObjectItem> PlanetBuildingSpaceObjectItems { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Planet>()
            .OwnsOne(p => p.StoredResources, sr =>
            {
                sr.Property(r => r.Fuel).HasColumnName("Fuel");
                sr.Property(r => r.Material).HasColumnName("Material");
                sr.Property(r => r.Energy).HasColumnName("Energy");
                sr.Property(r => r.Alloy).HasColumnName("Alloy");
                sr.Property(r => r.Polonium).HasColumnName("Polonium");
                sr.Property(r => r.Technetium).HasColumnName("Technetium");
                sr.Property(r => r.Actinium).HasColumnName("Actinium");
                sr.Property(r => r.Plutonium).HasColumnName("Plutonium");
            });

        base.OnModelCreating(modelBuilder);
    }
}