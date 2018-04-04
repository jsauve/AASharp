using Xunit;

namespace AASharp.Tests.VSOP87
{
    public class VSOP87MercuryTest
    {
        [Theory]
        [InlineData(2451545.0, 0.38709821216504059)]
        public void ATest(double jd, double expectedResult)
        {
            double result = AASVSOP87_Mercury.A(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2451545.0, 4.4026057778926564)]
        public void LTest(double jd, double expectedResult)
        {
            double result = AASVSOP87_Mercury.L(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2451545.0, 0.044664751792738176)]
        public void KTest(double jd, double expectedResult)
        {
            double result = AASVSOP87_Mercury.K(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2451545.0, 0.20072089579443869)]
        public void HTest(double jd, double expectedResult)
        {
            double result = AASVSOP87_Mercury.H(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2451545.0, 0.040616154121204714)]
        public void QTest(double jd, double expectedResult)
        {
            double result = AASVSOP87_Mercury.Q(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2451545.0, 0.045635503051191392)]
        public void PTest(double jd, double expectedResult)
        {
            double result = AASVSOP87_Mercury.P(jd);
            Assert.Equal(expectedResult, result);
        }
    }
}