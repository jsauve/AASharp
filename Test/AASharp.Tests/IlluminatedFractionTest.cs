using Xunit;

namespace AASharp.Tests
{
    public class IlluminatedFractionTest
    {
        [Theory]
        [InlineData(0.724604, 0.983824, 0.910947, 0.64656108707752236)]
        public void ComputeIlluminatedFractionTest(double r, double R, double Delta, double expectedK)
        {
            double k = AASIlluminatedFraction.IlluminatedFraction(r, R, Delta);
            Assert.Equal(expectedK, k);
        }

        [Theory]
        [InlineData(72.9634717092094, 0.64649066339399841)]
        [InlineData(72.963548706994558, 0.64649002094706154)]
        public void ComputeIlluminatedFractionTest2(double phaseAngle, double expectedK)
        {
            double k = AASIlluminatedFraction.IlluminatedFraction(phaseAngle);
            Assert.Equal(expectedK, k);
        }

        [Theory]
        [InlineData(0.724604, 0.983824, 0.910947, 72.955031181484486)]
        public void PhaseAngleTest(double r, double R, double Delta, double expectedPhaseAngle)
        {
            double phaseAngle = AASIlluminatedFraction.PhaseAngle(r, R, Delta);
            Assert.Equal(expectedPhaseAngle, phaseAngle);
        }

        [Theory]
        [InlineData(0.724604, 0.983824, -2.62070, 26.11428, 88.35704, 0.910947, 72.9634717092094)]
        public void PhaseAngleTest2(double R, double R0, double B, double L, double L0, double Delta, double expectedPhaseAngle)
        {
            double phaseAngle = AASIlluminatedFraction.PhaseAngle(R, R0, B, L, L0, Delta);
            Assert.Equal(expectedPhaseAngle, phaseAngle);
        }

        [Theory]
        [InlineData(0.621746, -0.664810, -0.033134, -2.62070, 26.11428, 0.910947, 72.963548706994558)]
        public void PhaseAngleRectangularTest(double x, double y, double z, double B, double L, double Delta, double expectedPhaseAngle)
        {
            double phaseAngle = AASIlluminatedFraction.PhaseAngleRectangular(x, y, z, B, L, Delta);
            Assert.Equal(expectedPhaseAngle, phaseAngle);
        }

        [Theory]
        [InlineData(0.724604, 0.910947, 72.96, -3.7725555332129925)]
        public void VenusMagnitudeMullerTest(double r, double Delta, double i, double expectedMagnitude)
        {
            double magnitude = AASIlluminatedFraction.VenusMagnitudeMuller(r, Delta, i);
            Assert.Equal(expectedMagnitude, magnitude);
        }

        [Theory]
        [InlineData(0.724604, 0.910947, 72.96, -4.2165768080630919)]
        public void VenusMagnitudeAATest(double r, double Delta, double i, double expectedMagnitude)
        {
            double magnitude = AASIlluminatedFraction.VenusMagnitudeAA(r, Delta, i);
            Assert.Equal(expectedMagnitude, magnitude);
        }
    }
}