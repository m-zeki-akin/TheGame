namespace TheGame.Core.Entities.SpaceObjects;

public class SpacecraftGroup
{
    public long Id { get; set; }
    public long SpacecraftId { get; set; }
    public Spacecraft Spacecraft { get; set; }
    public int Quantity { get; set; }
    
    public long FleetId { get; set; }
    public Fleet Fleet { get; set; }
}