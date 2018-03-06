using Xunit;

namespace AASharp.Tests
{
    public class MoslemCalendarTest
    {
        [Theory]
        [InlineData(1421, false)]
        public void IsLeapTest(long year, bool expectedLeapResult)
        {
            bool isLeap = AASMoslemCalendar.IsLeap(year);
            Assert.Equal(expectedLeapResult, isLeap);
        }

        [Theory]
        [InlineData(1421, 1, 1, 2000, 3, 24)]
        [InlineData(1427, 12, 23, 2006, 12, 31)]
        [InlineData(1428, 0, 24, 2007, 1, 1)]
        public void MoslemToJulianTest(long year, long month, long day, long expectedYear, long expectedMonth, long expectedDay)
        {
            AASCalendarDate julianDate = AASMoslemCalendar.MoslemToJulian(year, month, day);
            Assert.Equal(expectedYear, julianDate.Year);
            Assert.Equal(expectedMonth, julianDate.Month);
            Assert.Equal(expectedDay, julianDate.Day);
        }

        [Theory]
        [InlineData(2000, 3, 24, 1421, 1, 1)]
        [InlineData(2006, 12, 31, 1427, 12, 23)]
        [InlineData(2007, 1, 1, 1428, 0, 24)]
        public void JulianToMoslemTest(long year, long month, long day, long expectedYear, long expectedMonth, long expectedDay)
        {
            AASCalendarDate moslemDate = AASMoslemCalendar.JulianToMoslem(year, month, day);
            Assert.Equal(expectedYear, moslemDate.Year);
            Assert.Equal(expectedMonth, moslemDate.Month);
            Assert.Equal(expectedDay, moslemDate.Day);
        }
    }
}