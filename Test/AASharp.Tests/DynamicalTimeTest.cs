using Xunit;

namespace AASharp.Tests
{
    public class DynamicalTimeTest
    {
        [Theory]
        [InlineData(1977, 2, 18, 3, 37, 40, true, 47.653168257275553)]
        [InlineData(333, 2, 6, 6, 0, 0, false, 7358.75518884003)]
        public void DeltaTTest(long year, long month, double day, double hour, double minute, double second, bool bGregorianCalendar, double expectedDeltaT)
        {
            var date = new AASDate();
            date.Set(year, month, day, hour, minute, second, bGregorianCalendar);
            double deltaT = AASDynamicalTime.DeltaT(date.Julian);

            Assert.Equal(expectedDeltaT, deltaT);
        }
    }
}