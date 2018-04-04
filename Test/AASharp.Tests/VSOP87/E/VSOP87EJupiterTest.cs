using Xunit;

namespace AASharp.Tests.VSOP87.E
{
    public class VSOP87EJupiterTest
    {
        [Theory]
        [InlineData(2195870.0, 4.2423739219684151)]
        public void XTest(double jd, double expectedResult)
        {
            double result = AASVSOP87E_Jupiter.X(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2195870.0, 2.5868702423218806)]
        public void YTest(double jd, double expectedResult)
        {
            double result = AASVSOP87E_Jupiter.Y(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2195870.0, -0.10603627115318119)]
        public void ZTest(double jd, double expectedResult)
        {
            double result = AASVSOP87E_Jupiter.Z(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2195870.0, -0.0040046493278518055)]
        public void XDashTest(double jd, double expectedResult)
        {
            double result = AASVSOP87E_Jupiter.X_DASH(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2195870.0, 0.0067878381354922737)]
        public void YDashTest(double jd, double expectedResult)
        {
            double result = AASVSOP87E_Jupiter.Y_DASH(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2195870.0, 6.5711206859455599e-005)]
        public void ZDashTest(double jd, double expectedResult)
        {
            double result = AASVSOP87E_Jupiter.Z_DASH(jd);
            Assert.Equal(expectedResult, result);
        }
    }
}