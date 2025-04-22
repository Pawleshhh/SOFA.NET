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

}
