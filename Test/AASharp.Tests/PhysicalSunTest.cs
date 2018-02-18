using Xunit;

namespace AASharp.Tests
{
    public class PhysicalSunTest
    {
        [Theory]
        [InlineData(2448908.50068, false, 5.9882130001199663, 238.6316689148353, 26.274011444642024)]
        [InlineData(2451545.5, false, -3.0711457698488323, 354.87401230329306, 1.8918344621229075)]
        [InlineData(2451910.5, false, -3.0415292200986666, 217.31182640670187, 2.0089019889582511)]
        public void CalculateTest(double jd, bool highPrecision, double expectedB0, double expectedL0, double expectedP)
        {
            AASPhysicalSunDetails psd = AASPhysicalSun.Calculate(jd, highPrecision);
            Assert.Equal(expectedB0, psd.B0);
            Assert.Equal(expectedL0, psd.L0);
            Assert.Equal(expectedP, psd.P);
        }

        [Theory]
        [InlineData(1699, 2444480.7229647981)]
        public void TimeOfStartOfRotationTest(long c, double expectedResult)
        {
            double jed = AASPhysicalSun.TimeOfStartOfRotation(c);
            Assert.Equal(expectedResult, jed);
        }
    }
}