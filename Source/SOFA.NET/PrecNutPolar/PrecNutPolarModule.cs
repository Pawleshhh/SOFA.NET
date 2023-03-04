using static SOFA.NET.ThrowHelper;

namespace SOFA.NET;

public static class PrecNutPolarModule
{

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

    /// <summary>
    /// The CIO locator s, positioning the Celestial Intermediate Origin on
    /// the equator of the Celestial Intermediate Pole, given the CIP's X,Y
    /// coordinates.Compatible with IAU 2006/2000A precession-nutation.
    /// SOFA name: iauS06
    /// </summary>
    /// <param name="ttJulianDate"></param>
    /// <param name="cipCoordinates"></param>
    /// <returns></returns>
    public static double CIOLocatorS(JulianDate ttJulianDate, ICoordinateSystem2D<double> cipCoordinates)
    {
        ThrowHelper.ThrowIfNotExpectedJulianDateKind(JulianDateKind.Tt, ttJulianDate);

        double t, a, w0, w1, w2, w3, w4, w5, s;
        double[] fa = new double[8];
        double[] sp = 
        {
            /* 1-6 */
            94.00e-6,
            3808.65e-6,
            -122.68e-6,
            -72574.11e-6,
            27.98e-6,
            15.62e-6
        };

        var s0 = CIOLocatorCoefficients.CoefficientsS0;
        var s1 = CIOLocatorCoefficients.CoefficientsS1;
        var s2 = CIOLocatorCoefficients.CoefficientsS2;
        var s3 = CIOLocatorCoefficients.CoefficientsS3;
        var s4 = CIOLocatorCoefficients.CoefficientsS4;

        var (x, y) = cipCoordinates;

        /* Interval between fundamental epoch J2000.0 and current date (JC). */
        t = ttJulianDate.JulianCentury();

        /* Fundamental Arguments (from IERS Conventions 2003) */

        /* Mean anomaly of the Moon. */
        fa[0] = FundamentalArgsModule.MeanLongitudeIERS03Of(SolarSystemObject.Moon, t);

        /* Mean anomaly of the Sun. */
        fa[1] = FundamentalArgsModule.MeanLongitudeIERS03Of(SolarSystemObject.Sun, t);

        /* Mean longitude of the Moon minus that of the ascending node. */
        fa[2] = FundamentalArgsModule.MeanLongitudeOfMoonMinusAscendingNodeIERS03(t);

        /* Mean elongation of the Moon from the Sun. */
        fa[3] = FundamentalArgsModule.MeanElongationOfMoonFromSunIERS03(t);

        /* Mean longitude of the ascending node of the Moon. */
        fa[4] = FundamentalArgsModule.MeanLongitudeOfMoonAscendingNodeIERS03(t);

        /* Mean longitude of Venus. */
        fa[5] = FundamentalArgsModule.MeanLongitudeIERS03Of(SolarSystemObject.Venus, t);

        /* Mean longitude of Earth. */
        fa[6] = FundamentalArgsModule.MeanLongitudeIERS03Of(SolarSystemObject.Earth, t);

        /* General precession in longitude. */
        fa[7] = FundamentalArgsModule.GeneralAccumulatedPrecessionInLongitudeIERS03(t);

        /* Evaluate s. */
        w0 = sp[0];
        w1 = sp[1];
        w2 = sp[2];
        w3 = sp[3];
        w4 = sp[4];
        w5 = sp[5];

        int i = 0, j = 0;
        for (i = s0.Length - 1; i >= 0; i--)
        {
            a = 0.0;
            for (j = 0; j < 8; j++)
            {
                a += s0[i].nfa[j] * fa[j];
            }
            w0 += s0[i].s * Math.Sin(a) + s0[i].c * Math.Cos(a);
        }

        for (i = s1.Length - 1; i >= 0; i--)
        {
            a = 0.0;
            for (j = 0; j < 8; j++)
            {
                a += s1[i].nfa[j] * fa[j];
            }
            w1 += s1[i].s * Math.Sin(a) + s1[i].c * Math.Cos(a);
        }

        for (i = s2.Length - 1; i >= 0; i--)
        {
            a = 0.0;
            for (j = 0; j < 8; j++)
            {
                a += s2[i].nfa[j] * fa[j];
            }
            w2 += s2[i].s * Math.Sin(a) + s2[i].c * Math.Cos(a);
        }

        for (i = s3.Length - 1; i >= 0; i--)
        {
            a = 0.0;
            for (j = 0; j < 8; j++)
            {
                a += s3[i].nfa[j] * fa[j];
            }
            w3 += s3[i].s * Math.Sin(a) + s3[i].c * Math.Cos(a);
        }

        for (i = s4.Length - 1; i >= 0; i--)
        {
            a = 0.0;
            for (j = 0; j < 8; j++)
            {
                a += s4[i].nfa[j] * fa[j];
            }
            w4 += s4[i].s * Math.Sin(a) + s4[i].c * Math.Cos(a);
        }

        s = (w0 +
            (w1 +
            (w2 +
            (w3 +
            (w4 +
             w5 * t) * t) * t) * t) * t) * Constants.DAS2R - x * y / 2.0;

        return s;
    }

