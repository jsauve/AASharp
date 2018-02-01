using Xunit;

namespace AASharp.Tests
{
    public class StellarMagnitudesTest
    {
        [Theory]
        [InlineData(500, 6.7474250108400469)]
        [InlineData(6.1944107507678146, 1.98)]
        public void TheoryTest(double brightnessRatio, double expectedDifference)
        {
            double magDiff = AASStellarMagnitudes.MagnitudeDifference(brightnessRatio);
            Assert.Equal(expectedDifference, magDiff);
        }

        [Fact]
        public void CombinedMagnitudeTest()
        {
            double combinedMag = AASStellarMagnitudes.CombinedMagnitude(1.96, 2.89);
            Assert.Equal(1.5757527397308571, combinedMag);
        }

        [Fact]
        public void CombinedMagnitudeArrayTest()
        {
            double[] mags = { 4.73, 5.22, 5.60 };
            double combinedMag = AASStellarMagnitudes.CombinedMagnitude(3, mags);
            Assert.Equal(3.9319532160818769, combinedMag);
        }

        [Fact]
        public void BrightnessRatioTest()
        {
            double brightnessRatio = AASStellarMagnitudes.BrightnessRatio(0.14, 2.12);
            Assert.Equal(6.1944107507678146, brightnessRatio);
        }

    }
}