using Xunit;

namespace AASharp.Tests.VSOP87.A
{
    public class VSOP87AVenusTest
    {
        [Theory]
        [InlineData(2341970.0, 0.45311932653458625)]
        public void XTest(double jd, double expectedResult)
        {
            double result = AASVSOP87A_Venus.X(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2341970.0, -0.56924209685759919)]
        public void YTest(double jd, double expectedResult)
        {
            double result = AASVSOP87A_Venus.Y(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2341970.0, -0.03356432167949127)]
        public void ZTest(double jd, double expectedResult)
        {
            double result = AASVSOP87A_Venus.Z(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2341970.0, 0.01568726749747985)]
        public void XDashTest(double jd, double expectedResult)
        {
            double result = AASVSOP87A_Venus.X_DASH(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2341970.0, 0.012522807804638634)]
        public void YDashTest(double jd, double expectedResult)
        {
            double result = AASVSOP87A_Venus.Y_DASH(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2341970.0, -0.00074841896794114048)]
        public void ZDashTest(double jd, double expectedResult)
        {
            double result = AASVSOP87A_Venus.Z_DASH(jd);
            Assert.Equal(expectedResult, result);
        }
    }
}