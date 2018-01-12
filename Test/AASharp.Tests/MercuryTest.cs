using Xunit;

namespace AASharp.Tests
{
    public class MercuryTest
    {
        [Theory]
        [InlineData(2448976.5, false, 202.25641578265095)]
        public void EclipticLongitudeTest(double JD, bool bHighPrecision, double expectedLongitude)
        {
            double longitude = AASMercury.EclipticLongitude(JD, bHighPrecision);
            Assert.Equal(expectedLongitude, longitude);
        }

        [Theory]
        [InlineData(2448976.5, false, 3.0820706391827608)]
        public void EclipticLatitudeTest(double JD, bool bHighPrecision, double expectedEclipticLatitude)
        {
            double eclipticLatitude = AASMercury.EclipticLatitude(JD, bHighPrecision);
            Assert.Equal(expectedEclipticLatitude, eclipticLatitude);
        }

        [Theory]
        [InlineData(2448976.5, false, 0.41994054484246085)]
        public void RadiusVectorTest(double JD, bool bHighPrecision, double expectedRadiusVector)
        {
            double radiusVector = AASMercury.RadiusVector(JD, bHighPrecision);
            Assert.Equal(expectedRadiusVector, radiusVector);
        }
    }
}