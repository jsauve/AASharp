using Xunit;

namespace AASharp.Tests.VSOP87.A
{
    public class VSOP87ANeptuneTest
    {
        [Theory]
        [InlineData(2341970.0, 29.502281195023734)]
        public void XTest(double jd, double expectedResult)
        {
            double result = AASVSOP87A_Neptune.X(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2341970.0, 4.5987701113956589)]
        public void YTest(double jd, double expectedResult)
        {
            double result = AASVSOP87A_Neptune.Y(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2341970.0, -0.77405072551522258)]
        public void ZTest(double jd, double expectedResult)
        {
            double result = AASVSOP87A_Neptune.Z(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2341970.0, -0.00049730221671553552)]
        public void XDashTest(double jd, double expectedResult)
        {
            double result = AASVSOP87A_Neptune.X_DASH(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2341970.0, 0.0031231520863187205)]
        public void YDashTest(double jd, double expectedResult)
        {
            double result = AASVSOP87A_Neptune.Y_DASH(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2341970.0, -5.281856120302102e-005)]
        public void ZDashTest(double jd, double expectedResult)
        {
            double result = AASVSOP87A_Neptune.Z_DASH(jd);
            Assert.Equal(expectedResult, result);
        }
    }
}