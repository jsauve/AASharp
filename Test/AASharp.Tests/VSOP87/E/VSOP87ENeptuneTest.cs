using Xunit;

namespace AASharp.Tests.VSOP87.E
{
    public class VSOP87ENeptuneTest
    {
        [Theory]
        [InlineData(2195870.0, -24.623389450723327)]
        public void XTest(double jd, double expectedResult)
        {
            double result = AASVSOP87E_Neptune.X(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2195870.0, -17.654416043943463)]
        public void YTest(double jd, double expectedResult)
        {
            double result = AASVSOP87E_Neptune.Y(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2195870.0, 0.92971889866779001)]
        public void ZTest(double jd, double expectedResult)
        {
            double result = AASVSOP87E_Neptune.Z(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2195870.0, 0.0018093571344550182)]
        public void XDashTest(double jd, double expectedResult)
        {
            double result = AASVSOP87E_Neptune.X_DASH(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2195870.0, -0.0025335174880982496)]
        public void YDashTest(double jd, double expectedResult)
        {
            double result = AASVSOP87E_Neptune.Y_DASH(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2195870.0, 1.0558937031139072e-005)]
        public void ZDashTest(double jd, double expectedResult)
        {
            double result = AASVSOP87E_Neptune.Z_DASH(jd);
            Assert.Equal(expectedResult, result);
        }
    }
}