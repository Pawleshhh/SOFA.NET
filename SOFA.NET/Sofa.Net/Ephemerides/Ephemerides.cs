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
                Matrix<double>.FromFlatArray(2, 3, pvh),
                Matrix<double>.FromFlatArray(2, 3, pvb)),
            _ => throw new ArgumentException("Date outside the range 1900 - 2100 AD")
        };
    }

}
