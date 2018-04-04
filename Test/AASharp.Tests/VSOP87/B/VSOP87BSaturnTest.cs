using Xunit;

namespace AASharp.Tests.VSOP87.B
{
    public class VSOP87BSaturnTest
    {
        [Theory]
        [InlineData(2122820.0, 0.042230083090626029)]
        public void BTest(double jd, double expectedResult)
        {
            double result = AASVSOP87B_Saturn.B(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2122820.0, 3.7760794189913796)]
        public void LTest(double jd, double expectedResult)
        {
            double result = AASVSOP87B_Saturn.L(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2122820.0, 9.866993912688061)]
        public void RTest(double jd, double expectedResult)
        {
            double result = AASVSOP87B_Saturn.R(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2122820.0, -4.2295753160575982e-006)]
        public void BDashTest(double jd, double expectedResult)
        {
            double result = AASVSOP87B_Saturn.B_DASH(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2122820.0, 0.00054512047945383315)]
        public void LDashTest(double jd, double expectedResult)
        {
            double result = AASVSOP87B_Saturn.L_DASH(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2122820.0, 0.00025024301253743489)]
        public void RDashTest(double jd, double expectedResult)
        {
            double result = AASVSOP87B_Saturn.R_DASH(jd);
            Assert.Equal(expectedResult, result);
        }
    }
}