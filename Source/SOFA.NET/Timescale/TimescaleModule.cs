﻿using static System.Math;
using static SOFA.NET.ThrowHelper;

namespace SOFA.NET;

public static class TimescaleModule
{

    #region Constants

    private const double ttMinusTaiInDays
        = Constants.TTMTAI / Constants.DAYSEC;

    private const double jd77dayNumber
        = Constants.DJM0 + Constants.DJM77;

    private const double tdbDaysAtTAI77
        = Constants.TDB0 / Constants.DAYSEC;

    private const double tdbToTcbRate
        = Constants.ELB / (1.0 - Constants.ELB);

    private const double tdbToTcgRate
        = Constants.ELG / (1.0 - Constants.ELG);

    private const double mjd77 = Constants.DJM77 + ttMinusTaiInDays;

    #endregion

    #region Public

    /// <summary>
    /// SOFA name: iauDat
    /// </summary>
    /// <param name="dateTime"></param>
    /// <returns></returns>
    public static double DeltaAT(DateTime dateTime)
    {
        var (year, month, day) = dateTime;
        return DeltaAT(year, month, day, dateTime.TimeOfDay.TotalSeconds / Constants.DAYSEC);
    }

    /// <summary>
    /// SOFA name: iauDtdb
    /// </summary>
    /// <param name="tdbJulianDate"></param>
    /// <param name="ut"></param>
    /// <param name="geographicCoords"></param>
    /// <param name="earthSpinAxisDistance"></param>
    /// <param name="northEquatorialPlaneDistance"></param>
    /// <returns></returns>
    public static double BarycentricDynamicalTimeTerrestrialTimeDifference(
        JulianDate tdbJulianDate,
        TimeSpan ut,
        GeographicCoordinates geographicCoords,
        double earthSpinAxisDistance,
        double northEquatorialPlaneDistance)
        => BarycentricDynamicalTimeTerrestrialTimeDifference(
            tdbJulianDate,
            ut, 
            geographicCoords, 
            earthSpinAxisDistance,
            northEquatorialPlaneDistance, 
            false);

