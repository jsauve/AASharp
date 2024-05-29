using System;

namespace AASharp
{
    /// <summary>
    /// This class provides the algorithms which convert between the Gregorian and Julian calendars and the Julian Day. This refers to Chapter 7 and parts of Chapter 9 in the book.
    /// </summary>
    public class AASDate
    {
        #region constructors
        
        public AASDate()
        {
        }

        /// <summary>
        /// Constructs a date given a variety of parameters.
        /// </summary>
        /// <param name="year">The year. (Years are counted astronomically i.e. 1 BC = Year 0)</param>
        /// <param name="month">The month of the year (1 for January to 12 for December).</param>
        /// <param name="day">The day of the month (Can include decimals).</param>
        /// <param name="bGregorianCalendar">true to imply a date in the Gregorian Calendar, false means use the Julian Calendar.</param>
        public AASDate(long year, long month, double day, bool bGregorianCalendar)
        {
            Set(year, month, day, 0, 0, 0, bGregorianCalendar);
        }

        /// <summary>
        /// Constructs a date given a variety of parameters.
        /// </summary>
        /// <param name="year">The year. (Years are counted astronomically i.e. 1 BC = Year 0)</param>
        /// <param name="month">The month of the year (1 for January to 12 for December).</param>
        /// <param name="day">The day of the month (Can include decimals).</param>
        /// <param name="hour">The hour (Can include decimals).</param>
        /// <param name="minute">The minute (Can include decimals).</param>
        /// <param name="second">The seconds (Can include decimals).</param>
        /// <param name="isGregorianCalendar">true to imply a date in the Gregorian Calendar, false means use the Julian Calendar.</param>
        public AASDate(long year, long month, double day, double hour, double minute, double second, bool isGregorianCalendar)
        {
            Set(year, month, day, hour, minute, second, isGregorianCalendar);
        }

        /// <summary>
        /// Constructs a date given a variety of parameters.
        /// </summary>
        /// <param name="JD">The Julian day including decimals.</param>
        /// <param name="isGregorianCalendar">true to imply a date in the Gregorian Calendar, false means use the Julian Calendar.</param>
        public AASDate(double JD, bool isGregorianCalendar)
        {
            Set(JD, isGregorianCalendar);
        }

        #endregion

        #region static members
        /// <summary>
        /// Converts a calendar date to Julian day.
        /// </summary>
        /// <param name="year">The year. (Years are counted astronomically i.e. 1 BC = Year 0)</param>
        /// <param name="month">The month of the year (1 for January to 12 for December).</param>
        /// <param name="day">The day of the month (Can include decimals).</param>
        /// <param name="isGregorianCalendar">true to imply a date in the Gregorian Calendar, false means use the Julian Calendar.</param>
        /// <returns>Returns Julian Day including decimals.</returns>
        public static double DateToJD(long year, long month, double day, bool isGregorianCalendar)
        {
            long Y = year;
            long M = month;
            if (M < 3)
            {
                Y = Y - 1;
                M = M + 12;
            }

            long B = 0;
            if (isGregorianCalendar)
            {
                long A = INT(Y / 100.0);
                B = 2 - A + INT(A / 4.0);
            }

            return INT(365.25 * (Y + 4716)) + INT(30.6001 * (M + 1)) + day + B - 1524.5;
        }

        /// <param name="year">The year. (Years are counted astronomically i.e. 1 BC = Year 0)</param>
        /// <param name="isGregorianCalendar">true to imply a date in the Gregorian Calendar, false means use the Julian Calendar.</param>
        /// <returns>true if the specified year is leap otherwise false.</returns>
        public static bool IsLeap(long year, bool isGregorianCalendar)
        {
            if (isGregorianCalendar)
            {
                if (year % 100 == 0)
                {
                    return year % 400 == 0;
                }
                else
                {
                    return year % 4 == 0;
                }
            }
            else
            {
                return year % 4 == 0;
            }
        }

