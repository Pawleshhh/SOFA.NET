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
    {
        Func<double, double> meanLongitudeFunc = solarSystemObject switch
        {
            SolarSystemObject.Sun => MeanLongitudeOfSun,
            SolarSystemObject.Mercury => MeanLongitudeOfMercury,
            SolarSystemObject.Venus => MeanLongitudeOfVenus,
            SolarSystemObject.Earth => MeanLongitudeOfEarth,
            SolarSystemObject.Moon => MeanLongitudeOfMoon,
            SolarSystemObject.Mars => MeanLongitudeOfMars,
            SolarSystemObject.Jupiter => MeanLongitudeOfJupiter,
            SolarSystemObject.Saturn => MeanLongitudeOfSaturn,
            SolarSystemObject.Uranus => MeanLongitudeOfUranus,
            SolarSystemObject.Neptune => MeanLongitudeOfNeptune,
            _ => throw new ArgumentException($"Cannot calculate mean longitude of given solar system object")
        };

        return meanLongitudeFunc.Invoke(t);
    }

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
    /// mean longitude of Mercury.
    /// SOFA name: iauFame03
    /// </summary>
    /// <param name="t"></param>
    /// <returns></returns>
    internal static double MeanLongitudeOfMercury(double t)
    {
        return (4.402608842 + 2608.7903141574 * t) % Constants.PI2;
    }

    /// <summary>
    /// Fundamental argument, IERS Conventions (2003):
    /// mean longitude of Venus.
    /// SOFA name: iauFave03
    /// </summary>
    /// <param name="t"></param>
    /// <returns></returns>
    internal static double MeanLongitudeOfVenus(double t)
    {
        return (3.176146697 + 1021.3285546211 * t) % Constants.PI2;
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
    /// mean longitude of Mars.
    /// SOFA name: iauFama03
    /// </summary>
    /// <param name="t"></param>
    /// <returns></returns>
    internal static double MeanLongitudeOfMars(double t)
    {
        return (6.203480913 + 334.0612426700 * t) % Constants.PI2;
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

    /// <summary>
    /// Fundamental argument, IERS Conventions (2003):
    /// mean longitude of Saturn.
    /// SOFA name: iauFasa03
    /// </summary>
    /// <param name="t"></param>
    /// <returns></returns>
    internal static double MeanLongitudeOfSaturn(double t)
    {
        return (0.874016757 + 21.3299104960 * t) % Constants.PI2;
    }

    /// <summary>
    /// Fundamental argument, IERS Conventions (2003):
    /// mean longitude of Uranus.
    /// SOFA name: iauFaur03
    /// </summary>
    /// <param name="t"></param>
    /// <returns></returns>
    internal static double MeanLongitudeOfUranus(double t)
    {
        return (5.481293872 + 7.4781598567 * t) % Constants.PI2;
    }

    /// <summary>
    /// Fundamental argument, IERS Conventions (2003):
    /// mean longitude of Neptune.
    /// SOFA name: iauFane03
    /// </summary>
    /// <param name="t"></param>
    /// <returns></returns>
    internal static double MeanLongitudeOfNeptune(double t)
    {
        return (5.311886287 + 3.8133035638 * t) % Constants.PI2;
    }

}
