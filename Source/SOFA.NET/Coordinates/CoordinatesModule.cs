using static SOFA.NET.ThrowHelper;

namespace SOFA.NET;

public static class CoordinatesModule
{

    //public static EquatorialCoordinates EclipticToEquatorialIAU06(
    //    JulianDate ttJulianDate,
    //    EclipticCoordinates eclipticCoordinates)
    //{
    //    ThrowIfNotExpectedJulianDateKind(JulianDateKind.Tt, ttJulianDate);

    //    //iauS2c

    //    //iauEcm06

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

}
