using Xunit;

namespace AASharp.Tests
{
    public class MoonIlluminatedFractionTest
    {
        [Theory]
        [InlineData(8.97922, 13.7684, 1.377194, 8.6964, 110.79269758148001)]
        public void GeocentricElongationTest(double objectAlpha, double objectDelta, double sunAlpha, double sunDelta, double expectedGeocentricElongation)
        {
            double moonGeocentricElongation = AASMoonIlluminatedFraction.GeocentricElongation(objectAlpha, objectDelta, sunAlpha, sunDelta);
            Assert.Equal(expectedGeocentricElongation, moonGeocentricElongation);
        }

        [Theory]
        [InlineData(110.79269758148001, 368410, 149971520, 69.075835166669421)]
        public void PhaseAngleTest(double geocentricElongation, double earthObjectDistance, double earthSunDistance, double expectedPhaseAngle)
        {
            double moonPhaseAngle = AASMoonIlluminatedFraction.PhaseAngle(geocentricElongation, earthObjectDistance, earthSunDistance);
            Assert.Equal(expectedPhaseAngle, moonPhaseAngle);
        }

        [Theory]
        [InlineData(69.075835166669421, 0.67856598691668246)]
        public void IlluminatedFractionTest(double phaseAngle, double expectedIlluminatedFraction)
        {
            double moonIlluminatedFraction = AASMoonIlluminatedFraction.IlluminatedFraction(phaseAngle);
            Assert.Equal(expectedIlluminatedFraction, moonIlluminatedFraction);
        }

        [Theory]
        [InlineData(1.3771944444444444, 8.6964, 134.6885 / 15, 13.7684, 285.04418130945282)]
        public void PositionAngleTest(double alpha0, double delta0, double alpha, double delta, double expectedPositionAngle)
        {
            double moonPositionAngle = AASMoonIlluminatedFraction.PositionAngle(alpha0, delta0, alpha, delta);
            Assert.Equal(expectedPositionAngle, moonPositionAngle);
        }
    }
}