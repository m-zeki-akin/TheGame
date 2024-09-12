namespace TheGame.Core.Entities;

public class ArtificialSpaceObjectAuxiliaryAddon
{
    public long AuxiliaryAddonId { get; set; }
    public AuxiliaryAddon AuxiliaryAddon { get; set; }

    public long ArtificialSpaceObjectId { get; set; }
    public ArtificialSpaceObject ArtificialSpaceObject { get; set; }
}