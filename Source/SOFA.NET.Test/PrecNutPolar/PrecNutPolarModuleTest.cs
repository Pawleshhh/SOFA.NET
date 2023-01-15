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

}
