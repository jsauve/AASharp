using Xunit;

namespace AASharp.Tests
{
    public class MoonPhasesTest
    {
        [Theory]
        [InlineData(1977.13, -282.86759499999863)]
        [InlineData(2044, 544.21399999999994)]
        public void KTest(double year, double expectedK)
        {
            double k = AASMoonPhases.K(year);
            Assert.Equal(expectedK, k);
        }

        [Theory]
        [InlineData(-283, 2443192.6511826837)]
        [InlineData(544.75, 2467636.4918638906)]
        public void TruePhaseTest(double k, double expectedTruePhase)
        {
            double truePhase = AASMoonPhases.TruePhase(k);
            Assert.Equal(expectedTruePhase, truePhase);
        }
    }
}