        /// <param name="dayOfYear">The day of the year where 1st of January is 1 going up to 365 or 366 for 31st of December</param>
        /// <param name="isLeap">if the year being considered is a leap year, otherwise false.</param>
        /// <param name="dayOfMonth">Upon return will contain the day of the month.</param>
        /// <param name="Month">Upon return will contain the month.</param>
        public static void DayOfYearToDayAndMonth(long dayOfYear, bool isLeap, ref long dayOfMonth, ref long Month)
        {
            long K = isLeap ? 1 : 2;

            if (dayOfYear < 32)
            {
                Month = 1;
            }
            else
            {
                Month = INT(9 * (K + dayOfYear) / 275.0 + 0.98);
            }

            dayOfMonth = dayOfYear - INT(275 * Month / 9.0) + K * INT((Month + 9) / 12.0) + 30;
        }

        /// <summary>
        /// Converts a calendrical date expressed in the Julian Calendar to the equivalent date in the Gregorian Calendar. It is assumed that the adoption of the Gregorian Calendar occurred in 1582.
        /// </summary>
        /// <param name="year">The year in the Julian Calendar to convert. (Years are counted astronomically i.e. 1 BC = Year 0)</param>
        /// <param name="month">The month of the year in the Julian Calendar (1 for January to 12 for December).</param>
        /// <param name="day">The day of the month in the Julian Calendar.</param>
        /// <returns>
        /// <para>
        /// A class containing
        /// </para>
        /// <para>
        /// Year - The year in the Gregorian Calendar. (Years are counted astronomically i.e. 1 BC = Year 0)
        /// </para>
        /// <para>
        /// Month - The month of the year in the Gregorian Calendar(1 for January to 12 for December).
        /// </para>
        /// <para>
        /// Day - The day of the month in the Gregorian Calendar.
        /// </para>
        /// </returns>
        public static AASCalendarDate JulianToGregorian(long year, long month, long day)
        {
            AASDate date = new AASDate(year, month, day, false);
            date.SetInGregorianCalendar(true);

            long gregYear = 0;
            long gregMonth = 0;
            long gregDay = 0;
            long hour = 0;
            long minute = 0;
            double second = 0;
            date.Get(ref gregYear, ref gregMonth, ref gregDay, ref hour, ref minute, ref second);
            AASCalendarDate gregorianDate = new AASCalendarDate { Year = gregYear, Month = gregMonth, Day = gregDay };

            return gregorianDate;
        }

        /// <summary>
        /// Converts a calendrical date expressed in the Gregorian Calendar to the equivalent date in the Julian Calendar.
        /// </summary>
        /// <param name="year">The year in the Gregorian Calendar to convert. (Years are counted astronomically i.e. 1 BC = Year 0)</param>
        /// <param name="month">The month of the year in the Gregorian Calendar (1 for January to 12 for December).</param>
        /// <param name="day">The day of the month in the Gregorian Calendar.</param>
        /// <returns>A class containing
        /// <para>
        /// Year - The year in the Julian Calendar. (Years are counted astronomically i.e. 1 BC = Year 0)
        /// </para>
        /// <para>
        /// Month - The month of the year in the Julian Calendar(1 for January to 12 for December).
        /// </para>
        /// <para>
        /// Day - The day of the month in the Julian Calendar.
        /// </para>
        /// </returns>
        public static AASCalendarDate GregorianToJulian(long year, long month, long day)
        {
            AASDate date = new AASDate(year, month, day, true);
            date.SetInGregorianCalendar(false);

            long julYear = 0;
            long julMonth = 0;
            long julDay = 0;
            long hour = 0;
            long minute = 0;
            double second = 0;
            date.Get(ref julYear, ref julMonth, ref julDay, ref hour, ref minute, ref second);
            AASCalendarDate julianDate = new AASCalendarDate { Year = julYear, Month = julMonth, Day = julDay };

            return julianDate;
        }

        public static long INT(double value)
        {
            if (value >= 0)
            {
                return (long) value;
            }
            else
            {
                return (long) (value - 1);
            }
        }

