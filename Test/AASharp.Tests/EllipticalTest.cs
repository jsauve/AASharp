using System.Collections.Generic;
using Xunit;

namespace AASharp.Tests
{
    public class EllipticalTest
    {
        [Theory]
        [InlineData(5.5, 0.378, 10, 0.658, 1.5697179353256814)]
        [InlineData(5.5, 1.1017, 10, 1.5228, 7.5367454285840756)]
        public void CometMagnitudeTest(double g, double delta, double k, double r, double expectedMagnitude)
        {
            double magnitude = AASElliptical.CometMagnitude(g, delta, k, r);
            Assert.Equal(expectedMagnitude, magnitude);
        }

        [Theory]
        [InlineData(3.34, 1.6906631928, 0.12, 2.6154983761, 120, 11.459453341882822)]
        public void MinorPlanetMagnitudeTest(double H, double delta, double G, double r, double PhaseAngle, double expectedMagnitude)
        {
            double magnitude = AASElliptical.MinorPlanetMagnitude(H, delta, G, r, PhaseAngle);
            Assert.Equal(expectedMagnitude, magnitude);
        }

        [Theory]
        [InlineData(0.96727426, 17.9400782, 77.064913271862864)]
        public void LengthOfEllipseTest(double e, double a, double expectedLengthOfEllipse)
        {
            double length = AASElliptical.LengthOfEllipse(e, a);
            Assert.Equal(expectedLengthOfEllipse, length);
        }

        [Theory]
        [InlineData(1, 17.9400782, 41.530771685552118)]
        public void InstantaneousVelocityTest(double r, double a, double expectedInstantaneousVelocity)
        {
            double velocity = AASElliptical.InstantaneousVelocity(r, a);
            Assert.Equal(expectedInstantaneousVelocity, velocity);
        }

        [Theory]
        [InlineData(0.96727426, 17.9400782, 54.521623724983343)]
        public void VelocityAtPerihelionTest(double r, double a, double expectedVelocityAtPerihelion)
        {
            double velocity = AASElliptical.VelocityAtPerihelion(r, a);
            Assert.Equal(expectedVelocityAtPerihelion, velocity);
        }

        [Theory]
        [InlineData(0.96727426, 17.9400782, 0.90697088793386316)]
        public void VelocityAtAphelionTest(double r, double a, double expectedVelocityAtAphelion)
        {
            double velocity = AASElliptical.VelocityAtAphelion(r, a);
            Assert.Equal(expectedVelocityAtAphelion, velocity);
        }

        public static IEnumerable<object[]> CalculateTestParameters()
        {
            yield return new object[]
            {
                2448976.5,
                AASEllipticalObject.VENUS,
                false,
                new AASEllipticalPlanetaryDetails
                {
                    ApparentGeocentricLongitude = 313.08146797645469,
                    ApparentGeocentricLatitude = -2.0848807535804967,
                    ApparentGeocentricDistance = 0.91094680245149739,
                    ApparentLightTime = 0.0052611899278851085,
                    ApparentGeocentricRA = 21.078191173376492,
                    ApparentGeocentricDeclination = -18.888030266697541
                }
            };
            yield return new object[]
            {
                2448976.5,
                AASEllipticalObject.VENUS,
                true,
                new AASEllipticalPlanetaryDetails
                {
                    ApparentGeocentricLongitude = 313.08134354687473,
                    ApparentGeocentricLatitude = -2.0848233577020507,
                    ApparentGeocentricDistance = 0.91094771252372164,
                    ApparentLightTime = 0.0052611951840238931,
                    ApparentGeocentricRA = 21.078181619467397,
                    ApparentGeocentricDeclination = -18.88801099621335
                }
            };
            yield return new object[]
            {
                2453149.5,
                AASEllipticalObject.SUN,
                false,
                new AASEllipticalPlanetaryDetails
                {
                    ApparentGeocentricLongitude = 63.165663943945454,
                    ApparentGeocentricLatitude = 0.00017070008788243107,
                    ApparentGeocentricDistance = 1.0127542734293,
                    ApparentLightTime = 0.0058491808395941258,
                    ApparentGeocentricRA = 4.0751940069565524,
                    ApparentGeocentricDeclination = 20.791208742127115
                }
            };
            yield return new object[]
            {
                2453149.5,
                AASEllipticalObject.SUN,
                true,
                new AASEllipticalPlanetaryDetails
                {
                    ApparentGeocentricLongitude = 63.165691383267514,
                    ApparentGeocentricLatitude = 0.0001587878535048028,
                    ApparentGeocentricDistance = 1.0127537383139142,
                    ApparentLightTime = 0.005849177749025423,
                    ApparentGeocentricRA = 4.0751960903947237,
                    ApparentGeocentricDeclination = 20.791202322214222
                }
            };
        }

