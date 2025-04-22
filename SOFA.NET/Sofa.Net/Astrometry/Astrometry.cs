namespace SOFA.NET;

public class Astrometry
{

    /// <summary>
    /// Apply aberration to transform natural direction into proper
    /// direction.
    /// </summary>
    /// <param name="naturalDirection">Natural direction to the source.</param>
    /// <param name="observerBarycentricVelocity">Observer barycentric velocity in units of c.</param>
    /// <param name="sunObserverDistance">Distance between the Sun and the observer (au).</param>
    /// <param name="lorenzFactor">sqrt(1-|v|^2): reciprocal of Lorenz factor.</param>
    /// <returns>Proper direction to source.</returns>
    public static Vector3<double> ApplyAberration(
        Vector3<double> naturalDirection,
        Vector3<double> observerBarycentricVelocity,
        double sunObserverDistance,
        double lorenzFactor)
    {
        var result = new double[3];
        SofaAstrometry.Ab(
            naturalDirection.AsArray(),
            observerBarycentricVelocity.AsArray(),
            sunObserverDistance,
            lorenzFactor,
            result);

        return new(result[0], result[1], result[2]);
    }

    /// <summary>
    /// For a geocentric observer, prepare star-independent astrometry
    /// parameters for transformations between ICRS and GCRS coordinates.
    /// The Earth ephemeris is supplied by the caller.
    /// 
    /// The parameters produced by this function are required in the
    /// parallax, light deflection and aberration parts of the astrometric
    /// transformation chain.
    /// </summary>
    /// <param name="julianDate">TDB Julian Date.</param>
    /// <param name="barycentricEarthState">Earth barycentric pos/vel (au, au/day).</param>
    /// <param name="heliocentricEarthPosition">Earth heliocentric position (au).</param>
    /// <returns>
    /// Star-independent astrometry parameters.
    /// </returns>
    public static StarIndependentParameters PrepareAstrometryParametersGeocentric(
        JulianDate julianDate,
        Matrix<double> barycentricEarthState,
        Vector3<double> heliocentricEarthPosition)
    {
        var astrom = new ASTROM();
        SofaAstrometry.Apcg(
            julianDate.DayNumber,
            julianDate.FractionOfDay,
            barycentricEarthState.ToArray(),
            heliocentricEarthPosition.AsArray(),
            ref astrom);

        return StarIndependentParameters.FromASTROM(astrom);
    }

}
