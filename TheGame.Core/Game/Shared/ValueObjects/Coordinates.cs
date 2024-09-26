namespace TheGame.Core.Game.Shared.ValueObjects;

public struct Coordinates(double x, double y)
{
    public double X { get; set; } = x;
    public double Y { get; set; } = y;

    public static Coordinates operator -(Coordinates a, Coordinates b)
    {
        return new Coordinates(a.X - b.X, a.Y - b.Y);
    }

    public static Coordinates operator +(Coordinates a, Coordinates b)
    {
        return new Coordinates(a.X + b.X, a.Y + b.Y);
    }

    public static Coordinates operator +(Coordinates a, Vector2D b)
    {
        return new Coordinates(a.X + b.X, a.Y + b.Y);
    }

    public static Coordinates operator -(Coordinates a, Vector2D b)
    {
        return new Coordinates(a.X - b.X, a.Y - b.Y);
    }
}