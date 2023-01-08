namespace SOFA.NET.Test;

[TestFixture]
internal class CalendarsModuleTest
{

    #region Tests

    [Test]
    public void GregorianCalendarToJulianDate_Test()
    {
        DateTime dateTime = new(2003, 6, 1);

        JulianDate result = CalendarsModule.GregorianCalendarToJulianDate(dateTime);

        Assert.That(result.Date, Is.EqualTo(2452791.5));
    }

    [Test]
    public void JulianDateToBesselianEpoch_Test()
    {
        JulianDate julianDate = new(2415019.8135 + 30103.18648);

        double besselianEpoch = CalendarsModule.JulianDateToBesselianEpoch(julianDate);

        Assert.That(besselianEpoch, Is.EqualTo(1982.418424159278580).Within(1e-12));
    }

    [Test]
    public void BesselianEpochToJulianDate_Test()
    {
        double besselianEpoch = 1957.3;

        JulianDate julianDate = CalendarsModule.BesselianEpochToJulianDate(besselianEpoch);

        Assert.That(julianDate.Date, Is.EqualTo(2400000.5 + 35948.1915101513).Within(1e-9));
    }

    #endregion

}
