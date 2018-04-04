using Xunit;

namespace AASharp.Tests.VSOP87.A
{
    public class VSOP87AMarsTest
    {
        [Theory]
        [InlineData(2341970.0, -1.638748952361728)]
        public void XTest(double jd, double expectedResult)
        {
            double result = AASVSOP87A_Mars.X(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2341970.0, 0.25071052424930645)]
        public void YTest(double jd, double expectedResult)
        {
            double result = AASVSOP87A_Mars.Y(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2341970.0, 0.046560591326259809)]
        public void ZTest(double jd, double expectedResult)
        {
            double result = AASVSOP87A_Mars.Z(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2341970.0, -0.0015671783154111005)]
        public void XDashTest(double jd, double expectedResult)
        {
            double result = AASVSOP87A_Mars.X_DASH(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2341970.0, -0.012654177078222938)]
        public void YDashTest(double jd, double expectedResult)
        {
            double result = AASVSOP87A_Mars.Y_DASH(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2341970.0, -0.00022415662356789904)]
        public void ZDashTest(double jd, double expectedResult)
        {
            double result = AASVSOP87A_Mars.Z_DASH(jd);
            Assert.Equal(expectedResult, result);
        }
    }
}