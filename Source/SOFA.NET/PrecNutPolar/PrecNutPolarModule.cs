namespace SOFA.NET;

public static class PrecNutPolarModule
{

    /// <summary>
    /// Mean obliquity of the ecliptic, IAU 2006 precession model.
    /// SOFA name: iauObl06
    /// </summary>
    /// <param name="ttJulianDate"></param>
    /// <returns></returns>
    public static double MeanObliquityOfTheEclipticIAU06(JulianDate ttJulianDate)
    {
        ThrowHelper.ThrowIfNotExpectedJulianDateKind(JulianDateKind.Tt, ttJulianDate);

        var t = ttJulianDate.JulianCentury();
        double eps0 = (84381.406 +
          (-46.836769 +
          (-0.0001831 +
          (0.00200340 +
          (-0.000000576 +
          (-0.0000000434) * t) * t) * t) * t) * t) * Constants.DAS2R;

        return eps0;
    }

}
