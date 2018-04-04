using Xunit;

namespace AASharp.Tests.VSOP87.A
{
    public class VSOP87AJupiterTest
    {
        [Theory]
        [InlineData(2341970.0, 1.2817318352961367)]
        public void XTest(double jd, double expectedResult)
        {
            double result = AASVSOP87A_Jupiter.X(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2341970.0, -5.0280079874182544)]
        public void YTest(double jd, double expectedResult)
        {
            double result = AASVSOP87A_Jupiter.Y(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2341970.0, -0.0091251589760241811)]
        public void ZTest(double jd, double expectedResult)
        {
            double result = AASVSOP87A_Jupiter.Z(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2341970.0, 0.0072282645685070347)]
        public void XDashTest(double jd, double expectedResult)
        {
            double result = AASVSOP87A_Jupiter.X_DASH(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2341970.0, 0.0022248807623204058)]
        public void YDashTest(double jd, double expectedResult)
        {
            double result = AASVSOP87A_Jupiter.Y_DASH(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2341970.0, -0.00017148969152921747)]
        public void ZDashTest(double jd, double expectedResult)
        {
            double result = AASVSOP87A_Jupiter.Z_DASH(jd);
            Assert.Equal(expectedResult, result);
        }
    }
}