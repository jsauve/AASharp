using Xunit;

namespace AASharp.Tests.VSOP87.A
{
    public class VSOP87AEarthTest
    {
        [Theory]
        [InlineData(2341970.0, -0.21046546524694845)]
        public void XTest(double jd, double expectedResult)
        {
            double result = AASVSOP87A_Earth.X(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2341970.0, 0.96035799541424216)]
        public void YTest(double jd, double expectedResult)
        {
            double result = AASVSOP87A_Earth.Y(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2341970.0, 0.00064729292561254868)]
        public void ZTest(double jd, double expectedResult)
        {
            double result = AASVSOP87A_Earth.Z(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2341970.0, -0.017087558116086553)]
        public void XDashTest(double jd, double expectedResult)
        {
            double result = AASVSOP87A_Earth.X_DASH(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2341970.0, -0.0037496415077549737)]
        public void YDashTest(double jd, double expectedResult)
        {
            double result = AASVSOP87A_Earth.Y_DASH(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2341970.0, -2.9043304848906153e-006)]
        public void ZDashTest(double jd, double expectedResult)
        {
            double result = AASVSOP87A_Earth.Z_DASH(jd);
            Assert.Equal(expectedResult, result);
        }
    }
}