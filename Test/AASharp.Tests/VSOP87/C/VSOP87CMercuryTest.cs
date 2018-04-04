using Xunit;

namespace AASharp.Tests.VSOP87.C
{
    public class VSOP87CMercuryTest
    {
        [Theory]
        [InlineData(2195870.0, -0.095183536535779073)]
        public void XTest(double jd, double expectedResult)
        {
            double result = AASVSOP87C_Mercury.X(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2195870.0, 0.30436527631746646)]
        public void YTest(double jd, double expectedResult)
        {
            double result = AASVSOP87C_Mercury.Y(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2195870.0, 0.036085854386477857)]
        public void ZTest(double jd, double expectedResult)
        {
            double result = AASVSOP87C_Mercury.Z(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2195870.0, -0.03219171070222375)]
        public void XDashTest(double jd, double expectedResult)
        {
            double result = AASVSOP87C_Mercury.X_DASH(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2195870.0, -0.0062868160991465458)]
        public void YDashTest(double jd, double expectedResult)
        {
            double result = AASVSOP87C_Mercury.Y_DASH(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2195870.0, 0.0019491532284303427)]
        public void ZDashTest(double jd, double expectedResult)
        {
            double result = AASVSOP87C_Mercury.Z_DASH(jd);
            Assert.Equal(expectedResult, result);
        }
    }
}