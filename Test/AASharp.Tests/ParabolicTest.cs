using Xunit;

namespace AASharp.Tests
{
    public class ParabolicTest
    {
        [Theory]
        [InlineData(1.48678, 104.668, 222.103, 1.146, 2450917.705, 2451545.0, false, 
            -0.92863442225391335, -0.9119303421072531, 1.693363394814253, 
            -0.92863442225391324, -0.16309845559159331, 1.9163755971980911, 
            189.96140866352988, 63.803017382411028, 
            12.529018462281451, 50.722041420446686, 2.5723991775977266, 0.014856938525120621, 
            12.529096109113544, 50.717458962302587, 2.5722659686324807, 0.014856169174304119, 
            53.766284103454716, 22.529380589213471)]
        public void TheoryTest(double q, double i, double omega, double w, double T, double JDEquinox, bool bHighPrecision,
                                double expectedHeliocentricRectangularEquatorialX,
                                double expectedHeliocentricRectangularEquatorialY,
                                double expectedHeliocentricRectangularEquatorialZ,
                                double expectedHeliocentricRectangularEclipticalX,
                                double expectedHeliocentricRectangularEclipticalY,
                                double expectedHeliocentricRectangularEclipticalZ,
                                double expectedHeliocentricEclipticLongitude,
                                double expectedHeliocentricEclipticLatitude,
                                double expectedTrueGeocentricRA,
                                double expectedTrueGeocentricDeclination,
                                double expectedTrueGeocentricDistance,
                                double expectedTrueGeocentricLightTime,
                                double expectedAstrometricGeocentricRA,
                                double expectedAstrometricGeocentricDeclination,
                                double expectedAstrometricGeocentricDistance,
                                double expectedAstrometricGeocentricLightTime,
                                double expectedElongation,
                                double expectedPhaseAngle)
        {
            AASParabolicObjectElements elements = new AASParabolicObjectElements {q = q, i = i, omega = omega, w = w, T = T, JDEquinox = JDEquinox}; //Elements taken from http://www.cfa.harvard.edu/mpec/J98/J98H29.html
            AASParabolicObjectDetails details = AASParabolic.Calculate(2451030.5, ref elements, bHighPrecision);

            Assert.Equal(expectedHeliocentricRectangularEquatorialX, details.HeliocentricRectangularEquatorial.X);
            Assert.Equal(expectedHeliocentricRectangularEquatorialY, details.HeliocentricRectangularEquatorial.Y);
            Assert.Equal(expectedHeliocentricRectangularEquatorialZ, details.HeliocentricRectangularEquatorial.Z);
            Assert.Equal(expectedHeliocentricRectangularEclipticalX, details.HeliocentricRectangularEcliptical.X);
            Assert.Equal(expectedHeliocentricRectangularEclipticalY, details.HeliocentricRectangularEcliptical.Y);
            Assert.Equal(expectedHeliocentricRectangularEclipticalZ, details.HeliocentricRectangularEcliptical.Z);
            Assert.Equal(expectedHeliocentricEclipticLongitude, details.HeliocentricEclipticLongitude);
            Assert.Equal(expectedHeliocentricEclipticLatitude, details.HeliocentricEclipticLatitude);
            Assert.Equal(expectedTrueGeocentricRA, details.TrueGeocentricRA);
            Assert.Equal(expectedTrueGeocentricDeclination, details.TrueGeocentricDeclination);
            Assert.Equal(expectedTrueGeocentricDistance, details.TrueGeocentricDistance);
            Assert.Equal(expectedTrueGeocentricLightTime, details.TrueGeocentricLightTime);
            Assert.Equal(expectedAstrometricGeocentricRA, details.AstrometricGeocenticRA);
            Assert.Equal(expectedAstrometricGeocentricDeclination, details.AstrometricGeocentricDeclination);
            Assert.Equal(expectedAstrometricGeocentricDistance, details.AstrometricGeocentricDistance);
            Assert.Equal(expectedAstrometricGeocentricLightTime, details.AstrometricGeocentricLightTime);
            Assert.Equal(expectedElongation, details.Elongation);
            Assert.Equal(expectedPhaseAngle, details.PhaseAngle);
        }
    }
}