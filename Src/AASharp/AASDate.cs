using System;
using System.Collections.Generic;
using System.Linq;

namespace AASharp
{
    public class AASDate
    {
        public AASDate()
        {
        }

        public AASDate(long Year, long Month, double Day, bool bGregorianCalendar)
        {
            Set(Year, Month, Day, 0, 0, 0, bGregorianCalendar);
        }

        public AASDate(long Year, long Month, double Day, double Hour, double Minute, double Second, bool bGregorianCalendar)
        {
            Set(Year, Month, Day, Hour, Minute, Second, bGregorianCalendar);
        }

        public AASDate(double JD, bool bGregorianCalendar)
        {
            Set(JD, bGregorianCalendar);
        }

        #region static members

        public static double DateToJD(long Year, long Month, double Day, bool bGregorianCalendar)
        {
            long Y = Year;
            long M = Month;
            if (M < 3)
            {
                Y = Y - 1;
                M = M + 12;
            }

            long B = 0;
            if (bGregorianCalendar)
            {
                long A = INT(Y / 100.0);
                B = 2 - A + INT(A / 4.0);
            }

            return INT(365.25 * (Y + 4716)) + INT(30.6001 * (M + 1)) + Day + B - 1524.5;
        }

        public static bool IsLeap(long Year, bool bGregorianCalendar)
        {
            if (bGregorianCalendar)
            {
                if ((Year % 100) == 0)
                    return ((Year % 400) == 0) ? true : false;
                else
                    return ((Year % 4) == 0) ? true : false;
            }
            else
                return ((Year % 4) == 0) ? true : false;
        }

        public void DayOfYearToDayAndMonth(long DayOfYear, bool bLeap, ref long DayOfMonth, ref long Month)
        {
            long K = bLeap ? 1 : 2;

            if (DayOfYear < 32)
                Month = 1;
            else
                Month = INT(9 * (K + DayOfYear) / 275.0 + 0.98);

            DayOfMonth = DayOfYear - INT((275 * Month) / 9.0) + (K * INT((Month + 9) / 12.0)) + 30;
        }

        public static AASCalendarDate JulianToGregorian(long Year, long Month, long Day)
        {
            AASDate date = new AASDate(Year, Month, Day, false);
            date.SetInGregorianCalendar(true);

            long gregYear = 0;
            long gregMonth = 0;
            long gregDay = 0;
            long Hour = 0;
            long Minute = 0;
            double Second = 0;
            date.Get(ref gregYear, ref gregMonth, ref gregDay, ref Hour, ref Minute, ref Second);
            AASCalendarDate GregorianDate = new AASCalendarDate() { Year = gregYear, Month = gregMonth, Day = gregDay };

            return GregorianDate;
        }

        public static AASCalendarDate GregorianToJulian(long Year, long Month, long Day)
        {
            AASDate date = new AASDate(Year, Month, Day, true);
            date.SetInGregorianCalendar(false);

            long julYear = 0;
            long julMonth = 0;
            long julDay = 0;
            long Hour = 0;
            long Minute = 0;
            double Second = 0;
            date.Get(ref julYear, ref julMonth, ref julDay, ref Hour, ref Minute, ref Second);
            AASCalendarDate JulianDate = new AASCalendarDate() { Year = julYear, Month = julMonth, Day = julDay };

            return JulianDate;
        }

        public static long INT(double value)
        {
            if (value >= 0)
                return (long)(value);
            else
                return (long)(value - 1);
        }

        public static bool AfterPapalReform(long Year, long Month, double Day)
        {
            return ((Year > 1582) || ((Year == 1582) && (Month > 10)) || ((Year == 1582) && (Month == 10) && (Day >= 15)));
        }

        public static bool AfterPapalReform(double JD)
        {
            return (JD >= 2299160.5);
        }

        public static double DayOfYear(double JD, long Year, bool bGregorianCalendar)
        {
            return JD - DateToJD(Year, 1, 1, bGregorianCalendar) + 1;
        }

        public static long DaysInMonth(long Month, bool bLeap)
        {
            if (Month < 1 && Month > 12)
                throw new ArgumentOutOfRangeException("Month", "Month must be 1 - 12");
            int[] MonthLength = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            if (bLeap)
                MonthLength[1]++;

            return MonthLength[Month - 1];
        }

        #endregion

        #region instance members

        private double m_dblJulian;
        private bool m_bGregorianCalendar;

        public double Julian
        {
            get
            {
                return m_dblJulian;
            }
        }

        public long Day
        {
            get
            {
                long Year = 0;
                long Month = 0;
                long Day = 0;
                long Hour = 0;
                long Minute = 0;
                double Second = 0;
                Get(ref Year, ref Month, ref Day, ref Hour, ref Minute, ref Second);
                return Day;
            }
        }

        public long Month
        {
            get
            {
                long Year = 0;
                long Month = 0;
                long Day = 0;
                long Hour = 0;
                long Minute = 0;
                double Second = 0;
                Get(ref Year, ref Month, ref Day, ref Hour, ref Minute, ref Second);
                return Month;
            }
        }

