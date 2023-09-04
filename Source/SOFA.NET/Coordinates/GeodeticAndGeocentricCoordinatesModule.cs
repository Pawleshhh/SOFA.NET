namespace SOFA.NET;

public static partial class CoordinatesModule
{

    /// <summary>
    /// Transform geocentric coordinates to geodetic using the specified
    /// reference ellipsoid.
    /// SOFA name: iauGc2gd
    /// </summary>
    /// <param name="geocentricCoordinates"></param>
    /// <param name="referenceEllipsoid"></param>
    /// <returns></returns>
    public static GeodeticCoordinates GeocentricToGeodeticCoordinates(
        GeocentricCoordinates geocentricCoordinates,
        ReferenceEllipsoid referenceEllipsoid)
    {
        var referenceEllipsoidParams = referenceEllipsoid.EarthReferenceEllipsoids();
        return GeocentricToGeodeticCoordinates(geocentricCoordinates, referenceEllipsoidParams);
    }

    /// <summary>
    /// Transform geocentric coordinates to geodetic for a reference
    /// ellipsoid of specified form.
    /// SOFA name: iauGc2gde
    /// </summary>
    /// <param name="geocentricCoordinates"></param>
    /// <param name="ellipsoidParameter"></param>
    /// <returns></returns>
    public static GeodeticCoordinates GeocentricToGeodeticCoordinates(
        GeocentricCoordinates geocentricCoordinates,
        EllipsoidParameter ellipsoidParameter)
    {
        double aeps2, e2, e4t, ec2, ec, b, x, y, z,
            p2, absz, p, s0, pn, zc, c0, c02, c03,
            s02, s03, a02, a0, a03, d0, f0, b0, s1,
            cc, s12, cc2, elong, phi, height;

        var (a, f) = ellipsoidParameter;

        /* ------------- /
        / Preliminaries /
        / ------------- */

        /* Validate ellipsoid parameters. */
        if (f < 0.0 || f >= 1.0)
        {
            throw new ArgumentException($"Illegal flattening of {f}");
        }
        if (a <= 0.0)
        {
            throw new ArgumentException($"Illegal equatorial radius of {a}");
        }

        /* Functions of ellipsoid parameters (with further validation of f). */
        aeps2 = a * a * 1e-32;
        e2 = (2.0 - f) * f;
        e4t = e2 * e2 * 1.5;

        ec2 = 1.0 - e2;
        if (ec2 <= 0.0)
        {
            throw new ArgumentException($"Illegal flattening of {f}");
        }

        ec = Math.Sqrt(ec2);
        b = a * ec;

        /* Cartesian components. */
        (x, y, z) = geocentricCoordinates;

        /* Distance from polar axis squared. */
        p2 = x * x + y * y;

        /* Longitude. */
        elong = p2 > 0.0 ? Math.Atan2(y, x) : 0.0;

        /* Unsigned z-coordinate. */
        absz = Math.Abs(z);

        /* Proceed unless polar case. */
        if (p2 > aeps2)
        {

            /* Distance from polar axis. */
            p = Math.Sqrt(p2);

            /* Normalization. */
            s0 = absz / a;
            pn = p / a;
            zc = ec * s0;

            /* Prepare Newton correction factors. */
            c0 = ec * pn;
            c02 = c0 * c0;
            c03 = c02 * c0;
            s02 = s0 * s0;
            s03 = s02 * s0;
            a02 = c02 + s02;
            a0 = Math.Sqrt(a02);
            a03 = a02 * a0;
            d0 = zc * a03 + e2 * s03;
            f0 = pn * a03 - e2 * c03;

            /* Prepare Halley correction factor. */
            b0 = e4t * s02 * c02 * pn * (a0 - ec);
            s1 = d0 * f0 - b0 * s0;
            cc = ec * (f0 * f0 - b0 * c0);

            /* Evaluate latitude and height. */
            phi = Math.Atan(s1 / cc);
            s12 = s1 * s1;
            cc2 = cc * cc;
            height = (p * cc + absz * s1 - a * Math.Sqrt(ec2 * s12 + cc2)) / Math.Sqrt(s12 + cc2);
        }
        else
        {
            /* Exception: pole. */
            phi = Math.PI / 2.0;
            height = absz - b;
        }

        /* Restore sign of latitude. */
        if (z < 0)
        {
            phi = -phi;
        }

        return new(phi, elong, height);
    }