    /// <summary>
    /// Equation of the origins, given the classical NPB matrix and the
    /// quantity s.
    /// SOFA name: iauEors
    /// </summary>
    /// <param name="rnpb"></param>
    /// <param name="s"></param>
    /// <returns></returns>
    public static double EquationOfOrigins(double[,] rnpb, double s)
    {
        double x, ax, xs, ys, zs, p, q, eo;

        /* Evaluate Wallace & Capitaine (2006) expression (16). */
        x = rnpb[2, 0];
        ax = x / (1.0 + rnpb[2, 2]);
        xs = 1.0 - ax * x;
        ys = -ax * rnpb[2, 1];
        zs = -x;
        p = rnpb[0, 0] * xs + rnpb[0, 1] * ys + rnpb[0, 2] * zs;
        q = rnpb[1, 0] * xs + rnpb[1, 1] * ys + rnpb[1, 2] * zs;
        eo = ((p != 0) || (q != 0)) ? s - Math.Atan2(q, p) : s;

        return eo;
    }

    /// <summary>
    /// Form the matrix of precession-nutation for a given date (including
    /// frame bias), equinox based, IAU 2006 precession and IAU 2000A
    /// nutation models.
    /// SOFA name: iauPnm06a
    /// </summary>
    /// <param name="ttJulianDate"></param>
    /// <returns></returns>
    public static double[,] BiasPrecessionNutationMatrix(JulianDate ttJulianDate)
    {
        ThrowHelper.ThrowIfNotExpectedJulianDateKind(JulianDateKind.Tt, ttJulianDate);

        /* Fukushima-Williams angles for frame bias and precession. */
        var (gamb, phib, psib, epsa) = PrecessionAnglesIAU06(ttJulianDate);

        /* Nutation components. */
        var (dp, de) = NutationIAU06a(ttJulianDate);

        /* Equinox based nutation x precession x bias matrix. */
        return FormRotationMatrix(new(gamb, phib, psib + dp, epsa + de));
    }

    /// <summary>
    /// Extract from the bias-precession-nutation matrix the X,Y coordinates
    /// of the Celestial Intermediate Pole.
    /// SOFA name: iauBpn2xy
    /// </summary>
    /// <param name="rbpn"></param>
    /// <returns></returns>
    internal static ICoordinateSystem2D<double> ExtractXYOfCelestialIntermediatePole(double[,] rbpn)
    {
        return ICoordinateSystem2D<double>.Create(rbpn[2, 0], rbpn[2, 1]);
    }

