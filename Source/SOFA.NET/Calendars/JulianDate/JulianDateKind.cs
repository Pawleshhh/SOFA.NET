namespace SOFA.NET;

public enum JulianDateKind
{
    Unspecified,
    Local,
    Utc,
    Ut1,
    Tt,
    Tcb,
    Tdb,
    Tcg,
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

