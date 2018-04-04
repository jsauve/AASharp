using Xunit;

namespace AASharp.Tests.VSOP87.E
{
    public class VSOP87EMercuryTest
    {
        [Theory]
        [InlineData(2195870.0, -0.14537882155556453)]
        public void XTest(double jd, double expectedResult)
        {
            double result = AASVSOP87E_Mercury.X(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2195870.0, 0.28078384716698485)]
        public void YTest(double jd, double expectedResult)
        {
            double result = AASVSOP87E_Mercury.Y(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2195870.0, 0.036520362591710091)]
        public void ZTest(double jd, double expectedResult)
        {
            double result = AASVSOP87E_Mercury.Z(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2195870.0, -0.030654497636185711)]
        public void XDashTest(double jd, double expectedResult)
        {
            double result = AASVSOP87E_Mercury.X_DASH(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2195870.0, -0.011662883172466052)]
        public void YDashTest(double jd, double expectedResult)
        {
            double result = AASVSOP87E_Mercury.Y_DASH(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2195870.0, 0.0019274325358610443)]
        public void ZDashTest(double jd, double expectedResult)
        {
            double result = AASVSOP87E_Mercury.Z_DASH(jd);
            Assert.Equal(expectedResult, result);
        }
    }
}