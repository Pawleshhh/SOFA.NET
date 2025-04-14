namespace SOFA.NET;

public record HeliocentricEarthState(
    Vector3<double> HeliocentricPosition,
    Vector3<double> HeliocentricVelocity);