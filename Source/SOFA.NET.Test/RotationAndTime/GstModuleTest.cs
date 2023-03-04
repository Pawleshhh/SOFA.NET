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

    [Test]
    public void GreenwichSiderealTimeIAU00b_Test()
    {
        var julianDate1 = new JulianDate(2400000.5 + 53736.0);

        var result = GstModule.GreenwichSiderealTimeIAU00b(julianDate1);

        Assert.That(result, Is.EqualTo(1.754166136510680589).Within(1e-12));
    }

    [Test]
    public void GreenwichSiderealTimeIAU06_Test()
    {
        double[,] rnpb = new double[3, 3];
        rnpb[0, 0] = 0.9999989440476103608;
        rnpb[0, 1] = -0.1332881761240011518e-2;
        rnpb[0, 2] = -0.5790767434730085097e-3;
        rnpb[1, 0] = 0.1332858254308954453e-2;
        rnpb[1, 1] = 0.9999991109044505944;
        rnpb[1, 2] = -0.4097782710401555759e-4;
        rnpb[2, 0] = 0.5791308472168153320e-3;
        rnpb[2, 1] = 0.4020595661593994396e-4;
        rnpb[2, 2] = 0.9999998314954572365;
        var julianDate1 = new JulianDate(2400000.5 + 53736.0);
        var julianDate2 = new JulianDate(2400000.5 + 53736.0);

        var result = GstModule.GreenwichSiderealTimeIAU06(julianDate1, julianDate2, rnpb);

        Assert.That(result, Is.EqualTo(1.754166138018167568).Within(1e-12));
    }

    [Test]
    public void GreenwichSiderealTimeIAU06a_Test()
    {
        var julianDate1 = new JulianDate(2400000.5 + 53736.0);
        var julianDate2 = new JulianDate(2400000.5 + 53736.0);

        var result = GstModule.GreenwichSiderealTimeIAU06a(julianDate1, julianDate2);

        Assert.That(result, Is.EqualTo(1.754166137675019159).Within(1e-12));
    }

}
