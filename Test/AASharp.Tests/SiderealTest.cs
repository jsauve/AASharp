using Xunit;
using Xunit.Sdk;

namespace AASharp.Tests
{
    public class SiderealTest
    {
        [Theory]
        [InlineData(1987, 4, 10, 0, 0, 0, true, 13.179546340533079)]
        [InlineData(1987, 4, 10, 19, 21, 0, true, 8.5825248842142514)]
        public void MeanGreenwichSiderealTimeTest(int year, int month, int day, int hours, int minutes, int seconds, bool isGregorian, double expectedSideralTime)
        {
            var date = new AASDate();
            date.Set(year, month, day, hours, minutes, seconds, isGregorian);
            
            double meanGreenwichSiderealTime = AASSidereal.MeanGreenwichSiderealTime(date.Julian);
            Assert.Equal(expectedSideralTime, meanGreenwichSiderealTime);
        }
        
        [Theory]
        [InlineData(1987, 4, 10, 0, 0, 0, true, 13.179481984120102)]
        public void ApparentGreenwichSiderealTime(int year, int month, int day, int hours, int minutes, int seconds, bool isGregorian, double expectedSideralTime)
        {
            var date = new AASDate();
            date.Set(year, month, day, hours, minutes, seconds, isGregorian);



            var apparentGreenwichSiderealTime = AASSidereal.ApparentGreenwichSiderealTime(date.Julian);
            Assert.Equal(expectedSideralTime, apparentGreenwichSiderealTime);
        }
    }
}