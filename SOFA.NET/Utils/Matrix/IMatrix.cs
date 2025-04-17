using System.Numerics;

namespace SOFA.NET;

public interface IMatrix<T> : IEquatable<IMatrix<T>>, IReadOnlyCollection<T>, IEnumerable<T>
    where T : struct, INumber<T>
{

    public T this[int row, int column] { get; }

    public int Rows { get; }
    public int Columns { get; } 

    public T Value(int row, int column);

    public T[,] AsArray();

}
