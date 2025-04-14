namespace SOFA.NET;

internal class Ephemerides
{

    public static (object, object) EarthPositionAndVelocityBCRS(JulianDate julianDate)
    {
        var (d1, d2) = julianDate;
        var pvh = new double[6];
        var pvb = new double[6];
        return SofaEphemerides.Epv00(d1, d2, pvh, pvb) switch
        {
            0 => (pvh, pvb),
            _ => throw new ArgumentException("Date outside the range 1900 - 2100 AD")
        };
    }

}
