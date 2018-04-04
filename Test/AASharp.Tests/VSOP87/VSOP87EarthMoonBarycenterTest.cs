using Xunit;

namespace AASharp.Tests.VSOP87
{
    public class VSOP87EarthMoonBarycenterTest
    {
        [Theory]
        [InlineData(2305445.0, 0.99999952777205126)]
        public void ATest(double jd, double expectedResult)
        {
            double result = AASVSOP87_EMB.A(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2305445.0, 1.797273610989464)]
        public void LTest(double jd, double expectedResult)
        {
            double result = AASVSOP87_EMB.L(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2305445.0, 6.2797648157284165)]
        public void KTest(double jd, double expectedResult)
        {
            double result = AASVSOP87_EMB.K(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2305445.0, 0.016500409730078248)]
        public void HTest(double jd, double expectedResult)
        {
            double result = AASVSOP87_EMB.H(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2305445.0, 0.0004561548571621085)]
        public void QTest(double jd, double expectedResult)
        {
            double result = AASVSOP87_EMB.Q(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2305445.0, 6.283151624449351)]
        public void PTest(double jd, double expectedResult)
        {
            double result = AASVSOP87_EMB.P(jd);
            Assert.Equal(expectedResult, result);
        }
    }
}