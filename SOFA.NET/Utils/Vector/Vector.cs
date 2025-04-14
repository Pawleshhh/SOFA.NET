using System.Collections;
using System.Numerics;

namespace SOFA.NET;

public class Vector<T>(params T[] values) : IVector<T>
    where T : struct, INumber<T>
{

    private readonly T[] values = values;

    public T this[int index] => this.values[index];

    public int Count => this.values.Length;

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

        for (int i = 0; i < this.Count; i++)
        {
            if (!this[i].Equals(other[i]))
            {
                return false;
            }
        }

        return true;
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
