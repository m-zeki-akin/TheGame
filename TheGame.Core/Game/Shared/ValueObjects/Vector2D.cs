namespace TheGame.Core.Game.Shared.ValueObjects;

public readonly struct Vector2D(double x, double y)
{
    public double X { get; } = x;
    public double Y { get; } = y;

    public double Magnitude => Math.Sqrt(X * X + Y * Y);

    public Vector2D(Coordinates start, Coordinates end) : this(end.X - start.X, end.Y - start.Y)
    {
    }

    public static Vector2D operator -(Vector2D a, Vector2D b)
    {
        return new Vector2D(a.X - b.X, a.Y - b.Y);
    }

    public static Vector2D operator +(Vector2D a, Vector2D b)
    {
        return new Vector2D(a.X + b.X, a.Y + b.Y);
    }

    public static Vector2D operator *(Vector2D a, Vector2D b)
    {
        return new Vector2D(a.X * b.X, a.Y * b.Y);
    }

    public static Vector2D operator /(Vector2D a, Vector2D b)
    {
        return new Vector2D(a.X / b.X, a.Y / b.Y);
    }

    public static Vector2D operator *(Vector2D a, double b)
    {
        return new Vector2D(a.X * b, a.Y * b);
    }
}