namespace SOFA.NET;

internal static class ThrowHelper
{

    /// <summary>
    /// Throws exception if provided julian date is not as expected or is not specified.
    /// </summary>
    /// <exception cref="JulianDateKindException">Exception thrown.</exception>
    public static void ThrowIfNotExpectedJulianDateKind(JulianDateKind expected, JulianDate actual, bool ignore = false)
    {
        if (ignore) return;

        if (actual.Kind != JulianDateKind.Unspecified && actual.Kind != expected)
        {
            throw new JulianDateKindException(expected, actual.Kind);
        }
    }

    /// <summary>
    /// Throws if enum is not defined.
    /// </summary>
    /// <exception cref="ArgumentException">Exception thrown.</exception>
    public static void ThrowIfUndefinedEnum<TEnum>(TEnum enumValue)
        where TEnum : struct, Enum
    {
        if (!Enum.IsDefined(enumValue))
        {
            throw new ArgumentException($"The provided enum value of {enumValue.GetType().Name} is not valid.");
        }
    }

}
