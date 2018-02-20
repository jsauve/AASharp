using Xunit;

namespace AASharp.Tests
{
    //TODO : add high precision test
    public class SunTest
    {
        [Theory]
        [InlineData(2448908.5, false, 199.90737199072373)]
        [InlineData(2448908.5, true, 199.90729724204948)]
        public void GeometricEclipticLongitudeTest(double JD, bool bHighPrecision, double expectedLongitude)
        {
            double longitude = AASSun.GeometricEclipticLongitude(JD, bHighPrecision);
            Assert.Equal(expectedLongitude, longitude);
        }

        [Theory]
        [InlineData(2448908.5, false, 0.0001790125040739333)]
        [InlineData(2448908.5, true, 0.00020664594472918907)]
        public void GeometricEclipticLatitudeTest(double JD, bool bHighPrecision, double expectedLatitude)
        {
            double latitude = AASSun.GeometricEclipticLatitude(JD, bHighPrecision);
            Assert.Equal(expectedLatitude, latitude);
        }

        [Theory]
        [InlineData(2448908.5, 199.90737199072373, 0.0001790125040739333, -2.5091710229953771E-005)]
        [InlineData(2448908.5, 199.90729724204948, 0.00020664594472918907, -2.5091716954612701E-005)]
        public void CorrectionInLongitudeTest(double JD, double longitude, double latitude, double expectedCorrection)
        {
            double sunLongitudeCorrection = AASFK5.CorrectionInLongitude(longitude, latitude, JD);
            Assert.Equal(expectedCorrection, sunLongitudeCorrection);
        }

        [Theory]
        [InlineData(2448908.5, 199.90737199072373, -6.4993503750233375E-006)]
        [InlineData(2448908.5, 199.90729724204948, -6.4993685653558193E-006)]
        public void CorrectionInLatitudeTest(double JD, double longitude, double expectedCorrection)
        {
            double sunLatCorrection = AASFK5.CorrectionInLatitude(longitude, JD);
            Assert.Equal(expectedCorrection, sunLatCorrection);
        }
        
        [Theory]
        [InlineData(2448908.5, false, 199.90606043815316)]
        [InlineData(2448908.5, true, 199.9059880933325)]
        public void ApparentEclipticLongitudeTest(double JD, bool bHighPrecision, double expectedLongitude)
        {
            double longitude = AASSun.ApparentEclipticLongitude(JD, bHighPrecision);
            Assert.Equal(expectedLongitude, longitude);
        }

        [Theory]
        [InlineData(2448908.5, false, 0.00017251315369890997)]
        [InlineData(2448908.5, true, 0.00020014657616383325)]
        public void ApparentEclipticLatitudeTest(double JD, bool bHighPrecision, double expectedLatitude)
        {
            double latitude = AASSun.ApparentEclipticLatitude(JD, bHighPrecision);
            Assert.Equal(expectedLatitude, latitude);
        }
        
        [Theory(Skip = "//TODO : compare with values returned by original C++ code")]
        [InlineData(2448908.5, 199.90606043815316, 0.00017251315369890997, 13.225202775731649, -7.784202092067309)]
        [InlineData(2448908.5, 199.9059880933325, 0.00020014657616383325, 13.225202775731649, -7.784202092067309)]
        public void Ecliptic2EquatorialTest(double JD, double apparentEclipticLongitude, double apparentEclipticLatitude, double expectedX, double expectedY)
        {
            var equatorial = AASCoordinateTransformation.Ecliptic2Equatorial(apparentEclipticLongitude, apparentEclipticLatitude, AASNutation.TrueObliquityOfEcliptic(JD));
            Assert.Equal(expectedX, equatorial.X);
            Assert.Equal(expectedY, equatorial.Y);
        }

        [Theory]
        [InlineData(2448908.5, false, -0.93799517293367363, -0.31165438643141002, -0.13512150407486823)]
        [InlineData(2448908.5, true, -0.9379963407549563, -0.31165369586656311, -0.13512068024426888)]
        public void EquatorialRectangularCoordinatesMeanEquinoxTest(double JD, bool bHighPrecision, double expectedX, double expectedY, double expectedZ)
        {
            AAS3DCoordinate sunCoord = AASSun.EquatorialRectangularCoordinatesMeanEquinox(JD, bHighPrecision);
            Assert.Equal(expectedX, sunCoord.X);
            Assert.Equal(expectedY, sunCoord.Y);
            Assert.Equal(expectedZ, sunCoord.Z);
        }

        [Theory]
        [InlineData(2448908.5, false, -0.93739574827102456, -0.34133624624534392, -3.848288969956851e-006)]
        [InlineData(2448908.5, true, -0.93739691673993564, -0.34133528988631667, -3.36700662392761e-006)]
        public void EclipticRectangularCoordinatesJ2000Test(double JD, bool bHighPrecision, double expectedX, double expectedY, double expectedZ)
        {
            AAS3DCoordinate sunCoord = AASSun.EclipticRectangularCoordinatesJ2000(JD, bHighPrecision);
            Assert.Equal(expectedX, sunCoord.X);
            Assert.Equal(expectedY, sunCoord.Y);
            Assert.Equal(expectedZ, sunCoord.Z);
        }

        [Theory]
        [InlineData(2448908.5, false, -0.93739589858111927, -0.31316792799156906, -0.1357792329229553)]
        [InlineData(2448908.5, true, -0.93739706704970105, -0.31316724199172363, -0.13577841093739151)]
        public void EquatorialRectangularCoordinatesJ2000Test(double JD, bool bHighPrecision, double expectedX, double expectedY, double expectedZ)
        {
            AAS3DCoordinate sunCoord = AASSun.EquatorialRectangularCoordinatesJ2000(JD, bHighPrecision);
            Assert.Equal(expectedX, sunCoord.X);
            Assert.Equal(expectedY, sunCoord.Y);
            Assert.Equal(expectedZ, sunCoord.Z);
        }

        [Theory]
        [InlineData(2448908.5, false, -0.94148689425518228, -0.30266558095706397, -0.13121431330643032)]
        [InlineData(2448908.5, true, -0.94148805097417532, -0.30266488196016977, -0.13121348567161065)]
        public void EquatorialRectangularCoordinatesB1950Test(double JD, bool bHighPrecision, double expectedX, double expectedY, double expectedZ)
        {
            AAS3DCoordinate sunCoord = AASSun.EquatorialRectangularCoordinatesB1950(JD, bHighPrecision);
            Assert.Equal(expectedX, sunCoord.X);
            Assert.Equal(expectedY, sunCoord.Y);
            Assert.Equal(expectedZ, sunCoord.Z);
        }

        [Theory]
        [InlineData(2448908.5, 2467616.0, false, -0.93367982024805141, -0.32237414676162168, -0.13977884193849061)]
        [InlineData(2448908.5, 2467616.0, true, -0.9336809989138608, -0.32237347231033925, -0.13977802497015651)]
        public void EquatorialRectangularCoordinatesAnyEquinoxTest(double JD, double JDEquinox, bool bHighPrecision, double expectedX, double expectedY, double expectedZ)
        {
            AAS3DCoordinate sunCoord = AASSun.EquatorialRectangularCoordinatesAnyEquinox(JD, JDEquinox, bHighPrecision);
            Assert.Equal(expectedX, sunCoord.X);
            Assert.Equal(expectedY, sunCoord.Y);
            Assert.Equal(expectedZ, sunCoord.Z);
        }
    }
}