        /// <param name="year">The year. (Years are counted astronomically i.e. 1 BC = Year 0)</param>
        /// <param name="month">The month of the year (1 for January to 12 for December).</param>
        /// <param name="day">The day of the month (Can include decimals).</param>
        /// <returns>Returns true if the date occurs on or after the Gregorian calendar reform which occurred on 15th October 1582 (which corresponds to Julian Day 2299160.5), otherwise false. Please note that the CAADate class assumes the calendar change occured on this date. Historically of course different countries adopted the reform at different times.</returns>
        public static bool AfterPapalReform(long year, long month, double day)
        {
            return year > 1582 || year == 1582 && month > 10 || year == 1582 && month == 10 && day >= 15;
        }

        /// <param name="JD">The Julian day including decimals</param>
        /// <returns>Returns true if the date occurs on or after the Gregorian calendar reform which occurred on 15th October 1582 (which corresponds to Julian Day 2299160.5), otherwise false. Please note that the CAADate class assumes the calendar change occured on this date. Historically of course different countries adopted the reform at different times.</returns>
        public static bool AfterPapalReform(double JD)
        {
            return JD >= 2299160.5;
        }

        /// <param name="JD">The Julian day including decimals</param>
        /// <param name="year">The year. (Years are counted astronomically i.e. 1 BC = Year 0)</param>
        /// <param name="isGregorianCalendar">true to imply a date in the Gregorian Calendar, false means use the Julian Calendar.</param>
        /// <returns>Returns the day of year (including decimals) this date represents.</returns>
        public static double DayOfYear(double JD, long year, bool isGregorianCalendar)
        {
            return JD - DateToJD(year, 1, 1, isGregorianCalendar) + 1;
        }

        /// <param name="month">The month (1 - 12) whose number of days we are looking for.</param>
        /// <param name="isLeap">true if February is in a leap year, false otherwise.</param>
        /// <returns>Returns the total number of days in the month (28 - 31) which this date represents. The static version of the function can be used if you do not want to construct a AASDate instance to do this test.</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static long DaysInMonth(long month, bool isLeap)
        {
            if (month < 1 || month > 12)
            {
                throw new ArgumentOutOfRangeException(nameof(month), "Month must be 1 - 12");
            }

            int[] monthLength = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            if (isLeap)
            {
                monthLength[1]++;
            }

            return monthLength[month - 1];
        }

        #endregion

        #region instance members

        private double _mDblJulian;
        private bool _mBGregorianCalendar;

        /// <summary>
        /// Returns the underlying Julian Day including decimals.
        /// </summary>
        public double Julian => _mDblJulian;

        /// <summary>
        /// Returns the day of the month this date represents.
        /// </summary>
        public long Day
        {
            get
            {
                long year = 0;
                long month = 0;
                long day = 0;
                long hour = 0;
                long minute = 0;
                double second = 0;
                Get(ref year, ref month, ref day, ref hour, ref minute, ref second);
                return day;
            }
        }

        /// <summary>
        /// Returns the month (1 - 12) this date represents.
        /// </summary>
        public long Month
        {
            get
            {
                long year = 0;
                long month = 0;
                long day = 0;
                long hour = 0;
                long minute = 0;
                double second = 0;
                Get(ref year, ref month, ref day, ref hour, ref minute, ref second);
                return month;
            }
        }

        /// <summary>
        /// Returns the year this date represents.
        /// </summary>
        public long Year
        {
            get
            {
                long year = 0;
                long month = 0;
                long day = 0;
                long hour = 0;
                long minute = 0;
                double second = 0;
                Get(ref year, ref month, ref day, ref hour, ref minute, ref second);
                return year;
            }
        }

        /// <summary>
        /// Returns the hour this date represents.
        /// </summary>
        public long Hour
        {
            get
            {
                long year = 0;
                long month = 0;
                long day = 0;
                long hour = 0;
                long minute = 0;
                double second = 0;
                Get(ref year, ref month, ref day, ref hour, ref minute, ref second);
                return hour;
            }
        }

