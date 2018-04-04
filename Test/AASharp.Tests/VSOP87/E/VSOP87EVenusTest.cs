using Xunit;

namespace AASharp.Tests.VSOP87.E
{
    public class VSOP87EVenusTest
    {
        [Theory]
        [InlineData(2195870.0, -0.38296066780856441)]
        public void XTest(double jd, double expectedResult)
        {
            double result = AASVSOP87E_Venus.X(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2195870.0, -0.61806065582113878)]
        public void YTest(double jd, double expectedResult)
        {
            double result = AASVSOP87E_Venus.Y(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2195870.0, 0.015086476748270612)]
        public void ZTest(double jd, double expectedResult)
        {
            double result = AASVSOP87E_Venus.Z(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2195870.0, 0.017028480768191377)]
        public void XDashTest(double jd, double expectedResult)
        {
            double result = AASVSOP87E_Venus.X_DASH(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2195870.0, -0.010795913307639468)]
        public void YDashTest(double jd, double expectedResult)
        {
            double result = AASVSOP87E_Venus.Y_DASH(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2195870.0, -0.0011178669425233141)]
        public void ZDashTest(double jd, double expectedResult)
        {
            double result = AASVSOP87E_Venus.Z_DASH(jd);
            Assert.Equal(expectedResult, result);
        }
    }
}