    internal static double BarycentricDynamicalTimeTerrestrialTimeDifference(
        JulianDate tdbJulianDate,
        TimeSpan ut,
        GeographicCoordinates geographicCoords,
        double earthSpinAxisDistance,
        double northEquatorialPlaneDistance,
        bool ignoreKind)
    {
        ThrowIfNotExpectedJulianDateKind(JulianDateKind.Tdb, tdbJulianDate, ignoreKind);

        var fairhd = TdbToTtCoefficients.Coefficients;
        double t = tdbJulianDate.JulianMillenium();
        double utFractionOfDay = ut.TotalSeconds / Constants.DAYSEC;

        double tsol = (utFractionOfDay % 1.0) * Constants.PI2 + geographicCoords.Longitude;

        double w = t / 3600.0;

        double mlOfSun = FundamentalArgument(280.46645683, 1296027711.03429, w);
        double maOfSun = FundamentalArgument(357.52910918, 1295965810.481, w);
        double meOfMoonFromSun = FundamentalArgument(297.85019547, 16029616012.090, w);
        double mlOfJupiter = FundamentalArgument(34.35151874, 109306899.89453, w);
        double mlOfSaturn = FundamentalArgument(50.07744430, 44046398.47038, w);

        double topocentricTerms = 0.00029e-10 * earthSpinAxisDistance * Sin(tsol + mlOfSun - mlOfSaturn)
               + 0.00100e-10 * earthSpinAxisDistance * Sin(tsol - 2.0 * maOfSun)
               + 0.00133e-10 * earthSpinAxisDistance * Sin(tsol - meOfMoonFromSun)
               + 0.00133e-10 * earthSpinAxisDistance * Sin(tsol + mlOfSun - mlOfJupiter)
               - 0.00229e-10 * earthSpinAxisDistance * Sin(tsol + 2.0 * mlOfSun + maOfSun)
               - 0.02200e-10 * northEquatorialPlaneDistance * Cos(mlOfSun + maOfSun)
               + 0.05312e-10 * earthSpinAxisDistance * Sin(tsol - maOfSun)
               - 0.13677e-10 * earthSpinAxisDistance * Sin(tsol + 2.0 * mlOfSun)
               - 1.31840e-10 * northEquatorialPlaneDistance * Cos(mlOfSun)
               + 3.17679e-10 * earthSpinAxisDistance * Sin(tsol);

        double t0 = 0;
        int j;
        for (j = 473; j >= 0; j--)
        {
            t0 += fairhd[j][0] * Sin(fairhd[j][1] * t + fairhd[j][2]);
        }

        double t1 = 0;
        for (j = 678; j >= 474; j--)
        {
            t1 += fairhd[j][0] * Sin(fairhd[j][1] * t + fairhd[j][2]);
        }

        double t2 = 0;
        for (j = 763; j >= 679; j--)
        {
            t2 += fairhd[j][0] * Sin(fairhd[j][1] * t + fairhd[j][2]);
        }

        double t3 = 0;
        for (j = 783; j >= 764; j--)
        {
            t3 += fairhd[j][0] * Sin(fairhd[j][1] * t + fairhd[j][2]);
        }

        double t4 = 0;
        for (j = 786; j >= 784; j--)
        {
            t4 += fairhd[j][0] * Sin(fairhd[j][1] * t + fairhd[j][2]);
        }

        double wf = t * (t * (t * (t * t4 + t3) + t2) + t1) + t0;

        double adjustment = 0.00065e-6 * Sin(6069.776754 * t + 4.021194) +
               0.00033e-6 * Sin(213.299095 * t + 5.543132) +
               (-0.00196e-6 * Sin(6208.294251 * t + 5.696701)) +
               (-0.00173e-6 * Sin(74.781599 * t + 2.435900)) +
               0.03638e-6 * t * t;

        w = topocentricTerms + wf + adjustment;

        return w;

        static double FundamentalArgument(double a, double b, double w)
            => MathHelper.DegreesToRadians((a + b * w) % 360.0);
    }

    /// <summary>
    /// SOFA name: iauTaitt
    /// </summary>
    /// <param name="taiJulianDate"></param>
    /// <returns></returns>
    public static JulianDate InternationalAtomicTimeToTerrestrialTime(JulianDate taiJulianDate)
        => InternationalAtomicTimeToTerrestrialTime(taiJulianDate, false);

    internal static JulianDate InternationalAtomicTimeToTerrestrialTime(JulianDate taiJulianDate, bool ignoreKind)
    {
        ThrowIfNotExpectedJulianDateKind(JulianDateKind.Tai, taiJulianDate, ignoreKind);
        var (dayNumber, fractionOfDay) = taiJulianDate;

        return SafeguardingPrecision(taiJulianDate, fractionOfDay + ttMinusTaiInDays, dayNumber + fractionOfDay, JulianDateKind.Tt);
    }

    /// <summary>
    /// SOFA name: iauTaiut1
    /// </summary>
    /// <param name="taiJulianDate"></param>
    /// <param name="ut1TaiDelta"></param>
    /// <returns></returns>
    public static JulianDate InternationalAtomicTimeToUniversalTime(JulianDate taiJulianDate, double ut1TaiDelta)
        => InternationalAtomicTimeToUniversalTime(taiJulianDate, ut1TaiDelta, false);

    internal static JulianDate InternationalAtomicTimeToUniversalTime(JulianDate taiJulianDate, double ut1TaiDelta, bool ignoreKind)
    {
        ThrowIfNotExpectedJulianDateKind(JulianDateKind.Tai, taiJulianDate, ignoreKind);
        var (dayNumber, fractionOfDay) = taiJulianDate;
        double deltaInSec = ut1TaiDelta / Constants.DAYSEC;

        return SafeguardingPrecision(taiJulianDate, fractionOfDay + deltaInSec, dayNumber + deltaInSec, JulianDateKind.Ut1);
    }

