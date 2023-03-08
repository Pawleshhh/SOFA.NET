namespace SOFA.NET;

internal readonly struct ApproximateGeocentricPositionAndVelocityOfTheMoonCoefficients
{

    public readonly int nd, nem, nemp, nf;
    public readonly double coefl, coefr, coefb;

    public ApproximateGeocentricPositionAndVelocityOfTheMoonCoefficients(int nd, int nem, int nemp, int nf, double coefl, double coefr)
        => (this.nd, this.nem, this.nemp, this.nf, this.coefl, this.coefr) = (nd, nem, nemp, nf, coefl, coefr);

    public ApproximateGeocentricPositionAndVelocityOfTheMoonCoefficients(int nd, int nem, int nemp, int nf, double coefb)
        => (this.nd, this.nem, this.nemp, this.nf, this.coefb) = (nd, nem, nemp, nf, coefb);

    private static ApproximateGeocentricPositionAndVelocityOfTheMoonCoefficients[]? longitudeCoefficients;

    public static ApproximateGeocentricPositionAndVelocityOfTheMoonCoefficients[] LongitudeCoefficients
    {
        get
        {
            if (longitudeCoefficients == null)
            {
                longitudeCoefficients = InitializeLongitudeCoefficients();
            }

            return longitudeCoefficients;
        }
    }

    private static ApproximateGeocentricPositionAndVelocityOfTheMoonCoefficients[] InitializeLongitudeCoefficients()
    {
        return new ApproximateGeocentricPositionAndVelocityOfTheMoonCoefficients[]
        {
            new( 0,  0,  1,  0,  6.288774, -20905355.0),
            new( 2,  0, -1,  0,  1.274027,  -3699111.0),
            new( 2,  0,  0,  0,  0.658314,  -2955968.0),
            new( 0,  0,  2,  0,  0.213618,   -569925.0),
            new( 0,  1,  0,  0, -0.185116,     48888.0),
            new( 0,  0,  0,  2, -0.114332,     -3149.0),
            new( 2,  0, -2,  0,  0.058793,    246158.0),
            new( 2, -1, -1,  0,  0.057066,   -152138.0),
            new( 2,  0,  1,  0,  0.053322,   -170733.0),
            new( 2, -1,  0,  0,  0.045758,   -204586.0),
            new( 0,  1, -1,  0, -0.040923,   -129620.0),
            new( 1,  0,  0,  0, -0.034720,    108743.0),
            new( 0,  1,  1,  0, -0.030383,    104755.0),
            new( 2,  0,  0, -2,  0.015327,     10321.0),
            new( 0,  0,  1,  2, -0.012528,         0.0),
            new( 0,  0,  1, -2,  0.010980,     79661.0),
            new( 4,  0, -1,  0,  0.010675,    -34782.0),
            new( 0,  0,  3,  0,  0.010034,    -23210.0),
            new( 4,  0, -2,  0,  0.008548,    -21636.0),
            new( 2,  1, -1,  0, -0.007888,     24208.0),
            new( 2,  1,  0,  0, -0.006766,     30824.0),
            new( 1,  0, -1,  0, -0.005163,     -8379.0),
            new( 1,  1,  0,  0,  0.004987,    -16675.0),
            new( 2, -1,  1,  0,  0.004036,    -12831.0),
            new( 2,  0,  2,  0,  0.003994,    -10445.0),
            new( 4,  0,  0,  0,  0.003861,    -11650.0),
            new( 2,  0, -3,  0,  0.003665,     14403.0),
            new( 0,  1, -2,  0, -0.002689,     -7003.0),
            new( 2,  0, -1,  2, -0.002602,         0.0),
            new( 2, -1, -2,  0,  0.002390,     10056.0),
            new( 1,  0,  1,  0, -0.002348,      6322.0),
            new( 2, -2,  0,  0,  0.002236,     -9884.0),
            new( 0,  1,  2,  0, -0.002120,      5751.0),
            new( 0,  2,  0,  0, -0.002069,         0.0),
            new( 2, -2, -1,  0,  0.002048,     -4950.0),
            new( 2,  0,  1, -2, -0.001773,      4130.0),
            new( 2,  0,  0,  2, -0.001595,         0.0),
            new( 4, -1, -1,  0,  0.001215,     -3958.0),
            new( 0,  0,  2,  2, -0.001110,         0.0),
            new( 3,  0, -1,  0, -0.000892,      3258.0),
            new( 2,  1,  1,  0, -0.000810,      2616.0),
            new( 4, -1, -2,  0,  0.000759,     -1897.0),
            new( 0,  2, -1,  0, -0.000713,     -2117.0),
            new( 2,  2, -1,  0, -0.000700,      2354.0),
            new( 2,  1, -2,  0,  0.000691,         0.0),
            new( 2, -1,  0, -2,  0.000596,         0.0),
            new( 4,  0,  1,  0,  0.000549,     -1423.0),
            new( 0,  0,  4,  0,  0.000537,     -1117.0),
            new( 4, -1,  0,  0,  0.000520,     -1571.0),
            new( 1,  0, -2,  0, -0.000487,     -1739.0),
            new( 2,  1,  0, -2, -0.000399,         0.0),
            new( 0,  0,  2, -2, -0.000381,     -4421.0),
            new( 1,  1,  1,  0,  0.000351,         0.0),
            new( 3,  0, -2,  0, -0.000340,         0.0),
            new( 4,  0, -3,  0,  0.000330,         0.0),
            new( 2, -1,  2,  0,  0.000327,         0.0),
            new( 0,  2,  1,  0, -0.000323,      1165.0),
            new( 1,  1, -1,  0,  0.000299,         0.0),
            new( 2,  0,  3,  0,  0.000294,         0.0),
            new( 2,  0, -1, -2,  0.000000,      8752.0),
        };
    }

    private static ApproximateGeocentricPositionAndVelocityOfTheMoonCoefficients[]? latitudeCoefficients;

    public static ApproximateGeocentricPositionAndVelocityOfTheMoonCoefficients[] LatitudeCoefficients
    {
        get
        {
            if (latitudeCoefficients == null)
            {
                latitudeCoefficients = InitializeLatitudeCoefficients();
            }

            return latitudeCoefficients;
        }
    }

    private static ApproximateGeocentricPositionAndVelocityOfTheMoonCoefficients[] InitializeLatitudeCoefficients()
    {
        return new ApproximateGeocentricPositionAndVelocityOfTheMoonCoefficients[]
        {
            new(0,  0,  0,  1,  5.128122),
            new(0,  0,  1,  1,  0.280602),
            new(0,  0,  1, -1,  0.277693),
            new(2,  0,  0, -1,  0.173237),
            new(2,  0, -1,  1,  0.055413),
            new(2,  0, -1, -1,  0.046271),
            new(2,  0,  0,  1,  0.032573),
            new(0,  0,  2,  1,  0.017198),
            new(2,  0,  1, -1,  0.009266),
            new(0,  0,  2, -1,  0.008822),
            new(2, -1,  0, -1,  0.008216),
            new(2,  0, -2, -1,  0.004324),
            new(2,  0,  1,  1,  0.004200),
            new(2,  1,  0, -1, -0.003359),
            new(2, -1, -1,  1,  0.002463),
            new(2, -1,  0,  1,  0.002211),
            new(2, -1, -1, -1,  0.002065),
            new(0,  1, -1, -1, -0.001870),
            new(4,  0, -1, -1,  0.001828),
            new(0,  1,  0,  1, -0.001794),
            new(0,  0,  0,  3, -0.001749),
            new(0,  1, -1,  1, -0.001565),
            new(1,  0,  0,  1, -0.001491),
            new(0,  1,  1,  1, -0.001475),
            new(0,  1,  1, -1, -0.001410),
            new(0,  1,  0, -1, -0.001344),
            new(1,  0,  0, -1, -0.001335),
            new(0,  0,  3,  1,  0.001107),
            new(4,  0,  0, -1,  0.001021),
            new(4,  0, -1,  1,  0.000833),
            new(0,  0,  1, -3,  0.000777),
            new(4,  0, -2,  1,  0.000671),
            new(2,  0,  0, -3,  0.000607),
            new(2,  0,  2, -1,  0.000596),
            new(2, -1,  1, -1,  0.000491),
            new(2,  0, -2,  1, -0.000451),
            new(0,  0,  3, -1,  0.000439),
            new(2,  0,  2,  1,  0.000422),
            new(2,  0, -3, -1,  0.000421),
            new(2,  1, -1,  1, -0.000366),
            new(2,  1,  0,  1, -0.000351),
            new(4,  0,  0,  1,  0.000331),
            new(2, -1,  1,  1,  0.000315),
            new(2, -2,  0, -1,  0.000302),
            new(0,  0,  1,  3, -0.000283),
            new(2,  1,  1, -1, -0.000229),
            new(1,  1,  0, -1,  0.000223),
            new(1,  1,  0,  1,  0.000223),
            new(0,  1, -2, -1, -0.000220),
            new(2,  1, -1, -1, -0.000220),
            new(1,  0,  1,  1, -0.000185),
            new(2, -1, -2, -1,  0.000181),
            new(0,  1,  2,  1, -0.000177),
            new(4,  0, -2, -1,  0.000176),
            new(4, -1, -1, -1,  0.000166),
            new(1,  0,  1, -1, -0.000164),
            new(4,  0,  1, -1,  0.000132),
            new(1,  0, -1, -1, -0.000119),
            new(4, -1,  0, -1,  0.000115),
            new(2, -2,  0,  1,  0.000107),
        };
    }

}
