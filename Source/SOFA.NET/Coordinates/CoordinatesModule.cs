namespace SOFA.NET;

public static partial class CoordinatesModule
{

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
    /// SOFA name: iauC2s
    /// </summary>
    /// <param name="vector"></param>
    /// <returns></returns>
    public static ICoordinateSystem2D<double> VectorToSphericalCoordinates(double[] vector)
    {
        double x, y, z, d2;

        x = vector[0];
        y = vector[1];
        z = vector[2];
        d2 = x * x + y * y;

        double theta = (d2 == 0.0) ? 0.0 : Math.Atan2(y, x);
        double phi = (z == 0.0) ? 0.0 : Math.Atan2(z, Math.Sqrt(d2));

        return ICoordinateSystem2D<double>.Create(theta, phi);
    }

}