    /// <summary>
    /// SOFA name: iauTaiutc
    /// </summary>
    /// <param name="taiJulianDate"></param>
    /// <returns></returns>
    public static JulianDate InternationalAtomicTimeToCoordinatedUniversalTime(JulianDate taiJulianDate)
        => InternationalAtomicTimeToCoordinatedUniversalTime(taiJulianDate, false);

    internal static JulianDate InternationalAtomicTimeToCoordinatedUniversalTime(JulianDate taiJulianDate, bool ignoreKind)
    {
        ThrowIfNotExpectedJulianDateKind(JulianDateKind.Tai, taiJulianDate, ignoreKind);
        var (taiDayNumber, taiFractionOfDay) = taiJulianDate;

        var bigFirstOrder = Abs(taiDayNumber) >= Abs(taiFractionOfDay);

        double a1, a2;
        if (bigFirstOrder)
        {
            a1 = taiDayNumber;
            a2 = taiFractionOfDay;
        }
        else
        {
            a1 = taiFractionOfDay;
            a2 = taiDayNumber;
        }

        double u1 = a1;
        double u2 = a2;

        for (int i = 0; i < 3; i++)
        {
            var (g1, g2) = CoordinatedUniversalTimeToInternationalAtomicTime(new(u1, u2), true);

            u2 += a1 - g1;
            u2 += a2 - g2;
        }

        if (bigFirstOrder)
        {
            return new(u1, u2);
        }
        else
        {
            return new(u2, u1);
        }
    }

    /// <summary>
    /// SOFA name: iauUtctai
    /// </summary>
    /// <param name="utcJulianDate"></param>
    /// <returns></returns>
    public static JulianDate CoordinatedUniversalTimeToInternationalAtomicTime(JulianDate utcJulianDate)
        => CoordinatedUniversalTimeToInternationalAtomicTime(utcJulianDate, false);

    internal static JulianDate CoordinatedUniversalTimeToInternationalAtomicTime(JulianDate utcJulianDate, bool ignoreKind)
    {
        ThrowIfNotExpectedJulianDateKind(JulianDateKind.Utc, utcJulianDate, ignoreKind);
        var (utcDayNumber, utcFractionOfDay) = utcJulianDate;

        double u1, u2;
        var bigFirstOrder = (Abs(utcDayNumber) >= Abs(utcFractionOfDay));
        if (bigFirstOrder)
        {
            u1 = utcDayNumber;
            u2 = utcFractionOfDay;
        }
        else
        {
            u1 = utcFractionOfDay;
            u2 = utcDayNumber;
        }

        var (yearToday, monthToday, dayToday, fractionOfDay) = CalendarsModule.JulianDateToGregorianCalendar(new JulianDate(u1 + u2));
        double dat0 = DeltaAT(yearToday, monthToday, dayToday, 0.0);
        double dat12 = DeltaAT(yearToday, monthToday, dayToday, 0.5);

        var (tomorrowYear, tomorrowMonth, tomorrowDay, _) = CalendarsModule.JulianDateToGregorianCalendar(
            new JulianDate((u1 + 1.5) + (u2 - fractionOfDay)));
        double dat24 = DeltaAT(tomorrowYear, tomorrowMonth, tomorrowDay, 0.0);

        double perDay = 2.0 * (dat12 - dat0);
        double jump = dat24 - (dat0 + perDay);
        fractionOfDay *= (Constants.DAYSEC + jump) / Constants.DAYSEC;
        fractionOfDay *= (Constants.DAYSEC + perDay) / Constants.DAYSEC;

        var (mdjZeroPoint, mjdForZeroHour) = CalendarsModule.GregorianCalendarToJulianDate(new DateTime(yearToday, monthToday, dayToday));

        double a2 = mdjZeroPoint - u1;
        a2 += mjdForZeroHour;
        a2 += fractionOfDay + dat0 / Constants.DAYSEC;
        if (bigFirstOrder)
        {
            return new(u1, a2);
        }
        else
        {
            return new(a2, u1);
        }
    }

