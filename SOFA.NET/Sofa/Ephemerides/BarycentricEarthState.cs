namespace SOFA.NET;

public record BarycentricEarthState(
    Vector3<double> BarycentricPosition,
    Vector3<double> BarycentricVelocity);
