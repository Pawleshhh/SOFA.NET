namespace SOFA.NET.Tests;

[TestFixture]
internal class JulianDateTest
{

    #region Tests

    private const double Epsilon = 0.0001;

    [TestCase(20043.5, 0.4999, 20043.9999)]
    [TestCase(68569.5, 0.0, 68569.5)]
    [TestCase(2136.5, 0.6111, 2137.1111)]
    [TestCase(999_999_999.5, 0.5, 1e9)]
    public void Constructor_InitializeWithDayNumberAndFractionOfDay_PropertiesSet(double dayNumber, double fraction, double date)
    {
        // ARRANGE & ACT
        JulianDate julianDate = new JulianDate(dayNumber, fraction);

        // ASSERT
        Assert.Multiple(() =>
        {
            Assert.That(julianDate.DayNumber, Is.EqualTo(dayNumber));
            Assert.That(julianDate.FractionOfDay, Is.EqualTo(fraction));
            Assert.That(julianDate.Date, Is.EqualTo(date));
        });
    }

    [TestCase(0.5, 1.0)]
    [TestCase(20043.5, 1.1)]
    [TestCase(20043.5, -Epsilon)]
    [TestCase(20043.5, 1.0)]
    [TestCase(20043.5, 1.1)]
    [TestCase(20043.5, -Epsilon)]
    [TestCase(999_999_999.5, -Epsilon)]
    [TestCase(999_999_999.5, 1.0)]
    [TestCase(999_999_999.5, 1.1)]
    public void Constructor_InitializeWithInvalidFractionOfDay_ThrowsArgumentOutOfRangeException(double dayNumber, double fraction)
    {
        // ARRANGE & ACT & ASSERT
        Assert.Throws<ArgumentOutOfRangeException>(() => new JulianDate(dayNumber, fraction));
    }

    [TestCase(10.0)]
    [TestCase(10.0 + Epsilon)]
    [TestCase(10.5 - Epsilon)]
    [TestCase(10.5 + Epsilon)]
    [TestCase(11.0 - Epsilon)]
    [TestCase(11.0)]
    public void Constructor_InitializeWithInvalidDayNumber_ThrowsArgumentException(double dayNumber)
    {
        // ARRANGE & ACT & ASSERT
        Assert.Throws<ArgumentException>(() => new JulianDate(dayNumber, 0.0));
    }

    [TestCase(20043.9999, 20043.5, 0.4999)]
    [TestCase(68569.5, 68569.5, 0.0)]
    [TestCase(2137.1111, 2136.5, 0.6111)]
    [TestCase(1e9, 999_999_999.5, 0.5)]
    public void Constructor_InitializeWithDate_PropertiesSet(double date, double dayNumber, double fraction)
    {
        // ARRANGE & ACT
        JulianDate julianDate = new JulianDate(date);

        // ASSERT
        Assert.Multiple(() =>
        {
            Assert.That(julianDate.Date, Is.EqualTo(date));
            Assert.That(julianDate.DayNumber, Is.EqualTo(dayNumber));
            Assert.That(julianDate.FractionOfDay, Is.EqualTo(fraction).Within(0.0001)); // There is tolerance because of numerical problems
        });
    }

    [TestCase(0.0 - Epsilon)]
    [TestCase(1e9 + Epsilon)]
    public void Constructor_InitializeWithInvalidDate_ThrowsException(double date)
    {
        // ARRANGE & ACT & ASSERT
        Assert.Throws<ArgumentOutOfRangeException>(() => new JulianDate(date));
    }

    [Test]
    public void Deconstruct_DeconstructsJulianDate_DayNumberAndFractionOfDayReturned()
    {
        // ARRANGE
        double dayNumber = 4000.5;
        double fraction = 0.85;
        JulianDate julianDate = new JulianDate(dayNumber, fraction);

        // ACT
        var (resultDayNumber, resultFraction) = julianDate;

        // ASSERT
        Assert.Multiple(() =>
        {
            Assert.That(resultDayNumber, Is.EqualTo(dayNumber));
            Assert.That(resultFraction, Is.EqualTo(fraction));
        });
    }

    [TestCase]
    public void ObjectEquals_NotJulianDateTypeProvided_ReturnsFalse()
    {
        // ARRANGE
        JulianDate julianDate = new JulianDate();
        object obj = new object();

        // ACT
        bool result = julianDate.Equals(obj);

        // ASSERT
        Assert.That(result, Is.False);
    }

