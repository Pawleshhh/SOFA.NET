namespace SOFA.NET;

public enum JulianDateKind
{
    /// <summary>
    /// Unspecified kind of time
    /// </summary>
    Unspecified,
    /// <summary>
    /// Local time
    /// </summary>
    Local,
    /// <summary>
    /// Coordinated Universal Time
    /// </summary>
    Utc,
    /// <summary>
    /// Universal Time
    /// </summary>
    Ut1,
    /// <summary>
    /// Terrestrial Time
    /// </summary>
    Tt,
    /// <summary>
    /// Barycentric Coordinate Time
    /// </summary>
    Tcb,
    /// <summary>
    /// Barycentric Dynamical Time
    /// </summary>
    Tdb,
    /// <summary>
    /// Geocentric Coordinate Time
    /// </summary>
    Tcg,
    /// <summary>
    /// International Atomic Time
    /// </summary>
    Tai,
}

//internal static class JulianDateAndDateTimeKindExtensions
//{

//    public static DateTimeKind ToDateTimeKind(this JulianDateKind julianDateKind)
//    {
//        switch (julianDateKind)
//        {
//            case JulianDateKind.Local:
//                return DateTimeKind.Local;
//            case JulianDateKind.Utc:
//                return DateTimeKind.Utc;
//            default:
//                return DateTimeKind.Unspecified;
//        }
//    }

//    public static JulianDateKind ToJulianDateKind(this DateTimeKind dateTimeKind)
//    {
//        switch (dateTimeKind)
//        {
//            case DateTimeKind.Local:
//                return JulianDateKind.Local;
//            case DateTimeKind.Utc:
//                return JulianDateKind.Utc;
//            default:
//                return JulianDateKind.Unspecified;
//        }
//    }

//}

