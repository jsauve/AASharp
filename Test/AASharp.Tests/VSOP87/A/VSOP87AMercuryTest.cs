using Xunit;

namespace AASharp.Tests.VSOP87.A
{
    public class VSOP87AMercuryTest
    {
        [Theory]
        [InlineData(2341970.0, 0.32567203601575884)]
        public void XTest(double jd, double expectedResult)
        {
            double result = AASVSOP87A_Mercury.X(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2341970.0, 0.088086580155937219)]
        public void YTest(double jd, double expectedResult)
        {
            double result = AASVSOP87A_Mercury.Y(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2341970.0, -0.02298199117794204)]
        public void ZTest(double jd, double expectedResult)
        {
            double result = AASVSOP87A_Mercury.Z(jd);
            Assert.Equal(expectedResult, result);
        }
        
        [Theory]
        [InlineData(2341970.0, -0.012778874946309993)]
        public void XDashTest(double jd, double expectedResult)
        {
            double result = AASVSOP87A_Mercury.X_DASH(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2341970.0, 0.0284637828498624)]
        public void YDashTest(double jd, double expectedResult)
        {
            double result = AASVSOP87A_Mercury.Y_DASH(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2341970.0, 0.0034966930751645039)]
        public void ZDashTest(double jd, double expectedResult)
        {
            double result = AASVSOP87A_Mercury.Z_DASH(jd);
            Assert.Equal(expectedResult, result);
        }
    }
}