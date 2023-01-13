namespace SOFA.NET;

public interface ICoordinateSystem<T> : IEquatable<ICoordinateSystem<T>>
    where T : struct
{
    public int Axes { get; }

    public T Get(int axis);
    public void Set(int axis, T value);
}

public abstract record CoordinateSystem<T> : ICoordinateSystem<T>
    where T : struct
{

    private readonly T[] coords;

    public CoordinateSystem(params T[] coords)
    {
        if (coords.IsNullOrEmpty())
        {
            throw new ArgumentException("Coords array cannot be null or empty", nameof(coords));
        }

        this.coords = coords.Copy();
    }

    public int Axes => this.coords.Length;

    public T Get(int axis)
        => this.coords[axis];
    public void Set(int axis, T value)
        => this.coords[axis] = value;

    public bool Equals(ICoordinateSystem<T>? other)
        => other != null && this.coords.AllIterate((x, i) => other.Get(i).Equals(x));

}

public interface ICoordinateSystem2D<T> : ICoordinateSystem<T>
    where T : struct
{
    public T X { get; set; }
    public T Y { get; set; }

    public void Deconstruct(out T x, out T y)
    {
        x = X;
        y = Y;
    }

    public static ICoordinateSystem2D<T> Create(T x, T y)
        => new CoordinateSystem2D<T> { X = x, Y = y };
}

internal record CoordinateSystem2D<T>() : CoordinateSystem<T>, ICoordinateSystem2D<T>
    where T : struct
{
    public required T X { get => Get(0); set => Set(0, value); }
    public required T Y { get => Get(1); set => Set(1, value); }
}