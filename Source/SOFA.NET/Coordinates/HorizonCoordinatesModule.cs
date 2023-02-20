namespace SOFA.NET;

public static partial class CoordinatesModule
{

    /// <summary>
    /// Horizon to equatorial coordinates:  transform azimuth and altitude
    /// to hour angle and declination.
    /// </summary>
    /// <param name="horizonCoordinates"></param>
    /// <param name="siteLatitude"></param>
    /// <returns></returns>
    public static HourAngleCoordinates HorizonToHourAngleCoordinates(
        HorizonCoordinates horizonCoordinates,
        double siteLatitude)
    {
        double sa, ca, se, ce, sp, cp, x, y, z, r;
        var (el, az) = horizonCoordinates;

        sa = Math.Sin(az);
        ca = Math.Cos(az);
        se = Math.Sin(el);
        ce = Math.Cos(el);
        sp = Math.Sin(siteLatitude);
        cp = Math.Cos(siteLatitude);

        /* HA,Dec unit vector. */
        x = -ca * ce * sp + se * cp;
        y = -sa * ce;
        z = ca * ce * cp + se * sp;

        /* To spherical. */
        r = Math.Sqrt(x * x + y * y);
        
        var ha = (r != 0.0) ? Math.Atan2(y, x) : 0.0;
        var dec = Math.Atan2(z, r);

        return new(dec, ha);
    }

}
