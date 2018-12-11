using AASharp.Constellations;
using Xunit;

namespace AASharp.Tests.Constellations
{
    public class CoordinatesToConstellationTest
    {
        [Theory]
        [InlineData(0.5, 32, 2000, "And")]
        [InlineData(1.5, 48, 2000, "And")]
        public void GivenCoordinates_CorrectConstellationIsReturned(double ra, double dec, double epoch,
            string constellation)
        {
            var result = CoordinatesToConstellation.get_name(ra, dec, epoch);

            Assert.Equal(constellation, result);
        }
    }
}