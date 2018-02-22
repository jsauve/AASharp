using Xunit;

namespace AASharp.Tests
{
    public class SaturnTest
    {
        [Theory]
        [InlineData(2448972.50068, false, 319.19339570372551)]
        [InlineData(2448972.50068, true, 319.19354787916035)]
        public void EclipticLongitudeTest(double JD, bool bHighPrecision, double expectedLongitude)
        {
            double longitude = AASSaturn.EclipticLongitude(JD, bHighPrecision);
            Assert.Equal(expectedLongitude, longitude);
        }

        [Theory]                          
        [InlineData(2448972.50068, false, -1.0752788627316321)]
        [InlineData(2448972.50068, true, -1.0752714227378988)]
        public void EclipticLatitudeTest(double JD, bool bHighPrecision, double expectedEclipticLatitude)
        {
            double eclipticLatitude = AASSaturn.EclipticLatitude(JD, bHighPrecision);
            Assert.Equal(expectedEclipticLatitude, eclipticLatitude);
        }

        [Theory]
        [InlineData(2448972.50068, false, 9.8678269913865186)]
        [InlineData(2448972.50068, true, 9.8678688953694156)]
        public void RadiusVectorTest(double JD, bool bHighPrecision, double expectedRadiusVector)
        {
            double radiusVector = AASSaturn.RadiusVector(JD, bHighPrecision);
            Assert.Equal(expectedRadiusVector, radiusVector);
        }
    }
}