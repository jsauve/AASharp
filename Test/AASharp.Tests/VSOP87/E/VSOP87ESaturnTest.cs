using Xunit;

namespace AASharp.Tests.VSOP87.E
{
    public class VSOP87ESaturnTest
    {
        [Theory]
        [InlineData(2195870.0, -7.1627672767163055)]
        public void XTest(double jd, double expectedResult)
        {
            double result = AASVSOP87E_Saturn.X(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2195870.0, 5.7452916044087958)]
        public void YTest(double jd, double expectedResult)
        {
            double result = AASVSOP87E_Saturn.Y(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2195870.0, 0.17249066067407648)]
        public void ZTest(double jd, double expectedResult)
        {
            double result = AASVSOP87E_Saturn.Z(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2195870.0, -0.0038122126572606211)]
        public void XDashTest(double jd, double expectedResult)
        {
            double result = AASVSOP87E_Saturn.X_DASH(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2195870.0, -0.0043423789307423105)]
        public void YDashTest(double jd, double expectedResult)
        {
            double result = AASVSOP87E_Saturn.Y_DASH(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2195870.0, 0.00022871609353883795)]
        public void ZDashTest(double jd, double expectedResult)
        {
            double result = AASVSOP87E_Saturn.Z_DASH(jd);
            Assert.Equal(expectedResult, result);
        }
    }
}