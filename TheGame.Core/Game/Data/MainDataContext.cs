using Microsoft.EntityFrameworkCore;
using TheGame.Core.Game.Entities;
using TheGame.Core.Game.Entities.Buildings.Buildings;

namespace TheGame.Core.Game.Data;

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
    public DbSet<Empire> Players { get; set; }
    public DbSet<EmpireAlliance> PlayerAlliances { get; set; }
    public DbSet<EmpireCommander> PlayerCommanders { get; set; }
    public DbSet<EmpireFaction> PlayerFactions { get; set; }
    public DbSet<EmpireFleet> PlayerFleets { get; set; }
    public DbSet<EmpirePlanet> PlayerPlanets { get; set; }
    public DbSet<EmpireResearch> PlayerResearches { get; set; }
    public DbSet<TradePartner> TradePartners { get; set; }
    public DbSet<BuildingProductionItem> BuildingProductionItems { get; set; }
    public DbSet<SpaceObjectProductionItem> SpaceObjectProductionItems { get; set; }
    /*
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
     */
}