        /// <summary>
        /// Returns the minute this date represents.
        /// </summary>
        public long Minute
        {
            get
            {
                long year = 0;
                long month = 0;
                long day = 0;
                long hour = 0;
                long minute = 0;
                double second = 0;
                Get(ref year, ref month, ref day, ref hour, ref minute, ref second);
                return minute;
            }
        }

        /// <summary>
        /// Returns the seconds this date represents.
        /// </summary>
        public double Second
        {
            get
            {
                long year = 0;
                long month = 0;
                long day = 0;
                long hour = 0;
                long minute = 0;
                double second = 0;
                Get(ref year, ref month, ref day, ref hour, ref minute, ref second);
                return second;
            }
        }

        /// <summary>
        /// Returns an enum which identifies which day of the week this date represents.
        /// </summary>
        public DAY_OF_WEEK DayOfWeek => (DAY_OF_WEEK)((long)(_mDblJulian + 1.5) % 7);

        /// <returns>Returns the day of year (including decimals) this date represents.</returns>
        public double DayOfYear()
        {
            long year = 0;
            long month = 0;
            long day = 0;
            long hour = 0;
            long minute = 0;
            double second = 0;
            Get(ref year, ref month, ref day, ref hour, ref minute, ref second);

            return DayOfYear(_mDblJulian, year, AfterPapalReform(year, 1, 1));
        }

        /// <returns>Returns the total number of days in the month (28 - 31) which this date represents. The static version of the function can be used if you do not want to construct a AASDate instance to do this test.</returns>
        public long DaysInMonth()
        {
            long year = 0;
            long month = 0;
            long day = 0;
            long hour = 0;
            long minute = 0;
            double second = 0;
            Get(ref year, ref month, ref day, ref hour, ref minute, ref second);

            return DaysInMonth(month, IsLeap(year, _mBGregorianCalendar));
        }

        /// <returns>Returns the total number of days in the year (365 or 366) which this date represents.</returns>
        public long DaysInYear()
        {
            long year = 0;
            long month = 0;
            long day = 0;
            long hour = 0;
            long minute = 0;
            double second = 0;
            Get(ref year, ref month, ref day, ref hour, ref minute, ref second);

            return IsLeap(year, _mBGregorianCalendar) ? 366 : 365;
        }

        /// <summary>
        /// true if the year which this date represents is leap otherwise false.
        /// </summary>
        public bool Leap => IsLeap(Year, _mBGregorianCalendar);

        /// <summary>
        /// Returns true if this date is in the Gregorian calendar, false means the Julian Calendar.
        /// </summary>
        public bool InGregorianCalendar => _mBGregorianCalendar;

        /// <summary>
        /// Returns the years with decimals this date represents e.g. the middle of the year 2000 would be returned as 2000.5.
        /// </summary>
        public double FractionalYear
        {
            get
            {
                long year = 0;
                long month = 0;
                long day = 0;
                long hour = 0;
                long minute = 0;
                double second = 0;
                Get(ref year, ref month, ref day, ref hour, ref minute, ref second);

                long daysInYear = IsLeap(year, _mBGregorianCalendar) ? 366 : 365;

                return year + (_mDblJulian - DateToJD(year, 1, 1, AfterPapalReform(year, 1, 1))) / daysInYear;
            }
        }

        /// <summary>
        /// Allows the date to be modified after construction.
        /// </summary>
        /// <param name="year">The year. (Years are counted astronomically i.e. 1 BC = Year 0)</param>
        /// <param name="month">The month of the year (1 for January to 12 for December).</param>
        /// <param name="day">The day of the month (Can include decimals).</param>
        /// <param name="hour">The hour (Can include decimals).</param>
        /// <param name="minute">The minute (Can include decimals).</param>
        /// <param name="second">The seconds (Can include decimals).</param>
        /// <param name="isGregorianCalendar">true to imply a date in the Gregorian Calendar, false means use the Julian Calendar.</param>
        public void Set(long year, long month, double day, double hour, double minute, double second, bool isGregorianCalendar)
        {
            double dblDay = day + hour / 24 + minute / 1440 + second / 86400;
            Set(DateToJD(year, month, dblDay, isGregorianCalendar), isGregorianCalendar);
        }

