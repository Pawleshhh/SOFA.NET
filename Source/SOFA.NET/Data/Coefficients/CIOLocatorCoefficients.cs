namespace SOFA.NET;

internal readonly struct CIOLocatorCoefficients
{
    public readonly int[] nfa;
    public readonly double s, c;

    public CIOLocatorCoefficients(int[] nfa, double s, double c)
        => (this.nfa, this.s, this.c) = (nfa, s, c);


    private static CIOLocatorCoefficients[]? coefficientsS0;
    private static CIOLocatorCoefficients[]? coefficientsS1;
    private static CIOLocatorCoefficients[]? coefficientsS2;
    private static CIOLocatorCoefficients[]? coefficientsS3;
    private static CIOLocatorCoefficients[]? coefficientsS4;

    public static CIOLocatorCoefficients[] CoefficientsS0
    {
        get
        {
            if (coefficientsS0 == null)
            {
                coefficientsS0 = InitializeS0();
            }

            return coefficientsS0;
        }
    }
    public static CIOLocatorCoefficients[] CoefficientsS1
    {
        get
        {
            if (coefficientsS1 == null)
            {
                coefficientsS1 = InitializeS1();
            }

            return coefficientsS1;
        }
    }
    public static CIOLocatorCoefficients[] CoefficientsS2
    {
        get
        {
            if (coefficientsS2 == null)
            {
                coefficientsS2 = InitializeS2();
            }

            return coefficientsS2;
        }
    }
    public static CIOLocatorCoefficients[] CoefficientsS3
    {
        get
        {
            if (coefficientsS3 == null)
            {
                coefficientsS3 = InitializeS3();
            }

            return coefficientsS3;
        }
    }
    public static CIOLocatorCoefficients[] CoefficientsS4
    {
        get
        {
            if (coefficientsS4 == null)
            {
                coefficientsS4 = InitializeS4();
            }

            return coefficientsS4;
        }
    }

    private static CIOLocatorCoefficients[] InitializeS0()
    {
        return new CIOLocatorCoefficients[]
        {
            /* 1-10 */
            new(new [] { 0,  0,  0,  0,  1,  0,  0,  0}, -2640.73e-6,   0.39e-6 ),
            new(new [] { 0,  0,  0,  0,  2,  0,  0,  0},   -63.53e-6,   0.02e-6 ),
            new(new [] { 0,  0,  2, -2,  3,  0,  0,  0},   -11.75e-6,  -0.01e-6 ),
            new(new [] { 0,  0,  2, -2,  1,  0,  0,  0},   -11.21e-6,  -0.01e-6 ),
            new(new [] { 0,  0,  2, -2,  2,  0,  0,  0},     4.57e-6,   0.00e-6 ),
            new(new [] { 0,  0,  2,  0,  3,  0,  0,  0},    -2.02e-6,   0.00e-6 ),
            new(new [] { 0,  0,  2,  0,  1,  0,  0,  0},    -1.98e-6,   0.00e-6 ),
            new(new [] { 0,  0,  0,  0,  3,  0,  0,  0},     1.72e-6,   0.00e-6 ),
            new(new [] { 0,  1,  0,  0,  1,  0,  0,  0},     1.41e-6,   0.01e-6 ),
            new(new [] { 0,  1,  0,  0, -1,  0,  0,  0},     1.26e-6,   0.01e-6 ),

            /* 11-20 */
            new(new [] { 1,  0,  0,  0, -1,  0,  0,  0},     0.63e-6,   0.00e-6 ),
            new(new [] { 1,  0,  0,  0,  1,  0,  0,  0},     0.63e-6,   0.00e-6 ),
            new(new [] { 0,  1,  2, -2,  3,  0,  0,  0},    -0.46e-6,   0.00e-6 ),
            new(new [] { 0,  1,  2, -2,  1,  0,  0,  0},    -0.45e-6,   0.00e-6 ),
            new(new [] { 0,  0,  4, -4,  4,  0,  0,  0},    -0.36e-6,   0.00e-6 ),
            new(new [] { 0,  0,  1, -1,  1, -8, 12,  0},     0.24e-6,   0.12e-6 ),
            new(new [] { 0,  0,  2,  0,  0,  0,  0,  0},    -0.32e-6,   0.00e-6 ),
            new(new [] { 0,  0,  2,  0,  2,  0,  0,  0},    -0.28e-6,   0.00e-6 ),
            new(new [] { 1,  0,  2,  0,  3,  0,  0,  0},    -0.27e-6,   0.00e-6 ),
            new(new [] { 1,  0,  2,  0,  1,  0,  0,  0},    -0.26e-6,   0.00e-6 ),

            /* 21-30 */
            new(new [] { 0,  0,  2, -2,  0,  0,  0,  0},     0.21e-6,   0.00e-6 ),
            new(new [] { 0,  1, -2,  2, -3,  0,  0,  0},    -0.19e-6,   0.00e-6 ),
            new(new [] { 0,  1, -2,  2, -1,  0,  0,  0},    -0.18e-6,   0.00e-6 ),
            new(new [] { 0,  0,  0,  0,  0,  8,-13, -1},     0.10e-6,  -0.05e-6 ),
            new(new [] { 0,  0,  0,  2,  0,  0,  0,  0},    -0.15e-6,   0.00e-6 ),
            new(new [] { 2,  0, -2,  0, -1,  0,  0,  0},     0.14e-6,   0.00e-6 ),
            new(new [] { 0,  1,  2, -2,  2,  0,  0,  0},     0.14e-6,   0.00e-6 ),
            new(new [] { 1,  0,  0, -2,  1,  0,  0,  0},    -0.14e-6,   0.00e-6 ),
            new(new [] { 1,  0,  0, -2, -1,  0,  0,  0},    -0.14e-6,   0.00e-6 ),
            new(new [] { 0,  0,  4, -2,  4,  0,  0,  0},    -0.13e-6,   0.00e-6 ),

            /* 31-33 */
            new(new [] { 0,  0,  2, -2,  4,  0,  0,  0},     0.11e-6,   0.00e-6 ),
            new(new [] { 1,  0, -2,  0, -3,  0,  0,  0},    -0.11e-6,   0.00e-6 ),
            new(new [] { 1,  0, -2,  0, -1,  0,  0,  0},    -0.11e-6,   0.00e-6 ),
        };
    }
    private static CIOLocatorCoefficients[] InitializeS1()
    {
        return new CIOLocatorCoefficients[]
        {
            /* 1 - 3 */
            new(new [] { 0,  0,  0,  0,  2,  0,  0,  0},    -0.07e-6,   3.57e-6 ),
            new(new[] { 0,  0,  0,  0,  1,  0,  0,  0},     1.73e-6,  -0.03e-6 ),
            new (new [] { 0,  0,  2, -2,  3,  0,  0,  0},     0.00e-6,   0.48e-6 )
        };
    }
    private static CIOLocatorCoefficients[] InitializeS2()
    {
        return new CIOLocatorCoefficients[]
        {
            /* 1-10 */
            new(new[] { 0,  0,  0,  0,  1,  0,  0,  0},   743.52e-6,  -0.17e-6 ),
            new(new[] { 0,  0,  2, -2,  2,  0,  0,  0},    56.91e-6,   0.06e-6 ),
            new(new[] { 0,  0,  2,  0,  2,  0,  0,  0},     9.84e-6,  -0.01e-6 ),
            new(new[] { 0,  0,  0,  0,  2,  0,  0,  0},    -8.85e-6,   0.01e-6 ),
            new(new[] { 0,  1,  0,  0,  0,  0,  0,  0},    -6.38e-6,  -0.05e-6 ),
            new(new[] { 1,  0,  0,  0,  0,  0,  0,  0},    -3.07e-6,   0.00e-6 ),
            new(new[] { 0,  1,  2, -2,  2,  0,  0,  0},     2.23e-6,   0.00e-6 ),
            new(new[] { 0,  0,  2,  0,  1,  0,  0,  0},     1.67e-6,   0.00e-6 ),
            new(new[] { 1,  0,  2,  0,  2,  0,  0,  0},     1.30e-6,   0.00e-6 ),
            new(new[] { 0,  1, -2,  2, -2,  0,  0,  0},     0.93e-6,   0.00e-6 ),

            /* 11-20 */
            new(new[] { 1,  0,  0, -2,  0,  0,  0,  0},     0.68e-6,   0.00e-6 ),
            new(new[] { 0,  0,  2, -2,  1,  0,  0,  0},    -0.55e-6,   0.00e-6 ),
            new(new[] { 1,  0, -2,  0, -2,  0,  0,  0},     0.53e-6,   0.00e-6 ),
            new(new[] { 0,  0,  0,  2,  0,  0,  0,  0},    -0.27e-6,   0.00e-6 ),
            new(new[] { 1,  0,  0,  0,  1,  0,  0,  0},    -0.27e-6,   0.00e-6 ),
            new(new[] { 1,  0, -2, -2, -2,  0,  0,  0},    -0.26e-6,   0.00e-6 ),
            new(new[] { 1,  0,  0,  0, -1,  0,  0,  0},    -0.25e-6,   0.00e-6 ),
            new(new[] { 1,  0,  2,  0,  1,  0,  0,  0},     0.22e-6,   0.00e-6 ),
            new(new[] { 2,  0,  0, -2,  0,  0,  0,  0},    -0.21e-6,   0.00e-6 ),
            new(new[] { 2,  0, -2,  0, -1,  0,  0,  0},     0.20e-6,   0.00e-6 ),

            /* 21-25 */
            new(new[] { 0,  0,  2,  2,  2,  0,  0,  0},     0.17e-6,   0.00e-6 ),
            new(new[] { 2,  0,  2,  0,  2,  0,  0,  0},     0.13e-6,   0.00e-6 ),
            new(new[] { 2,  0,  0,  0,  0,  0,  0,  0},    -0.13e-6,   0.00e-6 ),
            new(new[] { 1,  0,  2, -2,  2,  0,  0,  0},    -0.12e-6,   0.00e-6 ),
            new(new[] { 0,  0,  2,  0,  0,  0,  0,  0},    -0.11e-6,   0.00e-6 ),
        };
    }
    private static CIOLocatorCoefficients[] InitializeS3()
    {
        return new CIOLocatorCoefficients[]
        {
            /* 1-4 */
            new(new[] { 0,  0,  0,  0,  1,  0,  0,  0},     0.30e-6, -23.42e-6 ),
            new(new[] { 0,  0,  2, -2,  2,  0,  0,  0},    -0.03e-6,  -1.46e-6 ),
            new(new[] { 0,  0,  2,  0,  2,  0,  0,  0},    -0.01e-6,  -0.25e-6 ),
            new(new[] { 0,  0,  0,  0,  2,  0,  0,  0},     0.00e-6,   0.23e-6 )
        };
    }
    private static CIOLocatorCoefficients[] InitializeS4()
    {
        return new CIOLocatorCoefficients[]
        {
            /* 1-1 */
            new(new[] { 0,  0,  0,  0,  1,  0,  0,  0},    -0.26e-6,  -0.01e-6 )
        };
    }
}
