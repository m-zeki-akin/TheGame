namespace TheGame.Core.Entities;

public class SpaceObjectAuxiliaryAddon
{
    public long AuxiliaryAddonId { get; set; }
    public AuxiliaryAddon AuxiliaryAddon { get; set; }

    public long SpaceElementId { get; set; }
    public SpaceObject SpaceObject { get; set; }
}