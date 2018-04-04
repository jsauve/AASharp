using Xunit;

namespace AASharp.Tests.VSOP87.A
{
    public class VSOP87AEarthMoonBarycenterTest
    {
        [Theory]
        [InlineData(2341970.0, -0.21043432211989979)]
        public void XTest(double jd, double expectedResult)
        {
            double result = AASVSOP87A_EMB.X(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2341970.0, 0.96036427817694248)]
        public void YTest(double jd, double expectedResult)
        {
            double result = AASVSOP87A_EMB.Y(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2341970.0, 0.00064629446247229164)]
        public void ZTest(double jd, double expectedResult)
        {
            double result = AASVSOP87A_EMB.Z(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2341970.0, -0.0170893882756738)]
        public void XDashTest(double jd, double expectedResult)
        {
            double result = AASVSOP87A_EMB.X_DASH(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2341970.0, -0.0037428931251219932)]
        public void YDashTest(double jd, double expectedResult)
        {
            double result = AASVSOP87A_EMB.Y_DASH(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2341970.0, -3.4648411816159188e-006)]
        public void ZDashTest(double jd, double expectedResult)
        {
            double result = AASVSOP87A_EMB.Z_DASH(jd);
            Assert.Equal(expectedResult, result);
        }
    }
}