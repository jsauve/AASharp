using Xunit;

namespace AASharp.Tests.VSOP87.B
{
    public class VSOP87BNeptuneTest
    {
        [Theory]
        [InlineData(2122820.0, 0.0040125142209051657)]
        public void BTest(double jd, double expectedResult)
        {
            double result = AASVSOP87B_Neptune.B(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2122820.0, 2.4315044301877862)]
        public void LTest(double jd, double expectedResult)
        {
            double result = AASVSOP87B_Neptune.L(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2122820.0, 30.065369488850518)]
        public void RTest(double jd, double expectedResult)
        {
            double result = AASVSOP87B_Neptune.R(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2122820.0, 3.1984009358611431e-006)]
        public void BDashTest(double jd, double expectedResult)
        {
            double result = AASVSOP87B_Neptune.B_DASH(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2122820.0, 0.00010452968500980002)]
        public void LDashTest(double jd, double expectedResult)
        {
            double result = AASVSOP87B_Neptune.L_DASH(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2122820.0, 3.1439733521695961E-05)]
        public void RDashTest(double jd, double expectedResult)
        {
            double result = AASVSOP87B_Neptune.R_DASH(jd);
            Assert.Equal(expectedResult, result);
        }
    }
}