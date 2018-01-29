using Xunit;

namespace AASharp.Tests
{
    public class PhysicalSunTest
    {
        [Theory]
        [InlineData(2448908.50068, false, 5.9882130001199663, 238.6316689148353, 26.274011444642024)]
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