using Xunit;

namespace AASharp.Tests.VSOP87
{
    public class VSOP87NeptuneTest
    { 
        [Theory]
        [InlineData(2305445.0, 30.270216162268483)]
        public void ATest(double jd, double expectedResult)
        {
            double result = AASVSOP87_Neptune.A(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2305445.0, 2.6344819844348208)]
        public void LTest(double jd, double expectedResult)
        {
            double result = AASVSOP87_Neptune.L(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2305445.0, 0.00012666240337773848)]
        public void KTest(double jd, double expectedResult)
        {
            double result = AASVSOP87_Neptune.K(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2305445.0, 0.0095018714045322587)]
        public void HTest(double jd, double expectedResult)
        {
            double result = AASVSOP87_Neptune.H(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2305445.0, 6.2729100251554142)]
        public void QTest(double jd, double expectedResult)
        {
            double result = AASVSOP87_Neptune.Q(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2305445.0, 0.01149740601924497)]
        public void PTest(double jd, double expectedResult)
        {
            double result = AASVSOP87_Neptune.P(jd);
            Assert.Equal(expectedResult, result);
        }
    }
}