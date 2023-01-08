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

}
