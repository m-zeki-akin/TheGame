using TheGame.Core.Game.Shared.Enums;

namespace TheGame.Core.Game.Entities;

public class Empire
{
    public Guid Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public EmpireType Type { get; set; }
    public Guid LeaderId { get; set; }
    public Player Leader { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public ICollection<EmpireAlliance> Alliances { get; set; }
    public ICollection<EmpireFaction> Factions { get; set; }
    public ICollection<TradePartner> TradePartners { get; set; }
    public ICollection<EmpirePlanet> Planets { get; set; }
    public ICollection<EmpireFleet> Fleets { get; set; }
    public ICollection<EmpireResearch> Researches { get; set; }
    public ICollection<EmpireCommander> Commanders { get; set; }
    public Guid? CurrentRoboticsResearchId { get; set; }
    public EmpireResearch? CurrentRoboticsResearch { get; set; }
    public Guid? CurrentGeneticsResearchId { get; set; }
    public EmpireResearch? CurrentGeneticsResearch { get; set; }
    public Guid? CurrentEconomicsResearchId { get; set; }
    public EmpireResearch? CurrentEconomicsResearch { get; set; }
    public Guid? CurrentWarfareResearchId { get; set; }
    public EmpireResearch? CurrentWarfareResearch { get; set; }
}