    /// <summary>
    /// SOFA name: iauTcbtdb
    /// </summary>
    /// <param name="tcbJulianDate"></param>
    /// <returns></returns>
    public static JulianDate BarycentricCoordinateTimeToBarycentricDynamicalTime(JulianDate tcbJulianDate)
        => BarycentricCoordinateTimeToBarycentricDynamicalTime(tcbJulianDate, false);

    internal static JulianDate BarycentricCoordinateTimeToBarycentricDynamicalTime(JulianDate tcbJulianDate, bool ignoreKind)
    {
        ThrowIfNotExpectedJulianDateKind(JulianDateKind.Tcb, tcbJulianDate, ignoreKind);
        var (dayNumber, fractionOfDay) = tcbJulianDate;

        return SafeguardingPrecision(tcbJulianDate,
            fractionOfDay + tdbDaysAtTAI77 - ((dayNumber - jd77dayNumber) + (fractionOfDay - ttMinusTaiInDays)) * Constants.ELB,
            dayNumber + tdbDaysAtTAI77 - ((fractionOfDay - jd77dayNumber) + (dayNumber - ttMinusTaiInDays)) * Constants.ELB);
    }

    /// <summary>
    /// SOFA name: iauTcgtt
    /// </summary>
    /// <param name="tcgJulianDate"></param>
    /// <returns></returns>
    public static JulianDate GeocentricCoordinateTimeToTerrestrialTime(JulianDate tcgJulianDate)
        => GeocentricCoordinateTimeToTerrestrialTime(tcgJulianDate, false);

    internal static JulianDate GeocentricCoordinateTimeToTerrestrialTime(JulianDate tcgJulianDate, bool ignoreKind)
    {
        ThrowIfNotExpectedJulianDateKind(JulianDateKind.Tcg, tcgJulianDate, ignoreKind);
        var (dayNumber, fractionOfDay) = tcgJulianDate;

        if (Abs(dayNumber) > Abs(fractionOfDay))
        {
            return new(dayNumber, fractionOfDay - ((dayNumber - Constants.DJM0) + (fractionOfDay - mjd77)) * Constants.ELG);
        }
        else
        {
            return new(dayNumber - ((fractionOfDay - Constants.DJM0) + (dayNumber - mjd77)) * Constants.ELG, fractionOfDay);
        }
    }

    /// <summary>
    /// SOFA name: iauTttai
    /// </summary>
    /// <param name="ttJulianDate"></param>
    /// <returns></returns>
    public static JulianDate TerrestrialTimeToInternationalAtomicTime(JulianDate ttJulianDate)
        => TerrestrialTimeToInternationalAtomicTime(ttJulianDate, false);

    internal static JulianDate TerrestrialTimeToInternationalAtomicTime(JulianDate ttJulianDate, bool ignoreKind)
    {
        ThrowIfNotExpectedJulianDateKind(JulianDateKind.Tt, ttJulianDate, ignoreKind);
        var (dayNumber, fractionOfDay) = ttJulianDate;
        return SafeguardingPrecision(ttJulianDate, fractionOfDay - ttMinusTaiInDays, dayNumber - ttMinusTaiInDays);
    }

    /// <summary>
    /// SOFA name: iauTdbtcb
    /// </summary>
    /// <param name="tdbJulianDate"></param>
    /// <returns></returns>
    public static JulianDate BarycentricDynamicalTimeToBarycentricCoordinateTime(JulianDate tdbJulianDate)
        => BarycentricDynamicalTimeToBarycentricCoordinateTime(tdbJulianDate, false);