    [TestCase]
    public void ObjectEquals_NullObjectProvided_ReturnsFalse()
    {
        // ARRANGE
        JulianDate julianDate = new JulianDate();
        object? obj = null;

        // ACT
        bool result = julianDate.Equals(obj);

        // ASSERT
        Assert.That(result, Is.False);
    }

    [TestCase(240519.44, 240519.44, true)]
    [TestCase(240519.439999, 240519.44, false)]
    public void ObjectEquals_CompareIfJulianDatesAreEqual_ReturnExepctedValue(double date1, double date2, bool expected)
    {
        // ARRANGE
        JulianDate julianDate1 = new JulianDate(date1);
        JulianDate julianDate2 = new JulianDate(date2);

        // ACT & ASSERT
        EqualsTestHelper(julianDate1, julianDate2, expected, false);
    }

    [TestCase(240519.44, 240519.44, true)]
    [TestCase(240519.439999, 240519.44, false)]
    public void Equals_CompareIfJulianDatesAreEqual_ReturnExepctedValue(double date1, double date2, bool expected)
    {
        // ARRANGE
        JulianDate julianDate1 = new JulianDate(date1);
        JulianDate julianDate2 = new JulianDate(date2);

        // ACT & ASSERT
        EqualsTestHelper(julianDate1, julianDate2, expected, true);
    }

    [Test]
    public void CompareTo_NotJulianDateProvided_ReturnsZero()
    {
        // ARRANGE
        JulianDate julianDate = new JulianDate();
        object obj = new object();

        // ACT
        int result = julianDate.CompareTo(obj);

        // ASSERT
        Assert.That(result, Is.Zero);
    }

    [Test]
    public void CompareTo_NullObjectProvided_ReturnsZero()
    {
        // ARRANGE
        JulianDate julianDate = new JulianDate();
        object? obj = null;

        // ACT
        int result = julianDate.CompareTo(obj);

        // ASSERT
        Assert.That(result, Is.Zero);
    }

    [TestCase(240519.44, 240519.44, 0)]
    [TestCase(240519.439999, 240519.44, -1)]
    [TestCase(240519.44, 240519.439999, 1)]
    [TestCase(240519.44, 240519.44, 0)]
    [TestCase(240518.44, 240519.44, -1)]
    [TestCase(240520.44, 240519.44, 1)]
    public void CompareToWithObjectParameterType_CompareJulianDates_ReturnExepctedValue(double date1, double date2, int expected)
    {
        // ARRANGE
        JulianDate julianDate1 = new JulianDate(date1);
        JulianDate julianDate2 = new JulianDate(date2);

        // ACT & ASSERT
        CompareToTestHelper(julianDate1, julianDate2, expected, false);
    }

    [TestCase(240519.44, 240519.44, 0)]
    [TestCase(240519.439999, 240519.44, -1)]
    [TestCase(240519.44, 240519.439999, 1)]
    [TestCase(240519.44, 240519.44, 0)]
    [TestCase(240518.44, 240519.44, -1)]
    [TestCase(240520.44, 240519.44, 1)]
    public void CompareTo_CompareJulianDates_ReturnExepctedValue(double date1, double date2, int expected)
    {
        // ARRANGE
        JulianDate julianDate1 = new JulianDate(date1);
        JulianDate julianDate2 = new JulianDate(date2);

        // ACT & ASSERT
        CompareToTestHelper(julianDate1, julianDate2, expected, true);
    }

    #endregion

    #region Helpers

    private void EqualsTestHelper(JulianDate julianDate1, object julianDate2, bool expectedResult, bool castJulianDate2)
    {
        bool result;
        // ACT
        if (castJulianDate2)
        {
            result = julianDate1.Equals((JulianDate)julianDate2);
        }
        else
        {
            result = julianDate1.Equals(julianDate2);
        }

        // ASSERT
        Assert.That(result, Is.EqualTo(expectedResult));
    }

    private void CompareToTestHelper(JulianDate julianDate1, object julianDate2, int expectedResult, bool castJulianDate2)
    {
        int result;
        // ACT
        if (castJulianDate2)
        {
            result = julianDate1.CompareTo((JulianDate)julianDate2);
        }
        else
        {
            result = julianDate1.CompareTo(julianDate2);
        }

        // ASSERT
        Assert.That(result, Is.EqualTo(expectedResult));
    }

    #endregion

}
