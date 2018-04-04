using Xunit;

namespace AASharp.Tests.VSOP87.D
{
    public class VSOP87DMercuryTest
    {
        [Theory]
        [InlineData(2122820.0, 6.1688577263963786)]
        public void BTest(double jd, double expectedResult)
        {
            double result = AASVSOP87D_Mercury.B(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2122820.0, 5.0128397763627035)]
        public void LTest(double jd, double expectedResult)
        {
            double result = AASVSOP87D_Mercury.L(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2122820.0, 0.4352063237384538)]
        public void RTest(double jd, double expectedResult)
        {
            double result = AASVSOP87D_Mercury.R(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2122820.0, -0.0023509297492469512)]
        public void BDashTest(double jd, double expectedResult)
        {
            double result = AASVSOP87D_Mercury.B_DASH(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2122820.0, 0.055615245514137157)]
        public void LDashTest(double jd, double expectedResult)
        {
            double result = AASVSOP87D_Mercury.L_DASH(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2122820.0, -0.0040232429496490033)]
        public void RDashTest(double jd, double expectedResult)
        {
            double result = AASVSOP87D_Mercury.R_DASH(jd);
            Assert.Equal(expectedResult, result);
        }
    }
}