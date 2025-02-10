using System;
using Xunit;

namespace AASharp.Tests {
    public class ExtensionsTest {
        [Theory]
        [InlineData(2000, 1, 1, 12, 0, 0, 0)]
        public void DateTimeToJD(int Year, int Month, int Day, int Hour, int Minute, int Second, int Millis) {
            var date = new DateTime(Year, Month, Day, Hour, Minute, Second, Millis, DateTimeKind.Utc);
            var aas_date = date.ToAASDate();
            Assert.Equal(2451545.0, aas_date.Julian);
        }

        [Theory]
        [InlineData(2451545.0)]
        public void DateTimeFromJD(double JD) {
            var date = JD.ToDateTime();
            Assert.Equal(630823248000000000L, date.Ticks);
        }

    }
}
