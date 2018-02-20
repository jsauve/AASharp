using Xunit;

namespace AASharp.Tests
{
    public class UranusTest
    {
        [Theory]
        [InlineData(2448976.5, false, 287.89089156624902)]
        [InlineData(2448976.5, true, 287.89104181385028)]
        public void EclipticLongitudeTest(double JD, bool bHighPrecision, double expectedLongitude)
        {
            double longitude = AASUranus.EclipticLongitude(JD, bHighPrecision);
            Assert.Equal(expectedLongitude, longitude);
        }

        [Theory]
        [InlineData(2448976.5, false, -0.43064206021268953)]
        [InlineData(2448976.5, true, -0.4306637836173195)]
        public void EclipticLatitudeTest(double JD, bool bHighPrecision, double expectedEclipticLatitude)
        {
            double eclipticLatitude = AASUranus.EclipticLatitude(JD, bHighPrecision);
            Assert.Equal(expectedEclipticLatitude, eclipticLatitude);
        }

        [Theory]
        [InlineData(2448976.5, false, 19.570256184055342)]
        [InlineData(2448976.5, true, 19.570237704842476)]
        public void RadiusVectorTest(double JD, bool bHighPrecision, double expectedRadiusVector)
        {
            double radiusVector = AASUranus.RadiusVector(JD, bHighPrecision);
            Assert.Equal(expectedRadiusVector, radiusVector);
        }
    }
}