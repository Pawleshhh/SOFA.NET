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

}
