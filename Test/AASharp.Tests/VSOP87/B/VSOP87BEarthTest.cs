using Xunit;

namespace AASharp.Tests.VSOP87.B
{
    public class VSOP87BEarthTest
    {
        [Theory]
        [InlineData(2122820.0, 0.0019445313797964224)]
        public void BTest(double jd, double expectedResult)
        {
            double result = AASVSOP87B_Earth.B(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2122820.0, 1.8557201152371761)]
        public void LTest(double jd, double expectedResult)
        {
            double result = AASVSOP87B_Earth.L(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2122820.0, 0.9830331808670556)]
        public void RTest(double jd, double expectedResult)
        {
            double result = AASVSOP87B_Earth.R(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2122820.0, -1.2290387395243618e-005)]
        public void BDashTest(double jd, double expectedResult)
        {
            double result = AASVSOP87B_Earth.B_DASH(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2122820.0, 0.01780298413167666)]
        public void LDashTest(double jd, double expectedResult)
        {
            double result = AASVSOP87B_Earth.L_DASH(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2122820.0, 2.737453560118737e-005)]
        public void RDashTest(double jd, double expectedResult)
        {
            double result = AASVSOP87B_Earth.R_DASH(jd);
            Assert.Equal(expectedResult, result);
        }
    }
}