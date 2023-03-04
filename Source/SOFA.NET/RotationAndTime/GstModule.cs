namespace SOFA.NET;

public static class GstModule
{

    /// <summary>
    /// Universal Time to Greenwich mean sidereal time (IAU 1982 model).
    /// SOFA name: iauGmst82
    /// </summary>
    /// <param name="ut1JulianDate"></param>
    /// <returns></returns>
    public static double GreenwichMeanSiderealTimeIAU82(JulianDate ut1JulianDate)
    {
        ThrowHelper.ThrowIfNotExpectedJulianDateKind(JulianDateKind.Ut1, ut1JulianDate);

        /* Coefficients of IAU 1982 GMST-UT1 model */
        double A = 24110.54841 - Constants.DAYSEC / 2.0;
        double B = 8640184.812866;
        double C = 0.093104;
        double D = -6.2e-6;

        /* The first constant, A, has to be adjusted by 12 hours because the */
        /* UT1 is supplied as a Julian date, which begins at noon.           */

        double d1, d2, t, f, gmst;

        var (dj1, dj2) = ut1JulianDate;

        /* Julian centuries since fundamental epoch. */
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
        t = (d1 + (d2 - Constants.DJ00)) / Constants.DJC;

        /* Fractional part of JD(UT1), in seconds. */
        f = Constants.DAYSEC * ((d1 % 1.0) + (d2 % 1.0));

        /* GMST at this UT1. */
        gmst = MathHelper.NormalizeAngleIntoZero2PI(Constants.DS2R * ((A + (B + (C + D * t) * t) * t) + f));

        return gmst;
    }

    /// <summary>
    /// Greenwich mean sidereal time (model consistent with IAU 2000
    /// resolutions).
    /// SOFA name: iauGmst00
    /// </summary>
    /// <param name="ut1JulianDate"></param>
    /// <param name="ttJulianDate"></param>
    /// <returns></returns>
    public static double GreenwichMeanSiderealTimeIAU00(JulianDate ut1JulianDate, JulianDate ttJulianDate) 
    {
        ThrowHelper.ThrowIfNotExpectedJulianDateKind(JulianDateKind.Ut1, ut1JulianDate);
        ThrowHelper.ThrowIfNotExpectedJulianDateKind(JulianDateKind.Tt, ttJulianDate);

        double t, gmst;

        /* TT Julian centuries since J2000.0. */
        t = ttJulianDate.JulianCentury();

        /* Greenwich Mean Sidereal Time, IAU 2000. */
        gmst = MathHelper.NormalizeAngleIntoZero2PI(EquinoxModule.EarthRotationAngleIAU00(ut1JulianDate) +
                        (0.014506 +
                        (4612.15739966 +
                        (1.39667721 +
                        (-0.00009344 +
                        (0.00001882)
               * t) * t) * t) * t) * Constants.DAS2R);

        return gmst;
    }

    /// <summary>
    /// Greenwich mean sidereal time (consistent with IAU 2006 precession).
    /// SOFA name: iauGmst06
    /// </summary>
    /// <param name="ut1JulianDate"></param>
    /// <param name="ttJulianDate"></param>
    /// <returns></returns>
    public static double GreenwichMeanSiderealTimeIAU06(JulianDate ut1JulianDate, JulianDate ttJulianDate)
    {
        ThrowHelper.ThrowIfNotExpectedJulianDateKind(JulianDateKind.Ut1, ut1JulianDate);
        ThrowHelper.ThrowIfNotExpectedJulianDateKind(JulianDateKind.Tt, ttJulianDate);

        double t, gmst;

        /* TT Julian centuries since J2000.0. */
        t = ttJulianDate.JulianCentury();

        /* Greenwich mean sidereal time, IAU 2006. */
        gmst = MathHelper.NormalizeAngleIntoZero2PI(EquinoxModule.EarthRotationAngleIAU00(ut1JulianDate) +
                       (0.014506 +
                       (4612.156534 +
                       (1.3915817 +
                       (-0.00000044 +
                       (-0.000029956 +
                       (-0.0000000368)
               * t) * t) * t) * t) * t) * Constants.DAS2R);

        return gmst;
    }

