using Xunit;

namespace AASharp.Tests.VSOP87
{
    public class VSOP87VenusTest
    { 
        [Theory]
        [InlineData(2305445.0, 0.72334441283935402)]
        public void ATest(double jd, double expectedResult)
        {
            double result = AASVSOP87_Venus.A(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2305445.0, 1.9323601819557865)]
        public void LTest(double jd, double expectedResult)
        {
            double result = AASVSOP87_Venus.L(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2305445.0, 6.2785746250752332)]
        public void KTest(double jd, double expectedResult)
        {
            double result = AASVSOP87_Venus.K(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2305445.0, 0.0052198095021948445)]
        public void HTest(double jd, double expectedResult)
        {
            double result = AASVSOP87_Venus.H(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2305445.0, 0.0062695296429578053)]
        public void QTest(double jd, double expectedResult)
        {
            double result = AASVSOP87_Venus.Q(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2305445.0, 0.028974758894741263)]
        public void PTest(double jd, double expectedResult)
        {
            double result = AASVSOP87_Venus.P(jd);
            Assert.Equal(expectedResult, result);
        }
    }
}