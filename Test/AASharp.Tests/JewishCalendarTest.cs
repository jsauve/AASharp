using Xunit;

namespace AASharp.Tests
{
    public class JewishCalendarTest
    {
        [Theory]
        [InlineData(1990, 5750, 4, 10)]
        public void DateOfPesachTest(long year, double expectedYear, double expectedMonth, double expectedDay)
        {
            AASCalendarDate jewishDate = AASJewishCalendar.DateOfPesach(year);
            Assert.Equal(expectedYear, jewishDate.Year);
            Assert.Equal(expectedMonth, jewishDate.Month);
            Assert.Equal(expectedDay, jewishDate.Day);
        }

        [Theory]
        [InlineData(5750, false)]
        public void IsLeapTest(long year, bool expectedLeapResult)
        {
            bool isLeap = AASJewishCalendar.IsLeap(year);
            Assert.Equal(expectedLeapResult, isLeap);
        }

        [Theory]
        [InlineData(5750, 355)]
        [InlineData(5751, 354)]
        public void DaysInYearTest(long year, long expectedDaysInYear)
        {
            long daysInJewishYear = AASJewishCalendar.DaysInYear(year);
            Assert.Equal(expectedDaysInYear, daysInJewishYear);
        }
    }
}