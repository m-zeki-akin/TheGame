namespace TheGame.Core.Shared.ValueObjects;

public class Vector3D(double x, double y, double z)
{
    public double X { get; } = x;
    public double Y { get; } = y;
    public double Z { get; } = z;

    public double Magnitude => Math.Sqrt(X * X + Y * Y + Z * Z);

    public Vector3D(Coordinates start, Coordinates end) : this(end.X - start.X, end.Y - start.Y, end.Z - start.Z)
    {
    }
}