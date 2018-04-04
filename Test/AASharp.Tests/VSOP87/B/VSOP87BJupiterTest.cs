using Xunit;

namespace AASharp.Tests.VSOP87.B
{
    public class VSOP87BJupiterTest
    {
        [Theory]
        [InlineData(2122820.0, 6.2777141271522678)]
        public void BTest(double jd, double expectedResult)
        {
            double result = AASVSOP87B_Jupiter.B(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2122820.0, 1.4885071579879252)]
        public void LTest(double jd, double expectedResult)
        {
            double result = AASVSOP87B_Jupiter.L(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2122820.0, 5.1193587263180405)]
        public void RTest(double jd, double expectedResult)
        {
            double result = AASVSOP87B_Jupiter.R(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2122820.0, 3.3605889955688449e-005)]
        public void BDashTest(double jd, double expectedResult)
        {
            double result = AASVSOP87B_Jupiter.B_DASH(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2122820.0, 0.0014958246636834773)]
        public void LDashTest(double jd, double expectedResult)
        {
            double result = AASVSOP87B_Jupiter.L_DASH(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2122820.0, 0.00034153794164771341)]
        public void RDashTest(double jd, double expectedResult)
        {
            double result = AASVSOP87B_Jupiter.R_DASH(jd);
            Assert.Equal(expectedResult, result);
        }
    }
}