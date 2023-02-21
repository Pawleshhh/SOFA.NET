namespace SOFA.NET;

public record GeographicCoordinates(double Latitude, double Longitude)
    : CoordinateSystemBase2D<double>(Latitude, Longitude);

public record HorizonCoordinates(double Altitude, double Azimuth)
    : CoordinateSystemBase2D<double>(Altitude, Azimuth);

public record EquatorialCoordinates(double Declination, double RightAscension)
    : CoordinateSystemBase2D<double>(Declination, RightAscension);

public record HourAngleCoordinates(double Declination, double HourAngle)
    : CoordinateSystemBase2D<double>(Declination, HourAngle);

public record EclipticCoordinates(double Longitude, double Latitude)
    : CoordinateSystemBase2D<double>(Longitude, Latitude);

public record GalacticCoordinates(double Longitude, double Latitude)
    : CoordinateSystemBase2D<double>(Longitude, Latitude);


/// <summary>
/// Contains single spherical coordinate (longitude angle, latitude angle or radial distance)
/// </summary>
public readonly struct SphericalCoordinate : ICoordinateSystem<double>
{
    public double Value { get; }
    public double RateOfChange { get; }

    public int Axes => 1;

    public SphericalCoordinate(double value, double rateOfChange)
    {
        Value = value;
        RateOfChange = rateOfChange;
    }

    public void Deconstruct(out double value, out double rate)
        => (value, rate) = (Value, RateOfChange);

    public double Get(int axis)
        => axis == 0 
        ? Value 
        : throw new ArgumentOutOfRangeException("Spherical coordinate has only one defined coordiante value that can be accessed under 0 index");

    public bool Equals(ICoordinateSystem<double>? other)
    {
        if (other is null)
        {
            return false;
        }

        if (other is SphericalCoordinate spherical)
        {
            return Value == spherical.Value && RateOfChange == spherical.RateOfChange;
        }
        
        return Value == other.Get(0);
    }
}
