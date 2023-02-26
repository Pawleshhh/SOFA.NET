namespace SOFA.NET;

public static class FundamentalArgsModule
{

    /// <summary>
    /// Fundamental argument, IERS Conventions (2003):
    /// mean elongation of the Moon from the Sun.
    /// SOFA name: iauFad03
    /// </summary>
    /// <param name="t"></param>
    /// <returns></returns>
    public static double MeanElongationOfMoonFromSunIERS03(double t)
    {
        return ((1072260.703692 + 
            t * (1602961601.2090 + 
            t * (-6.3706 +
            t * (0.006593 + 
            t * (-0.00003169))))) % Constants.TURNAS) * Constants.DAS2R;
    }

    /// <summary>
    /// Fundamental argument, IERS Conventions (2003):
    /// mean longitude of given <see cref="SolarSystemObject"/>.
    /// </summary>
    /// <param name="solarSystemObject"></param>
    /// <param name="t"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public static double MeanLongitudeIERS03Of(SolarSystemObject solarSystemObject, double t)
        => solarSystemObject switch
        {
            SolarSystemObject.Sun => MeanLongitudeOfSun(t),
            SolarSystemObject.Earth => MeanLongitudeOfEarth(t),
            SolarSystemObject.Moon => MeanLongitudeOfMoon(t),
            SolarSystemObject.Jupiter => MeanLongitudeOfJupiter(t),
            _ => throw new ArgumentException($"Cannot calculate mean longitude of given solar system object")
        };

    /// <summary>
    /// Fundamental argument, IERS Conventions (2003):
    /// mean anomaly of the Sun.
    /// SOFA name: iauFalp03
    /// </summary>
    /// <param name="t"></param>
    /// <returns></returns>
    internal static double MeanLongitudeOfSun(double t)
    {
        return ((1287104.793048 +
             t * (129596581.0481 +
             t * (-0.5532 +
             t * (0.000136 +
             t * (-0.00001149))))) % Constants.TURNAS) * Constants.DAS2R;
    }

    /// <summary>
    /// Fundamental argument, IERS Conventions (2003):
    /// mean longitude of Earth.
    /// SOFA name: iauFae03
    /// </summary>
    /// <param name="t"></param>
    /// <returns></returns>
    internal static double MeanLongitudeOfEarth(double t)
    {
        return (1.753470314 + 628.3075849991 * t) % Constants.PI2;
    }

    /// <summary>
    /// Fundamental argument, IERS Conventions (2003):
    /// mean anomaly of the Moon.
    /// SOFA name: iauFal03
    /// </summary>
    /// <param name="t"></param>
    /// <returns></returns>
    internal static double MeanLongitudeOfMoon(double t)
    {
        return ((485868.249036 +
             t * (1717915923.2178 +
             t * (31.8792 +
             t * (0.051635 +
             t * (-0.00024470))))) % Constants.TURNAS) * Constants.DAS2R;
    }

    /// <summary>
    /// Fundamental argument, IERS Conventions (2003):
    /// mean longitude of Jupiter.
    /// SOFA name: iauFaju03
    /// </summary>
    /// <param name="t"></param>
    /// <returns></returns>
    internal static double MeanLongitudeOfJupiter(double t)
    {
        return (0.599546497 + 52.9690962641 * t) % Constants.PI2;
    }

}
