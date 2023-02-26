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

}
