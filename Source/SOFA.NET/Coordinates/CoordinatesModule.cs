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

    /// <summary>
    /// P-vector to spherical polar coordinates.
    /// SOFA name: iauP2s
    /// </summary>
    /// <param name="vector"></param>
    /// <returns></returns>
    public static ICoordinateSystem3D<double> VectorToSphericalPolarCoordinates(double[] vector)
    {
        var sphericalCoords = VectorToSphericalCoordinates(vector);
        var r = MatrixHelper.ModulusOfVector(vector);
        return ICoordinateSystem3D<double>.Create(sphericalCoords.X, sphericalCoords.Y, r);
    }

    public static ICoordinateSystem3D<SphericalCoordinate> CartesianToSphericalPositionAndVelocityCoordinates(double[,] pvVector)
    {
        double x, y, z, xd, yd, zd, rxy2, rxy, r2, rtrue, rw, xyp, theta, phi, r, td, pd, rd;

        /* Components of position/velocity vector. */
        x = pvVector[0, 0];
        y = pvVector[0, 1];
        z = pvVector[0, 2];
        xd = pvVector[1, 0];
        yd = pvVector[1, 1];
        zd = pvVector[1, 2];

        /* Component of r in XY plane squared. */
        rxy2 = x * x + y * y;

        /* Modulus squared. */
        r2 = rxy2 + z * z;

        /* Modulus. */
        rtrue = Math.Sqrt(r2);

        /* If null vector, move the origin along the direction of movement. */
        rw = rtrue;
        if (rtrue == 0.0)
        {
            x = xd;
            y = yd;
            z = zd;
            rxy2 = x * x + y * y;
            r2 = rxy2 + z * z;
            rw = Math.Sqrt(r2);
        }

        /* Position and velocity in spherical coordinates. */
        rxy = Math.Sqrt(rxy2);
        xyp = x * xd + y * yd;
        if (rxy2 != 0.0)
        {
            theta = Math.Atan2(y, x);
            phi = Math.Atan2(z, rxy);
            td = (x * yd - y * xd) / rxy2;
            pd = (zd * rxy2 - z * xyp) / (r2 * rxy);
        }
        else
        {
            theta = 0.0;
            phi = (z != 0.0) ? Math.Atan2(z, rxy) : 0.0;
            td = 0.0;
            pd = 0.0;
        }
        r = rtrue;
        rd = (rw != 0.0) ? (xyp + z * zd) / rw : 0.0;

        return ICoordinateSystem3D<SphericalCoordinate>.Create(
            new(theta, td), new(phi, pd), new(r, rd));
    }

}
