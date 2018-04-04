using Xunit;

namespace AASharp.Tests.VSOP87
{
    public class VSOP87MarsTest
    {
        [Theory]
        [InlineData(2305445.0, 1.52377445051774)]
        public void ATest(double jd, double expectedResult)
        {
            double result = AASVSOP87_Mars.A(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2305445.0, 1.9938502931229038)]
        public void LTest(double jd, double expectedResult)
        {
            double result = AASVSOP87_Mars.L(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2305445.0, 0.083776741349140191)]
        public void KTest(double jd, double expectedResult)
        {
            double result = AASVSOP87_Mars.K(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2305445.0, 6.2428048880501921)]
        public void HTest(double jd, double expectedResult)
        {
            double result = AASVSOP87_Mars.H(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2305445.0, 0.010394892653336032)]
        public void QTest(double jd, double expectedResult)
        {
            double result = AASVSOP87_Mars.Q(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2305445.0, 0.012712659650461935)]
        public void PTest(double jd, double expectedResult)
        {
            double result = AASVSOP87_Mars.P(jd);
            Assert.Equal(expectedResult, result);
        }
    }
}