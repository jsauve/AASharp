using Xunit;

namespace AASharp.Tests
{
    public class NeptuneTest
    {
        [Theory]
        [InlineData(2448935.500683, false, 288.294033103193)]
        [InlineData(2448935.500683, true, 288.29382816201166)]
        public void EclipticLongitudeTest(double JD, bool bHighPrecision, double expectedLongitude)
        {
            double longitude = AASNeptune.EclipticLongitude(JD, bHighPrecision);
            Assert.Equal(expectedLongitude, longitude);
        }

        [Theory]
        [InlineData(2448935.500683, false, 0.70365364295795307)]
        [InlineData(2448935.500683, true, 0.70363430126627435)]
        public void EclipticLatitudeTest(double JD, bool bHighPrecision, double expectedEclipticLatitude)
        {
            double eclipticLatitude = AASNeptune.EclipticLatitude(JD, bHighPrecision);
            Assert.Equal(expectedEclipticLatitude, eclipticLatitude);
        }

        [Theory]
        [InlineData(2448935.500683, false, 30.188787306609946)]
        [InlineData(2448935.500683, true, 30.188829266420498)]
        public void RadiusVectorTest(double JD, bool bHighPrecision, double expectedRadiusVector)
        {
            double radiusVector = AASNeptune.RadiusVector(JD, bHighPrecision);
            Assert.Equal(expectedRadiusVector, radiusVector);
        }
    }
}