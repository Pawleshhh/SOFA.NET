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

        double t, om, dpsi, deps, eps0, ee;

        t = tdbJulianDate.JulianCentury();

        om = MathHelper.NormalizeAngleIntoMinusOnePIToPlusOnePI((450160.280 + (-482890.539
           + (7.455 + 0.008 * t) * t) * t) * Constants.DAS2R
           + ((-5.0 * t) % 1.0) * Constants.PI2);

        throw new NotImplementedException();
    }

}
