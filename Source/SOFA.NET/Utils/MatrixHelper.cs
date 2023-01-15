namespace SOFA.NET;

internal static class MatrixHelper
{


    /// <summary>
    /// SOFA name: iauRz
    /// </summary>
    /// <param name="this"></param>
    /// <param name="psi"></param>
    /// <returns></returns>
    public static double[,] RotateZ(this double[,] @this, double psi)
    {
        double s, c, a00, a01, a02, a10, a11, a12;

        s = Math.Sin(psi);
        c = Math.Cos(psi);

        a00 = c * @this[0, 0] + s * @this[1, 0];
        a01 = c * @this[0, 1] + s * @this[1, 1];
        a02 = c * @this[0, 2] + s * @this[1, 2];
        a10 = -s * @this[0, 0] + c * @this[1, 0];
        a11 = -s * @this[0, 1] + c * @this[1, 1];
        a12 = -s * @this[0, 2] + c * @this[1, 2];

        @this[0, 0] = a00;
        @this[0, 1] = a01;
        @this[0, 2] = a02;
        @this[1, 0] = a10;
        @this[1, 1] = a11;
        @this[1, 2] = a12;

        return @this;
    }

    /// <summary>
    /// SOFA name: iauRy
    /// </summary>
    /// <param name="this"></param>
    /// <param name="theta"></param>
    /// <returns></returns>
    public static double[,] RotateY(this double[,] @this, double theta)
    {
        double s, c, a00, a01, a02, a20, a21, a22;

        s = Math.Sin(theta);
        c = Math.Cos(theta);

        a00 = c * @this[0, 0] - s * @this[2, 0];
        a01 = c * @this[0, 1] - s * @this[2, 1];
        a02 = c * @this[0, 2] - s * @this[2, 2];
        a20 = s * @this[0, 0] + c * @this[2, 0];
        a21 = s * @this[0, 1] + c * @this[2, 1];
        a22 = s * @this[0, 2] + c * @this[2, 2];

        @this[0, 0] = a00;
        @this[0, 1] = a01;
        @this[0, 2] = a02;
        @this[2, 0] = a20;
        @this[2, 1] = a21;
        @this[2, 2] = a22;

        return @this;
    }

    /// <summary>
    /// SOFA name: iauRx
    /// </summary>
    /// <param name="this"></param>
    /// <param name="phi"></param>
    /// <returns></returns>
    public static double[,] RotateX(this double[,] @this, double phi)
    {
        double s, c, a10, a11, a12, a20, a21, a22;

        s = Math.Sin(phi);
        c = Math.Cos(phi);

        a10 = c * @this[1, 0] + s * @this[2, 0];
        a11 = c * @this[1, 1] + s * @this[2, 1];
        a12 = c * @this[1, 2] + s * @this[2, 2];
        a20 = -s * @this[1, 0] + c * @this[2, 0];
        a21 = -s * @this[1, 1] + c * @this[2, 1];
        a22 = -s * @this[1, 2] + c * @this[2, 2];

        @this[1, 0] = a10;
        @this[1, 1] = a11;
        @this[1, 2] = a12;
        @this[2, 0] = a20;
        @this[2, 1] = a21;
        @this[2, 2] = a22;

        return @this;
    }

    /// <summary>
    /// SOFA name: iauIr
    /// </summary>
    /// <returns></returns>
    public static double[,] IdentityMatrix()
        => new double[3, 3]
        {
            { 1, 0, 0 },
            { 0, 1, 0 },
            { 0, 0, 1 }
        };

    /// <summary>
    /// SOFA name: iauRxr
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static double[,] Multiply(this double[,] a, double[,] b)
    {
        int i, j, k;
        double w;
        double[,] wm = new double[3, 3];

        for (i = 0; i < 3; i++)
        {
            for (j = 0; j < 3; j++)
            {
                w = 0.0;
                for (k = 0; k < 3; k++)
                {
                    w += a[i, k] * b[k, j];
                }
                wm[i, j] = w;
            }
        }

        return wm;
    }

}
