using Xunit;

namespace AASharp.Tests
{
    public class DynamicalTimeTest
    {
        [Theory]
        [InlineData(1977, 2, 18, 3, 37, 40, true, 47.653413239352304)]
        [InlineData(333, 2, 6, 6, 0, 0, false, 7358.75518884003)]
        [InlineData(-501, 1, 1, 0, 0, 0, false, 17218.531200000001)]
        [InlineData(499, 1, 1, 0, 0, 0, false, 5719.8774385089582)]
        [InlineData(1599, 1, 1, 0, 0, 0, true, 120.69731555728993)]
        [InlineData(1699, 1, 1, 0, 0, 0, true, 20)]
        [InlineData(1799, 1, 1, 0, 0, 0, true, 12.6)]
        [InlineData(1859, 1, 1, 0, 0, 0, true, 7.19)]
        [InlineData(1899, 1, 1, 0, 0, 0, true, -3.72)]
        [InlineData(1919, 1, 1, 0, 0, 0, true, 20.86)]
        [InlineData(1940, 1, 1, 0, 0, 0, true, 24.35)]
        [InlineData(1960, 1, 1, 0, 0, 0, true, 33.15)]
        [InlineData(1973, 1, 31, 0, 0, 0, true, 43.469583)]
        [InlineData(1973, 2, 1, 0, 0, 0, true, 43.472437)]
        [InlineData(1985, 12, 31, 23, 59, 59, true, 54.87125098603017)]
        [InlineData(1986, 1, 1, 0, 0, 0, true, 54.871251)]
        [InlineData(2018, 1, 1, 0, 0, 0, true, 68.967642)]
        [InlineData(2025, 12, 31, 23, 59, 59, true, 72.829999982387378)]
        [InlineData(2026, 1, 1, 0, 0, 0, true, 72.829999999999998)]
        [InlineData(2149, 1, 1, 0, 0, 0, true, 325.81240000000003)]
        [InlineData(2150, 1, 1, 0, 0, 0, true, 328.47999999999996)]
        public void DeltaTTest2(long year, long month, double day, double hour, double minute, double second, bool isGregorianCalendar, double expectedDeltaT)
        {
            var date = new AASDate(year, month, day, hour, minute, second, isGregorianCalendar);
            double deltaT = AASDynamicalTime.DeltaT(date.Julian);

            Assert.Equal(expectedDeltaT, deltaT);
        }

        [Theory]
        [InlineData(2437300.0, 0)]
        [InlineData(2437300.5, 1.4228179999999999)]
        [InlineData(2437301.0, 1.4234659999999999)]
        [InlineData(2457754.5, 37.0)]
        [InlineData(2457755.0, 37.0)]
        public void CumulativeLeapSecondsTest(double jd, double expectedCumulativeLeapSeconds)
        {
            double cumulativeLeapSeconds = AASDynamicalTime.CumulativeLeapSeconds(jd);
            Assert.Equal(expectedCumulativeLeapSeconds, cumulativeLeapSeconds);
        }


        [Theory]
        [InlineData(2437300.0, 2437299.9996113023)]
        [InlineData(2457754.5 + 500, 2458254.4991992591)]
        [InlineData(2437300.5, 2437300.4996110322)]
        [InlineData(2457754.5, 2457754.4991992596)]
        public void TT2UTCTest(double jd, double expectedTime)
        {
            double time = AASDynamicalTime.TT2UTC(jd);
            Assert.Equal(expectedTime, time);
        }
 
        [Theory]
        [InlineData(2437300.0, 2437300.0003886977)]
        [InlineData(2457754.5 + 500, 2458254.5008007409)]
        [InlineData(2437300.5, 2437300.5003889678)]
        [InlineData(2457754.5, 2457754.5008007404)]
        public void UTC2TTTest(double jd, double expectedTime)
        {
            double time = AASDynamicalTime.UTC2TT(jd);
            Assert.Equal(expectedTime, time);
        }

        [Theory]
        [InlineData(2458119.5, 2458119.4996274998)]
        public void TT2TAITest(double jd, double expectedTime)
        {
            double time = AASDynamicalTime.TT2TAI(jd);
            Assert.Equal(expectedTime, time);
        }

        [Theory]
        [InlineData(2458119.4996274998, 2458119.5)]
        public void TAI2TTTest(double jd, double expectedTime)
        {
            double time = AASDynamicalTime.TAI2TT(jd);
            Assert.Equal(expectedTime, time);
        }

        [Theory]
        [InlineData(2458119.5, 2458119.4992017634)]
        public void TT2UT1Test(double jd, double expectedTime)
        {
            double time = AASDynamicalTime.TT2UT1(jd);
            Assert.Equal(expectedTime, time);
        }

        [Theory]
        [InlineData(2458119.499201763, 2458119.4999999995)]
        public void UT12TTTest(double jd, double expectedTime)
        {
            double time = AASDynamicalTime.UT12TT(jd);
            Assert.Equal(expectedTime, time);
        }

        [Theory]
        [InlineData(2458119.5, 0.21637380123138428)]
        public void UT1MinusUTCTest(double jd, double expectedTime)
        {
            double time = AASDynamicalTime.UT1MinusUTC(jd);
            Assert.Equal(expectedTime, time);
        }
    }
}