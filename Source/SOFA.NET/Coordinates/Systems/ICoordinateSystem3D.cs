namespace SOFA.NET;

public interface ICoordinateSystem3D<T> : ICoordinateSystem<T>
    where T : struct
{

    T X { get => Get(0); }
    T Y { get => Get(1); }
    T Z { get => Get(2); }

    public void Deconstruct(out T x, out T y, out T z)
    {
        x = X;
        y = Y;
        z = Z;
    }

    public static ICoordinateSystem3D<T> Create(T x, T y, T z)
        => new CoordinateSystemBase3D<T>(x, y, z);
}

public record CoordinateSystemBase3D<T>
    : CoordinateSystemBase<T>, ICoordinateSystem3D<T> where T : struct
{
    internal CoordinateSystemBase3D(T x, T y, T z)
        : base(x, y, z)
    {
    }
}