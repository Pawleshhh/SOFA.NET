namespace SOFA.NET;

public class FundamentalArguments
{

    /// <summary>
    /// Fundamental argument, IERS Conventions (2003):
    /// mean elongation of the Moon from the Sun.
    /// </summary>
    /// <param name="t">TDB, Julian centuries since J2000.0.</param>
    /// <returns>D, radians.</returns>
    public static double MeanElongationOfMoonFromSun(double t)
    { 
        return SofaFundamentalArgs.Fad03(t);
    }

    /// <summary>
    /// Fundamental argument, IERS Conventions (2003):
    /// mean longitude of Earth.
    /// </summary>
    /// <param name="t">TDB, Julian centuries since J2000.0</param>
    /// <returns>Mean longitude of Earth, radians.</returns>
    public static double MeanLongitudeOfEarth(double t)
    {
        return SofaFundamentalArgs.Fae03(t);
    }

    /// <summary>
    /// Fundamental argument, IERS Conventions (2003):
    /// mean longitude of the Moon minus mean longitude of the ascending
    /// node.
    /// </summary>
    /// <param name="t">TDB, Julian centuries since J2000.0.</param>
    /// <returns>F, radians.</returns>
    public static double MoonLongitudeMinusAscendingNode(double t)
    {
        return SofaFundamentalArgs.Faf03(t);
    }

    /// <summary>
    /// Fundamental argument, IERS Conventions (2003):
    /// mean longitude of Jupiter.
    /// </summary>
    /// <param name="t">TDB, Julian centuries since J2000.0.</param>
    /// <returns>Mean longitude of Jupiter, radians.</returns>
    public static double MeanLongitudeOfJupiter(double t)
    {
        return SofaFundamentalArgs.Faju03(t);
    }

    /// <summary>
    /// Fundamental argument, IERS Conventions (2003):
    /// mean anomaly of the Moon.
    /// </summary>
    /// <param name="t">TDB, Julian centuries since J2000.0.</param>
    /// <returns>l, radians.</returns>
    public static double MeanAnomalyOfMoon(double t)
    {
        return SofaFundamentalArgs.Fal03(t);
    }

    /// <summary>
    /// Fundamental argument, IERS Conventions (2003):
    /// mean anomaly of the Sun.
    /// </summary>
    /// <param name="t">TDB, Julian centuries since J2000.0.</param>
    /// <returns>l', radians.</returns>
    public static double MeanAnomalyOfSun(double t)
    {
        return SofaFundamentalArgs.Falp03(t);
    }

    /// <summary>
    /// Fundamental argument, IERS Conventions (2003):
    /// mean longitude of Mars.
    /// </summary>
    /// <param name="t">TDB, Julian centuries since J2000.0.</param>
    /// <returns>Mean longitude of Mars, radians.</returns>
    public static double MeanLongitudeOfMars(double t)
    {
        return SofaFundamentalArgs.Fama03(t);
    }

    /// <summary>
    /// Fundamental argument, IERS Conventions (2003):
    /// mean longitude of Mercury.
    /// </summary>
    /// <param name="t">TDB, Julian centuries since J2000.0.</param>
    /// <returns>Mean longitude of Mercury, radians.</returns>
    public static double MeanLongitudeOfMercury(double t)
    {
        return SofaFundamentalArgs.Fame03(t);
    }

    /// <summary>
    /// Fundamental argument, IERS Conventions (2003):
    /// mean longitude of Neptune.
    /// </summary>
    /// <param name="t">TDB, Julian centuries since J2000.0.</param>
    /// <returns>Mean longitude of Neptune, radians.</returns>
    public static double MeanLongitudeOfNeptune(double t)
    {
        return SofaFundamentalArgs.Fane03(t);
    }

    /// <summary>
    /// Fundamental argument, IERS Conventions (2003):
    /// mean longitude of the Moon's ascending node.
    /// </summary>
    /// <param name="t">TDB, Julian centuries since J2000.0.</param>
    /// <returns>Omega, radians.</returns>
    public static double MeanLongitudeOfMoonAscendingNode(double t)
    {
        return SofaFundamentalArgs.Faom03(t);
    }

    /// <summary>
    /// Fundamental argument, IERS Conventions (2003):
    /// general accumulated precession in longitude.
    /// </summary>
    /// <param name="t">TDB, Julian centuries since J2000.0.</param>
    /// <returns>General precession in longitude, radians.</returns>
    public static double GeneralAccumulatedPrecessionInLongitude(double t)
    {
        return SofaFundamentalArgs.Fapa03(t);
    }

    /// <summary>
    /// Fundamental argument, IERS Conventions (2003):
    /// mean longitude of Saturn.
    /// </summary>
    /// <param name="t">TDB, Julian centuries since J2000.0.</param>
    /// <returns>Mean longitude of Saturn, radians.</returns>
    public static double MeanLongitudeOfSaturn(double t)
    {
        return SofaFundamentalArgs.Fasa03(t);
    }

    /// <summary>
    /// Fundamental argument, IERS Conventions (2003):
    /// mean longitude of Uranus.
    /// </summary>
    /// <param name="t">TDB, Julian centuries since J2000.0.</param>
    /// <returns>Mean longitude of Uranus, radians.</returns>
    public static double MeanLongitudeOfUranus(double t)
    {
        return SofaFundamentalArgs.Faur03(t);
    }

    /// <summary>
    /// Fundamental argument, IERS Conventions (2003):
    /// mean longitude of Venus.
    /// </summary>
    /// <param name="t">TDB, Julian centuries since J2000.0.</param>
    /// <returns>Mean longitude of Venus, radians.</returns>
    public static double MeanLongitudeOfVenus(double t)
    {
        return SofaFundamentalArgs.Fave03(t);
    }
}
