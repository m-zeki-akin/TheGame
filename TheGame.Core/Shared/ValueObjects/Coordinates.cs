namespace TheGame.Core.Shared.ValueObjects;

public class Coordinates(double x, double y, double z)
{
    public double X { get; private set; } = x;
    public double Y { get; private set; } = y;
    public double Z { get; private set; } = z;
}