using System.Security.Cryptography;

namespace SOFA.NET;

public static class CalendarsModule
{
    /// <summary>
    /// Gregorian Calendar to Julian Date.
    /// SOFA name: iauCal2jd
    /// </summary>
    /// <param name="dateTime">Date time as gregorian calendar</param>
    /// <returns>Returns Modified Julian Date for 0 hours</returns>
    public static JulianDate GregorianCalendarToJulianDate(DateTime dateTime)
    {
        int my;
        long iypmy;
        int iy = dateTime.Year,
            im = dateTime.Month,
            id = dateTime.Day;

        // Return result
        my = (im - 14) / 12;
        iypmy = iy + my;
        double result = ((1461L * (iypmy + 4800L)) / 4L
                + (367L * (im - 2 - 12 * my)) / 12L
                - (3L * ((iypmy + 4900L) / 100L)) / 4L
                + id - 2432076L);

        return new(result + Constants.DJM0);
    }

    /// <summary>
    /// Julian Date to Gregorian Calendar
    /// SOFA name: iauJd2cal
    /// </summary>
    /// <param name="julianDate">Julian date</param>
    /// <returns>Returns date time as gregorian calendar</returns>
    public static DateTime JulianDateToGregorianCalendar(JulianDate julianDate)
    {
        long jd, i, l, n, k;
        double f1, f2, d, s, cs, x, t, f;
        double[] v = new double[2];
        var (dj1, dj2) = julianDate;

        // Separate day and fraction (where -0.5 <= fraction < 0.5).
        d = Math.Round(dj1);
        f1 = dj1 - d;
        jd = (long)d;
        d = Math.Round(dj2);
        f2 = dj2 - d;
        jd += (long)d;

        // Compute f1+f2+0.5 using compensated summation (Klein 2006).
        s = 0.5;
        cs = 0.0;
        v[0] = f1;
        v[1] = f2;
        for (i = 0; i < 2; i++)
        {
            x = v[i];
            t = s + x;
            cs += Math.Abs(s) >= Math.Abs(x) ? (s - t) + x : (x - t) + s;
            s = t;
            if (s >= 1.0)
            {
                jd++;
                s -= 1.0;
            }
        }
        f = s + cs;
        cs = f - s;

        // Deal with negative f.
        if (f < 0.0)
        {
            // Compensated summation: assume that |s| <= 1.0.
            f = s + 1.0;
            cs += (1.0 - f) + s;
            s = f;
            f = s + cs;
            cs = f - s;
            jd--;
        }

        // Deal with f that is 1.0 or more (when rounded to double).
        if ((f - 1.0) >= -double.Epsilon / 4.0)
        {
            // Compensated summation: assume that |s| <= 1.0.
            t = s - 1.0;
            cs += (s - t) - 1.0;
            s = t;
            f = s + cs;
            if (-double.Epsilon / 2.0 < f)
            {
                jd++;
                f = Math.Max(f, 0.0);
            }
        }

        // Express day in Gregorian calendar.
        l = jd + 68569L;
        n = (4L * l) / 146097L;
        l -= (146097L * n + 3L) / 4L;
        i = (4000L * (l + 1L)) / 1461001L;
        l -= (1461L * i) / 4L - 31L;
        k = (80L * l) / 2447L;
        int id = (int)(l - (2447L * k) / 80L);
        l = k / 11L;
        int im = (int)(k + 2L - 12L * l);
        int iy = (int)(100L * (n - 49L) + i + l);

        return new DateTime(iy, im, id).AddDays(f);
    }

    /// <summary>
    /// Julian Date to Besselian Epoch
    /// SOFA name: iauEpb
    /// </summary>
    /// <param name="julianDate">Julian date</param>
    /// <returns>Besselian Epoch</returns>
    public static double JulianDateToBesselianEpoch(JulianDate julianDate)
    {
        // J2000.0-B1900.0 (2415019.81352) in days
        const double D1900 = 36524.68648;
        return 1900.0
            + ((julianDate.DayNumber - Constants.DJ00)
            + (julianDate.FractionOfDay + D1900)) / Constants.DTY;
    }

    /// <summary>
    /// Besselian Epoch to Julian Date.
    /// SOFA name: iauEpb2jd
    /// </summary>
    /// <param name="besselianEpoch">Besselian epoch</param>
    /// <returns>Julian date</returns>
    public static JulianDate BesselianEpochToJulianDate(double besselianEpoch)
        => new(Constants.DJM0 + (15019.81352 + (besselianEpoch - 1900.0) * Constants.DTY));

    /// <summary>
    /// Julian Date to Julian Epoch.
    /// SOFA name: iauEpj
    /// </summary>
    /// <param name="julianDate">Julian date</param>
    /// <returns>Julian epoch</returns>
    public static double JulianDateToJulianEpoch(JulianDate julianDate)
        => 2000.0 + ((julianDate.DayNumber - Constants.DJ00) / Constants.DJY);

    /// <summary>
    /// Julian Epoch to Julian Date
    /// SOFA name: iauEpj2jd
    /// </summary>
    /// <param name="julianEpoch">Julian epoch</param>
    /// <returns>Julian date</returns>
    public static JulianDate JulianEpochToJulianDate(double julianEpoch)
        => new(Constants.DJM0 + (Constants.DJM00 + (julianEpoch - 2000.0) * 365.25));

}
