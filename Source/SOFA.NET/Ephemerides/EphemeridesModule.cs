using static System.Math;

namespace SOFA.NET;

public static class EphemeridesModule
{

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

}
