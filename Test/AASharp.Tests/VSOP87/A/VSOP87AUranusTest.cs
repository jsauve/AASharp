using Xunit;

namespace AASharp.Tests.VSOP87.A
{
    public class VSOP87AUranusTest
    {
        [Theory]
        [InlineData(2341970.0, -4.2214391935623654)]
        public void XTest(double jd, double expectedResult)
        {
            double result = AASVSOP87A_Uranus.X(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2341970.0, 18.316026638447411)]
        public void YTest(double jd, double expectedResult)
        {
            double result = AASVSOP87A_Uranus.Y(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2341970.0, 0.12475925684181505)]
        public void ZTest(double jd, double expectedResult)
        {
            double result = AASVSOP87A_Uranus.Z(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2341970.0, -0.0038580473772700983)]
        public void XDashTest(double jd, double expectedResult)
        {
            double result = AASVSOP87A_Uranus.X_DASH(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2341970.0, -0.0010609793433566529)]
        public void YDashTest(double jd, double expectedResult)
        {
            double result = AASVSOP87A_Uranus.Y_DASH(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2341970.0, 4.6196603486234878e-005)]
        public void ZDashTest(double jd, double expectedResult)
        {
            double result = AASVSOP87A_Uranus.Z_DASH(jd);
            Assert.Equal(expectedResult, result);
        }
    }
}