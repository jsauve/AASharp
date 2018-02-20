using Xunit;

namespace AASharp.Tests
{
    public class MarsTest
    {
        [Theory]
        [InlineData(2448935.500683, false, 78.473820271893032)]
        [InlineData(2448935.500683, true, 78.47378481953119)]
        public void EclipticLongitudeTest(double JD, bool bHighPrecision, double expectedLongitude)
        {
            double longitude = AASMars.EclipticLongitude(JD, bHighPrecision);
            Assert.Equal(expectedLongitude, longitude);
        }

        [Theory]
        [InlineData(2448935.500683, false, 0.89640101634757841)]
        [InlineData(2448935.500683, true, 0.89632892538680353)]
        public void EclipticLatitudeTest(double JD, bool bHighPrecision, double expectedEclipticLatitude)
        {
            double eclipticLatitude = AASMars.EclipticLatitude(JD, bHighPrecision);
            Assert.Equal(expectedEclipticLatitude, eclipticLatitude);
        }

        [Theory]
        [InlineData(2448935.500683, false, 1.5416610439393872)]
        [InlineData(2448935.500683, true, 1.5416593348419347)]
        public void RadiusVectorTest(double JD, bool bHighPrecision, double expectedRadiusVector)
        {
            double radiusVector = AASMars.RadiusVector(JD, bHighPrecision);
            Assert.Equal(expectedRadiusVector, radiusVector);
        }
    }
}