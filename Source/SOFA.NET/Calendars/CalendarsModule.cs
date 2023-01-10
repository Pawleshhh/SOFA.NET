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
    /// </summary>
    /// <param name="julianEpoch">Julian epoch</param>
    /// <returns>Julian date</returns>
    public static JulianDate JulianEpochToJulianDate(double julianEpoch)
        => new(Constants.DJM0 + (Constants.DJM00 + (julianEpoch - 2000.0) * 365.25));

}
