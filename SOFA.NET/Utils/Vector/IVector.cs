using System.Numerics;

namespace SOFA.NET;

public interface IVector<T> : IEquatable<IVector<T>>, IReadOnlyCollection<T>, IEnumerable<T>
    where T : struct, INumber<T>
{
    public T this[int index] { get; }

    public T Value(int index);

    public T[] AsArray();

}