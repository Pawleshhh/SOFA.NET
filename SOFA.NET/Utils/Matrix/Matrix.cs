using System.Collections;
using System.Numerics;

namespace SOFA.NET;

public class Matrix<T>(int rows, int columns) : IMatrix<T>
    where T : struct, INumber<T>
{

    private readonly T[,] values = new T[rows, columns];

    public T this[int row, int column] => this.values[row, column];

    public int Rows => rows;

    public int Columns => columns;

    public int Count => Rows * Columns;

    public T Value(int row, int column)
    {
        return this[row, column];
    }

    public T[,] AsArray()
    {
        return this.values;
    }

    public bool Equals(IMatrix<T>? other)
    {
        if (other is null)
        {
            return false;
        }

        for (int r = 0; r < Rows; r++)
        {
            for (int c = 0; c < Columns; c++)
            {
                if (!this[r, c].Equals(other[r, c]))
                {
                    return false;
                }
            }
        }

        return true;
    }

    public IEnumerator<T> GetEnumerator()
    {
        return this.values.Cast<T>().GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.values.GetEnumerator();
    }

    public static Matrix<T> FromFlatArray(int rows, int columns, T[] values)
    {
        if (values.Length != rows * columns)
        {
            throw new ArgumentException($"The length of the array must be {rows * columns}.");
        }

        var matrix = new Matrix<T>(rows, columns);
        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < columns; c++)
            {
                matrix.values[r, c] = values[r * columns + c];
            }
        }

        return matrix;
    }
}
