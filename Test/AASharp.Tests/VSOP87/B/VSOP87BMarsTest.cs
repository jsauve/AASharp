using Xunit;

namespace AASharp.Tests.VSOP87.B
{
    public class VSOP87BMarsTest
    {
        [Theory]
        [InlineData(2122820.0, 0.029828552448871296)]
        public void BTest(double jd, double expectedResult)
        {
            double result = AASVSOP87B_Mars.B(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2122820.0, 2.955771252307116)]
        public void LTest(double jd, double expectedResult)
        {
            double result = AASVSOP87B_Mars.L(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2122820.0, 1.6571002361777523)]
        public void RTest(double jd, double expectedResult)
        {
            double result = AASVSOP87B_Mars.R(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2122820.0, -0.0001179365868992265)]
        public void BDashTest(double jd, double expectedResult)
        {
            double result = AASVSOP87B_Mars.B_DASH(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2122820.0, 0.0077017637599708531)]
        public void LDashTest(double jd, double expectedResult)
        {
            double result = AASVSOP87B_Mars.L_DASH(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2122820.0, -0.00038600805907258208)]
        public void RDashTest(double jd, double expectedResult)
        {
            double result = AASVSOP87B_Mars.R_DASH(jd);
            Assert.Equal(expectedResult, result);
        }
    }
}