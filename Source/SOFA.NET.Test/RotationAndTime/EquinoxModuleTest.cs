namespace SOFA.NET.Test;

[TestFixture]
internal class EquinoxModuleTest
{

    [Test]
    public void EquationOfEquinoxesIAU94_Test()
    {
        var julianDate = new JulianDate(2400000.5 + 41234.0);

        var result = EquinoxModule.EquationOfEquinoxesIAU94(julianDate);

        Assert.That(result, Is.EqualTo(0.5357758254609256894e-4).Within(1e-17));
    }

    [Test]
    public void EquinoxesComplementaryTermsIAU00_Test()
    {
        var julianDate = new JulianDate(2400000.5 + 53736.0);

        var result = EquinoxModule.EquinoxesComplementaryTermsIAU00(julianDate);

        Assert.That(result, Is.EqualTo(0.2046085004885125264e-8).Within(1e-20));
    }

}
