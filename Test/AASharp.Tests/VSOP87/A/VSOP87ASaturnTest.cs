using Xunit;

namespace AASharp.Tests.VSOP87.A
{
    public class VSOP87ASaturnTest
    {
        [Theory]
        [InlineData(2341970.0, 8.993475899203041)]
        public void XTest(double jd, double expectedResult)
        {
            double result = AASVSOP87A_Saturn.X(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2341970.0, -3.7883225436938956)]
        public void YTest(double jd, double expectedResult)
        {
            double result = AASVSOP87A_Saturn.Y(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2341970.0, -0.28663892338533059)]
        public void ZTest(double jd, double expectedResult)
        {
            double result = AASVSOP87A_Saturn.Z(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2341970.0, 0.0018541529796600046)]
        public void XDashTest(double jd, double expectedResult)
        {
            double result = AASVSOP87A_Saturn.X_DASH(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2341970.0, 0.0051256054994256129)]
        public void YDashTest(double jd, double expectedResult)
        {
            double result = AASVSOP87A_Saturn.Y_DASH(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2341970.0, -0.00016510886425139275)]
        public void ZDashTest(double jd, double expectedResult)
        {
            double result = AASVSOP87A_Saturn.Z_DASH(jd);
            Assert.Equal(expectedResult, result);
        }
    }
}