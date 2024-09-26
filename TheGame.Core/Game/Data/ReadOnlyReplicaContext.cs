﻿using Microsoft.EntityFrameworkCore;
using TheGame.Core.Game.Entities;
using TheGame.Core.Game.Entities.Buildings.Buildings;

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
    public DbSet<Player> Players { get; set; }
    public DbSet<PlayerAlliance> PlayerAlliances { get; set; }
    public DbSet<PlayerCommander> PlayerCommanders { get; set; }
    public DbSet<PlayerFaction> PlayerFactions { get; set; }
    public DbSet<PlayerFleet> PlayerFleets { get; set; }
    public DbSet<PlayerPlanet> PlayerPlanets { get; set; }
    public DbSet<PlayerResearch> PlayerResearches { get; set; }
    public DbSet<TradePartner> TradePartners { get; set; }
    public DbSet<PlanetBuildingConstructionItem> PlanetBuildingConstructionItems { get; set; }
    public DbSet<PlanetBuildingSpaceObjectItem> PlanetBuildingDefencePlatformItems { get; set; }
    public DbSet<PlanetBuildingSpaceObjectItem> PlanetBuildingSpacecraftItems { get; set; }
    public DbSet<PlanetBuildingSpaceObjectItem> PlanetBuildingSpaceholdItems { get; set; }
}