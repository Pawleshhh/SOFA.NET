namespace SOFA.NET;

public static class EquinoxModule
{

    /// <summary>
    /// Equation of the equinoxes, IAU 1994 model.
    /// SOFA name: iauEqeq94
    /// </summary>
    /// <param name="tdbJulianDate"></param>
    /// <returns></returns>
    public static double EquationOfEquinoxesIAU94(JulianDate tdbJulianDate)
    {
        ThrowHelper.ThrowIfNotExpectedJulianDateKind(JulianDateKind.Tdb, tdbJulianDate);

        double t, om, eps0, ee;

        t = tdbJulianDate.JulianCentury();

        om = MathHelper.NormalizeAngleIntoMinusOnePIToPlusOnePI((450160.280 + (-482890.539
           + (7.455 + 0.008 * t) * t) * t) * Constants.DAS2R
           + ((-5.0 * t) % 1.0) * Constants.PI2);

        var ttJulianDate = new JulianDate(tdbJulianDate.DayNumber, tdbJulianDate.FractionOfDay, JulianDateKind.Tt);
        var dpsi = PrecNutPolarModule.NutationIAU80(ttJulianDate).Longitude;
        eps0 = PrecNutPolarModule.MeanObliquityOfTheEclipticIAU80(ttJulianDate);

        ee = dpsi * Math.Cos(eps0) + Constants.DAS2R * (0.00264 * Math.Sin(om) + 0.000063 * Math.Sin(om + om));

        return ee;
    }

}
