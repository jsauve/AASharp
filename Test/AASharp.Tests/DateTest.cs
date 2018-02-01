using Xunit;

namespace AASharp.Tests
{
    public class DateTest
    {
        [Theory]
        [InlineData(2017, false)]
        [InlineData(2008, true)]
        [InlineData(2000, true)]
        [InlineData(1900, false)]
        public void IsLeapYear(int year, bool isLeap)
        {
            Assert.Equal(isLeap, AASDate.IsLeap(year, year >= 1582));
        }

        [Theory]
        [InlineData(2017, 12, 22, true)]
        [InlineData(-1000, 1, 1, false)]
        [InlineData(1582, 10, 14, false)]
        [InlineData(1582, 10, 15, true)]
        [InlineData(1582, 10, 16, true)]
        [InlineData(1582, 9, 16, false)]
        [InlineData(1582, 11, 14, true)]
        public void IsAfterPapalReform(int year, int month, int day, bool isAfterPapalReform)
        {
            Assert.Equal(isAfterPapalReform, AASDate.AfterPapalReform(year, month, day));
        }

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
