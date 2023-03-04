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

    [Test]
    public void EarthRotationAngleIAU00_Test()
    {
        var julianDate = new JulianDate(2400000.5 + 54388.0);

        var result = EquinoxModule.EarthRotationAngleIAU00(julianDate);

        Assert.That(result, Is.EqualTo(0.4022837240028158102).Within(1e-12));
    }

    [Test]
    public void EquationOfEquinoxesIAU00_Test()
    {
        var nutation = new Nutation(-0.9630909107115582393e-5, 0.4090789763356509900);
        var julianDate = new JulianDate(2400000.5 + 53736.0);

        var result = EquinoxModule.EquationOfEquinoxesIAU00(julianDate, nutation);

        Assert.That(result, Is.EqualTo(-0.8834193235367965479e-5).Within(1e-18));
    }

    [Test]
    public void EquationOfEquinoxesIAU00a_Test()
    {
        var julianDate = new JulianDate(2400000.5 + 53736.0);

        var result = EquinoxModule.EquationOfEquinoxesIAU00a(julianDate);

        Assert.That(result, Is.EqualTo(-0.8834192459222588227e-5).Within(1e-18));
    }

    [Test]
    public void EquationOfEquinoxesIAU00b_Test()
    {
        var julianDate = new JulianDate(2400000.5 + 53736.0);

        var result = EquinoxModule.EquationOfEquinoxesIAU00b(julianDate);

        Assert.That(result, Is.EqualTo(-0.8835700060003032831e-5).Within(1e-18));
    }

}
