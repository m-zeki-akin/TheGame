using TheGame.Core.Game.Entities.StellarObjects;
using TheGame.Core.Game.Shared.Enums;

namespace TheGame.Core.Game.Entities.Empires;

public class Empire
{
    public Guid Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public EmpireType Type { get; set; }
    public int Truculence { get; set; }
    public Guid LeaderId { get; set; }
    public Player Leader { get; set; }
    
    public Guid CapitalId { get; set; }
    public Planet Capital { get; set; }
    public Guid TradeCenterId { get; set; }
    public Planet TradeCenter { get; set; }
    public ICollection<EmpireAlliance> Alliances { get; set; }
    public ICollection<EmpireFaction> Factions { get; set; }
    public ICollection<EmpireTrade> TradePartners { get; set; }
    public ICollection<EmpirePlanet> Planets { get; set; }
    public ICollection<EmpireFleet> Fleets { get; set; }
    public ICollection<EmpireCommander> Commanders { get; set; }
    public ICollection<EmpireTech> Technologies { get; set; }
    public EmpireResearch RoboticsResearch { get; set; }
    public EmpireResearch GeneticsResearch { get; set; }
    public EmpireResearch WarfareResearch { get; set; }
    public EmpireResearch EconomicsResearch { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}