using Xunit;

namespace AASharp.Tests.VSOP87.E
{
    public class VSOP87ESunTest
    {
        [Theory]
        [InlineData(2195870.0, 4.52874999615153E-05)]
        public void XTest(double jd, double expectedResult)
        {
            double result = AASVSOP87E_Sun.X(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2195870.0, -0.002973096994105826)]
        public void YTest(double jd, double expectedResult)
        {
            double result = AASVSOP87E_Sun.Y(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2195870.0, -5.524648924720651E-06)]
        public void ZTest(double jd, double expectedResult)
        {
            double result = AASVSOP87E_Sun.Z(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2195870.0, 4.7828736722184953e-006)]
        public void XDashTest(double jd, double expectedResult)
        {
            double result = AASVSOP87E_Sun.X_DASH(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2195870.0, -4.8952506498112801e-006)]
        public void YDashTest(double jd, double expectedResult)
        {
            double result = AASVSOP87E_Sun.Y_DASH(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2195870.0, -1.248472289744445e-007)]
        public void ZDashTest(double jd, double expectedResult)
        {
            double result = AASVSOP87E_Sun.Z_DASH(jd);
            Assert.Equal(expectedResult, result);
        }
    }
}