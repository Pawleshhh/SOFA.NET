namespace SOFA.NET;

public record EarthEphemerisStates(
    Matrix<double> HeliocentricEarthState,
    Matrix<double> BarycentricEarthState);
