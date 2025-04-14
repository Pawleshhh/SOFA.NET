namespace SOFA.NET;

internal class Ephemerides
{

    /// <summary>
    /// Earth position and velocity, heliocentric and barycentric, with
    /// respect to the Barycentric Celestial Reference System.
    /// </summary>
    /// <param name="julianDate">TDB date.</param>
    /// <returns>Heliocentric and barycentric position/velocity.</returns>
    /// <exception cref="ArgumentException">Thrown when date is outside the range 1900 - 2100 AD.</exception>
    public static EarthEphemerisStates EarthPositionAndVelocityBCRS(JulianDate julianDate)
    {
        var (d1, d2) = julianDate;
        var pvh = new double[6];
        var pvb = new double[6];
        return SofaEphemerides.Epv00(d1, d2, pvh, pvb) switch
        {
            0 => new EarthEphemerisStates(
                new HeliocentricEarthState(
                    new Vector3<double>(pvh[0], pvh[1], pvh[2]),
                    new Vector3<double>(pvh[3], pvh[4], pvh[5])),
                new BarycentricEarthState(
                    new Vector3<double>(pvb[0], pvb[1], pvb[2]),
                    new Vector3<double>(pvb[3], pvb[4], pvb[5]))),
            _ => throw new ArgumentException("Date outside the range 1900 - 2100 AD")
        };
    }

}
