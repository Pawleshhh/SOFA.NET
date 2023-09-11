namespace SOFA.NET;

internal static class VectorHelper
{

    /// <summary>
    /// p-vector inner (=scalar=dot) product.
    /// SOFA name: iauPdp
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static double VectorDotProduct(double[] a, double[] b)
    {
        return a[0] * b[0] + a[1] * b[1] + a[2] * b[2];
    }

    /// <summary>
    /// Modulus of p-vector.
    /// SOFA name: iauPm
    /// </summary>
    /// <param name="p"></param>
    /// <returns></returns>
    public static double VectorModulus(double[] p)
    {
        return Math.Sqrt(p[0] * p[0] + p[1] * p[1] + p[2] * p[2]);
    }

    /// <summary>
    /// P-vector subtraction.
    /// SOFA name: iauPmp
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static double[] VectorSubstraction(double[] a, double[] b)
    {
        return new[]
        {
            a[0] - b[0],
            a[1] - b[1],
            a[2] - b[2],
        };
    }

    /// <summary>
    /// Multiply a p-vector by a scalar.
    /// SOFA name: iauSxp
    /// </summary>
    /// <param name="s"></param>
    /// <param name="p"></param>
    /// <returns></returns>
    public static double[] VectorMultiplyByScalar(double s, double[] p)
    {
        return new[]
        {
            s * p[0],
            s * p[1],
            s * p[2],
        };
    }

}
