using Xunit;

namespace AASharp.Tests.VSOP87.B
{
    public class VSOP87BVenusTest
    {
        [Theory]
        [InlineData(2122820.0, 0.049616127153800253)]
        public void BTest(double jd, double expectedResult)
        {
            double result = AASVSOP87B_Venus.B(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2122820.0, 3.5336333775021913)]
        public void LTest(double jd, double expectedResult)
        {
            double result = AASVSOP87B_Venus.L(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2122820.0, 0.72158197730826557)]
        public void RTest(double jd, double expectedResult)
        {
            double result = AASVSOP87B_Venus.R(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2122820.0, -0.00091458261340032602)]
        public void BDashTest(double jd, double expectedResult)
        {
            double result = AASVSOP87B_Venus.B_DASH(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2122820.0, 0.028117106730254467)]
        public void LDashTest(double jd, double expectedResult)
        {
            double result = AASVSOP87B_Venus.L_DASH(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2122820.0, 0.00013733491158632994)]
        public void RDashTest(double jd, double expectedResult)
        {
            double result = AASVSOP87B_Venus.R_DASH(jd);
            Assert.Equal(expectedResult, result);
        }
    }
}