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
    public DbSet<PlayerResearchItem> PlayerResearchItems { get; set; }
    public DbSet<TradePartner> TradePartners { get; set; }
    public DbSet<PlanetBuildingConstructionItem> PlanetBuildingConstructionItems { get; set; }
    public DbSet<PlanetBuildingDefencePlatformItem> PlanetBuildingDefencePlatformItems { get; set; }
    public DbSet<PlanetBuildingSpacecraftItem> PlanetBuildingSpacecraftItems { get; set; }
    public DbSet<PlanetBuildingSpaceholdItem> PlanetBuildingSpaceholdItems { get; set; }
}