using Xunit;

namespace AASharp.Tests
{
    public class EarthTest
    {
        [Theory]
        [InlineData(2448908.5, false, 19.907371990723732)]
        public void EclipticLongitudeTest(double JD, bool bHighPrecision, double expectedLongitude)
        {
            double longitude = AASEarth.EclipticLongitude(JD, bHighPrecision);
            Assert.Equal(expectedLongitude, longitude);
        }

        [Theory]
        [InlineData(2448908.5, false, -0.0001790125040739333)]
        public void EclipticLatitudeTest(double JD, bool bHighPrecision, double expectedEclipticLatitude)
        {
            double eclipticLatitude = AASEarth.EclipticLatitude(JD, bHighPrecision);
            Assert.Equal(expectedEclipticLatitude, eclipticLatitude);
        }

        [Theory]
        [InlineData(2448908.5, false, 0.99760774951494113)]
        public void RadiusVectorTest(double JD, bool bHighPrecision, double expectedRadiusVector)
        {
            double radiusVector = AASEarth.RadiusVector(JD, bHighPrecision);
            Assert.Equal(expectedRadiusVector, radiusVector);
        }

        [Theory]
        [InlineData(2448908.5, false, 20.008208557572743)]
        public void EclipticLongitudeJ2000Test(double JD, bool bHighPrecision, double expectedLongitude)
        {
            double longitude = AASEarth.EclipticLongitudeJ2000(JD, bHighPrecision);
            Assert.Equal(expectedLongitude, longitude);
        }

        [Theory]
        [InlineData(2448908.5, false, 0.00022101945021280026)]
        public void EclipticLatitudeJ2000Test(double JD, bool bHighPrecision, double expectedEclipticLatitude)
        {
            double eclipticLatitude = AASEarth.EclipticLatitudeJ2000(JD, bHighPrecision);
            Assert.Equal(expectedEclipticLatitude, eclipticLatitude);
        }
    }
}