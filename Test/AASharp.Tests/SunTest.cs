using Xunit;

namespace AASharp.Tests
{
    public class SunTest
    {
        [Theory]
        [InlineData(2448908.5, false, 199.90737199072373)]
        public void GeometricEclipticLongitudeTest(double JD, bool bHighPrecision, double expectedLongitude)
        {
            double longitude = AASSun.GeometricEclipticLongitude(JD, bHighPrecision);
            Assert.Equal(expectedLongitude, longitude);
        }

        [Theory]
        [InlineData(2448908.5, false, -0.0001790125040739333)]
        public void GeometricEclipticLatitudeTest(double JD, bool bHighPrecision, double expectedLatitude)
        {
            double latitude = AASSun.GeometricEclipticLatitude(JD, bHighPrecision);
            Assert.Equal(expectedLatitude, latitude);
        }

        [Theory]
        [InlineData(2448908.5, false, -2.509162310337956E-05)]
        public void CorrectionInLongitudeTest(double JD, bool bHighPrecision, double expectedCorrection)
        {
            double latitude = AASSun.GeometricEclipticLatitude(JD, bHighPrecision);
            double longitude = AASSun.GeometricEclipticLongitude(JD, bHighPrecision);
            double sunLongitudeCorrection = AASFK5.CorrectionInLongitude(longitude, latitude, JD);
            Assert.Equal(expectedCorrection, sunLongitudeCorrection);
        }

        [Theory]
        [InlineData(2448908.5, false, -6.4993503750233375E-06)]
        public void CorrectionInLatitudeTest(double JD, bool bHighPrecision, double expectedCorrection)
        {
            double longitude = AASSun.GeometricEclipticLongitude(JD, bHighPrecision);
            double sunLatCorrection = AASFK5.CorrectionInLatitude(longitude, JD);
            Assert.Equal(expectedCorrection, sunLatCorrection);
        }
        
        [Theory]
        [InlineData(2448908.5, false, 199.90606043824027)]
        public void ApparentEclipticLongitudeTest(double JD, bool bHighPrecision, double expectedLongitude)
        {
            double longitude = AASSun.ApparentEclipticLongitude(JD, bHighPrecision);
            Assert.Equal(expectedLongitude, longitude);
        }

        [Theory]
        [InlineData(2448908.5, false, -0.00018551185444895662)]
        public void ApparentEclipticLatitudeTest(double JD, bool bHighPrecision, double expectedLatitude)
        {
            double latitude = AASSun.ApparentEclipticLatitude(JD, bHighPrecision);
            Assert.Equal(expectedLatitude, latitude);
        }

        [Theory]
        [InlineData(2448908.5, false, 13.225202775731649, -7.784202092067309)]
        public void Ecliptic2EquatorialTest(double JD, bool bHighPrecision, double expectedX, double expectedY)
        {
            double sunLong = AASSun.ApparentEclipticLongitude(JD, bHighPrecision);
            double sunLat = AASSun.ApparentEclipticLatitude(JD, bHighPrecision);
            var equatorial = AASCoordinateTransformation.Ecliptic2Equatorial(sunLong, sunLat, AASNutation.TrueObliquityOfEcliptic(JD));
            Assert.Equal(expectedX, equatorial.X);
            Assert.Equal(expectedY, equatorial.Y);
        }

        [Theory]
        [InlineData(2448908.5, false, -0.93799517293249224, -0.31165190668881765, -0.13512722340385019)]
        public void EquatorialRectangularCoordinatesMeanEquinoxTest(double JD, bool bHighPrecision, double expectedX, double expectedY, double expectedZ)
        {
            AAS3DCoordinate sunCoord = AASSun.EquatorialRectangularCoordinatesMeanEquinox(JD, bHighPrecision);
            Assert.Equal(expectedX, sunCoord.X);
            Assert.Equal(expectedY, sunCoord.Y);
            Assert.Equal(expectedZ, sunCoord.Z);
        }

        [Theory]
        [InlineData(2448908.5, false, -0.93739574827102456, -0.34133624624534392, 3.848288969956851E-06)]
        public void EclipticRectangularCoordinatesJ2000Test(double JD, bool bHighPrecision, double expectedX, double expectedY, double expectedZ)
        {
            AAS3DCoordinate sunCoord = AASSun.EclipticRectangularCoordinatesJ2000(JD, bHighPrecision);
            Assert.Equal(expectedX, sunCoord.X);
            Assert.Equal(expectedY, sunCoord.Y);
            Assert.Equal(expectedZ, sunCoord.Z);
        }

        [Theory]
        [InlineData(2448908.5, false, -0.93739589858258876, -0.31317098951312067, -0.13577217145017872)]
        public void EquatorialRectangularCoordinatesJ2000Test(double JD, bool bHighPrecision, double expectedX, double expectedY, double expectedZ)
        {
            AAS3DCoordinate sunCoord = AASSun.EquatorialRectangularCoordinatesJ2000(JD, bHighPrecision);
            Assert.Equal(expectedX, sunCoord.X);
            Assert.Equal(expectedY, sunCoord.Y);
            Assert.Equal(expectedZ, sunCoord.Z);
        }

        [Theory]
        [InlineData(2448908.5, false, -0.94148689416948839, -0.30266864247906955, -0.13120725183385126)]
        public void EquatorialRectangularCoordinatesB1950Test(double JD, bool bHighPrecision, double expectedX, double expectedY, double expectedZ)
        {
            AAS3DCoordinate sunCoord = AASSun.EquatorialRectangularCoordinatesB1950(JD, bHighPrecision);
            Assert.Equal(expectedX, sunCoord.X);
            Assert.Equal(expectedY, sunCoord.Y);
            Assert.Equal(expectedZ, sunCoord.Z);
        }

        [Theory]
        [InlineData(2448908.5, 2467616.0, false, -0.93367982031161023, -0.32237720828350458, -0.13977178046585792)]
        public void EquatorialRectangularCoordinatesAnyEquinoxTest(double JD, double JDEquinox, bool bHighPrecision, double expectedX, double expectedY, double expectedZ)
        {
            AAS3DCoordinate sunCoord = AASSun.EquatorialRectangularCoordinatesAnyEquinox(JD, JDEquinox, bHighPrecision);
            Assert.Equal(expectedX, sunCoord.X);
            Assert.Equal(expectedY, sunCoord.Y);
            Assert.Equal(expectedZ, sunCoord.Z);
        }
    }
}