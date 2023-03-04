using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SOFA.NET;

public static class EquinoxModule
{


    /// <summary>
    /// Equation of the equinoxes, IAU 1994 model.
    /// SOFA name: iauEqeq94
    /// </summary>
    /// <param name="tdbJulianDate"></param>
    /// <returns></returns>
    public static double EquationOfEquinoxesIAU94(JulianDate tdbJulianDate)
    {
        ThrowHelper.ThrowIfNotExpectedJulianDateKind(JulianDateKind.Tdb, tdbJulianDate);

        double t, om, eps0, ee;

        t = tdbJulianDate.JulianCentury();

        om = MathHelper.NormalizeAngleIntoMinusOnePIToPlusOnePI((450160.280 + (-482890.539
           + (7.455 + 0.008 * t) * t) * t) * Constants.DAS2R
           + ((-5.0 * t) % 1.0) * Constants.PI2);

        var ttJulianDate = new JulianDate(tdbJulianDate.DayNumber, tdbJulianDate.FractionOfDay, JulianDateKind.Tt);
        var dpsi = PrecNutPolarModule.NutationIAU80(ttJulianDate).Longitude;
        eps0 = PrecNutPolarModule.MeanObliquityOfTheEclipticIAU80(ttJulianDate);

        ee = dpsi * Math.Cos(eps0) + Constants.DAS2R * (0.00264 * Math.Sin(om) + 0.000063 * Math.Sin(om + om));

        return ee;
    }

    /// <summary>
    /// The equation of the equinoxes, compatible with IAU 2000 resolutions,
    /// given the nutation in longitude and the mean obliquity.
    /// SOFA name: iauEe00
    /// </summary>
    /// <param name="ttJulianDate"></param>
    /// <param name="nutation"></param>
    /// <returns></returns>
    public static double EquationOfEquinoxesIAU00(JulianDate ttJulianDate, Nutation nutation)
    {
        ThrowHelper.ThrowIfNotExpectedJulianDateKind(JulianDateKind.Tt, ttJulianDate);

        var (longitude, obliquity) = nutation;

        return longitude * Math.Cos(obliquity) + EquinoxesComplementaryTermsIAU00(ttJulianDate);
    }

    /// <summary>
    /// Equation of the equinoxes, compatible with IAU 2000 resolutions.
    /// SOFA name: iauEe00a
    /// </summary>
    /// <param name="ttJulianDate"></param>
    /// <returns></returns>
    public static double EquationOfEquinoxesIAU00a(JulianDate ttJulianDate)
    {
        ThrowHelper.ThrowIfNotExpectedJulianDateKind(JulianDateKind.Tt, ttJulianDate);

        double epsa, ee;

        /* IAU 2000 precession-rate adjustments. */
        var (_, depspr) = PrecNutPolarModule.PrecessionRateIAU00(ttJulianDate);

        /* Mean obliquity, consistent with IAU 2000 precession-nutation. */
        epsa = PrecNutPolarModule.MeanObliquityOfTheEclipticIAU80(ttJulianDate) + depspr;

        /* Nutation in longitude. */
        var (dpsi, _) = PrecNutPolarModule.NutationIAU00a(ttJulianDate);

        /* Equation of the equinoxes. */
        ee = EquationOfEquinoxesIAU00(ttJulianDate, new(dpsi, epsa));

        return ee;
    }

    /// <summary>
    /// Equation of the equinoxes, compatible with IAU 2000 resolutions but
    /// using the truncated nutation model IAU 2000B.
    /// SOFA name: iauEe00b
    /// </summary>
    /// <param name="ttJulianDate"></param>
    /// <returns></returns>
    public static double EquationOfEquinoxesIAU00b(JulianDate ttJulianDate)
    {
        ThrowHelper.ThrowIfNotExpectedJulianDateKind(JulianDateKind.Tt, ttJulianDate);

        double epsa, ee;

        /* IAU 2000 precession-rate adjustments. */
        var (_, depspr) = PrecNutPolarModule.PrecessionRateIAU00(ttJulianDate);

        /* Mean obliquity, consistent with IAU 2000 precession-nutation. */
        epsa = PrecNutPolarModule.MeanObliquityOfTheEclipticIAU80(ttJulianDate) + depspr;

        /* Nutation in longitude. */
        var (dpsi, _) = PrecNutPolarModule.NutationIAU00b(ttJulianDate);

        /* Equation of the equinoxes. */
        ee = EquationOfEquinoxesIAU00(ttJulianDate, new(dpsi, epsa));

        return ee;
    }

    /// <summary>
    /// Equation of the equinoxes complementary terms, consistent with
    /// IAU 2000 resolutions.
    /// SOFA name: iauEect00
    /// </summary>
    /// <param name="ttJulianDate"></param>
    /// <returns></returns>
    public static double EquinoxesComplementaryTermsIAU00(JulianDate ttJulianDate)
    {
        ThrowHelper.ThrowIfNotExpectedJulianDateKind(JulianDateKind.Tt, ttJulianDate);

        /* Time since J2000.0, in Julian centuries */
        double t;

        /* Miscellaneous */
        double a, s0, s1;

        /* Fundamental arguments */
        double[] fa = new double[14];

        /* Returned value. */
        double eect;

        var e0 = EquinoxesComplementaryTermsCoefficients.Coefficients;
        var e1 = new EquinoxesComplementaryTermsCoefficients(new[] { 0, 0, 0, 0, 1, 0, 0, 0 }, -0.87e-6, 0.00e-6);

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

        /* Evaluate the EE complementary terms. */
        s0 = 0.0;
        s1 = 0.0;

        for (int i = e0.Length - 1; i >= 0; i--)
        {
            a = 0.0;
            for (int j = 0; j < 8; j++)
            {
                a += (e0[i].nfa[j]) * fa[j];
            }
            s0 += e0[i].s * Math.Sin(a) + e0[i].c * Math.Cos(a);
        }

        a = 0.0;
        for (int j = 0; j < 8; j++)
        {
            a += (e1.nfa[j]) * fa[j];
        }
        s1 += e1.s * Math.Sin(a) + e1.c * Math.Cos(a);

        eect = (s0 + s1 * t) * Constants.DAS2R;

        return eect;
    }

    /// <summary>
    /// Earth rotation angle (IAU 2000 model).
    /// SOFA name: iauEra00
    /// </summary>
    /// <param name="ut1JulianDate"></param>
    /// <returns></returns>
    public static double EarthRotationAngleIAU00(JulianDate ut1JulianDate)
    {
        ThrowHelper.ThrowIfNotExpectedJulianDateKind(JulianDateKind.Ut1, ut1JulianDate);

        double d1, d2, t, f, theta;

        var (dj1, dj2) = ut1JulianDate;

        /* Days since fundamental epoch. */
        if (dj1 < dj2)
        {
            d1 = dj1;
            d2 = dj2;
        }
        else
        {
            d1 = dj2;
            d2 = dj1;
        }
        t = d1 + (d2 - Constants.DJ00);

        /* Fractional part of T (days). */
        f = (d1 % 1.0) + (d2 % 1.0);

        /* Earth rotation angle at this UT1. */
        theta = MathHelper.NormalizeAngleIntoZero2PI(
            Constants.PI2 * (f + 0.7790572732640 + 0.00273781191135448 * t));

        return theta;
    }

}
