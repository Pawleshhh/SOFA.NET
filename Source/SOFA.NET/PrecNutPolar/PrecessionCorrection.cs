using System.Diagnostics.CodeAnalysis;

namespace SOFA.NET;

public readonly struct PrecessionCorrection : IEquatable<PrecessionCorrection>
{

    public double Precession { get; }
    public double Obliquity { get; }

    public PrecessionCorrection(double precession, double obliquity)
        => (Precession, Obliquity) = (precession, obliquity);

    public void Deconstruct(out double precession, out double obliquity)
        => (precession, obliquity) = (Precession, Obliquity);

    public bool Equals(PrecessionCorrection other)
        => Precession == other.Precession && Obliquity == other.Obliquity;

    public override bool Equals([NotNullWhen(true)] object? obj)
    {
        if (obj is PrecessionCorrection correction)
        {
            return Equals(correction);
        }

        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Precession, Obliquity) * 21;
    }
}
