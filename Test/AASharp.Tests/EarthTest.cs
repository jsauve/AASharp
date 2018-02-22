using Xunit;

namespace AASharp.Tests
{
    public class EarthTest
    {
        [Theory]
        [InlineData(2448908.5, false, 19.907371990723732)]
        [InlineData(2448908.5, true, 19.907297242049481)]
        public void EclipticLongitudeTest(double JD, bool bHighPrecision, double expectedLongitude)
        {
            double longitude = AASEarth.EclipticLongitude(JD, bHighPrecision);
            Assert.Equal(expectedLongitude, longitude);
        }

        [Theory]
        [InlineData(2448908.5, false, -0.0001790125040739333)]
        [InlineData(2448908.5, true, -0.00020664594472918907)]
        public void EclipticLatitudeTest(double JD, bool bHighPrecision, double expectedEclipticLatitude)
        {
            double eclipticLatitude = AASEarth.EclipticLatitude(JD, bHighPrecision);
            Assert.Equal(expectedEclipticLatitude, eclipticLatitude);
        }

        [Theory]
        [InlineData(2448908.5, false, 0.99760774951494113)]
        [InlineData(2448908.5, true, 0.99760852023559332)]
        public void RadiusVectorTest(double JD, bool bHighPrecision, double expectedRadiusVector)
        {
            double radiusVector = AASEarth.RadiusVector(JD, bHighPrecision);
            Assert.Equal(expectedRadiusVector, radiusVector);
        }

        [Theory]
        [InlineData(2448908.5, false, 20.008208557572743)]
        [InlineData(2448908.5, true, 20.008133984452662)]
        public void EclipticLongitudeJ2000Test(double JD, bool bHighPrecision, double expectedLongitude)
        {
            double longitude = AASEarth.EclipticLongitudeJ2000(JD, bHighPrecision);
            Assert.Equal(expectedLongitude, longitude);
        }

        [Theory]
        [InlineData(2448908.5, false, 0.00022101945021280026)]
        [InlineData(2448908.5, true, 0.00019337772806757083)]
        public void EclipticLatitudeJ2000Test(double JD, bool bHighPrecision, double expectedEclipticLatitude)
        {
            double eclipticLatitude = AASEarth.EclipticLatitudeJ2000(JD, bHighPrecision);
            Assert.Equal(expectedEclipticLatitude, eclipticLatitude);
        }
    }
}