    internal static JulianDate BarycentricDynamicalTimeToBarycentricCoordinateTime(JulianDate tdbJulianDate, bool ignoreKind)
    {
        ThrowIfNotExpectedJulianDateKind(JulianDateKind.Tdb, tdbJulianDate, ignoreKind);
        var (dayNumber, fractionOfDay) = tdbJulianDate;
        double d1 = jd77dayNumber - dayNumber;
        double d2 = jd77dayNumber - fractionOfDay;
        double f1 = fractionOfDay - tdbDaysAtTAI77;
        double f2 = dayNumber - tdbDaysAtTAI77;

        return SafeguardingPrecision(tdbJulianDate,
            f1 - (d1 - (f1 - ttMinusTaiInDays)) * tdbToTcbRate,
            f2 - (d2 - (f2 - ttMinusTaiInDays)) * tdbToTcbRate);
    }

    /// <summary>
    /// SOFA name: iauTdbtt
    /// </summary>
    /// <param name="tdbJulianDate"></param>
    /// <param name="tdbMinusTtDelta"></param>
    /// <returns></returns>
    public static JulianDate BarycentricDynamicalTimeToTerrestrialTime(JulianDate tdbJulianDate, double tdbMinusTtDelta)
        => BarycentricDynamicalTimeToTerrestrialTime(tdbJulianDate, tdbMinusTtDelta, false);

    internal static JulianDate BarycentricDynamicalTimeToTerrestrialTime(JulianDate tdbJulianDate, double tdbMinusTtDelta, bool ignoreKind)
    {
        ThrowIfNotExpectedJulianDateKind(JulianDateKind.Tdb, tdbJulianDate, ignoreKind);
        var (dayNumber, fractionOfDay) = tdbJulianDate;

        double tdbMinusTtDeltaInDays = tdbMinusTtDelta / Constants.DAYSEC;
        return SafeguardingPrecision(tdbJulianDate,
            fractionOfDay - tdbMinusTtDeltaInDays,
            dayNumber - tdbMinusTtDeltaInDays);
    }

    /// <summary>
    /// SOFA name: iauTttcg
    /// </summary>
    /// <param name="ttJulianDate"></param>
    /// <returns></returns>
    public static JulianDate TerrestrialTimeToGeocentricCoordinateTime(JulianDate ttJulianDate)
        => TerrestrialTimeToGeocentricCoordinateTime(ttJulianDate, false);

    internal static JulianDate TerrestrialTimeToGeocentricCoordinateTime(JulianDate ttJulianDate, bool ignoreKind)
    {
        ThrowIfNotExpectedJulianDateKind(JulianDateKind.Tt, ttJulianDate, ignoreKind);
        var (dayNumber, fractionOfDay) = ttJulianDate;

        return SafeguardingPrecision(ttJulianDate,
            fractionOfDay + ((dayNumber - Constants.DJM0) + (fractionOfDay - mjd77)) * tdbToTcgRate,
            dayNumber + ((fractionOfDay - Constants.DJM0) + (dayNumber - mjd77)) * tdbToTcgRate);
    }

    /// <summary>
    /// SOFA name: iauTttdb
    /// </summary>
    /// <param name="ttJulianDate"></param>
    /// <param name="tdbMinusTtDelta"></param>
    /// <returns></returns>
    public static JulianDate TerrestrialTimeToBarycentricDynamicalTime(JulianDate ttJulianDate, double tdbMinusTtDelta)
        => TerrestrialTimeToBarycentricDynamicalTime(ttJulianDate, tdbMinusTtDelta, false);

    internal static JulianDate TerrestrialTimeToBarycentricDynamicalTime(JulianDate ttJulianDate, double tdbMinusTtDelta, bool ignoreKind)
    {
        ThrowIfNotExpectedJulianDateKind(JulianDateKind.Tt, ttJulianDate, ignoreKind);
        var (dayNumber, fractionOfDay) = ttJulianDate;

        double tdbMinusTtDeltaInDays = tdbMinusTtDelta / Constants.DAYSEC;

        return SafeguardingPrecision(ttJulianDate,
            fractionOfDay + tdbMinusTtDeltaInDays,
            dayNumber + tdbMinusTtDeltaInDays);
    }

