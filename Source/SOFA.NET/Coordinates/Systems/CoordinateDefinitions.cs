namespace SOFA.NET;

public record GeographicCoordinates(double Latitude, double Longitude)
    : CoordinateSystemBase<double>(Latitude, Longitude), ICoordinateSystem2D<double>;