        [Theory]
        [MemberData(nameof(CalculateTestParameters))]
        public void CalculateTest(double JD, AASEllipticalObject ellipticalObject, bool bHighPrecision, AASEllipticalPlanetaryDetails expectedAASEllipticalPlanetaryDetails)
        {

            AASEllipticalPlanetaryDetails details = AASElliptical.Calculate(JD, ellipticalObject, bHighPrecision);
            Assert.Equal(expectedAASEllipticalPlanetaryDetails.ApparentGeocentricLongitude, details.ApparentGeocentricLongitude);
            Assert.Equal(expectedAASEllipticalPlanetaryDetails.ApparentGeocentricLatitude, details.ApparentGeocentricLatitude);
            Assert.Equal(expectedAASEllipticalPlanetaryDetails.ApparentGeocentricDistance, details.ApparentGeocentricDistance);
            Assert.Equal(expectedAASEllipticalPlanetaryDetails.ApparentLightTime, details.ApparentLightTime);
            Assert.Equal(expectedAASEllipticalPlanetaryDetails.ApparentGeocentricRA, details.ApparentGeocentricRA);
            Assert.Equal(expectedAASEllipticalPlanetaryDetails.ApparentGeocentricDeclination, details.ApparentGeocentricDeclination);
        }

        
        public static IEnumerable<object[]> CalculateWithObjectElementsTestParameters()
        {
            yield return new object[]
            {
                2448170.5,
                false,
                new AASEllipticalObjectElements
                {
                    a = 2.2091404,
                    e = 0.8502196,
                    i = 11.94524,
                    omega = 334.75006,
                    w = 186.23352,
                    T = 2448192.5 + 0.54502,
                    JDEquinox = 2451544.5
                },
                new AASEllipticalObjectDetails
                {
                    HeliocentricRectangularEquatorial = new AAS3DCoordinate
                    {
                        X = 0.25080662090393591,
                        Y = 0.48491755634342543,
                        Z = 0.35733729658153013
                    },
                    HeliocentricRectangularEcliptical = new AAS3DCoordinate
                    {
                        X = 0.25080662090393574,
                        Y = 0.58704377348938708,
                        Z = 0.13496143147439146
                    },
                    HeliocentricEclipticLongitude = 66.866050257498955,
                    HeliocentricEclipticLatitude = 11.937328624923349,
                    TrueGeocentricRA = 10.570959954361483,
                    TrueGeocentricDeclination = 19.153849340866824,
                    TrueGeocentricDistance = 0.82436916444388142,
                    TrueGeocentricLightTime = 0.0047611591952013465,
                    AstrometricGeocentricRA = 10.570599371671703,
                    AstrometricGeocentricDeclination = 19.158462623135637,
                    AstrometricGeocentricDistance = 0.82428133149112359,
                    AstrometricGeocentricLightTime = 0.0047606519143753509,
                    Elongation = 40.507285407869865,
                    PhaseAngle = 84.362537056398878
                }
            };
            yield return new object[]
            {
                2448170.5,
                true,
                new AASEllipticalObjectElements
                {
                    a = 2.2091404,
                    e = 0.8502196,
                    i = 11.94524,
                    omega = 334.75006,
                    w = 186.23352,
                    T = 2448192.5 + 0.54502,
                    JDEquinox = 2451544.5
                },
                new AASEllipticalObjectDetails
                {
                    HeliocentricRectangularEquatorial = new AAS3DCoordinate
                    {
                        X = 0.25080662090393591,
                        Y = 0.48491755634342543,
                        Z = 0.35733729658153013
                    },
                    HeliocentricRectangularEcliptical = new AAS3DCoordinate
                    {
                        X = 0.25080662090393574,
                        Y = 0.58704377348938708,
                        Z = 0.13496143147439146
                    },
                    HeliocentricEclipticLongitude = 66.866050257498955,
                    HeliocentricEclipticLatitude = 11.937328624923349,
                    TrueGeocentricRA = 10.570957094174336,
                    TrueGeocentricDeclination = 19.153886335816278,
                    TrueGeocentricDistance = 0.82436912639970916,
                    TrueGeocentricLightTime = 0.0047611589754765335,
                    AstrometricGeocentricRA = 10.570596511037536,
                    AstrometricGeocentricDeclination = 19.158499620533004,
                    AstrometricGeocentricDistance = 0.82428129355039725,
                    AstrometricGeocentricLightTime = 0.0047606516952479914,
                    Elongation = 40.507307038623765,
                    PhaseAngle = 84.362482873306817
                }
            };
        }


