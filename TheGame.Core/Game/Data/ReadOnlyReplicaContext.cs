using Microsoft.EntityFrameworkCore;
using TheGame.Core.Game.Entities;
using TheGame.Core.Game.Entities.Empires;
using TheGame.Core.Game.Entities.Fleets;
using TheGame.Core.Game.Entities.Productions;
using TheGame.Core.Game.Entities.StellarObjects;

namespace TheGame.Core.Game.Data;

public class ReadOnlyReplicaContext : DbContext
{
    public ReadOnlyReplicaContext(DbContextOptions<ReadOnlyReplicaContext> options) : base(options)
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
    public DbSet<EmpireTrade> TradePartners { get; set; }
    public DbSet<BuildingProductionItem> BuildingProductionItems { get; set; }
    public DbSet<SpaceObjectProductionItem> DefencePlatformProductionItems { get; set; }
    public DbSet<SpaceObjectProductionItem> SpacecraftProductionItems { get; set; }
    public DbSet<SpaceObjectProductionItem> SpaceholdProductionItems { get; set; }
}