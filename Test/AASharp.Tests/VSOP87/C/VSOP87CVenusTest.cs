using Xunit;

namespace AASharp.Tests.VSOP87.C
{
    public class VSOP87CVenusTest
    {
        [Theory]
        [InlineData(2195870.0, -0.48176220803155145)]
        public void XTest(double jd, double expectedResult)
        {
            double result = AASVSOP87C_Venus.X(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2195870.0, -0.54120198687006049)]
        public void YTest(double jd, double expectedResult)
        {
            double result = AASVSOP87C_Venus.Y(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2195870.0, 0.016112811613880659)]
        public void ZTest(double jd, double expectedResult)
        {
            double result = AASVSOP87C_Venus.Z(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2195870.0, 0.014947079177837259)]
        public void XDashTest(double jd, double expectedResult)
        {
            double result = AASVSOP87C_Venus.X_DASH(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2195870.0, -0.01352373162130786)]
        public void YDashTest(double jd, double expectedResult)
        {
            double result = AASVSOP87C_Venus.Y_DASH(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2195870.0, -0.0011021166728882152)]
        public void ZDashTest(double jd, double expectedResult)
        {
            double result = AASVSOP87C_Venus.Z_DASH(jd);
            Assert.Equal(expectedResult, result);
        }
    }
}