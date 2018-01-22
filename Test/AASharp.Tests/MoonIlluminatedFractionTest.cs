using Xunit;

namespace AASharp.Tests
{
    public class MoonIlluminatedFractionTest
    {
        [Theory]
        [InlineData(8.97922, 13.7684, 1.377194, 8.6964, 110.79269758148001)]
        public void GeocentricElongationTest(double ObjectAlpha, double ObjectDelta, double SunAlpha, double SunDelta, double expectedGeocentricElongation)
        {
            double moonGeocentricElongation = AASMoonIlluminatedFraction.GeocentricElongation(8.97922, 13.7684, 1.377194, 8.6964);
            Assert.Equal(expectedGeocentricElongation, moonGeocentricElongation);
        }

        [Theory]
        [InlineData(110.79269758148001, 368410, 149971520, 69.075835166669421)]
        public void PhaseAngleTest(double GeocentricElongation, double EarthObjectDistance, double EarthSunDistance, double expectedPhaseAngle)
        {
            double moonPhaseAngle = AASMoonIlluminatedFraction.PhaseAngle(110.79269758148001, 368410, 149971520);
            Assert.Equal(expectedPhaseAngle, moonPhaseAngle);
        }

        [Theory]
        [InlineData(69.075835166669421, 0.67856598691668246)]
        public void IlluminatedFractionTest(double PhaseAngle, double expectedIlluminatedFraction)
        {
            double moonIlluminatedFraction = AASMoonIlluminatedFraction.IlluminatedFraction(PhaseAngle);
            Assert.Equal(expectedIlluminatedFraction, moonIlluminatedFraction);
        }

        [Theory]
        [InlineData(1.3771944444444444, 8.6964, 134.6885 / 15, 13.7684, 285.04418130945282)]
        public void PositionAngleTest(double Alpha0, double Delta0, double Alpha, double Delta, double expectedPositionAngle)
        {
            double moonPositionAngle = AASMoonIlluminatedFraction.PositionAngle(Alpha0, Delta0, Alpha, Delta);
            Assert.Equal(expectedPositionAngle, moonPositionAngle);
        }
    }
}