    /// <summary>
    /// SOFA name: iauTtut1
    /// </summary>
    /// <param name="ttJulianDate"></param>
    /// <param name="ttMinusUt1Delta"></param>
    /// <returns></returns>
    public static JulianDate TerrestrialTimeToUniversalTime(JulianDate ttJulianDate, double ttMinusUt1Delta)
        => TerrestrialTimeToUniversalTime(ttJulianDate, ttMinusUt1Delta, false);

    internal static JulianDate TerrestrialTimeToUniversalTime(JulianDate ttJulianDate, double ttMinusUt1Delta, bool ignoreKind)
    {
        ThrowIfNotExpectedJulianDateKind(JulianDateKind.Tt, ttJulianDate, ignoreKind);
        var (dayNumber, fractionOfDay) = ttJulianDate;

        double ttMinusUt1InDays = ttMinusUt1Delta / Constants.DAYSEC;

        return SafeguardingPrecision(ttJulianDate,
            fractionOfDay - ttMinusUt1InDays,
            dayNumber - ttMinusUt1InDays);
    }

    /// <summary>
    /// SOFA name: iauUt1tai
    /// </summary>
    /// <param name="ut1JulianDate"></param>
    /// <param name="ut1MinusTaiDelta"></param>
    /// <returns></returns>
    public static JulianDate UniversalTimeToInternationalAtomicTime(JulianDate ut1JulianDate, double ut1MinusTaiDelta)
        => UniversalTimeToInternationalAtomicTime(ut1JulianDate, ut1MinusTaiDelta, false);

    internal static JulianDate UniversalTimeToInternationalAtomicTime(JulianDate ut1JulianDate, double ut1MinusTaiDelta, bool ignoreKind)
    {
        ThrowIfNotExpectedJulianDateKind(JulianDateKind.Ut1, ut1JulianDate, ignoreKind);
        var (dayNumber, fractionOfDay) = ut1JulianDate;

        double ut1MinusTaiInDays = ut1MinusTaiDelta / Constants.DAYSEC;

        return SafeguardingPrecision(ut1JulianDate,
            fractionOfDay - ut1MinusTaiInDays,
            dayNumber - ut1MinusTaiInDays);
    }

    /// <summary>
    /// SOFA name: iauUt1tt
    /// </summary>
    /// <param name="ut1JulianDate"></param>
    /// <param name="ttMinusUt1Delta"></param>
    /// <returns></returns>
    public static JulianDate UniversalTimeToTerrestrialTime(JulianDate ut1JulianDate, double ttMinusUt1Delta)
        => UniversalTimeToTerrestrialTime(ut1JulianDate, ttMinusUt1Delta, false);

    internal static JulianDate UniversalTimeToTerrestrialTime(JulianDate ut1JulianDate, double ttMinusUt1Delta, bool ignoreKind)
    {
        ThrowIfNotExpectedJulianDateKind(JulianDateKind.Ut1, ut1JulianDate, ignoreKind);
        var (dayNumber, fractionOfDay) = ut1JulianDate;

        double ttMinusUt1DeltaInDays = ttMinusUt1Delta / Constants.DAYSEC;

        return SafeguardingPrecision(ut1JulianDate,
            fractionOfDay + ttMinusUt1DeltaInDays,
            dayNumber + ttMinusUt1DeltaInDays);
    }

    /// <summary>
    /// SOFA name: iauUt1utc
    /// </summary>
    /// <param name="ut1JulianDate"></param>
    /// <param name="ut1MinusUtcDelta"></param>
    /// <returns></returns>
    public static JulianDate UniversalTimeToCoordinatedUniversalTime(JulianDate ut1JulianDate, double ut1MinusUtcDelta)
        => UniversalTimeToCoordinatedUniversalTime(ut1JulianDate, ut1MinusUtcDelta);