    #region GeodeticToGeocentricCoordinates

    /// <summary>
    /// Status of returned calculation given by <see cref="GeodeticToGeocentricCoordinates"/>.
    /// </summary>
    public enum Gd2gceStatus
    {
        Ok = 0,
        /// <summary>
        ///  An error status -2 protects against cases that would 
        ///  lead to arithmetic exceptions.
        /// </summary>
        IllegalCase = -2,
    }

    /// <summary>
    /// Transform geodetic coordinates to geocentric using the specified
    /// reference ellipsoid.
    /// SOFA name: iauGd2gc
    /// </summary>
    /// <param name="geodeticCoordinates"></param>
    /// <param name="referenceEllipsoid"></param>
    /// <returns></returns>
    public static GeocentricCoordinates GeodeticToGeocentricCoordinates(
        GeodeticCoordinates geodeticCoordinates,
        ReferenceEllipsoid referenceEllipsoid)
    {
        return GeodeticToGeocentricCoordinates(geodeticCoordinates, referenceEllipsoid, out var _);
    }

    /// <summary>
    /// Transform geodetic coordinates to geocentric using the specified
    /// reference ellipsoid.
    /// Returns status of the calculation.
    /// SOFA name: iauGd2gc
    /// </summary>
    /// <param name="geodeticCoordinates"></param>
    /// <param name="referenceEllipsoid"></param>
    /// <returns></returns>
    public static GeocentricCoordinates GeodeticToGeocentricCoordinates(
        GeodeticCoordinates geodeticCoordinates,
        ReferenceEllipsoid referenceEllipsoid,
        out Gd2gceStatus status)
    {
        var referenceEllipsoidParams = referenceEllipsoid.EarthReferenceEllipsoids();
        var geocentricCoords = GeodeticToGeocentricCoordinates(geodeticCoordinates, referenceEllipsoidParams, out status);

        return geocentricCoords;
    }

    private static readonly GeocentricCoordinates geocentricArithmeticException = new(0, 0, 0);

    /// <summary>
    /// Transform geodetic coordinates to geocentric for a reference
    /// ellipsoid of specified form.
    /// SOFA name: iauGd2gce
    /// </summary>
    /// <param name="geodeticCoordinates"></param>
    /// <param name="ellipsoidParameter"></param>
    /// <returns></returns>
    public static GeocentricCoordinates GeodeticToGeocentricCoordinates(
        GeodeticCoordinates geodeticCoordinates,
        EllipsoidParameter ellipsoidParameter)
    {
        return GeodeticToGeocentricCoordinates(geodeticCoordinates, ellipsoidParameter, out var _);
    }

    /// <summary>
    /// Transform geodetic coordinates to geocentric for a reference
    /// ellipsoid of specified form.
    /// Returns status of the calculation.
    /// SOFA name: iauGd2gce
    /// </summary>
    /// <param name="geodeticCoordinates"></param>
    /// <param name="ellipsoidParameter"></param>
    /// <returns></returns>
    public static GeocentricCoordinates GeodeticToGeocentricCoordinates(
        GeodeticCoordinates geodeticCoordinates,
        EllipsoidParameter ellipsoidParameter,
        out Gd2gceStatus status)
    {
        double sp, cp, w, d, ac, @as, r;
        var (phi, elong, height) = geodeticCoordinates;
        var (a, f) = ellipsoidParameter;

        /* Functions of geodetic latitude. */
        sp = Math.Sin(phi);
        cp = Math.Cos(phi);
        w = 1.0 - f;
        w = w * w;
        d = cp * cp + w * sp * sp;
        if (d <= 0.0)
        {
            status = Gd2gceStatus.IllegalCase;
            return geocentricArithmeticException;
        }
        ac = a / Math.Sqrt(d);
        @as = w * ac;

        /* Geocentric vector. */
        r = (ac + height) * cp;
        var x = r * Math.Cos(elong);
        var y = r * Math.Sin(elong);
        var z = (@as + height) * sp;

        status = Gd2gceStatus.Ok;
        return new(x, y, z);
    }

    #endregion

}
