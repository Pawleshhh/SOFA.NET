namespace SOFA.NET.Test;

[TestFixture]
internal class PrecNutPolarModuleTest
{

    [Test]
    public static void MeanObliquityOfTheEclipticIAU06_Test()
    {
        var julianDate = new JulianDate(2400000.5 + 54388.0);

        var result = PrecNutPolarModule
            .MeanObliquityOfTheEclipticIAU06(julianDate);

        Assert.That(result, Is.EqualTo(0.4090749229387258204).Within(1e-14));
    }

    [Test]
    public static void MeanObliquityOfTheEclipticIAU80_Test()
    {
        var julianDate = new JulianDate(2400000.5 + 54388.0);

        var result = PrecNutPolarModule
            .MeanObliquityOfTheEclipticIAU80(julianDate);

        Assert.That(result, Is.EqualTo(0.4090751347643816218).Within(1e-14));
    }

    [Test]
    public static void PrecessionAnglesIAU06_Test()
    {
        var julianDate = new JulianDate(2400000.5 + 50123.9999);

        var result = PrecNutPolarModule
            .PrecessionAnglesIAU06(julianDate);

        Assert.Multiple(() =>
        {
            Assert.That(result.Gamma, Is.EqualTo(-0.2243387670997995690e-5).Within(1e-16));
            Assert.That(result.Phi, Is.EqualTo(0.4091014602391312808).Within(1e-12));
            Assert.That(result.Psi, Is.EqualTo(-0.9501954178013031895e-3).Within(1e-14));
            Assert.That(result.Epsilion, Is.EqualTo(0.4091014316587367491).Within(1e-12));
        });
    }

    [Test]
    public static void FormRotationMatrix_Test()
    {
        FukushimaWilliamsAngles angles = new(
            -0.2243387670997992368e-5,
            0.4091014602391312982,
            -0.9501954178013015092e-3,
            0.4091014316587367472);

        var result = PrecNutPolarModule
            .FormRotationMatrix(angles);

        Assert.Multiple(() =>
        {
            double delta = 1e-12;
            Assert.That(result[0, 0], Is.EqualTo(0.9999995505176007047).Within(delta));
            Assert.That(result[0, 1], Is.EqualTo(0.8695404617348192957e-3).Within(delta));
            Assert.That(result[0, 2], Is.EqualTo(0.3779735201865582571e-3).Within(delta));
            Assert.That(result[1, 0], Is.EqualTo(-0.8695404723772016038e-3).Within(delta));
            Assert.That(result[1, 1], Is.EqualTo(0.9999996219496027161).Within(delta));
            Assert.That(result[1, 2], Is.EqualTo(-0.1361752496887100026e-6).Within(delta));
            Assert.That(result[2, 0], Is.EqualTo(-0.3779734957034082790e-3).Within(delta));
            Assert.That(result[2, 1], Is.EqualTo(-0.1924880848087615651e-6).Within(delta));
            Assert.That(result[2, 2], Is.EqualTo(0.9999999285679971958).Within(delta));
        });
    }

    [Test]
    public static void PrecessionMatrixFromGcrsToDateIAU06_Test()
    {
        var julianDate = new JulianDate(2400000.5 + 50123.9999);

        var result = PrecNutPolarModule
            .PrecessionMatrixFromGcrsToDateIAU06(julianDate);

        Assert.Multiple(() =>
        {
            double delta14 = 1e-14;
            double delta12 = 1e-12; 
            Assert.That(result[0, 0], Is.EqualTo(0.9999995505176007047).Within(delta12));
            Assert.That(result[0, 1], Is.EqualTo(0.8695404617348208406e-3).Within(delta14));
            Assert.That(result[0, 2], Is.EqualTo(0.3779735201865589104e-3).Within(delta14));
            Assert.That(result[1, 0], Is.EqualTo(-0.8695404723772031414e-3).Within(delta14));
            Assert.That(result[1, 1], Is.EqualTo(0.9999996219496027161).Within(delta12));
            Assert.That(result[1, 2], Is.EqualTo(-0.1361752497080270143e-6).Within(delta14));
            Assert.That(result[2, 0], Is.EqualTo(-0.3779734957034089490e-3).Within(delta14));
            Assert.That(result[2, 1], Is.EqualTo(-0.1924880847894457113e-6).Within(delta14));
            Assert.That(result[2, 2], Is.EqualTo(0.9999999285679971958).Within(delta12));
        });
    }

    [Test]
    public static void LongTermPrecessionOfTheEquator_Test()
    {
        var julianEpoch = -2500.0;

        var result = PrecNutPolarModule
            .LongTermPrecessionOfTheEquator(julianEpoch);

        Assert.Multiple(() =>
        {
            double delta = 1e-14;
            Assert.That(result[0], Is.EqualTo(-0.3586652560237326659).Within(delta));
            Assert.That(result[1], Is.EqualTo(-0.1996978910771128475).Within(delta));
            Assert.That(result[2], Is.EqualTo(0.9118552442250819624).Within(delta));
        });
    }

    [Test]
    public static void LongTermPrecessionOfTheEcliptic_Test()
    {
        var julianEpoch = -1500.0;

        var result = PrecNutPolarModule
            .LongTermPrecessionOfTheEcliptic(julianEpoch);

        Assert.Multiple(() =>
        {
            double delta = 1e-14;
            Assert.That(result[0], Is.EqualTo(0.4768625676477096525e-3).Within(delta));
            Assert.That(result[1], Is.EqualTo(-0.4052259533091875112).Within(delta));
            Assert.That(result[2], Is.EqualTo(0.9142164401096448012).Within(delta));
        });
    }

    [Test]
    public static void NutationIAU80_Test()
    {
        var julianDate = new JulianDate(2453736.5);

        var result = PrecNutPolarModule.NutationIAU80(julianDate);

        Assert.Multiple(() =>
        {
            double delta = 1e-13;
            Assert.That(result.Longitude, Is.EqualTo(-0.9643658353226563966e-5).Within(delta));
            Assert.That(result.Obliquity, Is.EqualTo(0.4060051006879713322e-4).Within(delta));
        });
    }

    [Test]
    public static void PrecessionRateIAU00_Test()
    {
        var julianDate = new JulianDate(2400000.5 + 53736);

        var result = PrecNutPolarModule.PrecessionRateIAU00(julianDate);

        Assert.Multiple(() =>
        {
            double delta = 1e-22;
            Assert.That(result.Precession, Is.EqualTo(-0.8716465172668347629e-7).Within(delta));
            Assert.That(result.Obliquity, Is.EqualTo(-0.7342018386722813087e-8).Within(delta));
        });
    }

    [Test]
    public static void NutationIAU00a_Test()
    {
        var julianDate = new JulianDate(2400000.5 + 53736.0);

        var result = PrecNutPolarModule.NutationIAU00a(julianDate);

        Assert.Multiple(() =>
        {
            double delta = 1e-13;
            Assert.That(result.Longitude, Is.EqualTo(-0.9630909107115518431e-5).Within(delta));
            Assert.That(result.Obliquity, Is.EqualTo(0.4063239174001678710e-4).Within(delta));
        });
    }

}
