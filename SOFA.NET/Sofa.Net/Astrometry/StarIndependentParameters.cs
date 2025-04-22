namespace SOFA.NET;

/// <summary>
/// Star-independent astrometry parameter.
/// </summary>
/// <param name="Pmt">PM time interval (SSB, Julian years)</param>
/// <param name="SSBToObserver">SSB to observer (vector, au)</param>
/// <param name="SunToObserver">Sun to observer (unit vector)</param>
/// <param name="SunObserverDistance">Distance from Sun to observer (au)</param>
/// <param name="BarycentricObserverVelocity">Barycentric observer velocity (vector, c)</param>
/// <param name="Bm1">sqrt(1-|v|^2): reciprocal of Lorenz facto</param>
/// <param name="Bpn">Bias-precession-nutation matrix</param>
/// <param name="ALong">Longitude + s' + dERA(DUT) (radians)</param>
/// <param name="Phi">Geodetic latitude (radians)</param>
/// <param name="Xpl">Polar motion xp wrt local meridian (radians)</param>
/// <param name="Ypl">Polar motion yp wrt local meridian (radians)</param>
/// <param name="Sphi">Sine of geodetic latitude</param>
/// <param name="Cphi">Cosine of geodetic latitude</param>
/// <param name="Diurab">Magnitude of diurnal aberration vector</param>
/// <param name="Eral">"local" Earth rotation angle (radians)</param>
/// <param name="RefA">Refraction constant A (radians)</param>
/// <param name="RefB">Refraction constant B (radians)</param>
public record StarIndependentParameters(
    double Pmt,
    Vector3<double> SSBToObserver,
    Vector3<double> SunToObserver,
    double SunObserverDistance,
    Vector3<double> BarycentricObserverVelocity,
    double Bm1,
    Matrix<double> Bpn,
    double ALong,
    double Phi,
    double Xpl,
    double Ypl,
    double Sphi,
    double Cphi,
    double Diurab,
    double Eral,
    double RefA,
    double RefB)
{

    public virtual bool Equals(StarIndependentParameters? sip)
    {
        if (sip is null)
        {
            return false;
        }

        if (ReferenceEquals(this, sip))
        {
            return true;
        }

        return
            Pmt != sip.Pmt ||
            !SSBToObserver.Equals(sip.SSBToObserver) ||
            !SunToObserver.Equals(sip.SunToObserver) ||
            SunObserverDistance != sip.SunObserverDistance ||
            !BarycentricObserverVelocity.Equals(sip.BarycentricObserverVelocity) ||
            Bm1 != sip.Bm1 ||
            !Bpn.Equals(sip.Bpn) ||
            ALong != sip.ALong ||
            Phi != sip.Phi ||
            Xpl != sip.Xpl ||
            Ypl != sip.Ypl ||
            Sphi != sip.Sphi ||
            Cphi != sip.Cphi ||
            Diurab != sip.Diurab ||
            Eral != sip.Eral ||
            RefA != sip.RefA ||
            RefB != sip.RefB;
    }

    public override int GetHashCode()
    {
        HashCode hash = new();
        hash.Add(Pmt);
        hash.Add(SSBToObserver);
        hash.Add(SunToObserver);
        hash.Add(SunObserverDistance);
        hash.Add(BarycentricObserverVelocity);
        hash.Add(Bm1);
        hash.Add(Bpn);
        hash.Add(ALong);
        hash.Add(Phi);
        hash.Add(Xpl);
        hash.Add(Ypl);
        hash.Add(Sphi);
        hash.Add(Cphi);
        hash.Add(Diurab);
        hash.Add(Eral);
        hash.Add(RefA);
        hash.Add(RefB);
        return hash.ToHashCode();
    }

    internal static StarIndependentParameters FromASTROM(ASTROM astrom)
    {
        return new(
            astrom.pmt,
            Vector3<double>.FromArrayZeroIfInvalid(astrom.eb), 
            Vector3<double>.FromArrayZeroIfInvalid(astrom.eh),
            astrom.em,
            Vector3<double>.FromArrayZeroIfInvalid(astrom.v),
            astrom.bm1,
            Matrix<double>.FromArrayZeroIfInvalid(3, 3, astrom.bpn),
            astrom.along,
            astrom.phi,
            astrom.xpl,
            astrom.ypl,
            astrom.sphi,
            astrom.cphi,
            astrom.diurab,
            astrom.eral,
            astrom.refa,
            astrom.refb);
    }

}
