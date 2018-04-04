using Xunit;

namespace AASharp.Tests.VSOP87
{
    public class VSOP87SaturnTest
    {
        [Theory]
        [InlineData(2305445.0, 9.5727100003071222)]
        public void ATest(double jd, double expectedResult)
        {
            double result = AASVSOP87_Saturn.A(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2305445.0, 3.5107821038828035)]
        public void LTest(double jd, double expectedResult)
        {
            double result = AASVSOP87_Saturn.L(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2305445.0, 6.2783634260125725)]
        public void KTest(double jd, double expectedResult)
        {
            double result = AASVSOP87_Saturn.K(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2305445.0, 0.057551420270600201)]
        public void HTest(double jd, double expectedResult)
        {
            double result = AASVSOP87_Saturn.H(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2305445.0, 6.2741504082794179)]
        public void QTest(double jd, double expectedResult)
        {
            double result = AASVSOP87_Saturn.Q(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2305445.0, 0.01965793759137267)]
        public void PTest(double jd, double expectedResult)
        {
            double result = AASVSOP87_Saturn.P(jd);
            Assert.Equal(expectedResult, result);
        }
    }
}