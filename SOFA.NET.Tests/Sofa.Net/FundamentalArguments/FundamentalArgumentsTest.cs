namespace SOFA.NET.Tests;

using static FundamentalArguments;

[TestFixture]
internal class FundamentalArgumentsTest
{

    private const double t = 0.8;

    [Test]
    public void MeanElongationOfMoonFromSun_Test()
    {
        var result = MeanElongationOfMoonFromSun(t);
        Assert.That(result, Is.EqualTo(1.946709205396925672).Within(1e-12));
    }

    [Test]
    public void MeanLongitudeOfEarth_Test()
    {
        var result = MeanLongitudeOfEarth(t);
        Assert.That(result, Is.EqualTo(1.744713738913081846).Within(1e-12));
    }


    [Test]
    public void MoonLongitudeMinusAscendingNode_Test()
    {
        var result = MoonLongitudeMinusAscendingNode(t);
        Assert.That(result, Is.EqualTo(0.2597711366745499518).Within(1e-12));
    }

    [Test]
    public void MeanLongitudeOfJupiter_Test()
    {
        var result = MeanLongitudeOfJupiter(t);
        Assert.That(result, Is.EqualTo(5.275711665202481138).Within(1e-12));
    }

    [Test]
    public void MeanAnomalyOfMoon_Test()
    {
        var result = MeanAnomalyOfMoon(t);
        Assert.That(result, Is.EqualTo(5.132369751108684150).Within(1e-12));
    }

    [Test]
    public void MeanAnomalyOfSun_Test()
    {
        var result = MeanAnomalyOfSun(t);
        Assert.That(result, Is.EqualTo(6.226797973505507345).Within(1e-12));
    }

    [Test]
    public void MeanLongitudeOfMars_Test()
    {
        var result = MeanLongitudeOfMars(t);
        Assert.That(result, Is.EqualTo(3.275506840277781492).Within(1e-12));
    }

    [Test]
    public void MeanLongitudeOfMercury_Test()
    {
        var result = MeanLongitudeOfMercury(t);
        Assert.That(result, Is.EqualTo(5.417338184297289661).Within(1e-12));
    }

    [Test]
    public void MeanLongitudeOfNeptune_Test()
    {
        var result = MeanLongitudeOfNeptune(t);
        Assert.That(result, Is.EqualTo(2.079343830860413523).Within(1e-12));
    }

    [Test]
    public void MeanLongitudeOfMoonAscendingNode_Test()
    {
        var result = MeanLongitudeOfMoonAscendingNode(t);
        Assert.That(result, Is.EqualTo(-5.973618440951302183).Within(1e-12));
    }

    [Test]
    public void GeneralAccumulatedPrecessionInLongitude_Test()
    {
        var result = GeneralAccumulatedPrecessionInLongitude(t);
        Assert.That(result, Is.EqualTo(0.1950884762240000000e-1).Within(1e-12));
    }

    [Test]
    public void MeanLongitudeOfSaturn_Test()
    {
        var result = MeanLongitudeOfSaturn(t);
        Assert.That(result, Is.EqualTo(5.371574539440827046).Within(1e-12));
    }

    [Test]
    public void MeanLongitudeOfUranus_Test()
    {
        var result = MeanLongitudeOfUranus(t);
        Assert.That(result, Is.EqualTo(5.180636450180413523).Within(1e-12));
    }

    [Test]
    public void MeanLongitudeOfVenus_Test()
    {
        var result = MeanLongitudeOfVenus(t);
        Assert.That(result, Is.EqualTo(3.424900460533758000).Within(1e-12));
    }
}
