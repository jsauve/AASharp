using Xunit;

namespace AASharp.Tests.VSOP87.B
{
    public class VSOP87BMercuryTest
    {
        [Theory]
        [InlineData(2122820.0, 6.1671217639803073)]
        public void BTest(double jd, double expectedResult)
        {
            double result = AASVSOP87B_Mercury.B(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2122820.0, 5.2319689070726199)]
        public void LTest(double jd, double expectedResult)
        {
            double result = AASVSOP87B_Mercury.L(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2122820.0, 0.43520632352045407)]
        public void RTest(double jd, double expectedResult)
        {
            double result = AASVSOP87B_Mercury.R(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2122820.0, -0.00228888932506972)]
        public void BDashTest(double jd, double expectedResult)
        {
            double result = AASVSOP87B_Mercury.B_DASH(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2122820.0, 0.0556283749971343)]
        public void LDashTest(double jd, double expectedResult)
        {
            double result = AASVSOP87B_Mercury.L_DASH(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2122820.0, -0.0040232429154468665)]
        public void RDashTest(double jd, double expectedResult)
        {
            double result = AASVSOP87B_Mercury.R_DASH(jd);
            Assert.Equal(expectedResult, result);
        }
    }
}