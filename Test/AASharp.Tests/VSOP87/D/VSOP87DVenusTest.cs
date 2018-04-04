using Xunit;

namespace AASharp.Tests.VSOP87.D
{
    public class VSOP87DVenusTest
    {
        [Theory]
        [InlineData(2122820.0, 0.05050160525259028)]
        public void BTest(double jd, double expectedResult)
        {
            double result = AASVSOP87D_Venus.B(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2122820.0, 3.3145399295108646)]
        public void LTest(double jd, double expectedResult)
        {
            double result = AASVSOP87D_Venus.L(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2122820.0, 0.72158197831936133)]
        public void RTest(double jd, double expectedResult)
        {
            double result = AASVSOP87D_Venus.R(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2122820.0, -0.00086218038675415283)]
        public void BDashTest(double jd, double expectedResult)
        {
            double result = AASVSOP87D_Venus.B_DASH(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2122820.0, 0.028120678778049014)]
        public void LDashTest(double jd, double expectedResult)
        {
            double result = AASVSOP87D_Venus.L_DASH(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2122820.0, 0.00013733497279312733)]
        public void RDashTest(double jd, double expectedResult)
        {
            double result = AASVSOP87D_Venus.R_DASH(jd);
            Assert.Equal(expectedResult, result);
        }
    }
}