    internal static JulianDate UniversalTimeToCoordinatedUniversalTime(JulianDate ut1JulianDate, double ut1MinusUtcDelta, bool ignoreKind)
    {
        ThrowIfNotExpectedJulianDateKind(JulianDateKind.Ut1, ut1JulianDate, ignoreKind);
        double u1, u2, dayNumberTemp, fractionOfDayTemp, dats, deltaAT, deltaDats, us1, us2, du;
        var (dayNumber, fractionOfDay) = ut1JulianDate;

        var bigFirstOrder = Abs(dayNumber) >= Abs(fractionOfDay);
        if (bigFirstOrder)
        {
            u1 = dayNumber;
            u2 = fractionOfDay;
        }
        else
        {
            u1 = fractionOfDay;
            u2 = dayNumber;
        }

        dayNumberTemp = u1;
        dats = 0;
        for (int i = -1; i <= 3; i++)
        {
            fractionOfDayTemp = u2 + i;
            var (year, month, day, fd) = CalendarsModule.JulianDateToGregorianCalendar(new JulianDate(dayNumberTemp + fractionOfDayTemp));
            deltaAT = DeltaAT(year, month, day, 0.0);

            if (i == -1)
            {
                dats = deltaAT;
            }

            deltaDats = deltaAT - dats;

            if (Abs(deltaDats) >= 0.5)
            {
                if (deltaDats * ut1MinusUtcDelta >= 0)
                {
                    ut1MinusUtcDelta -= deltaDats;
                }

                (dayNumberTemp, fractionOfDayTemp) = CalendarsModule.GregorianCalendarToJulianDate(new DateTime(year, month, day));
                us1 = dayNumberTemp;
                us2 = fractionOfDayTemp - 1.0 + ut1MinusUtcDelta / Constants.DAYSEC;

                du = u1 - us1;
                du += u2 - us2;

                if (du > 0)
                {
                    fd = du * Constants.DAYSEC / (Constants.DAYSEC + deltaDats);

                    ut1MinusUtcDelta += deltaDats * (fd <= 1.0 ? fd : 1.0);
                }

                break;
            }

            dats = deltaAT;
        }

        u2 -= ut1MinusUtcDelta / Constants.DAYSEC;

        if (bigFirstOrder)
        {
            return new(u1, u2);
        }
        else
        {
            return new(u2, u1);
        }
    }

    /// <summary>
    /// SOFA name: iauUtcut1
    /// </summary>
    /// <param name="utcJulianDate"></param>
    /// <param name="ut1MinusUtcDelta"></param>
    /// <returns></returns>
    public static JulianDate CoordinatedUniversalTimeToUniversalTime(JulianDate utcJulianDate, double ut1MinusUtcDelta)
        => CoordinatedUniversalTimeToUniversalTime(utcJulianDate, ut1MinusUtcDelta, false);

    internal static JulianDate CoordinatedUniversalTimeToUniversalTime(JulianDate utcJulianDate, double ut1MinusUtcDelta, bool ignoreKind)
    {
        ThrowIfNotExpectedJulianDateKind(JulianDateKind.Utc, utcJulianDate, ignoreKind);
        var (dayNumber, fractionOfDay) = utcJulianDate;

        var (year, month, day, _) = CalendarsModule.JulianDateToGregorianCalendar(new JulianDate(dayNumber, fractionOfDay));

        double deltaAT = DeltaAT(year, month, day, 0.0);
        double ut1TaiDelta = ut1MinusUtcDelta - deltaAT;

        var taiJulianDate = CoordinatedUniversalTimeToInternationalAtomicTime(utcJulianDate, true);

        return InternationalAtomicTimeToUniversalTime(taiJulianDate, ut1TaiDelta, true);
    }

    #endregion

    #region Internals

    readonly struct Drift
    {
        private Drift(double referenceDate, double drift)
        {
            ReferenceDate = referenceDate; DriftRate = drift;
        }

        public readonly double ReferenceDate;
        public readonly double DriftRate;

        public static Lazy<Drift[]> Drifts { get; } = new Lazy<Drift[]>(() =>
        {
            return new Drift[]
            {
                new(37300.0, 0.0012960),
                new(37300.0, 0.0012960),
                new(37300.0, 0.0012960),
                new(37665.0, 0.0011232),
                new(37665.0, 0.0011232),
                new(38761.0, 0.0012960),
                new(38761.0, 0.0012960),
                new(38761.0, 0.0012960),
                new(38761.0, 0.0012960),
                new(38761.0, 0.0012960),
                new(38761.0, 0.0012960),
                new(38761.0, 0.0012960),
                new(39126.0, 0.0025920),
                new(39126.0, 0.0025920)
            };
        });
    }

