using static System.Math;
using EpvHelper = SOFA.NET.EarthPositionVelocityCoefficients;

namespace SOFA.NET;

public static class EphemeridesModule
{

    #region EarthPositionVelocity

    public readonly struct EarthPositionVelocityResult
    {
        public required double[] HeliocentricPosition { get; init; }
        public required double[] HeliocentricVelocity { get; init; }
        public required double[] BarycentricPosition { get; init; }
        public required double[] BarycentricVelocity { get; init; }

        public bool DateOutsideRange { get; init; }
    }

    /// <summary>
    /// Earth position and velocity, heliocentric and barycentric, with
    /// respect to the Barycentric Celestial Reference System.
    /// SOFA name: iauEpv00
    /// </summary>
    /// <param name="julianDate"></param>
    /// <returns></returns>
    public static EarthPositionVelocityResult EarthPositionVelocity(JulianDate julianDate)
    {
        ThrowHelper.ThrowIfNotExpectedJulianDateKind(JulianDateKind.Tdb, julianDate);

        const double am12 = 0.000000211284 , am13 = -0.000000091603,
                     am21 = -0.000000230286, am22 = 0.917482137087 , am23 = -0.397776982902,
                     am32 = 0.397776982902 , am33 = 0.917482137087;

        int[] ne0 = GetArraysLengths(EpvHelper.e0x, EpvHelper.e0y, EpvHelper.e0z),
              ne1 = GetArraysLengths(EpvHelper.e1x, EpvHelper.e1y, EpvHelper.e1z),
              ne2 = GetArraysLengths(EpvHelper.e2x, EpvHelper.e2y, EpvHelper.e2z),
              ns0 = GetArraysLengths(EpvHelper.s0x, EpvHelper.s0y, EpvHelper.s0z),
              ns1 = GetArraysLengths(EpvHelper.s1x, EpvHelper.s1y, EpvHelper.s1z),
              ns2 = GetArraysLengths(EpvHelper.s2x, EpvHelper.s2y, EpvHelper.s2z);

        int[] GetArraysLengths(params Lazy<double[]>[] arrays)
            => arrays.Select(x => x.Value.Length / 3).ToArray();

        double[][] 
            ce0 = new[] { EpvHelper.e0x.Value, EpvHelper.e0y.Value, EpvHelper.e0z.Value },
            ce1 = new[] { EpvHelper.e1x.Value, EpvHelper.e1y.Value, EpvHelper.e1z.Value },
            ce2 = new[] { EpvHelper.e2x.Value, EpvHelper.e2y.Value, EpvHelper.e2z.Value },
            cs0 = new[] { EpvHelper.s0x.Value, EpvHelper.s0y.Value, EpvHelper.s0z.Value },
            cs1 = new[] { EpvHelper.s1x.Value, EpvHelper.s1y.Value, EpvHelper.s1z.Value },
            cs2 = new[] { EpvHelper.s2x.Value, EpvHelper.s2y.Value, EpvHelper.s2z.Value };

        int jstat, i, j, nterms, k = 0;
        double t, t2, xyz, xyzd, a, b, c, ct, p, cp, x, y, z;
        double[] ph = new double[3],
            vh = new double[3],
            pb = new double[3],
            vb = new double[3];
        double[] coeffs;

        /* Time since reference epoch, Julian years. */
        t = julianDate.JulianYear(Constants.DJ00);
        t2 = t * t;

        /* Set status. */
        jstat = Abs(t) <= 100.0 ? 0 : 1;

        /* X then Y then Z. */
        for (i = 0; i < 3; i++)
        {
            /* Initialize position and velocity component. */
            xyz = 0.0;
            xyzd = 0.0;

            /* ------------------------------------------------ */
            /* Obtain component of Sun to Earth ecliptic vector */
            /* ------------------------------------------------ */

            /* Sun to Earth, T^0 terms. */
            coeffs = ce0[i];
            k = 0;
            nterms = ne0[i];
            for (j = 0; j < nterms; j++)
            {
                a = coeffs[k++];
                b = coeffs[k++];
                c = coeffs[k++];
                p = b + c * t;
                xyz += a * Cos(p);
                xyzd -= a * c * Sin(p);
            }

            /* Sun to Earth, T^1 terms. */
            coeffs = ce1[i];
            k = 0;
            nterms = ne1[i];
            for (j = 0; j < nterms; j++)
            {
                a = coeffs[k++];
                b = coeffs[k++];
                c = coeffs[k++];
                ct = c * t;
                p = b + ct;
                cp = Cos(p);
                xyz += a * t * cp;
                xyzd += a * (cp - ct * Sin(p));
            }

            /* Sun to Earth, T^2 terms. */
            coeffs = ce2[i];
            k = 0;
            nterms = ne2[i];
            for (j = 0; j < nterms; j++)
            {
                a = coeffs[k++];
                b = coeffs[k++];
                c = coeffs[k++];
                ct = c * t;
                p = b + ct;
                cp = Cos(p);
                xyz += a * t2 * cp;
                xyzd += a * t * (2.0 * cp - ct * Sin(p));
            }

            /* Heliocentric Earth position and velocity component. */
            ph[i] = xyz;
            vh[i] = xyzd / Constants.DJY;

            /* ------------------------------------------------ */
            /* Obtain component of SSB to Earth ecliptic vector */
            /* ------------------------------------------------ */

            /* SSB to Sun, T^0 terms. */
            coeffs = cs0[i];
            k = 0;
            nterms = ns0[i];
            for (j = 0; j < nterms; j++)
            {
                a = coeffs[k++];
                b = coeffs[k++];
                c = coeffs[k++];
                p = b + c * t;
                xyz += a * Cos(p);
                xyzd -= a * c * Sin(p);
            }

            /* SSB to Sun, T^1 terms. */
            coeffs = cs1[i];
            k = 0;
            nterms = ns1[i];
            for (j = 0; j < nterms; j++)
            {
                a = coeffs[k++];
                b = coeffs[k++];
                c = coeffs[k++];
                ct = c * t;
                p = b + ct;
                cp = Cos(p);
                xyz += a * t * cp;
                xyzd += a * (cp - ct * Sin(p));
            }

            /* SSB to Sun, T^2 terms. */
            coeffs = cs2[i];
            k = 0;
            nterms = ns2[i];
            for (j = 0; j < nterms; j++)
            {
                a = coeffs[k++];
                b = coeffs[k++];
                c = coeffs[k++];
                ct = c * t;
                p = b + ct;
                cp = Cos(p);
                xyz += a * t2 * cp;
                xyzd += a * t * (2.0 * cp - ct * Sin(p));
            }

            /* Barycentric Earth position and velocity component. */
            pb[i] = xyz;
            vb[i] = xyzd / Constants.DJY;

            /* Next Cartesian component. */
        }

        /* Rotate from ecliptic to BCRS coordinates. */

        var heliocentricPosition = new double[3];

        x = ph[0];
        y = ph[1];
        z = ph[2];
        heliocentricPosition[0] = x + am12 * y + am13 * z;
        heliocentricPosition[1] = am21 * x + am22 * y + am23 * z;
        heliocentricPosition[2] = am32 * y + am33 * z;

        var heliocentricVelocity = new double[3];
        x = vh[0];
        y = vh[1];
        z = vh[2];
        heliocentricVelocity[0] = x + am12 * y + am13 * z;
        heliocentricVelocity[1] = am21 * x + am22 * y + am23 * z;
        heliocentricVelocity[2] = am32 * y + am33 * z;

        var barycentricPosition = new double[3];
        x = pb[0];
        y = pb[1];
        z = pb[2];
        barycentricPosition[0] = x + am12 * y + am13 * z;
        barycentricPosition[1] = am21 * x + am22 * y + am23 * z;
        barycentricPosition[2] = am32 * y + am33 * z;

        var barycentricVelocity = new double[3];
        x = vb[0];
        y = vb[1];
        z = vb[2];
        barycentricVelocity[0] = x + am12 * y + am13 * z;
        barycentricVelocity[1] = am21 * x + am22 * y + am23 * z;
        barycentricVelocity[2] = am32 * y + am33 * z;

        return new()
        {
            HeliocentricPosition = heliocentricPosition,
            HeliocentricVelocity = heliocentricVelocity,
            BarycentricPosition = barycentricPosition,
            BarycentricVelocity = barycentricVelocity,
            DateOutsideRange = jstat == 1
        };
    }

