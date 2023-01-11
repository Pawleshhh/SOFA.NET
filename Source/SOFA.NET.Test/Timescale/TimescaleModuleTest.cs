namespace SOFA.NET.Test;

[TestFixture]
internal class TimescaleModuleTest
{
    #region Fields

    private const double DayNumber = 2453750.5;

    #endregion

    #region Tests

    [TestCase(2003, 6, 1, 0.0, 32.0)]
    [TestCase(2008, 1, 17, 0.0, 33.0)]
    [TestCase(2017, 9, 1, 0.0, 37.0)]
    public void DeltaAT_ProvideGregorianCalendarDate_ReturnsExpectedDeltaAT(int year, int month, int day, double fractionOfDay, double expected)
    {
        // ACT
        double result = TimescaleModule.DeltaAT(year, month, day, fractionOfDay);

        // ASSERT
        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase(2003, 6, 1, 0.0, 32.0)]
    [TestCase(2008, 1, 17, 0.0, 33.0)]
    [TestCase(2017, 9, 1, 0.0, 37.0)]
    public void DeltaAT_ProvideGregorianCalendarDateAsDateTime_ReturnsExpectedDeltaAT(int year, int month, int day, double fractionOfDay, double expected)
    {
        // ARRANGE
        DateTime dateTime = new DateTime(year, month, day).AddHours(fractionOfDay * 24.0);

        // ACT
        double result = TimescaleModule.DeltaAT(dateTime);

        // ASSERT
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void BarycentricDynamicalTimeTerrestrialTimeDifference_Test()
    {
        // ARRANGE
        JulianDate julianDate = new JulianDate(2448939.5, 0.123);
        TimeSpan ut = TimeSpan.FromDays(0.76543);
        GeographicCoordinates geoCoords = new GeographicCoordinates(0.0, 5.0123);
        double earthSpinAxisDistance = 5525.242;
        double northEquatorialPlaneDistance = 3190.0;

        // ACT
        var result = TimescaleModule.BarycentricDynamicalTimeTerrestrialTimeDifference(
            julianDate,
            ut,
            geoCoords,
            earthSpinAxisDistance,
            northEquatorialPlaneDistance);

        // ASSERT
        Assert.That(result, Is.EqualTo(-0.1280368005936998991e-2).Within(1e-15));
    }

    [Test]
    public void InternationalAtomicTimeToTerrestrialTime_Test()
    {
        // ARRANGE
        JulianDate julianDate = new JulianDate(DayNumber, 0.892482639);

        TestTimeScaleMethod(TimescaleModule.InternationalAtomicTimeToTerrestrialTime, julianDate, 0.892855139, JulianDateKind.Tt);
    }

    [Test]
    public void InternationalAtomicTimeToTerrestrialTime_WrongKind_Test()
    {
        TestTimeScaleMethodWrongKind(TimescaleModule.InternationalAtomicTimeToTerrestrialTime, JulianDateKind.Tai);
    }

    [Test]
    public void InternationalAtomicTimeToUniversalTime_Test()
    {
        // ARRANGE
        JulianDate julianDate = new JulianDate(DayNumber, 0.892482639);
        double delta = -32.6659;

        TestTimeScaleMethod(jd => TimescaleModule.InternationalAtomicTimeToUniversalTime(jd, delta), julianDate, 0.8921045614537037037, JulianDateKind.Ut1);
    }

    [Test]
    public void InternationalAtomicTimeToUniversalTime_WrongKind_Test()
    {
        TestTimeScaleMethodWrongKind(jd => TimescaleModule.InternationalAtomicTimeToUniversalTime(jd, 0.0), JulianDateKind.Tai);
    }

    [Test]
    public void InternationalAtomicTimeToCoordinatedUniversalTime_Test()
    {
        // ARRANGE
        JulianDate julianDate = new JulianDate(DayNumber, 0.892482639);

        TestTimeScaleMethod(TimescaleModule.InternationalAtomicTimeToCoordinatedUniversalTime, julianDate, 0.8921006945555555556, JulianDateKind.Utc);
    }

    [Test]
    public void InternationalAtomicTimeToCoordinatedUniversalTime_WrongKind_Test()
    {
        TestTimeScaleMethodWrongKind(TimescaleModule.InternationalAtomicTimeToCoordinatedUniversalTime, JulianDateKind.Tai);
    }

    [Test]
    public void CoordinatedUniversalTimeToInternationalAtomicTime_Test()
    {
        // ARRANGE
        JulianDate julianDate = new JulianDate(DayNumber, 0.892100694);

        TestTimeScaleMethod(TimescaleModule.CoordinatedUniversalTimeToInternationalAtomicTime, julianDate, 0.8924826384444444444, JulianDateKind.Tai);
    }

    [Test]
    public void CoordinatedUniversalTimeToInternationalAtomicTime_WrongKind_Test()
    {
        TestTimeScaleMethodWrongKind(TimescaleModule.CoordinatedUniversalTimeToInternationalAtomicTime, JulianDateKind.Utc);
    }

    [Test]
    public void BarycentricCoordinateTimeToBarycentricDynamicalTime_Test()
    {
        // ARRANGE
        JulianDate julianDate = new JulianDate(DayNumber, 0.893019599);

        TestTimeScaleMethod(TimescaleModule.BarycentricCoordinateTimeToBarycentricDynamicalTime, julianDate, 0.8928551362746343397, JulianDateKind.Tdb);
    }

    [Test]
    public void BarycentricCoordinateTimeToBarycentricDynamicalTime_WrongKind_Test()
    {
        TestTimeScaleMethodWrongKind(TimescaleModule.BarycentricCoordinateTimeToBarycentricDynamicalTime, JulianDateKind.Tcb);
    }

    [Test]
    public void GeocentricCoordinateTimeToTerrestrialTime_Test()
    {
        // ARRANGE
        JulianDate julianDate = new JulianDate(DayNumber, 0.892862531);

        TestTimeScaleMethod(TimescaleModule.GeocentricCoordinateTimeToTerrestrialTime, julianDate, 0.8928551387488816828, JulianDateKind.Tt);
    }

    [Test]
    public void GeocentricCoordinateTimeToTerrestrialTime_WrongKind_Test()
    {
        TestTimeScaleMethodWrongKind(TimescaleModule.GeocentricCoordinateTimeToTerrestrialTime, JulianDateKind.Tcg);
    }

    [Test]
    public void TerrestrialTimeToInternationalAtomicTime_Test()
    {
        // ARRANGE
        JulianDate julianDate = new JulianDate(DayNumber, 0.892482639);

        TestTimeScaleMethod(TimescaleModule.TerrestrialTimeToInternationalAtomicTime, julianDate, 0.892110139, JulianDateKind.Tai);
    }

    [Test]
    public void TerrestrialTimeToInternationalAtomicTime_WrongKind_Test()
    {
        TestTimeScaleMethodWrongKind(TimescaleModule.TerrestrialTimeToInternationalAtomicTime, JulianDateKind.Tt);
    }

    [Test]
    public void BarycentricDynamicalTimeToBarycentricCoordinateTime_Test()
    {
        // ARRANGE
        JulianDate julianDate = new JulianDate(DayNumber, 0.892855137);

        TestTimeScaleMethod(TimescaleModule.BarycentricDynamicalTimeToBarycentricCoordinateTime, julianDate, 0.8930195997253656716, JulianDateKind.Tcb);
    }

    [Test]
    public void BarycentricDynamicalTimeToBarycentricCoordinateTime_WrongKind_Test()
    {
        TestTimeScaleMethodWrongKind(TimescaleModule.BarycentricDynamicalTimeToBarycentricCoordinateTime, JulianDateKind.Tdb);
    }

    [Test]
    public void BarycentricDynamicalTimeToTerrestrialTime_Test()
    {
        // ARRANGE
        JulianDate julianDate = new JulianDate(DayNumber, 0.892855137);
        double tdbMinusTt = -0.000201;

        TestTimeScaleMethod(
            jd => TimescaleModule.BarycentricDynamicalTimeToTerrestrialTime(jd, tdbMinusTt),
            julianDate,
            0.8928551393263888889,
            JulianDateKind.Tt);
    }

    [Test]
    public void BarycentricDynamicalTimeToTerrestrialTime_WrongKind_Test()
    {
        TestTimeScaleMethodWrongKind(
            jd => TimescaleModule.BarycentricDynamicalTimeToTerrestrialTime(jd, 0.0),
            JulianDateKind.Tdb);
    }

    [Test]
    public void TerrestrialTimeToGeocentricCoordinateTime_Test()
    {
        // ARRANGE
        JulianDate julianDate = new JulianDate(DayNumber, 0.892482639);

        TestTimeScaleMethod(
            TimescaleModule.TerrestrialTimeToGeocentricCoordinateTime,
            julianDate,
            0.8924900312508587113,
            JulianDateKind.Tcg);
    }

    [Test]
    public void TerrestrialTimeToGeocentricCoordinateTime_WrongKind_Test()
    {
        TestTimeScaleMethodWrongKind(
            TimescaleModule.TerrestrialTimeToGeocentricCoordinateTime,
            JulianDateKind.Tt);
    }

    [Test]
    public void TerrestrialTimeToBarycentricDynamicalTime_Test()
    {
        // ARRANGE
        JulianDate julianDate = new JulianDate(DayNumber, 0.892855139);
        double tdbMinusTt = -0.000201;

        TestTimeScaleMethod(
            jd => TimescaleModule.TerrestrialTimeToBarycentricDynamicalTime(jd, tdbMinusTt),
            julianDate,
            0.8928551366736111111,
            JulianDateKind.Tdb);
    }

    [Test]
    public void TerrestrialTimeToBarycentricDynamicalTime_WrongKind_Test()
    {
        TestTimeScaleMethodWrongKind(
            jd => TimescaleModule.TerrestrialTimeToBarycentricDynamicalTime(jd, 0.0),
            JulianDateKind.Tt);
    }

    [Test]
    public void TerrestrialTimeToUniversalTime_Test()
    {
        // ARRANGE
        JulianDate julianDate = new JulianDate(DayNumber, 0.892855139);
        double ttMinusUt1 = 64.8499;

        TestTimeScaleMethod(
            jd => TimescaleModule.TerrestrialTimeToUniversalTime(jd, ttMinusUt1),
            julianDate,
            0.8921045614537037037,
            JulianDateKind.Ut1);
    }

    [Test]
    public void TerrestrialTimeToUniversalTime_WrongKind_Test()
    {
        TestTimeScaleMethodWrongKind(
            jd => TimescaleModule.TerrestrialTimeToUniversalTime(jd, 0.0),
            JulianDateKind.Tt);
    }

    [Test]
    public void UniversalTimeToInternationalAtomicTime_Test()
    {
        // ARRANGE
        JulianDate julianDate = new JulianDate(DayNumber, 0.892104561);
        double ut1MinusTai = -32.6659;

        TestTimeScaleMethod(
            jd => TimescaleModule.UniversalTimeToInternationalAtomicTime(jd, ut1MinusTai),
            julianDate,
            0.8924826385462962963,
            JulianDateKind.Tai);
    }

    [Test]
    public void UniversalTimeToInternationalAtomicTime_WrongKind_Test()
    {
        TestTimeScaleMethodWrongKind(
            jd => TimescaleModule.UniversalTimeToInternationalAtomicTime(jd, 0.0),
            JulianDateKind.Ut1);
    }

    [Test]
    public void UniversalTimeToTerrestrialTime_Test()
    {
        // ARRANGE
        JulianDate julianDate = new JulianDate(DayNumber, 0.892104561);
        double ttMinusUt1Delta = 64.8499;

        TestTimeScaleMethod(
            jd => TimescaleModule.UniversalTimeToTerrestrialTime(jd, ttMinusUt1Delta),
            julianDate,
            0.8928551385462962963,
            JulianDateKind.Tt);
    }

    [Test]
    public void UniversalTimeToTerrestrialTime_WrongKind_Test()
    {
        TestTimeScaleMethodWrongKind(
            jd => TimescaleModule.UniversalTimeToTerrestrialTime(jd, 0.0),
            JulianDateKind.Ut1);
    }

    [Test]
    public void UniversalTimeToCoordinatedUniversalTime_Test()
    {
        // ARRANGE
        JulianDate julianDate = new JulianDate(DayNumber, 0.892104561);
        double ut1MinusUtcDelta = 0.3341;

        TestTimeScaleMethod(
            jd => TimescaleModule.UniversalTimeToCoordinatedUniversalTime(jd, ut1MinusUtcDelta),
            julianDate,
            0.8921006941018518519,
            JulianDateKind.Utc);
    }

    [Test]
    public void UniversalTimeToCoordinatedUniversalTime_WrongKind_Test()
    {
        TestTimeScaleMethodWrongKind(
            jd => TimescaleModule.UniversalTimeToCoordinatedUniversalTime(jd, 0.0),
            JulianDateKind.Ut1);
    }

    [Test]
    public void CoordinatedUniversalTimeToUniversalTime_Test()
    {
        // ARRANGE
        JulianDate julianDate = new JulianDate(DayNumber, 0.892100694);
        double ut1MinusUtcDelta = 0.3341;

        TestTimeScaleMethod(
            jd => TimescaleModule.CoordinatedUniversalTimeToUniversalTime(jd, ut1MinusUtcDelta),
            julianDate,
            0.8921045608981481481,
            JulianDateKind.Ut1);
    }

    [Test]
    public void CoordinatedUniversalTimeToUniversalTime_WrongKind_Test()
    {
        TestTimeScaleMethodWrongKind(
            jd => TimescaleModule.CoordinatedUniversalTimeToUniversalTime(jd, 0.0),
            JulianDateKind.Utc);
    }

    #endregion

    #region Helpers

    private void TestTimeScaleMethod(Func<JulianDate, JulianDate> methodUnderTest, JulianDate input, double expectedFractionOfDay, JulianDateKind expectedKind, double expectedDayNumber = DayNumber)
    {
        var result = methodUnderTest(input);
        Assert.Multiple(() =>
        {
            Assert.That(result.DayNumber, Is.EqualTo(expectedDayNumber).Within(1e-6));
            Assert.That(result.FractionOfDay, Is.EqualTo(expectedFractionOfDay).Within(1e-12));
            Assert.That(result.Kind, Is.EqualTo(expectedKind));
        });
    }

    private void TestTimeScaleMethodWrongKind(Func<JulianDate, JulianDate> methodUnderTest, JulianDateKind validKind)
    {
        Assert.Throws<JulianDateKindException>(() => methodUnderTest(new JulianDate(10.5, 0.0, validKind + 1)));
        Assert.Throws<JulianDateKindException>(() => methodUnderTest(new JulianDate(10.5, 0.0, validKind - 1)));
    }

    #endregion

}
