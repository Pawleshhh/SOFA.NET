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

    /// <summary>
    /// Approximate geocentric position and velocity of the Moon.
    /// </summary>
    /// <param name="julianDate">TT date.</param>
    /// <returns>Moon p, v, GCRS (au, au/d).</returns>
    public static Matrix<double> ApproximateGeocentricMoonState(JulianDate julianDate)
    {
        var (d1, d2) = julianDate;
        var pv = new double[6];
        SofaEphemerides.Moon98(d1, d2, pv);
        return Matrix<double>.FromFlatArray(2, 3, pv);
    }

    /// <summary>
    /// Approximate heliocentric position and velocity of a nominated
    /// planet:  Mercury, Venus, EMB, Mars, Jupiter, Saturn, Uranus or
    /// Neptune (but not the Earth itself).
    /// </summary>
    /// <param name="julianDate">TDB date.</param>
    /// <param name="planet">Planet.</param>
    /// <returns>Planet p, v (heliocentric, J2000.0, au, au/d).</returns>
    /// <exception cref="ArgumentException">Invalid planet value.</exception>
    public static SofaData<Matrix<double>> ApproximatePlanetState(JulianDate julianDate, Planet planet)
    {
        var (d1, d2) = julianDate;
        var pv = new double[6];
        var result = SofaEphemerides.Plan94(d1, d2, (int)planet, pv);
        var matrix = Matrix<double>.FromFlatArray(2, 3, pv);
        return result switch
        {
            0 => new(matrix),
            1 => new(matrix, "Year outside 1000-3000"),
            2 => new(matrix, "Failed to converge"),
            _ => throw new ArgumentException("Invalid planet value."),
        };
    }

}
