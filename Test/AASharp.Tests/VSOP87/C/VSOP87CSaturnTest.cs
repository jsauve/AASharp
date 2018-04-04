using Xunit;

namespace AASharp.Tests.VSOP87.C
{
    public class VSOP87CSaturnTest
    {
        [Theory]
        [InlineData(2195870.0, -6.0841827842752174)]
        public void XTest(double jd, double expectedResult)
        {
            double result = AASVSOP87C_Saturn.X(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2195870.0, 6.879972114648031)]
        public void YTest(double jd, double expectedResult)
        {
            double result = AASVSOP87C_Saturn.Y(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2195870.0, 0.16398802346702601)]
        public void ZTest(double jd, double expectedResult)
        {
            double result = AASVSOP87C_Saturn.Z(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2195870.0, -0.0045017715821157401)]
        public void XDashTest(double jd, double expectedResult)
        {
            double result = AASVSOP87C_Saturn.X_DASH(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2195870.0, -0.0036310383415626268)]
        public void YDashTest(double jd, double expectedResult)
        {
            double result = AASVSOP87C_Saturn.Y_DASH(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2195870.0, 0.00023618128347768376)]
        public void ZDashTest(double jd, double expectedResult)
        {
            double result = AASVSOP87C_Saturn.Z_DASH(jd);
            Assert.Equal(expectedResult, result);
        }
    }
}