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

        TestTimeScaleMethod(TimescaleModule.TaiToTt, julianDate, 0.892855139, JulianDateKind.Tt);
    }

    [Test]
    public void InternationalAtomicTimeToTerrestrialTime_WrongKind_Test()
    {
        TestTimeScaleMethodWrongKind(TimescaleModule.TaiToTt, JulianDateKind.Tai);
    }

    [Test]
    public void InternationalAtomicTimeToUniversalTime_Test()
    {
        // ARRANGE
        JulianDate julianDate = new JulianDate(DayNumber, 0.892482639);
        double delta = -32.6659;

        TestTimeScaleMethod(jd => TimescaleModule.TaiToUt1(jd, delta), julianDate, 0.8921045614537037037, JulianDateKind.Ut1);
    }

    [Test]
    public void InternationalAtomicTimeToUniversalTime_WrongKind_Test()
    {
        TestTimeScaleMethodWrongKind(jd => TimescaleModule.TaiToUt1(jd, 0.0), JulianDateKind.Tai);
    }

    [Test]
    public void InternationalAtomicTimeToCoordinatedUniversalTime_Test()
    {
        // ARRANGE
        JulianDate julianDate = new JulianDate(DayNumber, 0.892482639);

        TestTimeScaleMethod(TimescaleModule.TaiToUtc, julianDate, 0.8921006945555555556, JulianDateKind.Utc);
    }

    [Test]
    public void InternationalAtomicTimeToCoordinatedUniversalTime_WrongKind_Test()
    {
        TestTimeScaleMethodWrongKind(TimescaleModule.TaiToUtc, JulianDateKind.Tai);
    }

    [Test]
    public void CoordinatedUniversalTimeToInternationalAtomicTime_Test()
    {
        // ARRANGE
        JulianDate julianDate = new JulianDate(DayNumber, 0.892100694);

        TestTimeScaleMethod(TimescaleModule.UtcToTai, julianDate, 0.8924826384444444444, JulianDateKind.Tai);
    }

    [Test]
    public void CoordinatedUniversalTimeToInternationalAtomicTime_WrongKind_Test()
    {
        TestTimeScaleMethodWrongKind(TimescaleModule.UtcToTai, JulianDateKind.Utc);
    }

    [Test]
    public void BarycentricCoordinateTimeToBarycentricDynamicalTime_Test()
    {
        // ARRANGE
        JulianDate julianDate = new JulianDate(DayNumber, 0.893019599);

        TestTimeScaleMethod(TimescaleModule.TcbToTdb, julianDate, 0.8928551362746343397, JulianDateKind.Tdb);
    }

    [Test]
    public void BarycentricCoordinateTimeToBarycentricDynamicalTime_WrongKind_Test()
    {
        TestTimeScaleMethodWrongKind(TimescaleModule.TcbToTdb, JulianDateKind.Tcb);
    }

    [Test]
    public void GeocentricCoordinateTimeToTerrestrialTime_Test()
    {
        // ARRANGE
        JulianDate julianDate = new JulianDate(DayNumber, 0.892862531);

        TestTimeScaleMethod(TimescaleModule.TcgToTt, julianDate, 0.8928551387488816828, JulianDateKind.Tt);
    }

    [Test]
    public void GeocentricCoordinateTimeToTerrestrialTime_WrongKind_Test()
    {
        TestTimeScaleMethodWrongKind(TimescaleModule.TcgToTt, JulianDateKind.Tcg);
    }

    [Test]
    public void TerrestrialTimeToInternationalAtomicTime_Test()
    {
        // ARRANGE
        JulianDate julianDate = new JulianDate(DayNumber, 0.892482639);

        TestTimeScaleMethod(TimescaleModule.TtToTai, julianDate, 0.892110139, JulianDateKind.Tai);
    }

    [Test]
    public void TerrestrialTimeToInternationalAtomicTime_WrongKind_Test()
    {
        TestTimeScaleMethodWrongKind(TimescaleModule.TtToTai, JulianDateKind.Tt);
    }

    [Test]
    public void BarycentricDynamicalTimeToBarycentricCoordinateTime_Test()
    {
        // ARRANGE
        JulianDate julianDate = new JulianDate(DayNumber, 0.892855137);

        TestTimeScaleMethod(TimescaleModule.TdbToTcb, julianDate, 0.8930195997253656716, JulianDateKind.Tcb);
    }

    [Test]
    public void BarycentricDynamicalTimeToBarycentricCoordinateTime_WrongKind_Test()
    {
        TestTimeScaleMethodWrongKind(TimescaleModule.TdbToTcb, JulianDateKind.Tdb);
    }

    [Test]
    public void BarycentricDynamicalTimeToTerrestrialTime_Test()
    {
        // ARRANGE
        JulianDate julianDate = new JulianDate(DayNumber, 0.892855137);
        double tdbMinusTt = -0.000201;

        TestTimeScaleMethod(
            jd => TimescaleModule.TdbToTt(jd, tdbMinusTt),
            julianDate,
            0.8928551393263888889,
            JulianDateKind.Tt);
    }

    [Test]
    public void BarycentricDynamicalTimeToTerrestrialTime_WrongKind_Test()
    {
        TestTimeScaleMethodWrongKind(
            jd => TimescaleModule.TdbToTt(jd, 0.0),
            JulianDateKind.Tdb);
    }

    [Test]
    public void TerrestrialTimeToGeocentricCoordinateTime_Test()
    {
        // ARRANGE
        JulianDate julianDate = new JulianDate(DayNumber, 0.892482639);

        TestTimeScaleMethod(
            TimescaleModule.TtToTcg,
            julianDate,
            0.8924900312508587113,
            JulianDateKind.Tcg);
    }

    [Test]
    public void TerrestrialTimeToGeocentricCoordinateTime_WrongKind_Test()
    {
        TestTimeScaleMethodWrongKind(
            TimescaleModule.TtToTcg,
            JulianDateKind.Tt);
    }

    [Test]
    public void TerrestrialTimeToBarycentricDynamicalTime_Test()
    {
        // ARRANGE
        JulianDate julianDate = new JulianDate(DayNumber, 0.892855139);
        double tdbMinusTt = -0.000201;

        TestTimeScaleMethod(
            jd => TimescaleModule.TtToTdb(jd, tdbMinusTt),
            julianDate,
            0.8928551366736111111,
            JulianDateKind.Tdb);
    }

    [Test]
    public void TerrestrialTimeToBarycentricDynamicalTime_WrongKind_Test()
    {
        TestTimeScaleMethodWrongKind(
            jd => TimescaleModule.TtToTdb(jd, 0.0),
            JulianDateKind.Tt);
    }

    [Test]
    public void TerrestrialTimeToUniversalTime_Test()
    {
        // ARRANGE
        JulianDate julianDate = new JulianDate(DayNumber, 0.892855139);
        double ttMinusUt1 = 64.8499;

        TestTimeScaleMethod(
            jd => TimescaleModule.TtToUt1(jd, ttMinusUt1),
            julianDate,
            0.8921045614537037037,
            JulianDateKind.Ut1);
    }

    [Test]
    public void TerrestrialTimeToUniversalTime_WrongKind_Test()
    {
        TestTimeScaleMethodWrongKind(
            jd => TimescaleModule.TtToUt1(jd, 0.0),
            JulianDateKind.Tt);
    }

    [Test]
    public void UniversalTimeToInternationalAtomicTime_Test()
    {
        // ARRANGE
        JulianDate julianDate = new JulianDate(DayNumber, 0.892104561);
        double ut1MinusTai = -32.6659;

        TestTimeScaleMethod(
            jd => TimescaleModule.Ut1ToTai(jd, ut1MinusTai),
            julianDate,
            0.8924826385462962963,
            JulianDateKind.Tai);
    }

    [Test]
    public void UniversalTimeToInternationalAtomicTime_WrongKind_Test()
    {
        TestTimeScaleMethodWrongKind(
            jd => TimescaleModule.Ut1ToTai(jd, 0.0),
            JulianDateKind.Ut1);
    }

    [Test]
    public void UniversalTimeToTerrestrialTime_Test()
    {
        // ARRANGE
        JulianDate julianDate = new JulianDate(DayNumber, 0.892104561);
        double ttMinusUt1Delta = 64.8499;

        TestTimeScaleMethod(
            jd => TimescaleModule.Ut1ToTt(jd, ttMinusUt1Delta),
            julianDate,
            0.8928551385462962963,
            JulianDateKind.Tt);
    }

    [Test]
    public void UniversalTimeToTerrestrialTime_WrongKind_Test()
    {
        TestTimeScaleMethodWrongKind(
            jd => TimescaleModule.Ut1ToTt(jd, 0.0),
            JulianDateKind.Ut1);
    }

    [Test]
    public void UniversalTimeToCoordinatedUniversalTime_Test()
    {
        // ARRANGE
        JulianDate julianDate = new JulianDate(DayNumber, 0.892104561);
        double ut1MinusUtcDelta = 0.3341;

        TestTimeScaleMethod(
            jd => TimescaleModule.Ut1ToUtc(jd, ut1MinusUtcDelta),
            julianDate,
            0.8921006941018518519,
            JulianDateKind.Utc);
    }

    [Test]
    public void UniversalTimeToCoordinatedUniversalTime_WrongKind_Test()
    {
        TestTimeScaleMethodWrongKind(
            jd => TimescaleModule.Ut1ToUtc(jd, 0.0),
            JulianDateKind.Ut1);
    }

    [Test]
    public void CoordinatedUniversalTimeToUniversalTime_Test()
    {
        // ARRANGE
        JulianDate julianDate = new JulianDate(DayNumber, 0.892100694);
        double ut1MinusUtcDelta = 0.3341;

        TestTimeScaleMethod(
            jd => TimescaleModule.UtcToUt1(jd, ut1MinusUtcDelta),
            julianDate,
            0.8921045608981481481,
            JulianDateKind.Ut1);
    }

    [Test]
    public void CoordinatedUniversalTimeToUniversalTime_WrongKind_Test()
    {
        TestTimeScaleMethodWrongKind(
            jd => TimescaleModule.UtcToUt1(jd, 0.0),
            JulianDateKind.Utc);
    }

    [Test]
    public void UtcToTt_Test()
    {
        TestKindOnly(TimescaleModule.UtcToTt, JulianDateKind.Utc, JulianDateKind.Tt);
    }

    [Test]
    public void UtcToTcb_Test()
    {
        TestKindOnly(TimescaleModule.UtcToTcb, JulianDateKind.Utc, JulianDateKind.Tcb);
    }

    [Test]
    public void UtcToTdb_Test()
    {
        TestKindOnly(TimescaleModule.UtcToTdb, JulianDateKind.Utc, JulianDateKind.Tdb);
    }

    [Test]
    public void UtcToTcg_Test()
    {
        TestKindOnly(TimescaleModule.UtcToTcg, JulianDateKind.Utc, JulianDateKind.Tcg);
    }

    [Test]
    public void Ut1ToTcb_Test()
    {
        TestKindOnly(TimescaleModule.Ut1ToTcb, JulianDateKind.Ut1, JulianDateKind.Tcb);
    }

    [Test]
    public void Ut1ToTdb_Test()
    {
        TestKindOnly(TimescaleModule.Ut1ToTdb, JulianDateKind.Ut1, JulianDateKind.Tdb);
    }

    [Test]
    public void Ut1ToTcg_Test()
    {
        TestKindOnly(TimescaleModule.Ut1ToTcg, JulianDateKind.Ut1, JulianDateKind.Tcg);
    }

    [Test]
    public void TtToUtc_Test()
    {
        TestKindOnly(TimescaleModule.TtToUtc, JulianDateKind.Tt, JulianDateKind.Utc);
    }

    [Test]
    public void TtToTcb_Test()
    {
        TestKindOnly(TimescaleModule.TtToTcb, JulianDateKind.Tt, JulianDateKind.Tcb);
    }

    [Test]
    public void TcbToTt_Test()
    {
        TestKindOnly(TimescaleModule.TcbToTt, JulianDateKind.Tcb, JulianDateKind.Tt);
    }

    [Test]
    public void TcbToUt1_Test()
    {
        TestKindOnly(TimescaleModule.TcbToUt1, JulianDateKind.Tcb, JulianDateKind.Ut1);
    }

    [Test]
    public void TcbToTai_Test()
    {
        TestKindOnly(TimescaleModule.TcbToTai, JulianDateKind.Tcb, JulianDateKind.Tai);
    }

    [Test]
    public void TcbToUtc_Test()
    {
        TestKindOnly(TimescaleModule.TcbToUtc, JulianDateKind.Tcb, JulianDateKind.Utc);
    }

    [Test]
    public void TcbToTcg_Test()
    {
        TestKindOnly(TimescaleModule.TcbToTcg, JulianDateKind.Tcb, JulianDateKind.Tcg);
    }

    [Test]
    public void TdbToUt1_Test()
    {
        TestKindOnly(TimescaleModule.TdbToUt1, JulianDateKind.Tdb, JulianDateKind.Ut1);
    }

    [Test]
    public void TdbToTai_Test()
    {
        TestKindOnly(TimescaleModule.TdbToTai, JulianDateKind.Tdb, JulianDateKind.Tai);
    }

    [Test]
    public void TdbToUtc_Test()
    {
        TestKindOnly(TimescaleModule.TdbToUtc, JulianDateKind.Tdb, JulianDateKind.Utc);
    }

    [Test]
    public void TdbToTcg_Test()
    {
        TestKindOnly(TimescaleModule.TdbToTcg, JulianDateKind.Tdb, JulianDateKind.Tcg);
    }

    [Test]
    public void TcgToUt1_Test()
    {
        TestKindOnly(TimescaleModule.TcgToUt1, JulianDateKind.Tcg, JulianDateKind.Ut1);
    }

    [Test]
    public void TcgToTai_Test()
    {
        TestKindOnly(TimescaleModule.TcgToTai, JulianDateKind.Tcg, JulianDateKind.Tai);
    }

    [Test]
    public void TcgToUtc_Test()
    {
        TestKindOnly(TimescaleModule.TcgToUtc, JulianDateKind.Tcg, JulianDateKind.Utc);
    }

    [Test]
    public void TcgToTdb_Test()
    {
        TestKindOnly(TimescaleModule.TcgToTdb, JulianDateKind.Tcg, JulianDateKind.Tdb);
    }

    [Test]
    public void TcgToTcb_Test()
    {
        TestKindOnly(TimescaleModule.TcgToTcb, JulianDateKind.Tcg, JulianDateKind.Tcb);
    }

    [Test]
    public void TaiToTdb_Test()
    {
        TestKindOnly(TimescaleModule.TaiToTdb, JulianDateKind.Tai, JulianDateKind.Tdb);
    }

    [Test]
    public void TaiToTcb_Test()
    {
        TestKindOnly(TimescaleModule.TaiToTcb, JulianDateKind.Tai, JulianDateKind.Tcb);
    }

    [Test]
    public void TaiToTcg_Test()
    {
        TestKindOnly(TimescaleModule.TaiToTcg, JulianDateKind.Tai, JulianDateKind.Tcg);
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

    private void TestKindOnly(Func<JulianDate, JulianDate> methodUnderTest, JulianDateKind inputKind, JulianDateKind expectedKind)
    {
        var jd = 2_451_545.0;
        var julianDate = new JulianDate(jd, inputKind);
        var result = methodUnderTest(julianDate);
        Assert.Multiple(() =>
        {
            Assert.That(result.Kind, Is.EqualTo(expectedKind));
            Assert.Throws<JulianDateKindException>(() => methodUnderTest(new JulianDate(jd, inputKind + 1)));
            Assert.Throws<JulianDateKindException>(() => methodUnderTest(new JulianDate(jd, inputKind - 1)));
        });
    }

    private void TestKindOnly(Func<JulianDate, double, JulianDate> methodUnderTest, JulianDateKind inputKind, JulianDateKind expectedKind)
    {
        var jd = 2_451_545.0;
        var julianDate = new JulianDate(jd, inputKind);
        var result = methodUnderTest(julianDate, 10);
        Assert.Multiple(() =>
        {
            Assert.That(result.Kind, Is.EqualTo(expectedKind));
            Assert.Throws<JulianDateKindException>(() => methodUnderTest(new JulianDate(jd, inputKind + 1), 10));
            Assert.Throws<JulianDateKindException>(() => methodUnderTest(new JulianDate(jd, inputKind - 1), 10));
        });
    }

    private void TestKindOnly(Func<JulianDate, double, double, JulianDate> methodUnderTest, JulianDateKind inputKind, JulianDateKind expectedKind)
    {
        var jd = 2_451_545.0;
        var julianDate = new JulianDate(jd, inputKind);
        var result = methodUnderTest(julianDate, 10, 10);
        Assert.Multiple(() =>
        {
            Assert.That(result.Kind, Is.EqualTo(expectedKind));
            Assert.Throws<JulianDateKindException>(() => methodUnderTest(new JulianDate(jd, inputKind + 1), 10, 10));
            Assert.Throws<JulianDateKindException>(() => methodUnderTest(new JulianDate(jd, inputKind - 1), 10, 10));
        });
    }
    private void TestTimeScaleMethodWrongKind(Func<JulianDate, JulianDate> methodUnderTest, JulianDateKind validKind)
    {
        Assert.Multiple(() =>
        {
            Assert.Throws<JulianDateKindException>(() => methodUnderTest(new JulianDate(10.5, 0.0, validKind + 1)));
            Assert.Throws<JulianDateKindException>(() => methodUnderTest(new JulianDate(10.5, 0.0, validKind - 1)));
        });
    }

    #endregion

}