    #endregion

    #region ApproximateHeliocentricPositionAndVelocity

    /// <summary>
    /// Approximate heliocentric position and velocity of a nominated major
    /// planet:  Mercury, Venus, EMB (<see cref="Planet.Earth"/>), Mars, Jupiter, Saturn, Uranus or
    /// Neptune (but not the Earth itself).
    /// SOFA name: iauPlan94
    /// </summary>
    /// <param name="tdbJulianDate"></param>
    /// <param name="planet"></param>
    /// <returns></returns>
    public static double[,] ApproximateHeliocentricPositionAndVelocity(JulianDate tdbJulianDate, Planet planet)
    {
        ThrowHelper.ThrowIfNotExpectedJulianDateKind(JulianDateKind.Tdb, tdbJulianDate);

        /* Gaussian constant */
        const double GK = 0.017202098950;
        /* Sin and cos of J2000.0 mean obliquity (IAU 1976) */
        const double SINEPS = 0.3977771559319137;
        const double COSEPS = 0.9174820620691818;
        /* Maximum number of iterations allowed to solve Kepler's equation */
        const int KMAX = 10;

        double t, da, dl, de, dp, di, dom, dmu, arga, argl, am,
          ae, dae, ae2, at, r, v, si2, xq, xp, tl, xsw,
          xcw, xm2, xf, ci2, xms, xmc, xpxq2, x, y, z;
        double[,] pv = new double[2, 3];

        var amas = planet.GetPlanetaryInverseMass();
        var a = planet.GetSemiMajorAxis();
        var dlm = planet.GetMeanLongitude();
        var e = planet.GetEccentricity();
        var pi = planet.GetLongitudeOfPerihelion();
        var dinc = planet.GetInclination();
        var omega = planet.GetLongitudeOfAscendingNode();
        var kp = planet.GetKp();
        var ca = planet.GetCa();
        var sa = planet.GetSa();
        var kq = planet.GetKq();
        var cl = planet.GetCl();
        var sl = planet.GetSl();

        /* Time: Julian millennia since J2000.0. */
        t = tdbJulianDate.JulianMillenium();

        /* Compute the mean elements. */
        da = a[0] +
            (a[1] +
             a[2] * t) * t;
        dl = (3600.0 * dlm[0] +
                      (dlm[1] +
                       dlm[2] * t) * t) * Constants.DAS2R;
        de = e[0] +
           (e[1] +
             e[2] * t) * t;
        dp = MathHelper.NormalizeAngleIntoMinusOnePIToPlusOnePI((3600.0 * pi[0] +
                              (pi[1] +
                               pi[2] * t) * t) * Constants.DAS2R);
        di = (3600.0 * dinc[0] +
                      (dinc[1] +
                       dinc[2] * t) * t) * Constants.DAS2R;
        dom = MathHelper.NormalizeAngleIntoMinusOnePIToPlusOnePI((3600.0 * omega[0] +
                               (omega[1] +
                                omega[2] * t) * t) * Constants.DAS2R);

        /* Apply the trigonometric terms. */
        dmu = 0.35953620 * t;
        for (int k = 0; k < 8; k++)
        {
            arga = kp[k] * dmu;
            argl = kq[k] * dmu;
            da += (ca[k] * Cos(arga) +
                   sa[k] * Sin(arga)) * 1e-7;
            dl += (cl[k] * Cos(argl) +
                   sl[k] * Sin(argl)) * 1e-7;
        }
        arga = kp[8] * dmu;
        da += t * (ca[8] * Cos(arga) +
                   sa[8] * Sin(arga)) * 1e-7;
        for (int k = 8; k < 10; k++)
        {
            argl = kq[k] * dmu;
            dl += t * (cl[k] * Cos(argl) +
                       sl[k] * Sin(argl)) * 1e-7;
        }
        dl = dl % Constants.PI2;

        /* Iterative soln. of Kepler's equation to get eccentric anomaly. */
        am = dl - dp;
        ae = am + de * Sin(am);
        int j = 0;
        dae = 1.0;
        while (j < KMAX && Abs(dae) > 1e-12)
        {
            dae = (am - ae + de * Sin(ae)) / (1.0 - de * Cos(ae));
            ae += dae;
            j++;
        }

        /* True anomaly. */
        ae2 = ae / 2.0;
        at = 2.0 * Atan2(Sqrt((1.0 + de) / (1.0 - de)) * Sin(ae2),
                                                         Cos(ae2));

        /* Distance (au) and speed (radians per day). */
        r = da * (1.0 - de * Cos(ae));
        v = GK * Sqrt((1.0 + 1.0 / amas) / (da * da * da));

        si2 = Sin(di / 2.0);
        xq = si2 * Cos(dom);
        xp = si2 * Sin(dom);
        tl = at + dp;
        xsw = Sin(tl);
        xcw = Cos(tl);
        xm2 = 2.0 * (xp * xcw - xq * xsw);
        xf = da / Sqrt(1 - de * de);
        ci2 = Cos(di / 2.0);
        xms = (de * Sin(dp) + xsw) * xf;
        xmc = (de * Cos(dp) + xcw) * xf;
        xpxq2 = 2 * xp * xq;

        /* Position (J2000.0 ecliptic x,y,z in au). */
        x = r * (xcw - xm2 * xp);
        y = r * (xsw + xm2 * xq);
        z = r * (-xm2 * ci2);

        /* Rotate to equatorial. */
        pv[0, 0] = x;
        pv[0, 1] = y * COSEPS - z * SINEPS;
        pv[0, 2] = y * SINEPS + z * COSEPS;

        /* Velocity (J2000.0 ecliptic xdot,ydot,zdot in au/d). */
        x = v * ((-1.0 + 2.0 * xp * xp) * xms + xpxq2 * xmc);
        y = v * ((1.0 - 2.0 * xq * xq) * xmc - xpxq2 * xms);
        z = v * (2.0 * ci2 * (xp * xms + xq * xmc));

        /* Rotate to equatorial. */
        pv[1, 0] = x;
        pv[1, 1] = y * COSEPS - z * SINEPS;
        pv[1, 2] = y * SINEPS + z * COSEPS;

        return pv;
    }

