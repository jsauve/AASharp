using Xunit;

namespace AASharp.Tests
{
    public class KeplerTest
    {
        [Theory]
        [InlineData(5, 0.1, 100, 5.5545892538723143)]
        [InlineData(5, 0.9, 100, 33.344446958990886)]
        [InlineData(-5, 0.9, 100, -33.344446958990886)]
        public void CalculateTest(double M, double e, int nIterations, double expectedResult)
        {
            double e0 = AASKepler.Calculate(M, e, nIterations);
            Assert.Equal(expectedResult, e0);
        }
    }
}