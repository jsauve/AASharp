using Xunit;

namespace AASharp.Tests
{
    public class MoonPerigeeApogeeTest
    {
        [Theory]
        [InlineData(1988.75, -148.72671000000037)]
        [InlineData(1990.9, -120.22738499999915)]
        [InlineData(1930.0, -927.48733500000037)]
        public void KTest(double year, double expectedK)
        {
            double moonK = AASMoonPerigeeApogee.K(year);
            Assert.Equal(expectedK, moonK);
        }

        [Theory]
        [InlineData(-148.5, 2447442.8191329385)]
        public void MeanApogeeTest(double k, double expectedMeanApogee)
        {
            double moonApogee = AASMoonPerigeeApogee.MeanApogee(k);
            Assert.Equal(expectedMeanApogee, moonApogee);
        }

        [Theory]
        [InlineData(-148.5, 2447442.3543003569)]
        public void TrueApogeeTest(double k, double expectedTrueApogee)
        {
            double moonApogee = AASMoonPerigeeApogee.TrueApogee(k);
            Assert.Equal(expectedTrueApogee, moonApogee);
        }

        [Theory]
        [InlineData(-148.5, 0.90018847822015136)]
        public void ApogeeParallaxTest(double k, double expectedApogeeParallax)
        {
            double moonApogeeParallax = AASMoonPerigeeApogee.ApogeeParallax(k);
            Assert.Equal(expectedApogeeParallax, moonApogeeParallax);
        }
        
        [Theory]
        [InlineData(-120.0, 2448228.1238077171)]
        public void MeanPerigeeTest(double k, double expectedMeanPerigee)
        {
            double moonPerigee = AASMoonPerigeeApogee.MeanPerigee(k);
            Assert.Equal(expectedMeanPerigee, moonPerigee);
        }

        [Theory]
        [InlineData(-120.0, 2448227.9504968375)]
        [InlineData(-927.0, 2425991.5174718117)]
        public void TruePerigeeTest(double k, double expectedTruePerigee)
        {
            double moonPerigee = AASMoonPerigeeApogee.TruePerigee(k);
            Assert.Equal(expectedTruePerigee, moonPerigee);
        }
        
        [Theory]
        [InlineData(-927.0, 1.0254225820430043)]
        public void PerigeeParallaxTest(double k, double expectedPerigeeParallax)
        {
            double moonPerigeeParallax = AASMoonPerigeeApogee.PerigeeParallax(k);
            Assert.Equal(expectedPerigeeParallax, moonPerigeeParallax);
        }
    }
}