using Xunit;

namespace AASharp.Tests.VSOP87.C
{
    public class VSOP87CMarsTest
    {
        [Theory]
        [InlineData(2195870.0, 0.15169886765027951)]
        public void XTest(double jd, double expectedResult)
        {
            double result = AASVSOP87C_Mars.X(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2195870.0, -1.4122847589547283)]
        public void YTest(double jd, double expectedResult)
        {
            double result = AASVSOP87C_Mars.Y(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2195870.0, -0.036232807140986673)]
        public void ZTest(double jd, double expectedResult)
        {
            double result = AASVSOP87C_Mars.Z(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2195870.0, 0.01469044199213252)]
        public void XDashTest(double jd, double expectedResult)
        {
            double result = AASVSOP87C_Mars.X_DASH(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2195870.0, 0.00253970239572266)]
        public void YDashTest(double jd, double expectedResult)
        {
            double result = AASVSOP87C_Mars.Y_DASH(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2195870.0, -0.00027234546121422199)]
        public void ZDashTest(double jd, double expectedResult)
        {
            double result = AASVSOP87C_Mars.Z_DASH(jd);
            Assert.Equal(expectedResult, result);
        }
    }
}