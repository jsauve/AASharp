using Xunit;

namespace AASharp.Tests
{
    public class ParallacticTest
    {
        [Fact]
        public void ParallacticAngleTest()
        {
            double hourAngle = AASParallactic.ParallacticAngle(-3, 10, 20);
            Assert.Equal(-96.146756941092, hourAngle);
        }

        [Fact]
        public void EclipticLongitudeOnHorizonTest()
        {
            double eclipticLongitude = AASParallactic.EclipticLongitudeOnHorizon(5, 23.44, 51);
            Assert.Equal(349.35830480234671, eclipticLongitude);
        }

        [Fact]
        public void AngleBetweenEclipticAndHorizonTest()
        {
            double eclipticAngle = AASParallactic.AngleBetweenEclipticAndHorizon(5, 23.44, 51);
            Assert.Equal(61.887310198300845, eclipticAngle);
        }

        [Fact]
        public void AngleBetweenNorthCelestialPoleAndNorthPoleOfEclipticTest()
        {
            double angle = AASParallactic.AngleBetweenNorthCelestialPoleAndNorthPoleOfEcliptic(90, 0, 23.44);
            Assert.Equal(180, angle);
        }
    }
}