using Xunit;

namespace AASharp.Tests
{
    public class JupiterTest
    {
        [Theory]
        [InlineData(2448972.50068, false, 181.88221315727958)]
        [InlineData(2448972.50068, true, 181.88219374695817)]
        public void EclipticLongitudeTest(double JD, bool bHighPrecision, double expectedLongitude)
        {
            double longitude = AASJupiter.EclipticLongitude(JD, bHighPrecision);
            Assert.Equal(expectedLongitude, longitude);
        }

        [Theory]
        [InlineData(2448972.50068, false, 1.2905488926450197)]
        [InlineData(2448972.50068, true, 1.2904742154561457)]
        public void EclipticLatitudeTest(double JD, bool bHighPrecision, double expectedEclipticLatitude)
        {
            double eclipticLatitude = AASJupiter.EclipticLatitude(JD, bHighPrecision);
            Assert.Equal(expectedEclipticLatitude, eclipticLatitude);
        }

        [Theory]
        [InlineData(2448972.50068, false, 5.4464378698661662)]
        [InlineData(2448972.50068, true, 5.4464231986526404)]
        public void RadiusVectorTest(double JD, bool bHighPrecision, double expectedRadiusVector)
        {
            double radiusVector = AASJupiter.RadiusVector(JD, bHighPrecision);
            Assert.Equal(expectedRadiusVector, radiusVector);
        }
    }
}