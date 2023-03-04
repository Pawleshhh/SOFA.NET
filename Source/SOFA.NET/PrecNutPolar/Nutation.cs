using System.Diagnostics.CodeAnalysis;

namespace SOFA.NET;

public readonly struct Nutation : IEquatable<Nutation>
{

    public double Longitude { get; }
    public double Obliquity { get; }

    public Nutation(double longitude, double obliquity)
        => (Longitude, Obliquity) = (longitude, obliquity);

    public void Deconstruct(out double longitude, out double obliquity)
        => (longitude, obliquity) = (Longitude, Obliquity);

    public bool Equals(Nutation other)
    {
        return Longitude == other.Longitude && Obliquity == other.Obliquity;
    }

    public override bool Equals([NotNullWhen(true)] object? obj)
    {
        if (obj is Nutation nutation)
        {
            return Equals(nutation);
        }

        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Longitude, Obliquity) * 17;
    }
}
