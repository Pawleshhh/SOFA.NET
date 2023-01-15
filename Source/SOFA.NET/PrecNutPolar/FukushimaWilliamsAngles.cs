using System.Diagnostics.CodeAnalysis;

namespace SOFA.NET;

/// <summary>
/// Fukushima-Williams 4-angle formulation.
/// </summary>
public readonly struct FukushimaWilliamsAngles : IEquatable<FukushimaWilliamsAngles>
{

    public readonly double Gamma;
    public readonly double Phi;
    public readonly double Psi;
    public readonly double Epsilion;

    public FukushimaWilliamsAngles(double gamma, double phi, double psi, double epsilion)
    {
        Gamma = gamma; Phi = phi; Psi = psi; Epsilion = epsilion;
    }

    public bool Equals(FukushimaWilliamsAngles other)
    {
        return Gamma == other.Gamma
            && Phi == other.Phi
            && Psi == other.Psi
            && Epsilion == other.Epsilion;
    }

    public override bool Equals([NotNullWhen(true)] object? obj)
    {
        if (obj is FukushimaWilliamsAngles angles)
        {
            return Equals(angles);
        }

        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Gamma, Phi, Psi, Epsilion);
    }

    public override string ToString()
    {
        return $"({Gamma}, {Phi}, {Psi}, {Epsilion})";
    }

    public static bool operator ==(FukushimaWilliamsAngles a, FukushimaWilliamsAngles b)
        => a.Equals(b);
    public static bool operator !=(FukushimaWilliamsAngles a, FukushimaWilliamsAngles b)
        => !a.Equals(b);

}
