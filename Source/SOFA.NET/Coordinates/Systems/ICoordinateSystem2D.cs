namespace SOFA.NET;

public interface ICoordinateSystem2D<T> : ICoordinateSystem<T>
    where T : struct
{
    T X { get => Get(0); }
    T Y { get => Get(1); }

    public void Deconstruct(out T x, out T y)
    {
        x = X;
        y = Y;
    }

    public static ICoordinateSystem2D<T> Create(T x, T y)
        => new CoordinateSystemBase2D<T>(x, y);
}

public record CoordinateSystemBase2D<T>
    : CoordinateSystemBase<T>, ICoordinateSystem2D<T> where T : struct
{
    internal CoordinateSystemBase2D(T x, T y)
        : base(x, y)
    {
    }
}