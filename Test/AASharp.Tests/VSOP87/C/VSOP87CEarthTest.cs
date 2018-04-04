using Xunit;

namespace AASharp.Tests.VSOP87.C
{
    public class VSOP87CEarthTest
    {
        [Theory]
        [InlineData(2195870.0, -0.089738129786775533)]
        public void XTest(double jd, double expectedResult)
        {
            double result = AASVSOP87C_Earth.X(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2195870.0, 0.97898996232055435)]
        public void YTest(double jd, double expectedResult)
        {
            double result = AASVSOP87C_Earth.Y(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2195870.0, 1.4875438443804988e-006)]
        public void ZTest(double jd, double expectedResult)
        {
            double result = AASVSOP87C_Earth.Z(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2195870.0, -0.017429975607865224)]
        public void XDashTest(double jd, double expectedResult)
        {
            double result = AASVSOP87C_Earth.X_DASH(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2195870.0, -0.0015704375034114968)]
        public void YDashTest(double jd, double expectedResult)
        {
            double result = AASVSOP87C_Earth.Y_DASH(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2195870.0, 2.9034992919760041e-007)]
        public void ZDashTest(double jd, double expectedResult)
        {
            double result = AASVSOP87C_Earth.Z_DASH(jd);
            Assert.Equal(expectedResult, result);
        }
    }
}