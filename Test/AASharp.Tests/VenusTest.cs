using Xunit;

namespace AASharp.Tests
{
    public class VenusTest
    {
        [Theory]
        [InlineData(2448976.5, false, 26.114283571919259)]
        public void EclipticLongitudeTest(double JD, bool bHighPrecision, double expectedLongitude)
        {
            double longitude = AASVenus.EclipticLongitude(JD, bHighPrecision);
            Assert.Equal(expectedLongitude, longitude);
        }

        [Theory]
        [InlineData(2448976.5, false, -2.6207031027030725)]
        public void EclipticLatitudeTest(double JD, bool bHighPrecision, double expectedEclipticLatitude)
        {
            double eclipticLatitude = AASVenus.EclipticLatitude(JD, bHighPrecision);
            Assert.Equal(expectedEclipticLatitude, eclipticLatitude);
        }

        [Theory]
        [InlineData(2448976.5, false, 0.72460293671652987)]
        public void RadiusVectorTest(double JD, bool bHighPrecision, double expectedRadiusVector)
        {
            double radiusVector = AASVenus.RadiusVector(JD, bHighPrecision);
            Assert.Equal(expectedRadiusVector, radiusVector);
        }
    }
}