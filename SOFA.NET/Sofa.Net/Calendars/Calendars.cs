namespace SOFA.NET;

/// <summary>
/// SOFA calendar and time related algorithms.
/// </summary>
public class Calendars
{
    /// <summary>
    /// Days per Julian year.
    /// </summary>
    public const double DaysPerJulianYear = 365.25;
    /// <summary>
    /// Days per Julian century.
    /// </summary>
    public const double DaysPerJulianCentury = 36525.0;
    /// <summary>
    /// Days per Julian millenium.
    /// </summary>
    public const double DaysPerJulianMillennium = 365250.0;

    /// <summary>
    /// Reference epoch (J2000.0), Julian Date
    /// </summary>
    public static readonly JulianDate J2000_0 = new(2451545.0);

    /// <summary>
    /// Converts Gregorian Calendar to Julian Date.
    /// </summary>
    /// <param name="date">Year, month, day in Gregorian calendar.</param>
    /// <returns>Julian Date of given Gregorian Calendar date.</returns>
    /// <exception cref="ArgumentException">Thrown when date is invalid or cannot be converted to Julian Date.</exception>
    public static JulianDate GregorianDateToJulianDate(DateOnly date)
    {
        double djm0 = 0, djm = 0;
        return SofaCalendars.Cal2jd(date.Year, date.Month, date.Day, ref djm0, ref djm) switch
        {
            0 => new JulianDate(djm0 + djm),
            _ => throw new ArgumentException("Invalid date")
        };
    }

    /// <summary>
    /// Converts Julian Date to Besselian Epoch.
    /// </summary>
    /// <param name="julianDate">Julian Date to be converted.</param>
    /// <returns>Besselian Epoch.</returns>
    public static double JulianDateToBesselianEpoch(JulianDate julianDate)
    {
        return SofaCalendars.Epb(julianDate.DayNumber, julianDate.FractionOfDay);
    }

    /// <summary>
    /// Besselian Epoch to Julian Date.
    /// </summary>
    /// <param name="besselianEpoch">Besselian Epoch to be converted.</param>
    /// <returns>Julian Date.</returns>
    public static JulianDate BesselianEpochToJulianDate(double besselianEpoch)
    {
        double djm0 = 0, djm = 0;
        SofaCalendars.Epb2jd(besselianEpoch, ref djm0, ref djm);
        return new(djm0 + djm);
    }

    /// <summary>
    /// Julian Date to Julian Epoch.
    /// </summary>
    /// <param name="julianDate">Julian Date to be converted.</param>
    /// <returns>Julian Epoch.</returns>
    public static double JulianDateToJulianEpoch(JulianDate julianDate)
    {
        return SofaCalendars.Epj(julianDate.DayNumber, julianDate.FractionOfDay);
    }

    /// <summary>
    /// Julian Epoch to Julian Date.
    /// </summary>
    /// <param name="julianEpoch">Julian Epoch to be converted.</param>
    /// <returns>Julian Date.</returns>
    public static JulianDate JulianEpochToJulianDate(double julianEpoch)
    {
        double djm0 = 0, djm = 0;
        SofaCalendars.Epj2jd(julianEpoch, ref djm0, ref djm);
        return new(djm0 + djm);
    }

    /// <summary>
    /// Julian Date to Gregorian Calendar Date Time.
    /// </summary>
    /// <param name="julianDate">Julian Date to be converted.</param>
    /// <returns>Gregorian Calendar Date Time.</returns>
    /// <exception cref="ArgumentException">Date is unacceptable.</exception>
    public static DateTime JulianDateToGregorianDateTime(JulianDate julianDate)
    {
        int y = 0, m = 0, d = 0;
        double f = 0;
        return SofaCalendars.Jd2cal(
            julianDate.DayNumber,
            julianDate.FractionOfDay,
            ref y,
            ref m,
            ref d,
            ref f) switch
        {
            0 => new DateTime(y, m, d).AddDays(f),
            _ => throw new ArgumentException("Invalid Julian Date")
        };
    }

}