    /// <summary>
    /// Greenwich apparent sidereal time (consistent with IAU 1982/94
    /// resolutions).
    /// SOFA name: iauGst94
    /// </summary>
    /// <param name="ut1JulianDate"></param>
    /// <returns></returns>
    public static double GreenwichSiderealTimeIAU94(JulianDate ut1JulianDate)
    {
        ThrowHelper.ThrowIfNotExpectedJulianDateKind(JulianDateKind.Ut1, ut1JulianDate);

        double gmst82, eqeq94, gst;

        gmst82 = GreenwichMeanSiderealTimeIAU82(ut1JulianDate);
        var (uta, utb) = ut1JulianDate;
        eqeq94 = EquinoxModule.EquationOfEquinoxesIAU94(new(uta, utb));
        gst = MathHelper.NormalizeAngleIntoZero2PI(gmst82 + eqeq94);

        return gst;
    }

    /// <summary>
    /// Greenwich apparent sidereal time (consistent with IAU 2000
    /// resolutions).
    /// SOFA name: iauGst00a
    /// </summary>
    /// <param name="ut1JulianDate"></param>
    /// <param name="ttJulianDate"></param>
    /// <returns></returns>
    public static double GreenwichSiderealTimeIAU00a(JulianDate ut1JulianDate, JulianDate ttJulianDate)
    {
        ThrowHelper.ThrowIfNotExpectedJulianDateKind(JulianDateKind.Ut1, ut1JulianDate);
        ThrowHelper.ThrowIfNotExpectedJulianDateKind(JulianDateKind.Tt, ttJulianDate);

        double gmst00, ee00a, gst;

        gmst00 = GreenwichMeanSiderealTimeIAU00(ut1JulianDate, ttJulianDate);
        ee00a = EquinoxModule.EquationOfEquinoxesIAU00a(ttJulianDate);
        gst = MathHelper.NormalizeAngleIntoZero2PI(gmst00 + ee00a);

        return gst;
    }

    /// <summary>
    /// Greenwich apparent sidereal time (consistent with IAU 2000
    /// resolutions but using the truncated nutation model IAU 2000B).
    /// SOFA name: iauGst00b
    /// </summary>
    /// <param name="ut1JulianDate"></param>
    /// <returns></returns>
    public static double GreenwichSiderealTimeIAU00b(JulianDate ut1JulianDate)
    {
        ThrowHelper.ThrowIfNotExpectedJulianDateKind(JulianDateKind.Ut1, ut1JulianDate);

        double gmst00, ee00b, gst;

        var (uta, utb) = ut1JulianDate;
        var jd = new JulianDate(uta, utb);
        gmst00 = GreenwichMeanSiderealTimeIAU00(ut1JulianDate, jd);
        ee00b = EquinoxModule.EquationOfEquinoxesIAU00b(jd);
        gst = MathHelper.NormalizeAngleIntoZero2PI(gmst00 + ee00b);

        return gst;
    }

    /// <summary>
    /// Greenwich apparent sidereal time, IAU 2006, given the NPB matrix.
    /// SOFA name: iauGst06
    /// </summary>
    /// <param name="ut1JulianDate"></param>
    /// <param name="ttJulianDate"></param>
    /// <param name="rnpb"></param>
    /// <returns></returns>
    //public static double GreenwichSiderealTimeIAU06(JulianDate ut1JulianDate, JulianDate ttJulianDate, double[,] rnpb)
    //{
    //    ThrowHelper.ThrowIfNotExpectedJulianDateKind(JulianDateKind.Ut1, ut1JulianDate);
    //    ThrowHelper.ThrowIfNotExpectedJulianDateKind(JulianDateKind.Tt, ttJulianDate);

    //    double s, era, eors, gst;

    //    /* Extract CIP coordinates. */
    //    var cipCoords = PrecNutPolarModule.ExtractXYOfCelestialIntermediatePole(rnpb);

    //    /* The CIO locator, s. */
    //    s = PrecNutPolarModule.CIOLocatorS(ttJulianDate, cipCoords);

    //    /* Greenwich apparent sidereal time. */
    //    era = EquinoxModule.EarthRotationAngleIAU00(ut1JulianDate);
    //    eors = iauEors(rnpb, s);
    //    gst = MathHelper.NormalizeAngleIntoZero2PI(era - eors);

    //    return gst;
    //}

}
