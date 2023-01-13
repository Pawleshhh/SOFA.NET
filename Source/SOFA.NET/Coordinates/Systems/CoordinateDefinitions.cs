namespace SOFA.NET;

public record GeographicCoordinates : CoordinateSystem<double>, ICoordinateSystem2D<double>
{

    public GeographicCoordinates(double latitude, double longitude)
        : base(latitude, longitude)
    {
        Latitude = latitude;
        Longitude = longitude;
    }

    double ICoordinateSystem2D<double>.X { get => Get(0); set => Set(0, value); }
    double ICoordinateSystem2D<double>.Y { get => Get(1); set => Set(1, value); }

    public double Latitude { get => Get(0); set => Set(0, value); }
    public double Longitude { get => Get(1); set => Set(1, value); }

}
