using static SOFA.NET.ThrowHelper;

namespace SOFA.NET;

public static class PrecNutPolarModule
{

    /// <summary>
    /// Mean obliquity of the ecliptic, IAU 2006 precession model.
    /// SOFA name: iauObl06
    /// </summary>
    /// <param name="ttJulianDate"></param>
    /// <returns></returns>
    public static double MeanObliquityOfTheEclipticIAU06(JulianDate ttJulianDate)
    {
        ThrowIfNotExpectedJulianDateKind(JulianDateKind.Tt, ttJulianDate);

        var t = ttJulianDate.JulianCentury();
        double eps0 = (84381.406 +
          (-46.836769 +
          (-0.0001831 +
          (0.00200340 +
          (-0.000000576 +
          (-0.0000000434) * t) * t) * t) * t) * t) * Constants.DAS2R;

        return eps0;
    }

    /// <summary>
    /// Precession matrix (including frame bias) from GCRS to a specified date, IAU 2006 model
    /// SOFA name: iauPmat06
    /// </summary>
    /// <param name="ttJulianDate"></param>
    /// <returns></returns>
    public static double[,] PrecessionMatrixFromGcrsToDateIAU06(JulianDate ttJulianDate)
    {
        ThrowIfNotExpectedJulianDateKind(JulianDateKind.Tt, ttJulianDate);

        var angles = PrecessionAnglesIAU06(ttJulianDate);
        var matrix = FormRotationMatrix(angles);

        return matrix;
    }

    /// <summary>
    /// Precession angles, IAU 2006 (Fukushima-Williams 4-angle formulation)
    /// SOFA name: iauPfw06
    /// </summary>
    /// <param name="ttJulianDate"></param>
    /// <returns></returns>
    public static FukushimaWilliamsAngles PrecessionAnglesIAU06(JulianDate ttJulianDate)
    {
        ThrowIfNotExpectedJulianDateKind(JulianDateKind.Tt, ttJulianDate);
        double gamb, phib, psib, epsa;

        var t = ttJulianDate.JulianCentury();
        gamb = (-0.052928 +
            (10.556378 +
            (0.4932044 +
            (-0.00031238 +
            (-0.000002788 +
            (0.0000000260)
            * t) * t) * t) * t) * t) * Constants.DAS2R;
        phib = (84381.412819 +
            (-46.811016 +
            (0.0511268 +
            (0.00053289 +
            (-0.000000440 +
            (-0.0000000176)
            * t) * t) * t) * t) * t) * Constants.DAS2R;
        psib = (-0.041775 +
            (5038.481484 +
            (1.5584175 +
            (-0.00018522 +
            (-0.000026452 +
            (-0.0000000148)
            * t) * t) * t) * t) * t) * Constants.DAS2R;
        epsa = MeanObliquityOfTheEclipticIAU06(ttJulianDate);

        return new(gamb, phib, psib, epsa);
    }

    /// <summary>
    /// Form rotation matrix given the Fukushima-Williams angles
    /// SOFA name: iauFw2m
    /// </summary>
    /// <param name="angles"></param>
    /// <returns></returns>
    public static double[,] FormRotationMatrix(FukushimaWilliamsAngles angles)
    {
        double[,] matrix = MatrixHelper.IdentityMatrix();
        var (gamma, phi, psi, eps) = angles;

        MatrixHelper.RotateZ(matrix, gamma);
        MatrixHelper.RotateX(matrix, phi);
        MatrixHelper.RotateZ(matrix, -psi);
        MatrixHelper.RotateX(matrix, -eps);

        return matrix;
    }

    #region LongTermPrecessionOfTheEquator

    private static Lazy<double[,]> periodicCoeffs = new Lazy<double[,]>(() =>
    {
        return new double[,]
        {
            { 256.75, -819.940624,75004.344875,81491.287984, 1558.515853},
            { 708.15,-8444.676815,  624.033993,  787.163481, 7774.939698},
            { 274.20, 2600.009459, 1251.136893, 1251.296102,-2219.534038},
            { 241.45, 2755.175630,-1102.212834,-1257.950837,-2523.969396},
            {2309.00, -167.659835,-2660.664980,-2966.799730,  247.850422},
            { 492.20,  871.855056,  699.291817,  639.744522, -846.485643},
            { 396.10,   44.769698,  153.167220,  131.600209,-1393.124055},
            { 288.90, -512.313065, -950.865637, -445.040117,  368.526116},
            { 231.10, -819.415595,  499.754645,  584.522874,  749.045012},
            {1610.00, -538.071099, -145.188210,  -89.756563,  444.704518},
            { 620.00, -189.793622,  558.116553,  524.429630,  235.934465},
            { 157.87, -402.922932,  -23.923029,  -13.549067,  374.049623},
            { 220.30,  179.516345, -165.405086, -210.157124, -171.330180},
            {1200.00,   -9.814756,    9.344131,  -44.919798,  -22.899655}
        };
    });
    private static Lazy<double[,]> polynomialCoeffs = new Lazy<double[,]>(() =>
    {
        return new double[,]
        {
            {  5453.282155, 0.4252841, -0.00037173, -0.000000152 },
            { -73750.930350, -0.7675452, -0.00018725, 0.000000231 }
        };
    });

    /// <summary>
    /// Long-term precession of the equator
    /// SOFA name: iauLtpequ
    /// </summary>
    /// <param name="ttJulianEpoch"></param>
    /// <returns></returns>
    public static double[] LongTermPrecessionOfTheEquator(double ttJulianEpoch)
    {
        var xypol = polynomialCoeffs.Value;
        var xyper = periodicCoeffs.Value;

        double t, x, y, w, a, s, c;

        /* Centuries since J2000. */
        t = (ttJulianEpoch - 2000.0) / 100.0;

        /* Initialize X and Y accumulators. */
        x = 0.0; y = 0.0;

        /* Periodic terms. */
        w = Constants.PI2 * t;
        int xyperLength = xyper.GetLength(0);
        for (int i = 0; i < xyperLength; i++)
        {
            a = w / xyper[i, 0];
            s = Math.Sin(a);
            c = Math.Cos(a);
            x += (c * xyper[i, 1]) + (s * xyper[i, 3]);
            y += (c * xyper[i, 2]) + (s * xyper[i, 4]);
        }

        /* Polynomial terms. */
        w = 1.0;
        int xypolLength = xypol.GetLength(1);
        for (int i = 0; i < xypolLength; i++)
        {
            x += xypol[0, i] * w;
            y += xypol[1, i] * w;
            w *= t;
        }

        /* X and Y (direction cosines). */
        x *= Constants.DAS2R;
        y *= Constants.DAS2R;

        /* Form the equator pole vector. */
        var veq = new double[3];
        veq[0] = x;
        veq[1] = y;
        w = 1.0 - (x * x) - (y * y);
        veq[2] = w < 0.0 ? 0.0 : Math.Sqrt(w);

        return veq;
    }

    #endregion

}
