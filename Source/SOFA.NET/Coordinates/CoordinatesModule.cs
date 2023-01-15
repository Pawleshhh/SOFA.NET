using static SOFA.NET.ThrowHelper;

namespace SOFA.NET;

public static class CoordinatesModule
{

    //public static EquatorialCoordinates EclipticToEquatorialIAU06(
    //    JulianDate ttJulianDate,
    //    EclipticCoordinates eclipticCoordinates)
    //{
    //    ThrowIfNotExpectedJulianDateKind(JulianDateKind.Tt, ttJulianDate);

    //    var v1 = SphericalToCartesian(eclipticCoordinates);
    //    var rm = RotationMatrixOfEquatorialToEclipticIAU06(ttJulianDate);
    //    var v2 = rm.TransposeMultiply(v1);
    //    //iauTrxp

    //    //iauC2s

    //    //ra = iauAnp
    //    //dec = iauAnpm

    //}

    /// <summary>
    /// Convert spherical coordinates to cartesian.
    /// SOFA name: iauS2c
    /// </summary>
    /// <param name="spherical"></param>
    /// <returns></returns>
    public static double[] SphericalToCartesian(ICoordinateSystem2D<double> spherical)
    {
        double[] result = new double[3];
        var (x, y) = spherical;
        double cp = Math.Cos(y);
        result[0] = Math.Cos(x) * cp;
        result[1] = Math.Sin(x) * cp;
        result[2] = Math.Sin(y);

        return result;
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

}
