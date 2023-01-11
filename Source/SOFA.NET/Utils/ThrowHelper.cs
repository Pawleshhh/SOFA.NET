namespace SOFA.NET;

internal static class ThrowHelper
{

    public static void ThrowIfNotExpectedJulianDateKind(JulianDateKind expected, JulianDate actual, bool ignore = false)
    {
        if (ignore) return;

        if (actual.Kind != JulianDateKind.Unspecified && actual.Kind != expected)
        {
            throw new JulianDateKindException(expected, actual.Kind);
        }
    }

}
