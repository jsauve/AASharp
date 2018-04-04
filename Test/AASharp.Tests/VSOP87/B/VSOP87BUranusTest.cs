using Xunit;

namespace AASharp.Tests.VSOP87.B
{
    public class VSOP87BUranusTest
    {
        [Theory]
        [InlineData(2122820.0, 6.278327768990458)]
        public void BTest(double jd, double expectedResult)
        {
            double result = AASVSOP87B_Uranus.B(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2122820.0, 0.91972932853349931)]
        public void LTest(double jd, double expectedResult)
        {
            double result = AASVSOP87B_Uranus.L(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2122820.0, 19.561208021888426)]
        public void RTest(double jd, double expectedResult)
        {
            double result = AASVSOP87B_Uranus.R(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2122820.0, 2.5467300154007273e-006)]
        public void BDashTest(double jd, double expectedResult)
        {
            double result = AASVSOP87B_Uranus.B_DASH(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2122820.0, 0.00019713640077670996)]
        public void LDashTest(double jd, double expectedResult)
        {
            double result = AASVSOP87B_Uranus.L_DASH(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2122820.0, -0.00016077536416749417)]
        public void RDashTest(double jd, double expectedResult)
        {
            double result = AASVSOP87B_Uranus.R_DASH(jd);
            Assert.Equal(expectedResult, result);
        }
    }
}