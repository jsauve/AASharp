using System;

namespace AASharp
{
    public class AASDate
    {
        #region constructors
        
        public AASDate()
        {
        }

        public AASDate(long year, long month, double day, bool bGregorianCalendar)
        {
            Set(year, month, day, 0, 0, 0, bGregorianCalendar);
        }

        public AASDate(long year, long month, double day, double hour, double minute, double second, bool isGregorianCalendar)
        {
            Set(year, month, day, hour, minute, second, isGregorianCalendar);
        }

        public AASDate(double JD, bool isGregorianCalendar)
        {
            Set(JD, isGregorianCalendar);
        }
        
        #endregion

        #region static members

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

        public static bool AfterPapalReform(long year, long month, double day)
        {
            return year > 1582 || year == 1582 && month > 10 || year == 1582 && month == 10 && day >= 15;
        }

        public static bool AfterPapalReform(double JD)
        {
            return JD >= 2299160.5;
        }

        public static double DayOfYear(double JD, long year, bool isGregorianCalendar)
        {
            return JD - DateToJD(year, 1, 1, isGregorianCalendar) + 1;
        }

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

        public double Julian => _mDblJulian;

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

        public DAY_OF_WEEK DayOfWeek => (DAY_OF_WEEK)((long)(_mDblJulian + 1.5) % 7);

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

        public bool Leap => IsLeap(Year, _mBGregorianCalendar);

        public bool InGregorianCalendar => _mBGregorianCalendar;

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

        public void Set(long year, long month, double day, double hour, double minute, double second, bool isGregorianCalendar)
        {
            double dblDay = day + hour / 24 + minute / 1440 + second / 86400;
            Set(DateToJD(year, month, dblDay, isGregorianCalendar), isGregorianCalendar);
        }

        public void Set(double JD, bool isGregorianCalendar)
        {
            _mDblJulian = JD;
            SetInGregorianCalendar(isGregorianCalendar);
        }

        public void SetInGregorianCalendar(bool isGregorianCalendar)
        {
            bool bAfterPapalReform = AfterPapalReform(_mDblJulian);

#if DEBUG
            if (isGregorianCalendar) //We do not allow storage of propalatic Gregorian dates
                System.Diagnostics.Debug.Assert(bAfterPapalReform);
#endif

            _mBGregorianCalendar = isGregorianCalendar && bAfterPapalReform;
        }

        public void Get(ref long Year, ref long Month, ref long Day, ref long Hour, ref long Minute, ref double Second)
        {
            double JD = _mDblJulian + 0.5;
            double tempZ = 0;
            double F = AASMath.modF(JD, ref tempZ);
            long Z = (long)tempZ;
            long A;

            if (_mBGregorianCalendar) //There is a difference here between the Meeus implementation and this one
            //if (Z >= 2299161)       //The Meeus implementation automatically assumes the Gregorian Calendar 
            //came into effect on 15 October 1582 (JD: 2299161), while the CAADate
            //implementation has a "m_bGregorianCalendar" value to decide if the date
            //was specified in the Gregorian or Julian Calendars. This difference
            //means in effect that CAADate fully supports a propalactive version of the
            //Julian calendar. This allows you to construct Julian dates after the Papal
            //reform in 1582. This is useful if you want to construct dates in countries
            //which did not immediately adapt the Gregorian calendar
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
