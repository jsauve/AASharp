using Xunit;

namespace AASharp.Tests.VSOP87.E
{
    public class VSOP87EMarsTest
    {
        [Theory]
        [InlineData(2195870.0, 0.38905267700611207)]
        public void XTest(double jd, double expectedResult)
        {
            double result = AASVSOP87E_Mars.X(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2195870.0, -1.3690161891964616)]
        public void YTest(double jd, double expectedResult)
        {
            double result = AASVSOP87E_Mars.Y(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2195870.0, -0.038386419797255454)]
        public void ZTest(double jd, double expectedResult)
        {
            double result = AASVSOP87E_Mars.Z(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2195870.0, 0.014050863801516184)]
        public void XDashTest(double jd, double expectedResult)
        {
            double result = AASVSOP87E_Mars.X_DASH(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2195870.0, 0.0049894676378457892)]
        public void YDashTest(double jd, double expectedResult)
        {
            double result = AASVSOP87E_Mars.Y_DASH(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2195870.0, -0.00026312238068284659)]
        public void ZDashTest(double jd, double expectedResult)
        {
            double result = AASVSOP87E_Mars.Z_DASH(jd);
            Assert.Equal(expectedResult, result);
        }
    }
}