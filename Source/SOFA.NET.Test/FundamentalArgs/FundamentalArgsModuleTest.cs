namespace SOFA.NET.Test;

[TestFixture]
internal class FundamentalArgsModuleTest
{

    [Test]
    public void MeanElongationOfMoonFromSunIERS03_Test()
    {
        double t = 0.8;

        var result = FundamentalArgsModule.MeanElongationOfMoonFromSunIERS03(t);

        Assert.That(result, Is.EqualTo(1.946709205396925672).Within(1e-12));
    }

    [TestCase(PlanetaryObject.Earth, 1.744713738913081846)]
    public void MeanLongitudeIERS03Of_Test(PlanetaryObject planetaryObject, double expected)
    {
        double t = 0.8;

        var result = FundamentalArgsModule.MeanLongitudeIERS03Of(planetaryObject, t);

        Assert.That(result, Is.EqualTo(expected).Within(1e-12));
    }

}
