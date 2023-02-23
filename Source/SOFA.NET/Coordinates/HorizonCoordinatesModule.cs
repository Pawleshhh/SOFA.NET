namespace SOFA.NET;

public static partial class CoordinatesModule
{

    /// <summary>
    /// Horizon to equatorial coordinates:  transform azimuth and altitude
    /// to hour angle and declination.
    /// SOFA name: iauAe2hd
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

    /// <summary>
    /// Equatorial to horizon coordinates:  transform hour angle and
    /// declination to azimuth and altitude.
    /// SOFA name: iauHd2ae
    /// </summary>
    /// <param name="hourAngleCoordinates"></param>
    /// <param name="siteLatitude"></param>
    /// <returns></returns>
    public static HorizonCoordinates HourAngleToHorizonCoordinates(
        HourAngleCoordinates hourAngleCoordinates,
        double siteLatitude)
    {
        double sh, ch, sd, cd, sp, cp, x, y, z, r;
        var (dec, ha) = hourAngleCoordinates;

        sh = Math.Sin(ha);
        ch = Math.Cos(ha);
        sd = Math.Sin(dec);
        cd = Math.Cos(dec);
        sp = Math.Sin(siteLatitude);
        cp = Math.Cos(siteLatitude);

        /* Az,Alt unit vector. */
        x = -ch * cd * sp + sd * cp;
        y = -sh * cd;
        z = ch * cd * cp + sd * sp;

        /* To spherical. */
        r = Math.Sqrt(x * x + y * y);
        double a = (r != 0.0) ? Math.Atan2(y, x) : 0.0;
        var az = (a < 0.0) ? a + Constants.PI2 : a;
        var el = Math.Atan2(z, r);

        return new(el, az);
    }

    /// <summary>
    /// Parallactic angle for a given hour angle and declination.
    /// SOFA name: iauHd2pa
    /// </summary>
    /// <param name="hourAngle"></param>
    /// <param name="declination"></param>
    /// <param name="siteLatitude"></param>
    /// <returns></returns>
    public static double ParallacticAngle(
        double hourAngle,
        double declination,
        double siteLatitude)
    {
        double cp, cqsz, sqsz;

        cp = Math.Cos(siteLatitude);
        sqsz = cp * Math.Sin(hourAngle);
        cqsz = Math.Sin(siteLatitude) * Math.Cos(declination) - cp * Math.Sin(declination) * Math.Cos(hourAngle);

        return ((sqsz != 0.0 || cqsz != 0.0) ? Math.Atan2(sqsz, cqsz) : 0.0);
    }

}
