namespace SOFA.NET;

/// <summary>
/// Helper of managing delegates for functional programming.
/// </summary>
internal static partial class Fp
{

    public static Func<T> AsFunc<T>(this T value)
    {
        return () => value;
    }

    public static Func<T> BuildFunc<T>(this T param, Func<T, T> build)
    {
        return () => build(param);
    }

    public static Func<TTo> MapFunc<TFrom, TTo>(this TFrom param, Func<TFrom, TTo> build)
    {
        return () => build(param);
    }

}