    #region Obliquity

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
    /// Mean obliquity of the ecliptic, IAU 1980 model.
    /// SOFA name: iauObl80
    /// </summary>
    /// <param name="ttJulianDate"></param>
    /// <returns></returns>
    public static double MeanObliquityOfTheEclipticIAU80(JulianDate ttJulianDate)
    {
        ThrowIfNotExpectedJulianDateKind(JulianDateKind.Tt, ttJulianDate);

        double t, eps0;

        t = ttJulianDate.JulianCentury();

        eps0 = Constants.DAS2R * (84381.448 +
                  (-46.8150 +
                  (-0.00059 +
                  (0.001813) * t) * t) * t);

        return eps0;
    }

    #endregion

    #region Precession

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
    /// Precession-rate part of the IAU 2000 precession-nutation models
    /// (part of MHB2000).
    /// SOFA name: iauPr00
    /// </summary>
    /// <param name="ttJulianDate"></param>
    /// <returns></returns>
    public static PrecessionCorrection PrecessionRateIAU00(JulianDate ttJulianDate)
    {
        /* Precession and obliquity corrections (radians per century) */
        const double PRECOR = -0.29965 * Constants.DAS2R,
                     OBLCOR = -0.02524 * Constants.DAS2R;

        /* Interval between fundamental epoch J2000.0 and given date (JC). */
        var t = ttJulianDate.JulianCentury();

        /* Precession rate contributions with respect to IAU 1976/80. */
        return new(PRECOR * t, OBLCOR * t);
    }

    #endregion

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

