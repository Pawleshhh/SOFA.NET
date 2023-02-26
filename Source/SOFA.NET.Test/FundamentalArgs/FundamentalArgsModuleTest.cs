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

    [TestCase(SolarSystemObject.Sun, 6.226797973505507345)]
    [TestCase(SolarSystemObject.Earth, 1.744713738913081846)]
    [TestCase(SolarSystemObject.Moon, 5.132369751108684150)]
    [TestCase(SolarSystemObject.Mars, 3.275506840277781492)]
    [TestCase(SolarSystemObject.Jupiter, 5.275711665202481138)]
    public void MeanLongitudeIERS03Of_Test(SolarSystemObject solarSystemObject, double expected)
    {
        double t = 0.8;

        var result = FundamentalArgsModule.MeanLongitudeIERS03Of(solarSystemObject, t);

        Assert.That(result, Is.EqualTo(expected).Within(1e-12));
    }

}