    #endregion

    #region ApproximateGeocentricPositionAndVelocityOfTheMoon

    /* Moon's mean longitude (wrt mean equinox and ecliptic of date) */
    private const double elp0 = 218.31665436, /* Simon et al. (1994). */
        elp1 = 481267.88123421,
        elp2 = -0.0015786,
        elp3 = 1.0 / 538841.0,
        elp4 = -1.0 / 65194000.0;
    /* Moon's mean elongation */
    private const double d0 = 297.8501921,
        d1 = 445267.1114034,
        d2 = -0.0018819,
        d3 = 1.0 / 545868.0,
        d4 = 1.0 / 113065000.0;
    private const double em0 = 357.5291092,
        em1 = 35999.0502909,
        em2 = -0.0001536,
        em3 = 1.0 / 24490000.0,
        em4 = 0.0;
    private const double emp0 = 134.9633964,
        emp1 = 477198.8675055,
        emp2 = 0.0087414,
        emp3 = 1.0 / 69699.0,
        emp4 = -1.0 / 14712000.0;
    private const double f0 = 93.2720950,
        f1 = 483202.0175233,
        f2 = -0.0036539,
        f3 = 1.0 / 3526000.0,
        f4 = 1.0 / 863310000.0;
    private const double a10 = 119.75,
        a11 = 131.849;
    private const double a20 = 53.09,
        a21 = 479264.290;
    private const double a30 = 313.45,
        a31 = 481266.484;
    private const double al1 = 0.003958,
        al2 = 0.001962,
        al3 = 0.000318;
    private const double ab1 = -0.002235,
        ab2 = 0.000382,
        ab3 = 0.000175,
        ab4 = 0.000175,
        ab5 = 0.000127,
        ab6 = -0.000115;
    private const double r0 = 385000560.0;
    private const double e1 = -0.002516,
        e2 = -0.0000074;

