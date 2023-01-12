namespace SOFA.NET;

internal static partial class Fp
{

    #region Compose Func forward

    public static Func<A, C> Compose<A, B, C>(
        this Func<A, B> func1, 
        Func<B, C> func2)
    {
        return p => func2(func1(p));
    }
    public static Func<A, C> Compose<A, A1, B, B1, C>(
        this Func<A1, A, B> func1, A1 a1,
        Func<B1, B, C> func2, B1 b1)
    {
        return p => func2(b1, func1(a1, p));
    }
    public static Func<A, C> Compose<A, A1, A2, B, B1, B2, C>(
        this Func<A1, A2, A, B> func1, A1 a1, A2 a2,
        Func<B1, B2, B, C> func2, B1 b1, B2 b2)
    {
        return p => func2(b1, b2, func1(a1, a2, p));
    }
    public static Func<A, C> Compose<A, A1, A2, A3, B, B1, B2, B3, C>(
        this Func<A1, A2, A3, A, B> func1, A1 a1, A2 a2, A3 a3,
        Func<B1, B2, B3, B, C> func2, B1 b1, B2 b2, B3 b3)
    {
        return p => func2(b1, b2, b3, func1(a1, a2, a3, p));
    }
    public static Func<A, C> Compose<A, A1, A2, A3, A4, B, B1, B2, B3, B4, C>(
        this Func<A1, A2, A3, A4, A, B> func1, A1 a1, A2 a2, A3 a3, A4 a4,
        Func<B1, B2, B3, B4, B, C> func2, B1 b1, B2 b2, B3 b3, B4 b4)
    {
        return p => func2(b1, b2, b3, b4, func1(a1, a2, a3, a4, p));
    }
    public static Func<A, C> Compose<A, A1, A2, A3, A4, A5, B, B1, B2, B3, B4, B5, C>(
        this Func<A1, A2, A3, A4, A5, A, B> func1, A1 a1, A2 a2, A3 a3, A4 a4, A5 a5,
        Func<B1, B2, B3, B4, B5, B, C> func2, B1 b1, B2 b2, B3 b3, B4 b4, B5 b5)
    {
        return p => func2(b1, b2, b3, b4, b5, func1(a1, a2, a3, a4, a5, p));
    }
    public static Func<A, C> Compose<A, A1, A2, A3, A4, A5, A6, B, B1, B2, B3, B4, B5, B6, C>(
        this Func<A1, A2, A3, A4, A5, A6, A, B> func1, A1 a1, A2 a2, A3 a3, A4 a4, A5 a5, A6 a6,
        Func<B1, B2, B3, B4, B5, B6, B, C> func2, B1 b1, B2 b2, B3 b3, B4 b4, B5 b5, B6 b6)
    {
        return p => func2(b1, b2, b3, b4, b5, b6, func1(a1, a2, a3, a4, a5, a6, p));
    }
    public static Func<A, C> Compose<A, A1, A2, A3, A4, A5, A6, A7, B, B1, B2, B3, B4, B5, B6, B7, C>(
        this Func<A1, A2, A3, A4, A5, A6, A7, A, B> func1, A1 a1, A2 a2, A3 a3, A4 a4, A5 a5, A6 a6, A7 a7,
        Func<B1, B2, B3, B4, B5, B6, B7, B, C> func2, B1 b1, B2 b2, B3 b3, B4 b4, B5 b5, B6 b6, B7 b7)
    {
        return p => func2(b1, b2, b3, b4, b5, b6, b7, func1(a1, a2, a3, a4, a5, a6, a7, p));
    }
    public static Func<A, C> Compose<A, A1, A2, A3, A4, A5, A6, A7, A8, B, B1, B2, B3, B4, B5, B6, B7, B8, C>(
        this Func<A1, A2, A3, A4, A5, A6, A7, A8, A, B> func1, A1 a1, A2 a2, A3 a3, A4 a4, A5 a5, A6 a6, A7 a7, A8 a8,
        Func<B1, B2, B3, B4, B5, B6, B7, B8, B, C> func2, B1 b1, B2 b2, B3 b3, B4 b4, B5 b5, B6 b6, B7 b7, B8 b8)
    {
        return p => func2(b1, b2, b3, b4, b5, b6, b7, b8, func1(a1, a2, a3, a4, a5, a6, a7, a8, p));
    }
    public static Func<A, C> Compose<A, A1, A2, A3, A4, A5, A6, A7, A8, A9, B, B1, B2, B3, B4, B5, B6, B7, B8, B9, C>(
        this Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A, B> func1, A1 a1, A2 a2, A3 a3, A4 a4, A5 a5, A6 a6, A7 a7, A8 a8, A9 a9,
        Func<B1, B2, B3, B4, B5, B6, B7, B8, B9, B, C> func2, B1 b1, B2 b2, B3 b3, B4 b4, B5 b5, B6 b6, B7 b7, B8 b8, B9 b9)
    {
        return p => func2(b1, b2, b3, b4, b5, b6, b7, b8, b9, func1(a1, a2, a3, a4, a5, a6, a7, a8, a9, p));
    }
    public static Func<A, C> Compose<A, A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, B, B1, B2, B3, B4, B5, B6, B7, B8, B9, B10, C>(
        this Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A, B> func1, A1 a1, A2 a2, A3 a3, A4 a4, A5 a5, A6 a6, A7 a7, A8 a8, A9 a9, A10 a10,
        Func<B1, B2, B3, B4, B5, B6, B7, B8, B9, B10, B, C> func2, B1 b1, B2 b2, B3 b3, B4 b4, B5 b5, B6 b6, B7 b7, B8 b8, B9 b9, B10 b10)
    {
        return p => func2(b1, b2, b3, b4, b5, b6, b7, b8, b9, b10, func1(a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, p));
    }
    public static Func<A, C> Compose<A, A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, B, B1, B2, B3, B4, B5, B6, B7, B8, B9, B10, B11, C>(
        this Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A, B> func1, A1 a1, A2 a2, A3 a3, A4 a4, A5 a5, A6 a6, A7 a7, A8 a8, A9 a9, A10 a10, A11 a11,
        Func<B1, B2, B3, B4, B5, B6, B7, B8, B9, B10, B11, B, C> func2, B1 b1, B2 b2, B3 b3, B4 b4, B5 b5, B6 b6, B7 b7, B8 b8, B9 b9, B10 b10, B11 b11)
    {
        return p => func2(b1, b2, b3, b4, b5, b6, b7, b8, b9, b10, b11, func1(a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, p));
    }
    public static Func<A, C> Compose<A, A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, B, B1, B2, B3, B4, B5, B6, B7, B8, B9, B10, B11, B12, C>(
        this Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A, B> func1, A1 a1, A2 a2, A3 a3, A4 a4, A5 a5, A6 a6, A7 a7, A8 a8, A9 a9, A10 a10, A11 a11, A12 a12,
        Func<B1, B2, B3, B4, B5, B6, B7, B8, B9, B10, B11, B12, B, C> func2, B1 b1, B2 b2, B3 b3, B4 b4, B5 b5, B6 b6, B7 b7, B8 b8, B9 b9, B10 b10, B11 b11, B12 b12)
    {
        return p => func2(b1, b2, b3, b4, b5, b6, b7, b8, b9, b10, b11, b12, func1(a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, p));
    }
    public static Func<A, C> Compose<A, A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, B, B1, B2, B3, B4, B5, B6, B7, B8, B9, B10, B11, B12, B13, C>(
        this Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A, B> func1, A1 a1, A2 a2, A3 a3, A4 a4, A5 a5, A6 a6, A7 a7, A8 a8, A9 a9, A10 a10, A11 a11, A12 a12, A13 a13,
        Func<B1, B2, B3, B4, B5, B6, B7, B8, B9, B10, B11, B12, B13, B, C> func2, B1 b1, B2 b2, B3 b3, B4 b4, B5 b5, B6 b6, B7 b7, B8 b8, B9 b9, B10 b10, B11 b11, B12 b12, B13 b13)
    {
        return p => func2(b1, b2, b3, b4, b5, b6, b7, b8, b9, b10, b11, b12, b13, func1(a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13, p));
    }
    public static Func<A, C> Compose<A, A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, B, B1, B2, B3, B4, B5, B6, B7, B8, B9, B10, B11, B12, B13, B14, C>(
        this Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, A, B> func1, A1 a1, A2 a2, A3 a3, A4 a4, A5 a5, A6 a6, A7 a7, A8 a8, A9 a9, A10 a10, A11 a11, A12 a12, A13 a13, A14 a14,
        Func<B1, B2, B3, B4, B5, B6, B7, B8, B9, B10, B11, B12, B13, B14, B, C> func2, B1 b1, B2 b2, B3 b3, B4 b4, B5 b5, B6 b6, B7 b7, B8 b8, B9 b9, B10 b10, B11 b11, B12 b12, B13 b13, B14 b14)
    {
        return p => func2(b1, b2, b3, b4, b5, b6, b7, b8, b9, b10, b11, b12, b13, b14, func1(a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13, a14, p));
    }
    public static Func<A, C> Compose<A, A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, A15, B, B1, B2, B3, B4, B5, B6, B7, B8, B9, B10, B11, B12, B13, B14, B15, C>(
        this Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, A15, A, B> func1, A1 a1, A2 a2, A3 a3, A4 a4, A5 a5, A6 a6, A7 a7, A8 a8, A9 a9, A10 a10, A11 a11, A12 a12, A13 a13, A14 a14, A15 a15,
        Func<B1, B2, B3, B4, B5, B6, B7, B8, B9, B10, B11, B12, B13, B14, B15, B, C> func2, B1 b1, B2 b2, B3 b3, B4 b4, B5 b5, B6 b6, B7 b7, B8 b8, B9 b9, B10 b10, B11 b11, B12 b12, B13 b13, B14 b14, B15 b15)
    {
        return p => func2(b1, b2, b3, b4, b5, b6, b7, b8, b9, b10, b11, b12, b13, b14, b15, func1(a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13, a14, a15, p));
    }

