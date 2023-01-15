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

}
