using Xunit;

namespace AASharp.Tests.VSOP87.C
{
    public class VSOP87CJupiterTest
    {
        [Theory]
        [InlineData(2195870.0, 4.6200396688340808)]
        public void XTest(double jd, double expectedResult)
        {
            double result = AASVSOP87C_Jupiter.X(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2195870.0, 1.8327269764228984)]
        public void YTest(double jd, double expectedResult)
        {
            double result = AASVSOP87C_Jupiter.Y(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2195870.0, -0.11058150116218274)]
        public void ZTest(double jd, double expectedResult)
        {
            double result = AASVSOP87C_Jupiter.Z(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2195870.0, -0.0028006109649932713)]
        public void XDashTest(double jd, double expectedResult)
        {
            double result = AASVSOP87C_Jupiter.X_DASH(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2195870.0, 0.0073774541081043643)]
        public void YDashTest(double jd, double expectedResult)
        {
            double result = AASVSOP87C_Jupiter.Y_DASH(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2195870.0, 5.5371182842283437e-005)]
        public void ZDashTest(double jd, double expectedResult)
        {
            double result = AASVSOP87C_Jupiter.Z_DASH(jd);
            Assert.Equal(expectedResult, result);
        }
    }
}