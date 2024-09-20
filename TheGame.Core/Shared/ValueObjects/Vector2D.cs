namespace TheGame.Core.Shared.ValueObjects;

public class Vector2D(double x, double y)
{
    public double X { get; } = x;
    public double Y { get; } = y;

    public double Magnitude => Math.Sqrt(X * X + Y * Y);

    public Vector2D(Coordinates start, Coordinates end) : this(end.X - start.X, end.Y - start.Y)
    {
    }
}