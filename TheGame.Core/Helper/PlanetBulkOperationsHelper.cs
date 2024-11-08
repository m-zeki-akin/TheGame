﻿using EFCore.BulkExtensions;
using TheGame.Core.Game.Data;
using TheGame.Core.Game.Entities;
using TheGame.Core.Game.Entities.Productions;
using TheGame.Core.Game.Entities.StellarObjects;
using TheGame.Core.Game.Shared.ValueObjects;

namespace TheGame.Core.Helper;

public class PlanetBulkOperationsHelper
{
    public List<PlanetBuilding> PlanetBuildingsToAdd { get; } = new();
    public List<PlanetBuilding> PlanetBuildingsToRemove { get; } = new();
    public List<PlanetBuilding> PlanetBuildingsToUpdate { get; } = new();
    public List<BuildingProductionItem> ConstructionItemsToAdd { get; } = new();
    public List<BuildingProductionItem> ConstructionItemsToRemove { get; } = new();
    public List<BuildingProductionItem> ConstructionItemsToUpdate { get; } = new();
    public List<SpaceObjectProductionItem> SpaceObjectItemsToAdd { get; } = new();
    public List<SpaceObjectProductionItem> SpaceObjectItemsToRemove { get; } = new();
    public List<SpaceObjectProductionItem> SpaceObjectItemsToUpdate { get; } = new();
    public List<ResourceValue> ResourcesToUpdate { get; } = new();

    public async Task PerformBulkOperations(MainDataContext dbContext,
        PlanetBulkOperationsHelper helper,
        CancellationToken cancellationToken)
    {
        if (helper.PlanetBuildingsToAdd.Any())
        {
            await dbContext.BulkInsertAsync(helper.PlanetBuildingsToAdd, cancellationToken: cancellationToken);
            helper.PlanetBuildingsToAdd.Clear();
        }

        if (helper.PlanetBuildingsToUpdate.Any())
        {
            await dbContext.BulkUpdateAsync(helper.PlanetBuildingsToUpdate, cancellationToken: cancellationToken);
            helper.PlanetBuildingsToUpdate.Clear();
        }

        if (helper.PlanetBuildingsToRemove.Any())
        {
            await dbContext.BulkDeleteAsync(helper.PlanetBuildingsToRemove, cancellationToken: cancellationToken);
            helper.PlanetBuildingsToRemove.Clear();
        }

        if (helper.ConstructionItemsToAdd.Any())
        {
            await dbContext.BulkInsertAsync(helper.ConstructionItemsToAdd, cancellationToken: cancellationToken);
            helper.ConstructionItemsToAdd.Clear();
        }

        if (helper.ConstructionItemsToUpdate.Any())
        {
            await dbContext.BulkUpdateAsync(helper.ConstructionItemsToUpdate, cancellationToken: cancellationToken);
            helper.ConstructionItemsToUpdate.Clear();
        }

        if (helper.ConstructionItemsToRemove.Any())
        {
            await dbContext.BulkDeleteAsync(helper.ConstructionItemsToRemove, cancellationToken: cancellationToken);
            helper.ConstructionItemsToRemove.Clear();
        }

        if (helper.SpaceObjectItemsToAdd.Any())
        {
            await dbContext.BulkInsertAsync(helper.SpaceObjectItemsToAdd, cancellationToken: cancellationToken);
            helper.SpaceObjectItemsToAdd.Clear();
        }

        if (helper.SpaceObjectItemsToUpdate.Any())
        {
            await dbContext.BulkUpdateAsync(helper.SpaceObjectItemsToUpdate, cancellationToken: cancellationToken);
            helper.SpaceObjectItemsToUpdate.Clear();
        }

        if (helper.SpaceObjectItemsToRemove.Any())
        {
            await dbContext.BulkDeleteAsync(helper.SpaceObjectItemsToRemove, cancellationToken: cancellationToken);
            helper.SpaceObjectItemsToRemove.Clear();
        }
    }
}