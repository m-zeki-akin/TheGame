namespace TheGame.Core.Shared.ValueObjects;

public class Coordinates(double x, double y, double z)
{
    public double X { get; set; } = x;
    public double Y { get; set; } = y;
}