using System.Collections;
using System.Numerics;

namespace SOFA.NET;

public class Vector3<T>(T x, T y, T z) : IVector<T>
    where T : struct, INumber<T>
{

    private readonly T[] values = [x, y, z];

    public T this[int index] => this.values[index];

    public int Count => 3;

    public bool IsReadOnly => true;

    public T Value(int index)
    {
        return this[index];
    }

    public T[] AsArray()
    {
        return this.values;
    }

    public bool Equals(IVector<T>? other)
    {
        if (other is null)
        {
            return false;
        }

        return this[0].Equals(other[0]) && this[1].Equals(other[1]);
    }

    internal static Vector3<T> FromArrayZeroIfInvalid(T[] array)
    {
        if (array is null || array.Length != 3)
        {
            return new Vector3<T>(T.Zero, T.Zero, T.Zero);
        }

        return new Vector3<T>(array[0], array[1], array[2]);
    }

    public IEnumerator<T> GetEnumerator()
    {
        return this.values.AsEnumerable().GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.values.GetEnumerator();
    }
}
