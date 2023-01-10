namespace SOFA.NET;

public readonly struct JulianDate : IComparable, IComparable<JulianDate>, IEquatable<JulianDate>
{

    #region Properties

    public double Date => DayNumber + FractionOfDay;

    public double DayNumber { get; }

    public double FractionOfDay { get; }

    #endregion

    #region Constructors

    public JulianDate(double julianDate)
    {
        this = new();

        DayNumber = RetrieveDayNumber(julianDate);
        FractionOfDay = RetrieveFractionOfDay(julianDate);

        ThrowIfDateIsNotValid(julianDate);
    }

    public JulianDate(double dayNumber, double fractionOfDay)
    {
        if (fractionOfDay < 0.0 || fractionOfDay >= 1.0)
        {
            throw new ArgumentOutOfRangeException(nameof(fractionOfDay), fractionOfDay, "Fraction of day must be in range [0.0; 1.0)");
        }
        if (dayNumber - Math.Truncate(dayNumber) != 0.5)
        {
            throw new ArgumentException("Julian date number's fractional part must be equal to +0.5", nameof(dayNumber));
        }

        DayNumber = dayNumber;
        FractionOfDay = fractionOfDay;

        ThrowIfDateIsNotValid(Date);
    }

    #endregion

    #region Deconstructors

    public void Deconstruct(out double dayNumber, out double fractionOfDay)
    {
        dayNumber = DayNumber;
        fractionOfDay = FractionOfDay;
    }

    #endregion

    #region Methods

    public double JulianYear(double epoch = Constants.DJ00)
        => ((DayNumber - epoch) + FractionOfDay) / Constants.DJY;

    public double JulianCentury(double epoch = Constants.DJ00)
        => ((DayNumber - epoch) + FractionOfDay) / Constants.DJC;

    public double JulianMillenium(double epoch = Constants.DJ00)
        => ((DayNumber - epoch) + FractionOfDay) / Constants.DJM;

    public double ToBesselianEpoch()
        => CalendarsModule.JulianDateToBesselianEpoch(this);

    public double ToJulianEpoch()
        => CalendarsModule.JulianDateToJulianEpoch(this);

    public DateTime ToDateTime()
        => CalendarsModule.JulianDateToGregorianCalendar(this);

    #endregion

    #region Private methods

    private double RetrieveDayNumber(double date)
    {
        return Math.Truncate(date - 0.5) + 0.5;
    }

    private double RetrieveFractionOfDay(double date)
    {
        var fraction = date - Math.Truncate(date) + 0.5;

        if (fraction >= 1.0)
        {
            return fraction - 1.0;
        }
        else
        {
            return fraction;
        }
    }

    private void ThrowIfDateIsNotValid(double date)
    {
        if (date < minValue || date > maxValue)
        {
            throw new ArgumentOutOfRangeException(null, date, "Julian date is out of range");
        }
    }

    #endregion

    #region Object

    public override bool Equals(object? obj)
    {
        if (obj is JulianDate julianDate)
        {
            return Equals(julianDate);
        }

        return false;
    }

    public override int GetHashCode()
    {
        return (DayNumber.GetHashCode() * 17) + (FractionOfDay.GetHashCode() * 13);
    }

    public override string ToString()
    {
        return Date.ToString();
    }

    #endregion

    #region Static members

    private static double minValue = 0.0;
    private static double maxValue = 1e9;

    public static JulianDate MinValue { get; } = new JulianDate(minValue);

    public static JulianDate MaxValue { get; } = new JulianDate(maxValue);

    public static JulianDate FromBesselianEpoch(double besselianEpoch)
        => CalendarsModule.BesselianEpochToJulianDate(besselianEpoch);

    #endregion

    #region IComparable

    public int CompareTo(object? obj)
    {
        if (obj is JulianDate julianDate)
        {
            return CompareTo(julianDate);
        }

        return 0;
    }

    public int CompareTo(JulianDate other)
    {
        int dayNumberCompare = DayNumber.CompareTo(other.DayNumber);

        if (dayNumberCompare != 0)
        {
            return dayNumberCompare;
        }

        return FractionOfDay.CompareTo(other.FractionOfDay); ;
    }

    #endregion

    #region IEquatable

    public bool Equals(JulianDate other)
    {
        return DayNumber.Equals(other.DayNumber)
            && FractionOfDay.Equals(other.FractionOfDay);
    }

    #endregion

    #region Operators

    public static bool operator ==(JulianDate left, JulianDate right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(JulianDate left, JulianDate right)
    {
        return !left.Equals(right);
    }

    public static bool operator <(JulianDate left, JulianDate right)
    {
        return left.CompareTo(right) < 0;
    }

    public static bool operator <=(JulianDate left, JulianDate right)
    {
        return left.CompareTo(right) <= 0;
    }

    public static bool operator >(JulianDate left, JulianDate right)
    {
        return left.CompareTo(right) > 0;
    }

    public static bool operator >=(JulianDate left, JulianDate right)
    {
        return left.CompareTo(right) >= 0;
    }

    public static JulianDate operator +(JulianDate left, JulianDate right)
    {
        return new JulianDate(left.Date + right.Date);
    }

    public static JulianDate operator -(JulianDate left, JulianDate right)
    {
        return new JulianDate(left.Date - right.Date);
    }

    public static JulianDate operator *(JulianDate left, JulianDate right)
    {
        return new JulianDate(left.Date * right.Date);
    }

    public static JulianDate operator /(JulianDate left, JulianDate right)
    {
        return new JulianDate(left.Date / right.Date);
    }
    
    public static implicit operator double(JulianDate julianDate)
    {
        return julianDate.Date;
    }

    public static explicit operator JulianDate(double date)
    {
        return new JulianDate(date);
    }

    #endregion

}
