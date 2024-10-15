using MediatR;
using TheGame.Core.Game.Cache.Interfaces;
using TheGame.Core.Game.Entities.Buildings;
using TheGame.Core.Game.Entities.Empires;
using TheGame.Core.Game.Entities.Productions;
using TheGame.Core.Game.Entities.StellarObjects;
using TheGame.Core.Game.Events;
using TheGame.Core.Game.Services.Interface;
using TheGame.Core.Game.Shared;

namespace TheGame.Core.Game.Services;

public class PlanetProcessService(
    IMediator mediator,
    ICacheService<Planet> planetCache
) : IPlanetProcessService
{
    public Task Process()
    {
        ActionProcessor.Process(ProcessPlanets);
        return Task.CompletedTask;
    }

    private void ProcessPlanets()
    {
        foreach (var planet in planetCache.GetAll())
        {
            ActionProcessor.Process(ProcessBuildingProductions, planet);
            ActionProcessor.Process(ProcessResourceBuildings, planet);
            ActionProcessor.Process(ProcessFactoryBuildings, planet);
            ActionProcessor.Process(ProcessResearchBuildings, planet);
        }
    }

    private void ProcessResourceBuildings(Planet planet)
    {
        foreach (var building in planet.ResourceBuildings)
        {
            ProcessBuildingResourceConsumption(planet, building);

            if (building.IsActive)
            {
                planet.StoredResources += building.ResourceProductionsRate;
            }
        }
    }

    private void ProcessFactoryBuildings(Planet planet)
    {
        foreach (var building in planet.FactoryBuildings)
        {
            ProcessBuildingResourceConsumption(planet, building);

            if (building.IsActive)
            {
                ProcessFactory(planet.Id, building);
            }
        }
    }

    private void ProcessFactory(Guid planetId, FactoryBuilding building)
    {
        building.Production.CurrentProduction += building.WorkRate;

        if (building.Production.CurrentProduction >= building.Production.SpaceObject.ProductionCost)
        {
            var @event = new SpaceObjectProductionCompletedEvent
            {
                PlanetId = planetId,
                SpaceObjectId = building.Production.SpaceObjectId,
            };
            mediator.Publish(@event);
        }
    }

    private void ProcessResearchBuildings(Planet planet)
    {
        var workFor = planet.IsOccupied ? planet.Occupier : planet.Owner;

        foreach (var building in planet.ResearchBuildings)
        {
            ProcessBuildingResourceConsumption(planet, building);

            if (building.IsActive)
            {
                ProcessResearch(workFor!.EconomicsResearch, building.EconomicsResearchRate);
                ProcessResearch(workFor.WarfareResearch, building.WarfareResearchRate);
                ProcessResearch(workFor.GeneticsResearch, building.GeneticsResearchRate);
                ProcessResearch(workFor.RoboticsResearch, building.RoboticsResearchRate);
            }
        }
    }

    private void ProcessResearch(EmpireResearch empireResearch, int researchRate)
    {
        empireResearch.Research.ResearchCost += researchRate;
        if (empireResearch.Value >= empireResearch.Research.ResearchCost)
        {
            var @event = new ResearchCompletedEvent
            {
                EmpireId = empireResearch.EmpireId,
                ResearchId = empireResearch.ResearchId
            };
            mediator.Publish(@event);
        }
    }

    private void ProcessBuildingProductions(Planet planet)
    {
        foreach (var production in planet.BuildingProductions)
        {
            if (planet.IsActive && production.Workforce > 0)
            {
                ProcessBuildingProduction(production);
            }
        }
    }

    private void ProcessBuildingProduction(BuildingProductionItem productionItem)
    {
        productionItem.CurrentProduction +=
            (int)(productionItem.Workforce *
                  GameRules.PlanetWorkforceBuildingProductionCoefficient); //TODO add bonuses(research etc...)

        if (productionItem.CurrentProduction >= productionItem.ProducedBuilding.Building.ProductionCost)
        {
            var @event = new ConstructionCompletedEvent { ConstructionItemId = productionItem.Id };
            mediator.Publish(@event);
        }
    }

    private void ProcessBuildingResourceConsumption(Planet planet, Building building)
    {
        if (!building.IsActive || building.ResourceConsumptionsRate == null) return;

        var consumptions = building.ResourceConsumptionsRate!.ResourceValue;

        (planet.StoredResources, var negativeResources) =
            planet.StoredResources - consumptions; //TODO here should be some decrements/increments to cost

        if (negativeResources.Count > 0)
        {
            planet.StoredResources += consumptions;
            building.IsActive = false; //TODO deactivate building event should be added.
        }
    }
}