    #endregion Compose Func

    #region Compose Func backward
    public static Func<A, C> ComposeBack<A, B, C>(
        this Func<B, C> func1, 
        Func<A, B> func2)
    {
        return p => func1(func2(p));
    }
    public static Func<A, C> ComposeBack<A, A1, B, B1, C>(
        this Func<A1, B, C> func1, A1 a1,
        Func<B1, A, B> func2, B1 b1)
    {
        return p => func1(a1, func2(b1, p));
    }
    public static Func<A, C> ComposeBack<A, A1, A2, B, B1, B2, C>(
        this Func<A1, A2, B, C> func1, A1 a1, A2 a2,
        Func<B1, B2, A, B> func2, B1 b1, B2 b2)
    {
        return p => func1(a1, a2, func2(b1, b2, p));
    }
    public static Func<A, C> ComposeBack<A, A1, A2, A3, B, B1, B2, B3, C>(
        this Func<A1, A2, A3, B, C> func1, A1 a1, A2 a2, A3 a3,
        Func<B1, B2, B3, A, B> func2, B1 b1, B2 b2, B3 b3)
    {
        return p => func1(a1, a2, a3, func2(b1, b2, b3, p));
    }
    public static Func<A, C> ComposeBack<A, A1, A2, A3, A4, B, B1, B2, B3, B4, C>(
        this Func<A1, A2, A3, A4, B, C> func1, A1 a1, A2 a2, A3 a3, A4 a4,
        Func<B1, B2, B3, B4, A, B> func2, B1 b1, B2 b2, B3 b3, B4 b4)
    {
        return p => func1(a1, a2, a3, a4, func2(b1, b2, b3, b4, p));
    }
    public static Func<A, C> ComposeBack<A, A1, A2, A3, A4, A5, B, B1, B2, B3, B4, B5, C>(
        this Func<A1, A2, A3, A4, A5, B, C> func1, A1 a1, A2 a2, A3 a3, A4 a4, A5 a5,
        Func<B1, B2, B3, B4, B5, A, B> func2, B1 b1, B2 b2, B3 b3, B4 b4, B5 b5)
    {
        return p => func1(a1, a2, a3, a4, a5, func2(b1, b2, b3, b4, b5, p));
    }
    public static Func<A, C> ComposeBack<A, A1, A2, A3, A4, A5, A6, B, B1, B2, B3, B4, B5, B6, C>(
        this Func<A1, A2, A3, A4, A5, A6, B, C> func1, A1 a1, A2 a2, A3 a3, A4 a4, A5 a5, A6 a6,
        Func<B1, B2, B3, B4, B5, B6, A, B> func2, B1 b1, B2 b2, B3 b3, B4 b4, B5 b5, B6 b6)
    {
        return p => func1(a1, a2, a3, a4, a5, a6, func2(b1, b2, b3, b4, b5, b6, p));
    }
    public static Func<A, C> ComposeBack<A, A1, A2, A3, A4, A5, A6, A7, B, B1, B2, B3, B4, B5, B6, B7, C>(
        this Func<A1, A2, A3, A4, A5, A6, A7, B, C> func1, A1 a1, A2 a2, A3 a3, A4 a4, A5 a5, A6 a6, A7 a7,
        Func<B1, B2, B3, B4, B5, B6, B7, A, B> func2, B1 b1, B2 b2, B3 b3, B4 b4, B5 b5, B6 b6, B7 b7)
    {
        return p => func1(a1, a2, a3, a4, a5, a6, a7, func2(b1, b2, b3, b4, b5, b6, b7, p));
    }
    public static Func<A, C> ComposeBack<A, A1, A2, A3, A4, A5, A6, A7, A8, B, B1, B2, B3, B4, B5, B6, B7, B8, C>(
        this Func<A1, A2, A3, A4, A5, A6, A7, A8, B, C> func1, A1 a1, A2 a2, A3 a3, A4 a4, A5 a5, A6 a6, A7 a7, A8 a8,
        Func<B1, B2, B3, B4, B5, B6, B7, B8, A, B> func2, B1 b1, B2 b2, B3 b3, B4 b4, B5 b5, B6 b6, B7 b7, B8 b8)
    {
        return p => func1(a1, a2, a3, a4, a5, a6, a7, a8, func2(b1, b2, b3, b4, b5, b6, b7, b8, p));
    }
    public static Func<A, C> ComposeBack<A, A1, A2, A3, A4, A5, A6, A7, A8, A9, B, B1, B2, B3, B4, B5, B6, B7, B8, B9, C>(
        this Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, B, C> func1, A1 a1, A2 a2, A3 a3, A4 a4, A5 a5, A6 a6, A7 a7, A8 a8, A9 a9,
        Func<B1, B2, B3, B4, B5, B6, B7, B8, B9, A, B> func2, B1 b1, B2 b2, B3 b3, B4 b4, B5 b5, B6 b6, B7 b7, B8 b8, B9 b9)
    {
        return p => func1(a1, a2, a3, a4, a5, a6, a7, a8, a9, func2(b1, b2, b3, b4, b5, b6, b7, b8, b9, p));
    }
    public static Func<A, C> ComposeBack<A, A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, B, B1, B2, B3, B4, B5, B6, B7, B8, B9, B10, C>(
        this Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, B, C> func1, A1 a1, A2 a2, A3 a3, A4 a4, A5 a5, A6 a6, A7 a7, A8 a8, A9 a9, A10 a10,
        Func<B1, B2, B3, B4, B5, B6, B7, B8, B9, B10, A, B> func2, B1 b1, B2 b2, B3 b3, B4 b4, B5 b5, B6 b6, B7 b7, B8 b8, B9 b9, B10 b10)
    {
        return p => func1(a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, func2(b1, b2, b3, b4, b5, b6, b7, b8, b9, b10, p));
    }
    public static Func<A, C> ComposeBack<A, A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, B, B1, B2, B3, B4, B5, B6, B7, B8, B9, B10, B11, C>(
        this Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, B, C> func1, A1 a1, A2 a2, A3 a3, A4 a4, A5 a5, A6 a6, A7 a7, A8 a8, A9 a9, A10 a10, A11 a11,
        Func<B1, B2, B3, B4, B5, B6, B7, B8, B9, B10, B11, A, B> func2, B1 b1, B2 b2, B3 b3, B4 b4, B5 b5, B6 b6, B7 b7, B8 b8, B9 b9, B10 b10, B11 b11)
    {
        return p => func1(a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, func2(b1, b2, b3, b4, b5, b6, b7, b8, b9, b10, b11, p));
    }
    public static Func<A, C> ComposeBack<A, A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, B, B1, B2, B3, B4, B5, B6, B7, B8, B9, B10, B11, B12, C>(
        this Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, B, C> func1, A1 a1, A2 a2, A3 a3, A4 a4, A5 a5, A6 a6, A7 a7, A8 a8, A9 a9, A10 a10, A11 a11, A12 a12,
        Func<B1, B2, B3, B4, B5, B6, B7, B8, B9, B10, B11, B12, A, B> func2, B1 b1, B2 b2, B3 b3, B4 b4, B5 b5, B6 b6, B7 b7, B8 b8, B9 b9, B10 b10, B11 b11, B12 b12)
    {
        return p => func1(a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, func2(b1, b2, b3, b4, b5, b6, b7, b8, b9, b10, b11, b12, p));
    }
    public static Func<A, C> ComposeBack<A, A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, B, B1, B2, B3, B4, B5, B6, B7, B8, B9, B10, B11, B12, B13, C>(
        this Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, B, C> func1, A1 a1, A2 a2, A3 a3, A4 a4, A5 a5, A6 a6, A7 a7, A8 a8, A9 a9, A10 a10, A11 a11, A12 a12, A13 a13,
        Func<B1, B2, B3, B4, B5, B6, B7, B8, B9, B10, B11, B12, B13, A, B> func2, B1 b1, B2 b2, B3 b3, B4 b4, B5 b5, B6 b6, B7 b7, B8 b8, B9 b9, B10 b10, B11 b11, B12 b12, B13 b13)
    {
        return p => func1(a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13, func2(b1, b2, b3, b4, b5, b6, b7, b8, b9, b10, b11, b12, b13, p));
    }
    public static Func<A, C> ComposeBack<A, A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, B, B1, B2, B3, B4, B5, B6, B7, B8, B9, B10, B11, B12, B13, B14, C>(
        this Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, B, C> func1, A1 a1, A2 a2, A3 a3, A4 a4, A5 a5, A6 a6, A7 a7, A8 a8, A9 a9, A10 a10, A11 a11, A12 a12, A13 a13, A14 a14,
        Func<B1, B2, B3, B4, B5, B6, B7, B8, B9, B10, B11, B12, B13, B14, A, B> func2, B1 b1, B2 b2, B3 b3, B4 b4, B5 b5, B6 b6, B7 b7, B8 b8, B9 b9, B10 b10, B11 b11, B12 b12, B13 b13, B14 b14)
    {
        return p => func1(a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13, a14, func2(b1, b2, b3, b4, b5, b6, b7, b8, b9, b10, b11, b12, b13, b14, p));
    }
    public static Func<A, C> ComposeBack<A, A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, A15, B, B1, B2, B3, B4, B5, B6, B7, B8, B9, B10, B11, B12, B13, B14, B15, C>(
        this Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, A15, B, C> func1, A1 a1, A2 a2, A3 a3, A4 a4, A5 a5, A6 a6, A7 a7, A8 a8, A9 a9, A10 a10, A11 a11, A12 a12, A13 a13, A14 a14, A15 a15,
        Func<B1, B2, B3, B4, B5, B6, B7, B8, B9, B10, B11, B12, B13, B14, B15, A, B> func2, B1 b1, B2 b2, B3 b3, B4 b4, B5 b5, B6 b6, B7 b7, B8 b8, B9 b9, B10 b10, B11 b11, B12 b12, B13 b13, B14 b14, B15 b15)
    {
        return p => func1(a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13, a14, a15, func2(b1, b2, b3, b4, b5, b6, b7, b8, b9, b10, b11, b12, b13, b14, b15, p));
    }

    #endregion Compose Func backward

}
