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
        => new CoordinateSystem2D<T>(x, y);
}

internal record CoordinateSystem2D<T>(T X, T Y) 
    : CoordinateSystemBase<T>(X, Y), ICoordinateSystem2D<T> where T : struct;