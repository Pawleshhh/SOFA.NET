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
    public static double PositionVectorInnerProduct(double[] a, double[] b)
    {
        return a[0] * b[0] + a[1] * b[1] + a[2] * b[2];
    }

    /// <summary>
    /// Modulus of p-vector.
    /// SOFA name: iauPm
    /// </summary>
    /// <param name="p"></param>
    /// <returns></returns>
    public static double PositionVectorModulus(double[] p)
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
    public static double[] PositionVectorSubstraction(double[] a, double[] b)
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
    public static (double Modulus, double[] UnitVector) PositionVectorToModulusAndUnitVector(double[] p)
    {
        double w = PositionVectorModulus(p);
        double[] u;

        if (w != 0.0)
        {
            u = PositionVectorMultiplyByScalar(1.0 / w, p);
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
    public static double[] PositionVectorAddition(double[] a, double[] b)
    {
        return new[]
        {
            a[0] + b[0],
            a[1] + b[1],
            a[2] + b[2],
        };
    }

    /// <summary>
    /// P-vector plus scaled p-vector.
    /// SOFA name: iauPpsp
    /// </summary>
    /// <param name="a"></param>
    /// <param name="s"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static double[] PositionVectorPlusScaledPositionVector(double[] a, double s, double[] b)
    {
        var sb = PositionVectorMultiplyByScalar(s, b);
        return PositionVectorAddition(a, sb);
    }

    /// <summary>
    /// Inner (=scalar=dot) product of two pv-vectors.
    /// SOFA name: iauPvdpv
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static double[] InnerProductOfTwoPositionVelocityVectors(double[,] a , double[,] b)
    {
        double[] adb = new double[2];

        var aFirstRow = a.GetRow(0);
        var bFirstRow = b.GetRow(0);

        adb[0] = PositionVectorInnerProduct(aFirstRow, bFirstRow);

        var adbd = PositionVectorInnerProduct(aFirstRow, b.GetRow(1));
        var addb = PositionVectorInnerProduct(a.GetRow(1), bFirstRow);

        adb[1] = adbd + addb;

        return adb;
    }

    public static (double PositionModulus, double VelocityModulus) ModulusOfPositionVelocityVector(double[,] pv)
    {
        return (PositionVectorModulus(pv.GetRow(0)), PositionVectorModulus(pv.GetRow(1)));
    }

    /// <summary>
    /// Multiply a p-vector by a scalar.
    /// SOFA name: iauSxp
    /// </summary>
    /// <param name="s"></param>
    /// <param name="p"></param>
    /// <returns></returns>
    public static double[] PositionVectorMultiplyByScalar(double s, double[] p)
    {
        return new[]
        {
            s * p[0],
            s * p[1],
            s * p[2],
        };
    }

}
