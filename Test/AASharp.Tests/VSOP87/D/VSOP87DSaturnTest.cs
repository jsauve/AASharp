using Xunit;

namespace AASharp.Tests.VSOP87.D
{
    public class VSOP87DSaturnTest
    {
        [Theory]
        [InlineData(2122820.0, 0.043537113880927583)]
        public void BTest(double jd, double expectedResult)
        {
            double result = AASVSOP87D_Saturn.B(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2122820.0, 3.5570108068712685)]
        public void LTest(double jd, double expectedResult)
        {
            double result = AASVSOP87D_Saturn.L(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2122820.0, 9.8669939497914498)]
        public void RTest(double jd, double expectedResult)
        {
            double result = AASVSOP87D_Saturn.R(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2122820.0, -3.3630280971527116e-006)]
        public void BDashTest(double jd, double expectedResult)
        {
            double result = AASVSOP87D_Saturn.B_DASH(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2122820.0, 0.00054582328652718996)]
        public void LDashTest(double jd, double expectedResult)
        {
            double result = AASVSOP87D_Saturn.L_DASH(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2122820.0, 0.00025024292229156367)]
        public void RDashTest(double jd, double expectedResult)
        {
            double result = AASVSOP87D_Saturn.R_DASH(jd);
            Assert.Equal(expectedResult, result);
        }
    }
}