    /// <summary>
    /// Approximate geocentric position and velocity of the Moon.
    /// SOFA name: iauMoon98
    /// </summary>
    /// <param name="ttJulianDate"></param>
    /// <returns></returns>
    public static double[,] ApproximateGeocentricPositionAndVelocityOfTheMoon(JulianDate ttJulianDate)
    {
        ThrowHelper.ThrowIfNotExpectedJulianDateKind(JulianDateKind.Tt, ttJulianDate);

        double elp, delp, d, dd,
        /* Sun's mean anomaly */
            em, dem,
        /* Moon's mean anomaly */
            emp, demp,
        /* Mean distance of the Moon from its ascending node */
            f, df,
        /* Meeus A_1, due to Venus (deg) */
            a1, da1,
        /* Meeus A_2, due to Jupiter (deg) */
            a2, da2,
        /* Meeus A_3, due to sidereal motion of the Moon in longitude (deg) */
            a3, da3,
        /* Coefficients for (dimensionless) E factor */
            e, de, esq, desq;

        double t, elpmf, delpmf, vel, vdel, vr, vdr, a1mf, da1mf, a1pf,
               da1pf, dlpmp, slpmp, vb, vdb, v, dv, emn, empn, dn, fn, en,
               den, arg, darg, farg, coeff, el, del, r, dr, b, db;
        int i = 0;

        var tlr = ApproximateGeocentricPositionAndVelocityOfTheMoonCoefficients.LongitudeCoefficients;
        var tb = ApproximateGeocentricPositionAndVelocityOfTheMoonCoefficients.LatitudeCoefficients;

        /* Centuries since J2000.0 */
        t = ttJulianDate.JulianCentury();

        /* --------------------- */
        /* Fundamental arguments */
        /* --------------------- */

        /* Arguments (radians) and derivatives (radians per Julian century)
           for the current date. */

        /* Moon's mean longitude. */
        elp = Constants.DD2R * ((elp0
                        + (elp1
                        + (elp2
                        + (elp3
                        + elp4 * t) * t) * t) * t) % 360.0);
        delp = Constants.DD2R * (elp1
                        + (elp2 * 2.0
                        + (elp3 * 3.0
                        + elp4 * 4.0 * t) * t) * t);

        /* Moon's mean elongation. */
        d = Constants.DD2R * ((d0
                      + (d1
                      + (d2
                      + (d3
                      + d4 * t) * t) * t) * t) % 360.0);
        dd = Constants.DD2R * (d1
                      + (d2 * 2.0
                      + (d3 * 3.0
                      + d4 * 4.0 * t) * t) * t);

        /* Sun's mean anomaly. */
        em = Constants.DD2R * ((em0
                       + (em1
                       + (em2
                       + (em3
                       + em4 * t) * t) * t) * t) % 360.0);
        dem = Constants.DD2R * (em1
                       + (em2 * 2.0
                       + (em3 * 3.0
                       + em4 * 4.0 * t) * t) * t);

        /* Moon's mean anomaly. */
        emp = Constants.DD2R * ((emp0
                        + (emp1
                        + (emp2
                        + (emp3
                        + emp4 * t) * t) * t) * t) % 360.0);
        demp = Constants.DD2R * (emp1
                        + (emp2 * 2.0
                        + (emp3 * 3.0
                        + emp4 * 4.0 * t) * t) * t);

        /* Mean distance of the Moon from its ascending node. */
        f = Constants.DD2R * ((f0
                      + (f1
                      + (f2
                      + (f3
                      + f4 * t) * t) * t) * t) % 360.0);
        df = Constants.DD2R * (f1
                      + (f2 * 2.0
                      + (f3 * 3.0
                      + f4 * 4.0 * t) * t) * t);

        /* Meeus further arguments. */
        a1 = Constants.DD2R * (a10 + a11 * t);
        da1 = Constants.DD2R * al1;
        a2 = Constants.DD2R * (a20 + a21 * t);
        da2 = Constants.DD2R * a21;
        a3 = Constants.DD2R * (a30 + a31 * t);
        da3 = Constants.DD2R * a31;

        /* E-factor, and square. */
        e = 1.0 + (e1 + e2 * t) * t;
        de = e1 + 2.0 * e2 * t;
        esq = e * e;
        desq = 2.0 * e * de;

        /* Use the Meeus additive terms (deg) to start off the summations. */
        elpmf = elp - f;
        delpmf = delp - df;
        vel = al1 * Sin(a1)
            + al2 * Sin(elpmf)
            + al3 * Sin(a2);
        vdel = al1 * Cos(a1) * da1
             + al2 * Cos(elpmf) * delpmf
             + al3 * Cos(a2) * da2;

        vr = 0.0;
        vdr = 0.0;

        a1mf = a1 - f;
        da1mf = da1 - df;
        a1pf = a1 + f;
        da1pf = da1 + df;
        dlpmp = elp - emp;
        slpmp = elp + emp;
        vb = ab1 * Sin(elp)
           + ab2 * Sin(a3)
           + ab3 * Sin(a1mf)
           + ab4 * Sin(a1pf)
           + ab5 * Sin(dlpmp)
           + ab6 * Sin(slpmp);
        vdb = ab1 * Cos(elp) * delp
            + ab2 * Cos(a3) * da3
            + ab3 * Cos(a1mf) * da1mf
            + ab4 * Cos(a1pf) * da1pf
            + ab5 * Cos(dlpmp) * (delp - demp)
            + ab6 * Cos(slpmp) * (delp + demp);

        /* ----------------- */
        /* Series expansions */
        /* ----------------- */

        /* Longitude and distance plus derivatives. */
        for (int n = tlr.Length - 1; n >= 0; n--)
        {
            dn = tlr[n].nd;
            emn = (i = tlr[n].nem);
            empn = tlr[n].nemp;
            fn = tlr[n].nf;
            switch (Abs(i))
            {
                case 1:
                    en = e;
                    den = de;
                    break;
                case 2:
                    en = esq;
                    den = desq;
                    break;
                default:
                    en = 1.0;
                    den = 0.0;
                    break;
            }
            arg = dn * d + emn * em + empn * emp + fn * f;
            darg = dn * dd + emn * dem + empn * demp + fn * df;
            farg = Sin(arg);
            v = farg * en;
            dv = Cos(arg) * darg * en + farg * den;
            coeff = tlr[n].coefl;
            vel += coeff * v;
            vdel += coeff * dv;
            farg = Cos(arg);
            v = farg * en;
            dv = -Sin(arg) * darg * en + farg * den;
            coeff = tlr[n].coefr;
            vr += coeff * v;
            vdr += coeff * dv;
        }
        el = elp + Constants.DD2R * vel;
        del = (delp + Constants.DD2R * vdel) / Constants.DJC;
        r = (vr + r0) / Constants.DAU;
        dr = vdr / Constants.DAU / Constants.DJC;

        /* Latitude plus derivative. */
        for (int n = tb.Length - 1; n >= 0; n--)
        {
            dn = tb[n].nd;
            emn = (i = tb[n].nem);
            empn = tb[n].nemp;
            fn = tb[n].nf;
            switch (Abs(i))
            {
                case 1:
                    en = e;
                    den = de;
                    break;
                case 2:
                    en = esq;
                    den = desq;
                    break;
                default:
                    en = 1.0;
                    den = 0.0;
                    break;
            }
            arg = dn * d + emn * em + empn * emp + fn * f;
            darg = dn * dd + emn * dem + empn * demp + fn * df;
            farg = Sin(arg);
            v = farg * en;
            dv = Cos(arg) * darg * en + farg * den;
            coeff = tb[n].coefb;
            vb += coeff * v;
            vdb += coeff * dv;
        }
        b = vb * Constants.DD2R;
        db = vdb * Constants.DD2R / Constants.DJC;

        /* ------------------------------ */
        /* Transformation into final form */
        /* ------------------------------ */

        /* Longitude, latitude to x, y, z (AU). */
        // el, b, r, del, db, dr
        var pv = CoordinatesModule.SphericalToCartesianPositionAndVelocityCoordinates(
            ICoordinateSystem3D<SphericalCoordinate>.Create(new(el, del), new(b, db), new(r, dr)));

        /* IAU 2006 Fukushima-Williams bias+precession angles. */
        var (gamb, phib, psib, _) = PrecNutPolarModule.PrecessionAnglesIAU06(ttJulianDate);

        /* Mean ecliptic coordinates to GCRS rotation matrix. */
        var rm = MatrixHelper.IdentityMatrix()
            .RotateZ(psib)
            .RotateX(-phib)
            .RotateZ(-gamb);

        /* Rotate the Moon position and velocity into GCRS (Note 6). */
        return MatrixHelper.MultiplyPvVectorByRMatrix(rm, pv);
    }

    #endregion

}
