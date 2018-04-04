using Xunit;

namespace AASharp.Tests.VSOP87.C
{
    public class VSOP87CUranusTest
    {
        [Theory]
        [InlineData(2195870.0, -18.273816164295653)]
        public void XTest(double jd, double expectedResult)
        {
            double result = AASVSOP87C_Uranus.X(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2195870.0, -2.094685136777569)]
        public void YTest(double jd, double expectedResult)
        {
            double result = AASVSOP87C_Uranus.Y(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2195870.0, 0.22242381358314692)]
        public void ZTest(double jd, double expectedResult)
        {
            double result = AASVSOP87C_Uranus.Z(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2195870.0, 0.00038565950990929166)]
        public void XDashTest(double jd, double expectedResult)
        {
            double result = AASVSOP87C_Uranus.X_DASH(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2195870.0, -0.004083688353978719)]
        public void YDashTest(double jd, double expectedResult)
        {
            double result = AASVSOP87C_Uranus.Y_DASH(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2195870.0, -2.3196602322862996e-005)]
        public void ZDashTest(double jd, double expectedResult)
        {
            double result = AASVSOP87C_Uranus.Z_DASH(jd);
            Assert.Equal(expectedResult, result);
        }
    }
}