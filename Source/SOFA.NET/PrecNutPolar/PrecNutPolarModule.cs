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

    private static Lazy<double[,]> equatorPeriodicCoeffs = new Lazy<double[,]>(() =>
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
    private static Lazy<double[,]> equatorPolynomialCoeffs = new Lazy<double[,]>(() =>
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
        var xypol = equatorPolynomialCoeffs.Value;
        var xyper = equatorPeriodicCoeffs.Value;

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

    #region LongTermPrecessionOfTheEcliptic

    private static readonly Lazy<double[,]> eclipticPeriodicCoeffs = new Lazy<double[,]>(() =>
    {
        return new double[,]
        {
            { 708.15,-5486.751211,-684.661560,  667.666730,-5523.863691},
            {2309.00,  -17.127623,2446.283880,-2354.886252, -549.747450},
            {1620.00, -617.517403, 399.671049, -428.152441, -310.998056},
            { 492.20,  413.442940,-356.652376,  376.202861,  421.535876},
            {1183.00,   78.614193,-186.387003,  184.778874,  -36.776172},
            { 622.00, -180.732815,-316.800070,  335.321713, -145.278396},
            { 882.00,  -87.676083, 198.296701, -185.138669,  -34.744450},
            { 547.00,   46.140315, 101.135679, -120.972830,   22.885731}
        };
    });
    private static readonly Lazy<double[,]> eclipticPolynomialCoeffs = new Lazy<double[,]>(() =>
    {
        return new double[,]
        {
            { 5851.607687, -0.1189000, -0.00028913, 0.000000101},
            {-1600.886300, 1.1689818, -0.00000020, -0.000000437}
        };
    });

    /// <summary>
    /// Long-term precession of the ecliptic
    /// SOFA name: iauLtpecl
    /// </summary>
    /// <param name="ttJulianEpoch"></param>
    /// <returns></returns>
    public static double[] LongTermPrecessionOfTheEcliptic(double ttJulianEpoch)
    {
        var pqper = eclipticPeriodicCoeffs.Value;
        var pqpol = eclipticPolynomialCoeffs.Value; 
        double eps0 = 84381.406 * Constants.DAS2R;
        double t, p, q, w, a, s, c;

        /* Centuries since J2000. */
        t = (ttJulianEpoch - 2000.0) / 100.0;

        /* Initialize P_A and Q_A accumulators. */
        p = 0.0;
        q = 0.0;

        /* Periodic terms. */
        w = Constants.PI2 * t;
        int pqperLength = pqper.GetLength(0);
        for (int i = 0; i < pqperLength; i++)
        {
            a = w / pqper[i, 0];
            s = Math.Sin(a);
            c = Math.Cos(a);
            p += c * pqper[i, 1] + s * pqper[i, 3];
            q += c * pqper[i, 2] + s * pqper[i, 4];
        }

        /* Polynomial terms. */
        w = 1.0;
        int pqpolLength = pqpol.GetLength(1);
        for (int i = 0; i < pqpolLength; i++)
        {
            p += pqpol[0, i] * w;
            q += pqpol[1, i] * w;
            w *= t;
        }

        /* P_A and Q_A (radians). */
        p *= Constants.DAS2R;
        q *= Constants.DAS2R;

        /* Form the ecliptic pole vector. */
        w = 1.0 - p * p - q * q;
        w = w < 0.0 ? 0.0 : Math.Sqrt(w);
        s = Math.Sin(eps0);
        c = Math.Cos(eps0);
        var vec = new double[3];
        vec[0] = p;
        vec[1] = -q * c - w * s;
        vec[2] = -q * s + w * c;
        return vec;
    }

    #endregion

    #region Nutation

    /// <summary>
    /// Nutation, IAU 1980 model.
    /// SOFA name: iauNut80
    /// </summary>
    /// <param name="ttJulianDate"></param>
    /// <returns></returns>
    public static Nutation NutationIAU80(JulianDate ttJulianDate)
    {
        ThrowIfNotExpectedJulianDateKind(JulianDateKind.Tt, ttJulianDate);

        const double U2R = Constants.DAS2R / 1e4;
        double t, el, elp, f, d, om, dp, de, arg, s, c;

        t = ttJulianDate.JulianCentury();

        /* --------------------- */
        /* Fundamental arguments */
        /* --------------------- */

        /* Mean longitude of Moon minus mean longitude of Moon's perigee. */
        el = MathHelper.NormalizeAngleIntoMinusOnePIToPlusOnePI(
             (485866.733 + (715922.633 + (31.310 + 0.064 * t) * t) * t)
             * Constants.DAS2R + ((1325.0 * t) % 1.0) * Constants.PI2);

        /* Mean longitude of Sun minus mean longitude of Sun's perigee. */
        elp = MathHelper.NormalizeAngleIntoMinusOnePIToPlusOnePI(
              (1287099.804 + (1292581.224 + (-0.577 - 0.012 * t) * t) * t)
              * Constants.DAS2R + ((99.0 * t) % 1.0) * Constants.PI2);

        /* Mean longitude of Moon minus mean longitude of Moon's node. */
        f = MathHelper.NormalizeAngleIntoMinusOnePIToPlusOnePI(
            (335778.877 + (295263.137 + (-13.257 + 0.011 * t) * t) * t)
            * Constants.DAS2R + ((1342.0 * t) % 1.0) * Constants.PI2);

        /* Mean elongation of Moon from Sun. */
        d = MathHelper.NormalizeAngleIntoMinusOnePIToPlusOnePI(
            (1072261.307 + (1105601.328 + (-6.891 + 0.019 * t) * t) * t) 
            * Constants.DAS2R + ((1236.0 * t) % 1.0) * Constants.PI2);

        /* Longitude of the mean ascending node of the lunar orbit on the */
        /* ecliptic, measured from the mean equinox of date. */
        om = MathHelper.NormalizeAngleIntoMinusOnePIToPlusOnePI(
             (450160.280 + (-482890.539 + (7.455 + 0.008 * t) * t) * t)
             * Constants.DAS2R + ((-5.0 * t) % 1.0) * Constants.PI2);

        /* --------------- */
        /* Nutation series */
        /* --------------- */

        /* Initialize nutation components. */
        dp = 0.0;
        de = 0.0;

        var x = NutationIAU80Coefficients.Coefficients;

        /* Sum the nutation terms, ending with the biggest. */
        for (int j = x.Length - 1; j >= 0; j--)
        {

            /* Form argument for current term. */
            arg = (double)x[j].nl * el
                + (double)x[j].nlp * elp
                + (double)x[j].nf * f
                + (double)x[j].nd * d
                + (double)x[j].nom * om;

            /* Accumulate current nutation term. */
            s = x[j].sp + x[j].spt * t;
            c = x[j].ce + x[j].cet * t;
            if (s != 0.0) dp += s * Math.Sin(arg);
            if (c != 0.0) de += c * Math.Cos(arg);
        }

        /* Convert results from 0.1 mas units to radians. */
        return new(dp * U2R, de * U2R);
    }

    #endregion

}
