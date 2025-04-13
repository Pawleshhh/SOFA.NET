namespace SOFA.NET.Tests;

[TestFixture]
internal class CalendarsTest
{

    [Test]
    public void GregorianToJulian_Test()
    {
        var dt = new DateOnly(2003, 6, 1);
        var result = Calendars.GregorianDateToJulianDate(dt);
        Assert.That(result.Date, Is.EqualTo(2400000.5 + 52791.0));
    }

    [Test]
    public void JulianDateToBesselianEpoch_Test()
    {
        var jd = new JulianDate(2415019.8135 + 30103.18648);
        var result = Calendars.JulianDateToBesselianEpoch(jd);
        Assert.That(result, Is.EqualTo(1982.418424159278580).Within(1e-12));
    }

    [Test]
    public void BesselianEpochToJulianDate_Test()
    {
        var be = 1957.3;
        var result = Calendars.BesselianEpochToJulianDate(be);
        Assert.That(result.Date, Is.EqualTo(2400000.5 + 35948.1915101513).Within(1e-9));
    }

    [Test]
    public void JulianDateToJulianEpoch_Test()
    {
        var jd = new JulianDate(2451545 - 7392.5);
        var result = Calendars.JulianDateToJulianEpoch(jd);
        Assert.That(result, Is.EqualTo(1979.760438056125941).Within(1e-12));
    }

    [Test]
    public void JulianEpochToJulianDate_Test()
    {
        var epj = 1996.8;
        var result = Calendars.JulianEpochToJulianDate(epj);
        Assert.That(result.Date, Is.EqualTo(2400000.5 + 50375.7).Within(1e-9));
    }

    [Test]
    public void JulianDateToGregorianDateTime_Test()
    {
        var jd = new JulianDate(2400000.5 + 50123.9999);
        var result = Calendars.JulianDateToGregorianDateTime(jd);
        Assert.Multiple(() =>
        {
            Assert.That(result.Year, Is.EqualTo(1996));
            Assert.That(result.Month, Is.EqualTo(2));
            Assert.That(result.Day, Is.EqualTo(10));
            Assert.That(result.TimeOfDay.TotalDays, Is.EqualTo(0.9999).Within(1e-7));
        });
    }

}
