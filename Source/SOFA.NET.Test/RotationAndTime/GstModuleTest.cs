namespace SOFA.NET;

[TestFixture]
internal class GstModuleTest
{

    [Test]
    public void GreenwichMeanSiderealTimeIAU82_Test()
    {
        var julianDate = new JulianDate(2400000.5 + 53736.0);

        var result = GstModule.GreenwichMeanSiderealTimeIAU82(julianDate);

        Assert.That(result, Is.EqualTo(1.754174981860675096).Within(1e-12));
    }

    [Test]
    public void GreenwichMeanSiderealTimeIAU00_Test()
    {
        var julianDate1 = new JulianDate(2400000.5 + 53736.0);
        var julianDate2 = new JulianDate(2400000.5 + 53736.0);

        var result = GstModule.GreenwichMeanSiderealTimeIAU00(julianDate1, julianDate2);

        Assert.That(result, Is.EqualTo(1.754174972210740592).Within(1e-12));
    }

    [Test]
    public void GreenwichMeanSiderealTimeIAU06_Test()
    {
        var julianDate1 = new JulianDate(2400000.5 + 53736.0);
        var julianDate2 = new JulianDate(2400000.5 + 53736.0);

        var result = GstModule.GreenwichMeanSiderealTimeIAU06(julianDate1, julianDate2);

        Assert.That(result, Is.EqualTo(1.754174971870091203).Within(1e-12));
    }

    [Test]
    public void GreenwichSiderealTimeIAU94_Test()
    {
        var julianDate = new JulianDate(2400000.5 + 53736.0);

        var result = GstModule.GreenwichSiderealTimeIAU94(julianDate);

        Assert.That(result, Is.EqualTo(1.754166136020645203).Within(1e-12));
    }

    [Test]
    public void GreenwichSiderealTimeIAU00a_Test()
    {
        var julianDate1 = new JulianDate(2400000.5 + 53736.0);
        var julianDate2 = new JulianDate(2400000.5 + 53736.0);

        var result = GstModule.GreenwichSiderealTimeIAU00a(julianDate1, julianDate2);

        Assert.That(result, Is.EqualTo(1.754166138018281369).Within(1e-12));
    }

}
