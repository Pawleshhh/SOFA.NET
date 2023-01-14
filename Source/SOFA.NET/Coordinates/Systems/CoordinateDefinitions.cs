namespace SOFA.NET;

public record GeographicCoordinates(double Latitude, double Longitude)
    : CoordinateSystemBase2D<double>(Latitude, Longitude);

public record HorizonCoordinates(double Altitude, double Azimuth)
    : CoordinateSystemBase2D<double>(Altitude, Azimuth);

public record EquatorialCoordinates(double Declination, double RightAscension)
    : CoordinateSystemBase2D<double>(Declination, RightAscension);

public record EclipticCoordinates(double Longitude, double Latitude)
    : CoordinateSystemBase2D<double>(Longitude, Latitude);

public record GalacticCoordinates(double Longitude, double Latitude)
    : CoordinateSystemBase2D<double>(Longitude, Latitude);