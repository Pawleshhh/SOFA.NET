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
    /// mean longitude of given <see cref="PlanetaryObject"/>.
    /// </summary>
    /// <param name="planetaryObject"></param>
    /// <param name="t"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public static double MeanLongitudeIERS03Of(PlanetaryObject planetaryObject, double t)
        => planetaryObject switch
        {
            PlanetaryObject.Earth => MeanLongitudeOfEarth(t),
            PlanetaryObject.Jupiter => MeanLongitudeOfJupiter(t),
            _ => throw new ArgumentException($"Cannot calculate mean longitude of given planetary object")
        };

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
    /// mean longitude of Jupiter.
    /// SOFA name: iauFaju03
    /// </summary>
    /// <param name="t"></param>
    /// <returns></returns>
    internal static double MeanLongitudeOfJupiter(double t)
    {
        return (1.753470314 + 628.3075849991 * t) % Constants.PI2;
    }

}