    /// <summary>
    /// Nutation, IAU 2000A model (MHB2000 luni-solar and planetary nutation
    /// with free core nutation omitted).
    /// SOFA name: iauNut00a
    /// </summary>
    /// <param name="ttJulianDate"></param>
    /// <returns></returns>
    public static Nutation NutationIAU00a(JulianDate ttJulianDate)
    {
        ThrowHelper.ThrowIfNotExpectedJulianDateKind(JulianDateKind.Tt, ttJulianDate);

        double t, el, elp, f, d, om, arg, dp, de, sarg, carg,
          al, af, ad, aom, alme, alve, alea, alma,
          alju, alsa, alur, alne, apa, dpsils, depsls,
          dpsipl, depspl;

        /* Units of 0.1 microarcsecond to radians */
        const double U2R = Constants.DAS2R / 1e7;

        t = ttJulianDate.JulianCentury();

        /* Mean anomaly of the Moon (IERS 2003). */
        el = FundamentalArgsModule.MeanLongitudeIERS03Of(SolarSystemObject.Moon, t);

        /* Mean anomaly of the Sun (MHB2000). */
        elp = ((1287104.79305 +
                 t * (129596581.0481 +
                 t * (-0.5532 +
                 t * (0.000136 +
                 t * (-0.00001149))))) % Constants.TURNAS) * Constants.DAS2R;

        /* Mean longitude of the Moon minus that of the ascending node */
        /* (IERS 2003. */
        f = FundamentalArgsModule.MeanLongitudeOfMoonMinusAscendingNodeIERS03(t);

        /* Mean elongation of the Moon from the Sun (MHB2000). */
        d = ((1072260.70369 +
               t * (1602961601.2090 +
               t * (-6.3706 +
               t * (0.006593 +
               t * (-0.00003169))))) % Constants.TURNAS) * Constants.DAS2R;

        /* Mean longitude of the ascending node of the Moon (IERS 2003). */
        om = FundamentalArgsModule.MeanLongitudeOfMoonAscendingNodeIERS03(t);

        /* Initialize the nutation values. */
        dp = 0.0;
        de = 0.0;

        /* Summation of luni-solar nutation series (in reverse order). */
        var xls = NutationIAU00aLuniSolarCoefficients.Coefficients;
        for (int i = xls.Length - 1; i >= 0; i--)
        {
            /* Argument and functions. */
            arg = ((xls[i].nl * el +
                       xls[i].nlp * elp +
                       xls[i].nf * f +
                       xls[i].nd * d +
                       xls[i].nom * om) % Constants.PI2);
            sarg = Math.Sin(arg);
            carg = Math.Cos(arg);

            /* Term. */
            dp += (xls[i].sp + xls[i].spt * t) * sarg + xls[i].cp * carg;
            de += (xls[i].ce + xls[i].cet * t) * carg + xls[i].se * sarg;
        }

        /* Convert from 0.1 microarcsec units to radians. */
        dpsils = dp * U2R;
        depsls = de * U2R;

        /* ------------------ */
        /* PLANETARY NUTATION */
        /* ------------------ */

        /* n.b.  The MHB2000 code computes the luni-solar and planetary nutation */
        /* in different functions, using slightly different Delaunay */
        /* arguments in the two cases.  This behaviour is faithfully */
        /* reproduced here.  Use of the IERS 2003 expressions for both */
        /* cases leads to negligible changes, well below */
        /* 0.1 microarcsecond. */

        /* Mean anomaly of the Moon (MHB2000). */
        al = (2.35555598 + 8328.6914269554 * t) % Constants.PI2;

        /* Mean longitude of the Moon minus that of the ascending node */
        /*(MHB2000). */
        af = (1.627905234 + 8433.466158131 * t) % Constants.PI2;

        /* Mean elongation of the Moon from the Sun (MHB2000). */
        ad = (5.198466741 + 7771.3771468121 * t) % Constants.PI2;

        /* Mean longitude of the ascending node of the Moon (MHB2000). */
        aom = (2.18243920 - 33.757045 * t) % Constants.PI2;

        /* General accumulated precession in longitude (IERS 2003). */
        apa = FundamentalArgsModule.GeneralAccumulatedPrecessionInLongitudeIERS03(t);

        /* Planetary longitudes, Mercury through Uranus (IERS 2003). */
        alme = FundamentalArgsModule.MeanLongitudeIERS03Of(SolarSystemObject.Mercury, t);
        alve = FundamentalArgsModule.MeanLongitudeIERS03Of(SolarSystemObject.Venus, t);
        alea = FundamentalArgsModule.MeanLongitudeIERS03Of(SolarSystemObject.Earth, t);
        alma = FundamentalArgsModule.MeanLongitudeIERS03Of(SolarSystemObject.Mars, t);
        alju = FundamentalArgsModule.MeanLongitudeIERS03Of(SolarSystemObject.Jupiter, t);
        alsa = FundamentalArgsModule.MeanLongitudeIERS03Of(SolarSystemObject.Saturn, t);
        alur = FundamentalArgsModule.MeanLongitudeIERS03Of(SolarSystemObject.Uranus, t);

        /* Neptune longitude (MHB2000). */
        alne = (5.321159000 + 3.8127774000 * t) % Constants.PI2;

        /* Initialize the nutation values. */
        dp = 0.0;
        de = 0.0;

        /* Summation of planetary nutation series (in reverse order). */
        var xpl = NutationIAU80aPlanetaryCoefficients.Coefficients;
        for (int i = xpl.Length - 1; i >= 0; i--)
        {

            /* Argument and functions. */
            arg = ((xpl[i].nl * al +
                       xpl[i].nf * af +
                       xpl[i].nd * ad +
                       xpl[i].nom * aom +
                       xpl[i].nme * alme +
                       xpl[i].nve * alve +
                       xpl[i].nea * alea +
                       xpl[i].nma * alma +
                       xpl[i].nju * alju +
                       xpl[i].nsa * alsa +
                       xpl[i].nur * alur +
                       xpl[i].nne * alne +
                       xpl[i].npa * apa) % Constants.PI2);
            sarg = Math.Sin(arg);
            carg = Math.Cos(arg);

            /* Term. */
            dp += xpl[i].sp * sarg + xpl[i].cp * carg;
            de += xpl[i].se * sarg + xpl[i].ce * carg;
        }

        /* Convert from 0.1 microarcsec units to radians. */
        dpsipl = dp * U2R;
        depspl = de * U2R;

        /* ------- */
        /* RESULTS */
        /* ------- */

        /* Add luni-solar and planetary components. */
        return new(dpsils + dpsipl, depsls + depspl);
    }

