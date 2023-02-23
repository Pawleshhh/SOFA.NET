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

    /// <summary>
    /// SOFA name: iauRxp
    /// </summary>
    /// <param name="r"></param>
    /// <param name="p"></param>
    /// <returns></returns>
    public static double[] Multiply(this double[,] r, double[] p)
    {
        double w;
        double[] wrp = new double[3];
        int i, j;

        /* Matrix r * vector p. */
        for (j = 0; j < 3; j++)
        {
            w = 0.0;
            for (i = 0; i < 3; i++)
            {
                w += r[j, i] * p[i];
            }
            wrp[j] = w;
        }

        return wrp;
    }

    /// <summary>
    /// SOFA name: iauSxp
    /// </summary>
    /// <param name="p"></param>
    /// <param name="s"></param>
    /// <returns></returns>
    public static double[] Multiply(this double[] p, double s)
    {
        var sp = new double[3];
        sp[0] = s * p[0];
        sp[1] = s * p[1];
        sp[2] = s * p[2];
        return sp;
    }

    /// <summary>
    /// SOFA name: iauTr
    /// </summary>
    /// <param name="r"></param>
    /// <returns></returns>
    public static double[,] Transpose(this double[,] r)
    {
        double[,] wm = new double[3, 3];
        int i, j;

        for (i = 0; i < 3; i++)
        {
            for (j = 0; j < 3; j++)
            {
                wm[i, j] = r[j, i];
            }
        }

        return wm;
    }
    
    /// <summary>
    /// SOFA name: iauTrxp
    /// </summary>
    /// <param name="r"></param>
    /// <param name="p"></param>
    /// <returns></returns>
    public static double[] TransposeMultiply(this double[,] r, double[] p)
    {
        return r.Transpose().Multiply(p);
    }

    /// <summary>
    /// SOFA name: iauPxp
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static double[] VectorOuterProduct(double[] a, double[] b)
    {
        double xa, ya, za, xb, yb, zb;

        xa = a[0];
        ya = a[1];
        za = a[2];
        xb = b[0];
        yb = b[1];
        zb = b[2];
        double[] axb = new double[3];
        axb[0] = ya * zb - za * yb;
        axb[1] = za * xb - xa * zb;
        axb[2] = xa * yb - ya * xb;

        return axb;
    }

    /// <summary>
    /// SOFA name: iauPm
    /// </summary>
    /// <param name="p"></param>
    /// <returns></returns>
    public static double ModulusOfVector(double[] p)
        => Math.Sqrt(p[0] * p[0] + p[1] * p[1] + p[2] * p[2]);

    /// <summary>
    /// SOFA name: iauPn
    /// </summary>
    /// <param name="p"></param>
    /// <returns></returns>
    public static (double[] UnitVector, double Modulus) VectorToModulusAndUnitVector(double[] p)
    {
        double[] unitVector;
        double w = ModulusOfVector(p);
        if (w == 0.0)
        {
            unitVector = new double[3];
        }
        else
        {
            unitVector = p.Multiply(1.0 / w);
        }

        return (unitVector, w);
    }

}
