namespace SOFA.NET;

/// <summary>
/// Reference ellipsoids
/// </summary>
public enum ReferenceEllipsoid
{
    GRS80 = 2,
    WGS72 = 3,
    WGS84 = 1
}

public readonly struct EllipsoidParameter
{
    public double EquatorialRadius { get; }
    public double Flattening { get; }

    public EllipsoidParameter(double equatorialRadius, double flattening)
        => (EquatorialRadius, Flattening) = (equatorialRadius, flattening);
}

public static class ReferenceEllipsoidExtension
{

    /// <summary>
    /// Earth reference ellipsoids.
    /// SOFA name: iauEform
    /// </summary>
    /// <param name="referenceEllipsoid"></param>
    /// <returns></returns>
    public static EllipsoidParameter EarthReferenceEllipsoids(this ReferenceEllipsoid referenceEllipsoid)
        => referenceEllipsoid switch
        {
            ReferenceEllipsoid.WGS84 => new(6378137.0, 1.0 / 298.257223563),
            ReferenceEllipsoid.GRS80 => new(6378137.0, 1.0 / 298.257222101),
            ReferenceEllipsoid.WGS72 => new(6378135.0, 1.0 / 298.26),
            _ => new(0.0, 0.0)
        };

}