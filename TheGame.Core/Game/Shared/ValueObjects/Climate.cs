namespace TheGame.Core.Game.Shared.ValueObjects;

public struct Climate
{
    public int MaxTemperature { get; set; }
    public int MinTemperature { get; set; }
    public int AverageTemperature { get; set; }
    public int Humidity { get; set; }
    public int Vegetation { get; set; }
}