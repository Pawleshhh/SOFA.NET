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

    #endregion

}
