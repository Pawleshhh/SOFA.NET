namespace SOFA.NET;

internal static class VectorHelper
{

    /// <summary>
    /// Zero a p-vector.
    /// SOFA name: iauZp
    /// </summary>
    /// <param name="p"></param>
    public static void ZeroVector(double[] p)
    {
        p[0] = p[1] = p[2] = 0;
    }

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
    /// Convert a p-vector into modulus and unit vector.
    /// SOFA name: iauPn
    /// </summary>
    /// <param name="p"></param>
    /// <returns></returns>
    public static (double Modulus, double[] UnitVector) VectorToModulusAndUnitVector(double[] p)
    {
        double w = VectorModulus(p);
        double[] u;

        if (w != 0.0)
        {
            u = VectorMultiplyByScalar(1.0 / w, p);
        }
        else
        {
            u = new double[3];
        }

        return (w, u);
    }

    /// <summary>
    /// P-vector addition.
    /// SOFA name: iauPpp
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static double[] VectorAddition(double[] a, double[] b)
    {
        return new[]
        {
            a[0] + b[0],
            a[1] + b[1],
            a[2] + b[2],
        };
    }

    public static double[] VectorPlusScaledVector(double[] a, double s, double[] b)
    {
        var sb = VectorMultiplyByScalar(s, b);
        return VectorAddition(a, sb);
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
