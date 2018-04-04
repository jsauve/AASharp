using Xunit;

namespace AASharp.Tests.VSOP87.E
{
    public class VSOP87EUranusTest
    {
        [Theory]
        [InlineData(2195870.0, -17.653879119740697)]
        public void XTest(double jd, double expectedResult)
        {
            double result = AASVSOP87E_Uranus.X(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2195870.0, -5.1666300879773077)]
        public void YTest(double jd, double expectedResult)
        {
            double result = AASVSOP87E_Uranus.Y(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2195870.0, 0.21246140280471718)]
        public void ZTest(double jd, double expectedResult)
        {
            double result = AASVSOP87E_Uranus.Z(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2195870.0, 0.0010739540480098539)]
        public void XDashTest(double jd, double expectedResult)
        {
            double result = AASVSOP87E_Uranus.X_DASH(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2195870.0, -0.0039522427395165477)]
        public void YDashTest(double jd, double expectedResult)
        {
            double result = AASVSOP87E_Uranus.Y_DASH(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2195870.0, -2.949774673324808e-005)]
        public void ZDashTest(double jd, double expectedResult)
        {
            double result = AASVSOP87E_Uranus.Z_DASH(jd);
            Assert.Equal(expectedResult, result);
        }
    }
}