        [Theory]
        [MemberData(nameof(CalculateWithObjectElementsTestParameters))]
        public void CalculateWithObjectElementsTest(double JD, bool bHighPrecision, AASEllipticalObjectElements elements, AASEllipticalObjectDetails expectedEllipticalObjectDetails)
        {
            AASEllipticalObjectDetails details = AASElliptical.Calculate(JD, ref elements, bHighPrecision);

            Assert.Equal(expectedEllipticalObjectDetails.HeliocentricRectangularEquatorial.X, details.HeliocentricRectangularEquatorial.X);
            Assert.Equal(expectedEllipticalObjectDetails.HeliocentricRectangularEquatorial.Y, details.HeliocentricRectangularEquatorial.Y);
            Assert.Equal(expectedEllipticalObjectDetails.HeliocentricRectangularEquatorial.Z, details.HeliocentricRectangularEquatorial.Z);
            Assert.Equal(expectedEllipticalObjectDetails.HeliocentricRectangularEcliptical.X, details.HeliocentricRectangularEcliptical.X);
            Assert.Equal(expectedEllipticalObjectDetails.HeliocentricRectangularEcliptical.Y, details.HeliocentricRectangularEcliptical.Y);
            Assert.Equal(expectedEllipticalObjectDetails.HeliocentricRectangularEcliptical.Z, details.HeliocentricRectangularEcliptical.Z);
            Assert.Equal(expectedEllipticalObjectDetails.HeliocentricEclipticLongitude, details.HeliocentricEclipticLongitude);
            Assert.Equal(expectedEllipticalObjectDetails.HeliocentricEclipticLatitude, details.HeliocentricEclipticLatitude);
            Assert.Equal(expectedEllipticalObjectDetails.TrueGeocentricRA, details.TrueGeocentricRA);
            Assert.Equal(expectedEllipticalObjectDetails.TrueGeocentricDeclination, details.TrueGeocentricDeclination);
            Assert.Equal(expectedEllipticalObjectDetails.TrueGeocentricDistance, details.TrueGeocentricDistance);
            Assert.Equal(expectedEllipticalObjectDetails.TrueGeocentricLightTime, details.TrueGeocentricLightTime);
            Assert.Equal(expectedEllipticalObjectDetails.AstrometricGeocentricRA, details.AstrometricGeocentricRA);
            Assert.Equal(expectedEllipticalObjectDetails.AstrometricGeocentricDeclination, details.AstrometricGeocentricDeclination);
            Assert.Equal(expectedEllipticalObjectDetails.AstrometricGeocentricDistance, details.AstrometricGeocentricDistance);
            Assert.Equal(expectedEllipticalObjectDetails.AstrometricGeocentricLightTime, details.AstrometricGeocentricLightTime);
            Assert.Equal(expectedEllipticalObjectDetails.Elongation, details.Elongation);
            Assert.Equal(expectedEllipticalObjectDetails.PhaseAngle, details.PhaseAngle);
        }
    }
}