    /// <summary>
    /// Nutation, IAU 2000B model.
    /// SOFA name: iauNut00b
    /// </summary>
    /// <param name="ttJulianDate"></param>
    /// <returns></returns>
    public static Nutation NutationIAU00b(JulianDate ttJulianDate)
    {
        ThrowHelper.ThrowIfNotExpectedJulianDateKind(JulianDateKind.Tt, ttJulianDate);

        double t, el, elp, f, d, om, arg, dp, de, sarg, carg,
          dpsils, depsls, dpsipl, depspl;
        const double U2R = Constants.DAS2R / 1e7;
        const double DPPLAN = -0.135 * Constants.DMAS2R;
        const double DEPLAN = 0.388 * Constants.DMAS2R;

        /* Interval between fundamental epoch J2000.0 and given date (JC). */
        t = ttJulianDate.JulianCentury();

        /* --------------------*/
        /* LUNI-SOLAR NUTATION */
        /* --------------------*/

        /* Fundamental (Delaunay) arguments from Simon et al. (1994) */

        /* Mean anomaly of the Moon. */
        el = DelaunayArgument(485868.249036, 1717915923.2178);

        /* Mean anomaly of the Sun. */
        elp = DelaunayArgument(1287104.79305, 129596581.0481);

        /* Mean argument of the latitude of the Moon. */
        f = DelaunayArgument(335779.526232, 1739527262.8478);

        /* Mean elongation of the Moon from the Sun. */
        d = DelaunayArgument(1072260.70369, 1602961601.2090);

        /* Mean longitude of the ascending node of the Moon. */
        om = DelaunayArgument(450160.398036, -6962890.5431);

        /* Initialize the nutation values. */
        dp = 0.0;
        de = 0.0;

        /* Summation of luni-solar nutation series (smallest terms first). */
        var x = NutationIAU00bCoefficients.Coefficients;
        for (int i = x.Length - 1; i >= 0; i--)
        {
            /* Argument and functions. */
            arg = ((x[i].nl * el +
                    x[i].nlp * elp +
                    x[i].nf * f +
                    x[i].nd * d +
                    x[i].nom * om) % Constants.PI2);
            sarg = Math.Sin(arg);
            carg = Math.Cos(arg);

            /* Term. */
            dp += (x[i].ps + x[i].pst * t) * sarg + x[i].pc * carg;
            de += (x[i].ec + x[i].ect * t) * carg + x[i].es * sarg;
        }

        /* Convert from 0.1 microarcsec units to radians. */
        dpsils = dp * U2R;
        depsls = de * U2R;

        /* ------------------------------*/
        /* IN LIEU OF PLANETARY NUTATION */
        /* ------------------------------*/

        /* Fixed offset to correct for missing terms in truncated series. */
        dpsipl = DPPLAN;
        depspl = DEPLAN;

        /* --------*/
        /* RESULTS */
        /* --------*/

        /* Add luni-solar and planetary components. */
        return new(dpsils + dpsipl, depsls + depspl);

        double DelaunayArgument(double a, double b)
            => ((a + (b * t)) % Constants.TURNAS) * Constants.DAS2R;
    }

    /// <summary>
    /// IAU 2000A nutation with adjustments to match the IAU 2006
    /// precession.
    /// SOFA name: iauNut06a
    /// </summary>
    /// <param name="ttJulianDate"></param>
    /// <returns></returns>
    public static Nutation NutationIAU06a(JulianDate ttJulianDate)
    {
        ThrowHelper.ThrowIfNotExpectedJulianDateKind(JulianDateKind.Tt, ttJulianDate);

        double t, fj2;

        /* Interval between fundamental date J2000.0 and given date (JC). */
        t = ttJulianDate.JulianCentury();

        /* Factor correcting for secular variation of J2. */
        fj2 = -2.7774e-6 * t;

        /* Obtain IAU 2000A nutation. */
        var (dp, de) = NutationIAU00a(ttJulianDate);

        /* Apply P03 adjustments (Wallace & Capitaine, 2006, Eqs.5). */
        return new(dp + dp * (0.4697e-6 + fj2), de + de * fj2);
    }

    #endregion

}
