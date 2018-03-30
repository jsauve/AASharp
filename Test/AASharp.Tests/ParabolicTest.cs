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
                2451030.5,
                false,
                new AASParabolicObjectElements
                {
                    q = 1.48678,
                    i = 104.668,
                    omega = 222.103,
                    w = 1.146,
                    T = 2450917.705,
                    JDEquinox = 2451545.0
                }, //Elements taken from http://www.cfa.harvard.edu/mpec/J98/J98H29.html
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
                    TrueGeocentricRA = 12.529028827917752,
                    TrueGeocentricDeclination = 50.722175924951728,
                    TrueGeocentricDistance = 2.5724075344822066,
                    TrueGeocentricLightTime = 0.014856986790459865,
                    AstrometricGeocenticRA = 12.529106474494315,
                    AstrometricGeocentricDeclination = 50.717593472316992,
                    AstrometricGeocentricDistance = 2.5722743246607962,
                    AstrometricGeocentricLightTime = 0.01485621743469857,
                    Elongation = 53.765835380490721,
                    PhaseAngle = 22.529244193647607
                }
            };
            yield return new object[]
            {
                2451030.5,
                true,
                new AASParabolicObjectElements
                {
                    q = 1.48678,
                    i = 104.668,
                    omega = 222.103,
                    w = 1.146,
                    T = 2450917.705,
                    JDEquinox = 2451545.0
                }, //Elements taken from http://www.cfa.harvard.edu/mpec/J98/J98H29.html
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
                    TrueGeocentricRA = 12.529029981397166,
                    TrueGeocentricDeclination = 50.722193777863765,
                    TrueGeocentricDistance = 2.5724076713238784,
                    TrueGeocentricLightTime = 0.014856987580791445,
                    AstrometricGeocenticRA = 12.529107627950989,
                    AstrometricGeocentricDeclination = 50.717611325937675,
                    AstrometricGeocentricDistance = 2.57227446143634,
                    AstrometricGeocentricLightTime = 0.014856218224648226,
                    Elongation = 53.765821116962549,
                    PhaseAngle = 22.529228089649944
                }
            };
        }


        [Theory]
        [MemberData(nameof(Parameters))]
        public void TheoryTest(double JD, bool bHighPrecision, AASParabolicObjectElements elements, AASParabolicObjectDetails expectedParabolicObjectDetails)
        {
            AASParabolicObjectDetails details = AASParabolic.Calculate(JD, ref elements, bHighPrecision);

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