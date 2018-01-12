using Xunit;

namespace AASharp.Tests
{
    public class PlutoTest
    {
        [Theory]
        [InlineData(2448908.5, 232.74071142300883)]
        public void EclipticLongitudeTest(double JD, double expectedLongitude)
        {
            double longitude = AASPluto.EclipticLongitude(JD);
            Assert.Equal(expectedLongitude, longitude);
        }

        [Theory]
        [InlineData(2448908.5, 14.587817301722664)]
        public void EclipticLatitudeTest(double JD, double expectedEclipticLatitude)
        {
            double eclipticLatitude = AASPluto.EclipticLatitude(JD);
            Assert.Equal(expectedEclipticLatitude, eclipticLatitude);
        }

        [Theory]
        [InlineData(2448908.5, 29.711110981008407)]
        public void RadiusVectorTest(double JD, double expectedRadiusVector)
        {
            double radiusVector = AASPluto.RadiusVector(JD);
            Assert.Equal(expectedRadiusVector, radiusVector);
        }
    }
}