        /// <summary>
        /// Allows the date to be modified after construction.
        /// </summary>
        /// <param name="JD">The Julian day including decimals</param>
        /// <param name="isGregorianCalendar">true to imply a date in the Gregorian Calendar, false means use the Julian Calendar.</param>
        public void Set(double JD, bool isGregorianCalendar)
        {
            _mDblJulian = JD;
            SetInGregorianCalendar(isGregorianCalendar);
        }

        /// <summary>
        /// Allows the date's calendar type to be changed after construction.
        /// </summary>
        /// <param name="isGregorianCalendar">true to imply a date in the Gregorian Calendar, false means use the Julian Calendar.</param>
        public void SetInGregorianCalendar(bool isGregorianCalendar)
        {
            bool bAfterPapalReform = AfterPapalReform(_mDblJulian);

#if DEBUG
            if (isGregorianCalendar) //We do not allow storage of propalatic Gregorian dates
                System.Diagnostics.Debug.Assert(bAfterPapalReform);
#endif

            _mBGregorianCalendar = isGregorianCalendar && bAfterPapalReform;
        }

        /// <summary>
        /// Allows the date parts to be retrieved.
        /// </summary>
        /// <param name="Year">Upon return will contain the year. (Years are counted astronomically i.e. 1 BC = Year 0)</param>
        /// <param name="Month">Upon return will contain the month of the year (1 for January to 12 for December).</param>
        /// <param name="Day">Upon return will contain the day of the month.</param>
        /// <param name="Hour">Upon return will contain the hour.</param>
        /// <param name="Minute">Upon return will contain the minute.</param>
        /// <param name="Second">Upon return will contain the seconds (Can include decimals).</param>
        public void Get(ref long Year, ref long Month, ref long Day, ref long Hour, ref long Minute, ref double Second)
        {
            double JD = _mDblJulian + 0.5;
            double tempZ = 0;
            double F = AASMath.modF(JD, ref tempZ);
            long Z = (long)tempZ;
            long A;

            //There is a difference here between the Meeus implementation and this one 
            //if Z >= 2299161 The Meeus implementation automatically assumes the Gregorian Calendar 
            //came into effect on 15 October 1582 (JD: 2299161), while the CAADate
            //implementation has a "m_bGregorianCalendar" value to decide if the date
            //was specified in the Gregorian or Julian Calendars. This difference
            //means in effect that CAADate fully supports a propalactive version of the
            //Julian calendar. This allows you to construct Julian dates after the Papal
            //reform in 1582. This is useful if you want to construct dates in countries
            //which did not immediately adapt the Gregorian calendar
            if (_mBGregorianCalendar)
            {
                long alpha = INT((Z - 1867216.25) / 36524.25);
                A = Z + 1 + alpha - INT(INT(alpha) / 4.0);
            }
            else
                A = Z;

            long B = A + 1524;
            long C = INT((B - 122.1) / 365.25);
            long D = INT(365.25 * C);
            long E = INT((B - D) / 30.6001);

            double dblDay = B - D - INT(30.6001 * E) + F;
            Day = (long)dblDay;

            if (E < 14)
                Month = E - 1;
            else
                Month = E - 13;

            if (Month > 2)
                Year = C - 4716;
            else
                Year = C - 4715;

            F = AASMath.modF(dblDay, ref tempZ);
            Hour = INT(F * 24);
            Minute = INT((F - Hour / 24.0) * 1440.0);
            Second = (F - Hour / 24.0 - Minute / 1440.0) * 86400.0;
        }

        #endregion
    }
}