        public long Year
        {
            get
            {
                long Year = 0;
                long Month = 0;
                long Day = 0;
                long Hour = 0;
                long Minute = 0;
                double Second = 0;
                Get(ref Year, ref Month, ref Day, ref Hour, ref Minute, ref Second);
                return Year;
            }
        }

        public long Hour
        {
            get
            {
                long Year = 0;
                long Month = 0;
                long Day = 0;
                long Hour = 0;
                long Minute = 0;
                double Second = 0;
                Get(ref Year, ref Month, ref Day, ref Hour, ref Minute, ref Second);
                return Hour;
            }
        }

        public long Minute
        {
            get
            {
                long Year = 0;
                long Month = 0;
                long Day = 0;
                long Hour = 0;
                long Minute = 0;
                double Second = 0;
                Get(ref Year, ref Month, ref Day, ref Hour, ref Minute, ref Second);
                return Minute;
            }
        }

        public double Second
        {
            get
            {
                long Year = 0;
                long Month = 0;
                long Day = 0;
                long Hour = 0;
                long Minute = 0;
                double Second = 0;
                Get(ref Year, ref Month, ref Day, ref Hour, ref Minute, ref Second);
                return Second;
            }
        }

        public DAY_OF_WEEK DayOfWeek
        {
            get
            {
                return (DAY_OF_WEEK)(((long)(m_dblJulian + 1.5) % 7));
            }

        }

        public double DayOfYear()
        {
            long Year = 0;
            long Month = 0;
            long Day = 0;
            long Hour = 0;
            long Minute = 0;
            double Second = 0;
            Get(ref Year, ref Month, ref Day, ref Hour, ref Minute, ref Second);

            return DayOfYear(m_dblJulian, Year, AfterPapalReform(Year, 1, 1));
        }

        public long DaysInMonth()
        {
            long Year = 0;
            long Month = 0;
            long Day = 0;
            long Hour = 0;
            long Minute = 0;
            double Second = 0;
            Get(ref Year, ref Month, ref Day, ref Hour, ref Minute, ref Second);

            return DaysInMonth(Month, IsLeap(Year, m_bGregorianCalendar));
        }



        public long DaysInYear()
        {
            long Year = 0;
            long Month = 0;
            long Day = 0;
            long Hour = 0;
            long Minute = 0;
            double Second = 0;
            Get(ref Year, ref Month, ref Day, ref Hour, ref Minute, ref Second);

            if (IsLeap(Year, m_bGregorianCalendar))
                return 366;
            else
                return 365;

        }

        public bool Leap
        {
            get
            {
                return IsLeap(Year, m_bGregorianCalendar);
            }
        }

        public bool InGregorianCalendar
        {
            get
            {
                return m_bGregorianCalendar;
            }
        }

        public double FractionalYear
        {
            get
            {
                long Year = 0;
                long Month = 0;
                long Day = 0;
                long Hour = 0;
                long Minute = 0;
                double Second = 0;
                Get(ref Year, ref Month, ref Day, ref Hour, ref Minute, ref Second);

                long DaysInYear;
                if (IsLeap(Year, m_bGregorianCalendar))
                    DaysInYear = 366;
                else
                    DaysInYear = 365;

                return Year + ((m_dblJulian - DateToJD(Year, 1, 1, AfterPapalReform(Year, 1, 1))) / DaysInYear);
            }
        }

        public void Set(long Year, long Month, double Day, double Hour, double Minute, double Second, bool bGregorianCalendar)
        {
            double dblDay = Day + (Hour / 24) + (Minute / 1440) + (Second / 86400);
            Set(DateToJD(Year, Month, dblDay, bGregorianCalendar), bGregorianCalendar);
        }

        public void Set(double JD, bool bGregorianCalendar)
        {
            m_dblJulian = JD;
            SetInGregorianCalendar(bGregorianCalendar);
        }

        public void SetInGregorianCalendar(bool bGregorianCalendar)
        {
            bool bAfterPapalReform = (m_dblJulian >= 2299160.5);

#if DEBUG
            if (bGregorianCalendar) //We do not allow storage of propalatic Gregorian dates
                System.Diagnostics.Debug.Assert(bAfterPapalReform);
#endif

            m_bGregorianCalendar = bGregorianCalendar && bAfterPapalReform;
        }

        public void Get(ref long Year, ref long Month, ref long Day, ref long Hour, ref long Minute, ref double Second)
        {
            double JD = m_dblJulian + 0.5;
            double tempZ = 0;
            double F = AASMath.modF(JD, ref tempZ);
            long Z = (long)(tempZ);
            long A;

            if (m_bGregorianCalendar) //There is a difference here between the Meeus implementation and this one
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
            Day = (long)(dblDay);

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
            Minute = INT((F - (Hour) / 24.0) * 1440.0);
            Second = (F - (Hour / 24.0) - (Minute / 1440.0)) * 86400.0;
        }

        #endregion
    }
}
