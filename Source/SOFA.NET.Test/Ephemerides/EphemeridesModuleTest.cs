namespace SOFA.NET.Test;

[TestFixture]
internal class EphemeridesModuleTest
{

    [Test]
    public void EarthPositionVelocity_Test()
    {
        var julianDate = new JulianDate(2400000.5 + 53411.52501161); // 2005-02-10 12:36:01

        var result = EphemeridesModule.EarthPositionVelocity(julianDate);

        Assert.Multiple(() =>
        {
            Assert.That(result.HeliocentricPosition[0], Is.EqualTo(-0.7757238809297706813).Within(1e-11));
            Assert.That(result.HeliocentricPosition[1], Is.EqualTo(0.5598052241363340596).Within(1e-11));
            Assert.That(result.HeliocentricPosition[2], Is.EqualTo(0.2426998466481686993).Within(1e-11));

            Assert.That(result.HeliocentricVelocity[0], Is.EqualTo(-0.1091891824147313846e-1).Within(1e-12));
            Assert.That(result.HeliocentricVelocity[1], Is.EqualTo(-0.1247187268440845008e-1).Within(1e-12));
            Assert.That(result.HeliocentricVelocity[2], Is.EqualTo(-0.5407569418065039061e-2).Within(1e-12));

            Assert.That(result.BarycentricPosition[0], Is.EqualTo(-0.7714104440491111971).Within(1e-11));
            Assert.That(result.BarycentricPosition[1], Is.EqualTo(0.5598412061824171323).Within(1e-11));
            Assert.That(result.BarycentricPosition[2], Is.EqualTo(0.2425996277722452400).Within(1e-11));

            Assert.That(result.BarycentricVelocity[0], Is.EqualTo(-0.1091874268116823295e-1).Within(1e-12));
            Assert.That(result.BarycentricVelocity[1], Is.EqualTo(-0.1246525461732861538e-1).Within(1e-12));
            Assert.That(result.BarycentricVelocity[2], Is.EqualTo(-0.5404773180966231279e-2).Within(1e-12));

            Assert.That(result.DateOutsideRange, Is.False);
        });
    }

    [TestCase(2413905d)] //1896-12-11 12:00:00
    [TestCase(2513905d)] //2170-09-26 12:00:00
    public void EarthPositionVelocity_DateOutsideRange_Test(double jd)
    {
        var julianDate = new JulianDate(jd);

        var result = EphemeridesModule.EarthPositionVelocity(julianDate);

        Assert.That(result.DateOutsideRange, Is.True);
    }

    [Test]
    public void ApproximateHeliocentricPositionAndVelocity_Test()
    {
        var julianDate = new JulianDate(2400000.5 + 43999.9);
        var planet = Planet.Mercury;

        var result = EphemeridesModule.ApproximateHeliocentricPositionAndVelocity(julianDate, planet);

        Assert.Multiple(() =>
        {
            double delta = 1e-11;
            Assert.That(result[0, 0], Is.EqualTo(0.2945293959257430832).Within(delta));
            Assert.That(result[0, 1], Is.EqualTo(-0.2452204176601049596).Within(delta));
            Assert.That(result[0, 2], Is.EqualTo(-0.1615427700571978153).Within(delta));

            Assert.That(result[1, 0], Is.EqualTo(0.1413867871404614441e-1).Within(delta));
            Assert.That(result[1, 1], Is.EqualTo(0.1946548301104706582e-1).Within(delta));
            Assert.That(result[1, 2], Is.EqualTo(0.8929809783898904786e-2).Within(delta));
        });
    }

    [Test]
    public void ApproximateGeocentricPositionAndVelocityOfTheMoon_Test()
    {
        var julianDate = new JulianDate(2400000.5 + 43999.9);

        var result = EphemeridesModule.ApproximateGeocentricPositionAndVelocityOfTheMoon(julianDate);

        Assert.Multiple(() =>
        {
            double delta = 1e-11;
            Assert.That(result[0, 0], Is.EqualTo(-0.2601295959971044180e-2).Within(delta));
            Assert.That(result[0, 1], Is.EqualTo(0.6139750944302742189e-3).Within(delta));
            Assert.That(result[0, 2], Is.EqualTo(0.2640794528229828909e-3).Within(delta));

            Assert.That(result[1, 0], Is.EqualTo(-0.1244321506649895021e-3).Within(delta));
            Assert.That(result[1, 1], Is.EqualTo(-0.5219076942678119398e-3).Within(delta));
            Assert.That(result[1, 2], Is.EqualTo(-0.1716132214378462047e-3).Within(delta));
        });
    }

}
