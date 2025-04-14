using System.Collections;
using System.Numerics;

namespace SOFA.NET;

public readonly struct Vector3<T>(T x, T y, T z) : IVector<T>
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

    public bool Equals(IVector<T>? other)
    {
        if (other is null)
        {
            return false;
        }

        return this[0].Equals(other[0]) && this[1].Equals(other[1]);
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
