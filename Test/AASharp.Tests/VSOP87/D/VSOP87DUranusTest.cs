using Xunit;

namespace AASharp.Tests.VSOP87.D
{
    public class VSOP87DUranusTest
    {
        [Theory]
        [InlineData(2122820.0, 6.2766242460409041)]
        public void BTest(double jd, double expectedResult)
        {
            double result = AASVSOP87D_Uranus.B(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2122820.0, 0.70072262243255068)]
        public void LTest(double jd, double expectedResult)
        {
            double result = AASVSOP87D_Uranus.L(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2122820.0, 19.561207827109836)]
        public void RTest(double jd, double expectedResult)
        {
            double result = AASVSOP87D_Uranus.R(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2122820.0, 2.3222935753942077e-006)]
        public void BDashTest(double jd, double expectedResult)
        {
            double result = AASVSOP87D_Uranus.B_DASH(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2122820.0, 0.00019780545944777755)]
        public void LDashTest(double jd, double expectedResult)
        {
            double result = AASVSOP87D_Uranus.L_DASH(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2122820.0, -0.00016077906446417982)]
        public void RDashTest(double jd, double expectedResult)
        {
            double result = AASVSOP87D_Uranus.R_DASH(jd);
            Assert.Equal(expectedResult, result);
        }
    }
}