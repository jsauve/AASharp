using System;
using Xunit;

namespace AASharp.Tests
{
    public class DateTest
    {
        [Theory]
        [InlineData(2018, 1, 1)]
        [InlineData(1582, 10, 14)]
        [InlineData(1582, 10, 15)]
        [InlineData(1582, 10, 16)]
        [InlineData(1, 1, 1)]
        [InlineData(-1, 1, 1)]
        public void DateInitialisation(int year, int month, int day)
        {
            bool bGregorian = AASDate.AfterPapalReform(year, month, day);
            var date = new AASDate(year, month, day, 12, 0, 0, bGregorian);

            Assert.Equal(year, date.Year);
            Assert.Equal(month, date.Month);
            Assert.Equal(day, date.Day);
        }

        [Theory]
        [InlineData(2018, 3, 22, true, 2458199.5)]
        [InlineData(500, 3, 22, false, 1903763.5)]
        public void DateToJDTest(long year, long month, double day, bool isGregorianCalendar, double expectedJD)
        {
            double JD = AASDate.DateToJD(year, month, day, isGregorianCalendar);
            Assert.Equal(expectedJD, JD);
        }

        [Theory]
        [InlineData(2017, false)]
        [InlineData(2008, true)]
        [InlineData(2000, true)]
        [InlineData(1900, false)]
        public void IsLeapTest(int year, bool isLeap)
        {
            //Test of the instance property
            var date = new AASDate(year, 1, 1, year >= 1582);
            Assert.Equal(isLeap, date.Leap);

            //Test of the static method
            Assert.Equal(isLeap, AASDate.IsLeap(year, year >= 1582));
        }

        [Theory]
        [InlineData(1, false, 1, 1)]
        [InlineData(31, false, 31, 1)]
        [InlineData(32, false, 1, 2)]
        [InlineData(59, false, 28, 2)]
        [InlineData(60, false, 1, 3)]
        [InlineData(90, false, 31, 3)]
        [InlineData(91, false, 1, 4)]
        [InlineData(120, false, 30, 4)]
        [InlineData(121, false, 1, 5)]
        [InlineData(151, false, 31, 5)]
        [InlineData(152, false, 1, 6)]
        [InlineData(181, false, 30, 6)]
        [InlineData(182, false, 1, 7)]
        [InlineData(212, false, 31, 7)]
        [InlineData(213, false, 1, 8)]
        [InlineData(243, false, 31, 8)]
        [InlineData(244, false, 1, 9)]
        [InlineData(273, false, 30, 9)]
        [InlineData(274, false, 1, 10)]
        [InlineData(304, false, 31, 10)]
        [InlineData(305, false, 1, 11)]
        [InlineData(334, false, 30, 11)]
        [InlineData(335, false, 1, 12)]
        [InlineData(365, false, 31, 12)]
        [InlineData(1, true, 1, 1)]
        [InlineData(31, true, 31, 1)]
        [InlineData(32, true, 1, 2)]
        [InlineData(60, true, 29, 2)]
        [InlineData(61, true, 1, 3)]
        [InlineData(91, true, 31, 3)]
        [InlineData(92, true, 1, 4)]
        [InlineData(121, true, 30, 4)]
        [InlineData(122, true, 1, 5)]
        [InlineData(152, true, 31, 5)]
        [InlineData(153, true, 1, 6)]
        [InlineData(182, true, 30, 6)]
        [InlineData(183, true, 1, 7)]
        [InlineData(213, true, 31, 7)]
        [InlineData(214, true, 1, 8)]
        [InlineData(244, true, 31, 8)]
        [InlineData(245, true, 1, 9)]
        [InlineData(274, true, 30, 9)]
        [InlineData(275, true, 1, 10)]
        [InlineData(305, true, 31, 10)]
        [InlineData(306, true, 1, 11)]
        [InlineData(335, true, 30, 11)]
        [InlineData(336, true, 1, 12)]
        [InlineData(366, true, 31, 12)]
        public void DayOfYearToDayAndMonthTest(long dayOfYear, bool isLeap, long expectedDayOfMonth, long expectedMonth)
        {
            long dayOfMonth = 0;
            long month = 0;

            AASDate.DayOfYearToDayAndMonth(dayOfYear, isLeap, ref dayOfMonth, ref month);

            Assert.Equal(expectedDayOfMonth, dayOfMonth);
            Assert.Equal(expectedMonth, month);
        }

        [Theory]
        [InlineData(2018, 3, 9, 2018, 3, 22)]
        public void JulianToGregorianTest(long year, long month, long day, long expectedYear, long expectedMonth, long expectedDay)
        {
            AASCalendarDate gregorianDate = AASDate.JulianToGregorian(year, month, day);
            Assert.Equal(expectedYear, gregorianDate.Year);
            Assert.Equal(expectedMonth, gregorianDate.Month);
            Assert.Equal(expectedDay, gregorianDate.Day);
        }

        [Theory]
        [InlineData(2018, 3, 22, 2018, 3, 9)]
        public void GregorianToJulianTest(long year, long month, long day, long expectedYear, long expectedMonth, long expectedDay)
        {
            AASCalendarDate gregorianDate = AASDate.GregorianToJulian(year, month, day);
            Assert.Equal(expectedYear, gregorianDate.Year);
            Assert.Equal(expectedMonth, gregorianDate.Month);
            Assert.Equal(expectedDay, gregorianDate.Day);
        }