    readonly struct Change
    {
        private Change(int year, int month, double delta)
        {
            Year = year; Month = month; Delta = delta;
        }

        public readonly int Year;
        public readonly int Month;
        public readonly double Delta;

        public static Lazy<Change[]> Changes { get; } = new Lazy<Change[]>(() =>
        {
            return new Change[]
            {
                new(1960,  1,  1.4178180 ),
                new(1961, 1, 1.4228180   ),
                new(1961, 8, 1.3728180   ),
                new(1962, 1, 1.8458580   ),
                new(1963, 11, 1.9458580  ),
                new(1964, 1, 3.2401300   ),
                new(1964,  4,  3.3401300 ),
                new(1964,  9,  3.4401300 ),
                new(1965,  1,  3.5401300 ),
                new(1965,  3,  3.6401300 ),
                new(1965,  7,  3.7401300 ),
                new(1965,  9,  3.8401300 ),
                new(1966,  1,  4.3131700 ),
                new(1968,  2,  4.2131700 ),
                new(1972,  1, 10.0       ),
                new(1972,  7, 11.0       ),
                new(1973,  1, 12.0       ),
                new(1974,  1, 13.0       ),
                new(1975,  1, 14.0       ),
                new(1976,  1, 15.0       ),
                new(1977,  1, 16.0       ),
                new(1978,  1, 17.0       ),
                new(1979,  1, 18.0       ),
                new(1980,  1, 19.0       ),
                new(1981,  7, 20.0       ),
                new(1982,  7, 21.0       ),
                new(1983,  7, 22.0       ),
                new(1985,  7, 23.0       ),
                new(1988,  1, 24.0       ),
                new(1990,  1, 25.0       ),
                new(1991,  1, 26.0       ),
                new(1992,  7, 27.0       ),
                new(1993,  7, 28.0       ),
                new(1994,  7, 29.0       ),
                new(1996,  1, 30.0       ),
                new(1997,  7, 31.0       ),
                new(1999,  1, 32.0       ),
                new(2006,  1, 33.0       ),
                new(2009,  1, 34.0       ),
                new(2012,  7, 35.0       ),
                new(2015,  7, 36.0       ),
                new(2017,  1, 37.0       )
            };
        });
    }

    internal static double DeltaAT(int year, int month, int day, double fractionOfDay)
    {
        Drift[] drift = Drift.Drifts.Value;
        Change[] changes = Change.Changes.Value;

        double da;

        var mjdForZeroHours = CalendarsModule.GregorianCalendarToJulianDate(new DateTime(year, month, day)).Date - Constants.DJM0;

        int dateOrdered = 12 * year + month;

        int i;
        for (i = changes.Length - 1; i >= 0; i--)
        {
            if (dateOrdered >= (12 * changes[i].Year + changes[i].Month))
            {
                break;
            }
        }

        da = changes[i].Delta;

        if (i < drift.Length)
        {
            da += (mjdForZeroHours + fractionOfDay - drift[i].ReferenceDate) * drift[i].DriftRate;
        }

        return da;
    }

    #endregion

    #region Helpers

    private static JulianDate SafeguardingPrecision(JulianDate julianDate, double newFractionOfDay, double newDayNumber, JulianDateKind kind)
    {
        var (dayNumber, fractionOfDay) = julianDate;
        if (Abs(dayNumber) > Abs(fractionOfDay))
        {
            return new(dayNumber, newFractionOfDay, kind);
        }
        else
        {
            return new(newDayNumber, fractionOfDay, kind);
        }
    }

    #endregion

}