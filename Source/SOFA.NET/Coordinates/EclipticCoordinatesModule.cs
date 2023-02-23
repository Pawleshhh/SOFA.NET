using static SOFA.NET.ThrowHelper;

namespace SOFA.NET;

public static partial class CoordinatesModule
{
    #region Ecliptic <-> Equatorial IAU06

    /// <summary>
    /// Transformation from ecliptic coordinates (mean equinox and ecliptic of date)
    /// to ICRS RA,Dec, using the IAU 2006 precession model
    /// SOFA name: iauEceq06
    /// </summary>
    /// <param name="ttJulianDate"></param>
    /// <param name="eclipticCoordinates"></param>
    /// <returns></returns>
    public static EquatorialCoordinates EclipticToEquatorialIAU06(
        JulianDate ttJulianDate,
        EclipticCoordinates eclipticCoordinates)
    {
        ThrowIfNotExpectedJulianDateKind(JulianDateKind.Tt, ttJulianDate);

        var v1 = SphericalToCartesian(eclipticCoordinates);
        var rm = RotationMatrixOfEquatorialToEclipticIAU06(ttJulianDate);
        var v2 = rm.TransposeMultiply(v1);
        var p = VectorToSphericalCoordinates(v2);

        double ra = MathHelper.NormalizeAngleIntoZero2PI(p.X);
        double dec = MathHelper.NormalizeAngleIntoMinusOnePIToPlusOnePI(p.Y);

        return new(dec, ra);
    }

    /// <summary>
    /// Transformation from ICRS equatorial coordinates to ecliptic 
    /// coordinates (mean equinox and ecliptic of date) using IAU 2006 precession model.
    /// SOFA name: iauEqec06
    /// </summary>
    /// <param name="ttJulianDate"></param>
    /// <param name="equatorialCoordinates"></param>
    /// <returns></returns>
    public static EclipticCoordinates EquatorialToEclipticIAU06(
        JulianDate ttJulianDate,
        EquatorialCoordinates equatorialCoordinates)
    {
        ThrowIfNotExpectedJulianDateKind(JulianDateKind.Tt, ttJulianDate);

        var v1 = SphericalToCartesian(ICoordinateSystem2D<double>
            .Create(equatorialCoordinates.RightAscension, equatorialCoordinates.Declination));
        var rm = RotationMatrixOfEquatorialToEclipticIAU06(ttJulianDate);
        var v2 = rm.Multiply(v1);
        var p = VectorToSphericalCoordinates(v2);

        double lon = MathHelper.NormalizeAngleIntoZero2PI(p.X);
        double lat = MathHelper.NormalizeAngleIntoMinusOnePIToPlusOnePI(p.Y);

        return new(lon, lat);
    }

    /// <summary>
    /// ICRS equatorial to ecliptic rotation matrix, IAU 2006
    /// SOFA name: iauEcm06
    /// </summary>
    /// <param name="ttJulianDate"></param>
    /// <returns></returns>
    public static double[,] RotationMatrixOfEquatorialToEclipticIAU06(JulianDate ttJulianDate)
    {
        ThrowIfNotExpectedJulianDateKind(JulianDateKind.Tt, ttJulianDate);

        var ob = PrecNutPolarModule.MeanObliquityOfTheEclipticIAU06(ttJulianDate);
        var bp = PrecNutPolarModule.PrecessionMatrixFromGcrsToDateIAU06(ttJulianDate);
        var e = MatrixHelper.IdentityMatrix().RotateX(ob);
        var rm = e.Multiply(bp);

        return rm;
    }

    #endregion

    #region Ecliptic <-> Equatorial Long term

    /// <summary>
    /// Transformation from ecliptic coordinates (mean equinox and ecliptic of date) 
    /// to ICRS RA,Dec, using a long-term precession model
    /// SOFA name: iauLteceq
    /// </summary>
    /// <param name="ttJulianEpoch"></param>
    /// <param name="eclipticCoordinates"></param>
    /// <returns></returns>
    public static EquatorialCoordinates EclipticToEquatorialLongTerm(
        double ttJulianEpoch,
        EclipticCoordinates eclipticCoordinates)
    {
        var v1 = SphericalToCartesian(eclipticCoordinates);
        var rm = RotationMatrixOfEquatorialToEclipticLongTerm(ttJulianEpoch);
        var v2 = rm.TransposeMultiply(v1);
        var p = VectorToSphericalCoordinates(v2);

        double ra = MathHelper.NormalizeAngleIntoZero2PI(p.X);
        double dec = MathHelper.NormalizeAngleIntoMinusOnePIToPlusOnePI(p.Y);

        return new(dec, ra);
    }

    /// <summary>
    /// Transformation from ICRS equatorial coordinates to ecliptic coordinates (mean equinox and ecliptic of date) 
    /// using a long-termprecession model
    /// SOFA name: iauLteqec
    /// </summary>
    /// <param name="ttJulianEpoch"></param>
    /// <param name="equatorialCoordinates"></param>
    /// <returns></returns>
    public static EclipticCoordinates EquatorialToEclipticLongTerm(
        double ttJulianEpoch,
        EquatorialCoordinates equatorialCoordinates)
    {
        var v1 = SphericalToCartesian(ICoordinateSystem2D<double>
            .Create(equatorialCoordinates.RightAscension, equatorialCoordinates.Declination));
        var rm = RotationMatrixOfEquatorialToEclipticLongTerm(ttJulianEpoch);
        var v2 = rm.Multiply(v1);
        var p = VectorToSphericalCoordinates(v2);

        double lon = MathHelper.NormalizeAngleIntoZero2PI(p.X);
        double lat = MathHelper.NormalizeAngleIntoMinusOnePIToPlusOnePI(p.Y);

        return new(lon, lat);
    }

    /// <summary>
    /// ICRS equatorial to ecliptic rotation matrix, long-term
    /// SOFA name: iauLtecm
    /// </summary>
    /// <param name="ttJulianEpoch"></param>
    /// <returns></returns>
    public static double[,] RotationMatrixOfEquatorialToEclipticLongTerm(double ttJulianEpoch)
    {
        double dx = -0.016617 * Constants.DAS2R,
            de = -0.0068192 * Constants.DAS2R,
            dr = -0.0146 * Constants.DAS2R;

        var p = PrecNutPolarModule.LongTermPrecessionOfTheEquator(ttJulianEpoch);
        var z = PrecNutPolarModule.LongTermPrecessionOfTheEcliptic(ttJulianEpoch);
        var w = MatrixHelper.VectorOuterProduct(p, z);
        var (x, _) = MatrixHelper.VectorToModulusAndUnitVector(w);
        var y = MatrixHelper.VectorOuterProduct(z, x);

        var rm = new double[3, 3];
        rm[0, 0] = x[0] - x[1] * dr + x[2] * dx;
        rm[0, 1] = x[0] * dr + x[1] + x[2] * de;
        rm[0, 2] = -x[0] * dx - x[1] * de + x[2];
        rm[1, 0] = y[0] - y[1] * dr + y[2] * dx;
        rm[1, 1] = y[0] * dr + y[1] + y[2] * de;
        rm[1, 2] = -y[0] * dx - y[1] * de + y[2];
        rm[2, 0] = z[0] - z[1] * dr + z[2] * dx;
        rm[2, 1] = z[0] * dr + z[1] + z[2] * de;
        rm[2, 2] = -z[0] * dx - z[1] * de + z[2];

        return rm;
    }

    #endregion

}
