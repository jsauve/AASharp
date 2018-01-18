using Xunit;

namespace AASharp.Tests
{
    public class EquationOfTimeTest
    {
        [Theory]
        [InlineData(2448908.5, false, 13.709950290402466)]
        public void CalculateTest(double jd, bool highPrecision, double expectedResult)
        {
            double e = AASEquationOfTime.Calculate(jd, highPrecision);
            Assert.Equal(expectedResult, e);
        }
    }
}