namespace SOFA.NET;

public interface ICoordinateSystem<T> : IEquatable<ICoordinateSystem<T>>
    where T : struct
{
    public int Axes { get; }

    public T Get(int axis);
}

public abstract record CoordinateSystemBase<T> : ICoordinateSystem<T>
    where T : struct
{

    private readonly T[] coords;

    public CoordinateSystemBase(params T[] coords)
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

    public bool Equals(ICoordinateSystem<T>? other)
        => other != null && this.coords.AllIterate((x, i) => other.Get(i).Equals(x));

}