        [Theory]
        [InlineData(2017, 12, 22, true)]
        [InlineData(-1000, 1, 1, false)]
        [InlineData(1582, 10, 14, false)]
        [InlineData(1582, 10, 15, true)]
        [InlineData(1582, 10, 16, true)]
        [InlineData(1582, 9, 16, false)]
        [InlineData(1582, 11, 14, true)]
        public void AfterPapalReformTest(int year, int month, int day, bool isAfterPapalReform)
        {
            Assert.Equal(isAfterPapalReform, AASDate.AfterPapalReform(year, month, day));
        }

        [Theory]
        [InlineData(2299160.0, false)]
        [InlineData(2299160.5, true)]
        [InlineData(2299161.0, true)]
        public void JulianDayAfterPapalReformTest(double jd, bool isAfterPapalReform)
        {
            Assert.Equal(isAfterPapalReform, AASDate.AfterPapalReform(jd));
        }

        [Theory]
        [InlineData(2018, 1, 1, 1)]
        [InlineData(2018, 2, 1, 32)]
        [InlineData(2018, 3, 1, 60)]
        [InlineData(2018, 12, 31, 365)]
        [InlineData(2016, 1, 1, 1)]
        [InlineData(2016, 2, 1, 32)]
        [InlineData(2016, 3, 1, 61)]
        [InlineData(2016, 12, 31, 366)]
        public void DayOfYearTest(int year, int month, int day, double expectedDayOfYear)
        {
            var date = new AASDate(year, month, day, true);
            Assert.Equal(expectedDayOfYear, date.DayOfYear());
        }

        [Theory]
        [InlineData(1, false, 31)]
        [InlineData(2, false, 28)]
        [InlineData(2, true, 29)]
        [InlineData(3, false, 31)]
        [InlineData(4, false, 30)]
        [InlineData(5, false, 31)]
        [InlineData(6, false, 30)]
        [InlineData(7, false, 31)]
        [InlineData(8, false, 31)]
        [InlineData(9, false, 30)]
        [InlineData(10, false, 31)]
        [InlineData(11, false, 30)]
        [InlineData(12, false, 31)]
        public void DaysInMonthTest(int month, bool isLeap, int expectedNumberOfDay)
        {
            //Test of the instance method
            var date = new AASDate(isLeap ? 2016 : 2017, month, 1, true);
            Assert.Equal(expectedNumberOfDay, date.DaysInMonth());

            //Test of the static method
            Assert.Equal(expectedNumberOfDay, AASDate.DaysInMonth(month, isLeap));
        }
        
        [Theory]
        [InlineData(0)]
        [InlineData(13)]
        public void DaysInMonthTest_InvalidParmThrowsException(int month)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => AASDate.DaysInMonth(month, false));
        }
        
        
        

        [Theory]
        [InlineData(2018, 365)]
        [InlineData(2016, 366)]
        public void DaysInYearTest(int year, int expectedNumberOfDay)
        {
            var date = new AASDate(year, 1, 1, true);
            Assert.Equal(expectedNumberOfDay, date.DaysInYear());
        }

        [Theory]
        [InlineData(2018, 3, 25, true, 2458202.5)]
        public void JulianTest(int year, int month, int day, bool isGregorianCalendar, double expectedJulianDay)
        {
            var date = new AASDate(year, month, day, isGregorianCalendar);
            Assert.Equal(expectedJulianDay, date.Julian);
        }

        [Theory]
        [InlineData(2018, 3, 25, 12, 15, 29.999984800815632)]//TODO : Second should return 30. But AA+ also return 29.9999... To check with AA+ author
        public void YearMonthDayHourMinuteSecondTest(int year, int month, int day, double hour, double minute, double second)
        {
            var date = new AASDate(year, month, day, hour, minute, second, true);
            Assert.Equal(year, date.Year);
            Assert.Equal(month, date.Month);
            Assert.Equal(day, date.Day);
            Assert.Equal(hour, date.Hour);
            Assert.Equal(minute, date.Minute);
            Assert.Equal(second, date.Second);
        }


        [Theory]
        [InlineData(2018, 3, 19, true, DAY_OF_WEEK.MONDAY)]
        [InlineData(2018, 3, 20, true, DAY_OF_WEEK.TUESDAY)]
        [InlineData(2018, 3, 21, true, DAY_OF_WEEK.WEDNESDAY)]
        [InlineData(2018, 3, 22, true, DAY_OF_WEEK.THURSDAY)]
        [InlineData(2018, 3, 23, true, DAY_OF_WEEK.FRIDAY)]
        [InlineData(2018, 3, 24, true, DAY_OF_WEEK.SATURDAY)]
        [InlineData(2018, 3, 25, true, DAY_OF_WEEK.SUNDAY)]
        public void DayOfWeekTest(long year, long month, double day, bool isGregorianCalendar, DAY_OF_WEEK expectedDayOfWeek)
        {
            var date = new AASDate(year, month, day, isGregorianCalendar);
            Assert.Equal(expectedDayOfWeek, date.DayOfWeek);
        }

        

        

        [Theory]
        [InlineData(2018, 1, 1, 2458120)]
        [InlineData(1582, 10, 14, 2299170)]//bug, this date does not exist in gregorian calendar
        [InlineData(1582, 10, 5, 2299161)]//bug, this date does not exist in gregorian calendar
        [InlineData(1582, 10, 15, 2299161)]
        [InlineData(1582, 10, 16, 2299162)]
        [InlineData(1, 1, 1, 1721424)]
        [InlineData(-1, 1, 1, 1720693)]
        public void JulianDate(int year, int month, int day, int expectedJulianDay)
        {
            bool bGregorian = AASDate.AfterPapalReform(year, month, day);
            var date = new AASDate(year, month, day, 12, 0, 0, bGregorian);
        
            Assert.Equal(expectedJulianDay, date.Julian);
        }
    }
}
