using System.Collections.Generic;
using Xunit;

namespace AASharp.Tests
{
    public class ParabolicTest
    {
        public static IEnumerable<object[]> Parameters()
        {
            yield return new object[]
            {
                1.48678, 104.668, 222.103, 1.146, 2450917.705, 2451545.0, false,
                new AASParabolicObjectDetails
                {
                    HeliocentricRectangularEquatorial = new AAS3DCoordinate
                    {
                        X = -0.92863442225391335,
                        Y = -0.9119303421072531,
                        Z = 1.693363394814253
                    },
                    HeliocentricRectangularEcliptical = new AAS3DCoordinate
                    {
                        X = -0.92863442225391324,
                        Y = -0.16309845559159331,
                        Z = 1.9163755971980911
                    },

                    HeliocentricEclipticLongitude = 189.96140866352988,
                    HeliocentricEclipticLatitude = 63.803017382411028,
                    TrueGeocentricRA = 12.529018462281451,
                    TrueGeocentricDeclination = 50.722041420446686,
                    TrueGeocentricDistance = 2.5723991775977266,
                    TrueGeocentricLightTime = 0.014856938525120621,
                    AstrometricGeocenticRA = 12.529096109113544,
                    AstrometricGeocentricDeclination = 50.717458962302587,
                    AstrometricGeocentricDistance = 2.5722659686324807,
                    AstrometricGeocentricLightTime = 0.014856169174304119,
                    Elongation = 53.766284103454716,
                    PhaseAngle = 22.529380589213471
                }
            };
        }


        [Theory]
        [MemberData(nameof(Parameters))]
        public void TheoryTest(double q, double i, double omega, double w, double T, double JDEquinox, bool bHighPrecision, AASParabolicObjectDetails expectedParabolicObjectDetails)
        {
            AASParabolicObjectElements elements = new AASParabolicObjectElements {q = q, i = i, omega = omega, w = w, T = T, JDEquinox = JDEquinox}; //Elements taken from http://www.cfa.harvard.edu/mpec/J98/J98H29.html
            AASParabolicObjectDetails details = AASParabolic.Calculate(2451030.5, ref elements, bHighPrecision);

            Assert.Equal(expectedParabolicObjectDetails.HeliocentricRectangularEquatorial.X, details.HeliocentricRectangularEquatorial.X);
            Assert.Equal(expectedParabolicObjectDetails.HeliocentricRectangularEquatorial.Y, details.HeliocentricRectangularEquatorial.Y);
            Assert.Equal(expectedParabolicObjectDetails.HeliocentricRectangularEquatorial.Z, details.HeliocentricRectangularEquatorial.Z);
            Assert.Equal(expectedParabolicObjectDetails.HeliocentricRectangularEcliptical.X, details.HeliocentricRectangularEcliptical.X);
            Assert.Equal(expectedParabolicObjectDetails.HeliocentricRectangularEcliptical.Y, details.HeliocentricRectangularEcliptical.Y);
            Assert.Equal(expectedParabolicObjectDetails.HeliocentricRectangularEcliptical.Z, details.HeliocentricRectangularEcliptical.Z);
            Assert.Equal(expectedParabolicObjectDetails.HeliocentricEclipticLongitude, details.HeliocentricEclipticLongitude);
            Assert.Equal(expectedParabolicObjectDetails.HeliocentricEclipticLatitude, details.HeliocentricEclipticLatitude);
            Assert.Equal(expectedParabolicObjectDetails.TrueGeocentricRA, details.TrueGeocentricRA);
            Assert.Equal(expectedParabolicObjectDetails.TrueGeocentricDeclination, details.TrueGeocentricDeclination);
            Assert.Equal(expectedParabolicObjectDetails.TrueGeocentricDistance, details.TrueGeocentricDistance);
            Assert.Equal(expectedParabolicObjectDetails.TrueGeocentricLightTime, details.TrueGeocentricLightTime);
            Assert.Equal(expectedParabolicObjectDetails.AstrometricGeocenticRA, details.AstrometricGeocenticRA);
            Assert.Equal(expectedParabolicObjectDetails.AstrometricGeocentricDeclination, details.AstrometricGeocentricDeclination);
            Assert.Equal(expectedParabolicObjectDetails.AstrometricGeocentricDistance, details.AstrometricGeocentricDistance);
            Assert.Equal(expectedParabolicObjectDetails.AstrometricGeocentricLightTime, details.AstrometricGeocentricLightTime);
            Assert.Equal(expectedParabolicObjectDetails.Elongation, details.Elongation);
            Assert.Equal(expectedParabolicObjectDetails.PhaseAngle, details.PhaseAngle);
        }
    }
}