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

        [Theory]
        [InlineData(2448976.5, AASEllipticalObject.VENUS, false, 313.08146797645469, -2.0848807535804967, 0.91094680245149739, 0.0052611899278851085, 21.078191173376492, -18.888030266697541)]
        [InlineData(2453149.5, AASEllipticalObject.SUN, false, 63.160042353195564, -0.00018022324899989037, 1.0127532253492104, 0.0058491747863883888, 4.0748054040217614, 20.78978446624993)]
        public void CalculateTest(double JD, AASEllipticalObject ellipticalObject, bool bHighPrecision, 
                                double expectedApparentGeocentricLongitude, double expectedApparentGeocentricLatitude, 
                                double expectedApparentGeocentricDistance, double expectedApparentLightTime, 
                                double expectedApparentGeocentricRA, double expectedApparentGeocentricDeclination)
        {
            AASEllipticalPlanetaryDetails details = AASElliptical.Calculate(JD, ellipticalObject, bHighPrecision);
            Assert.Equal(expectedApparentGeocentricLongitude, details.ApparentGeocentricLongitude);
            Assert.Equal(expectedApparentGeocentricLatitude, details.ApparentGeocentricLatitude);
            Assert.Equal(expectedApparentGeocentricDistance, details.ApparentGeocentricDistance);
            Assert.Equal(expectedApparentLightTime, details.ApparentLightTime);
            Assert.Equal(expectedApparentGeocentricRA, details.ApparentGeocentricRA);
            Assert.Equal(expectedApparentGeocentricDeclination, details.ApparentGeocentricDeclination);
        }





        public static IEnumerable<object[]> Parameters()
        {
            yield return new object[]
            {
                2448170.5, 2.2091404, 0.8502196, 11.94524, 334.75006, 186.23352, 2448192.5 + 0.54502, 2451544.5, false,
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
                    TrueGeocentricRA = 10.570976697892744,
                    TrueGeocentricDeclination = 19.154435241867631,
                    TrueGeocentricDistance = 0.82437067376481921,
                    TrueGeocentricLightTime = 0.0047611679123120429,
                    AstrometricGeocentricRA = 10.570616116199949,
                    AstrometricGeocentricDeclination = 19.159048593591574,
                    AstrometricGeocentricDistance = 0.82428284103181093,
                    AstrometricGeocentricLightTime = 0.0047606606327552153,
                    Elongation = 40.507275061114285,
                    PhaseAngle = 84.362414223484478
                }
            };
        }


        [Theory]
        [MemberData(nameof(Parameters))]
        public void CalculateWithObjectElementsTest(
                                double JD, double a, double e, double i, double omega, double w, double T, double JDEquinox, bool bHighPrecision, AASEllipticalObjectDetails expectedEllipticalObjectDetails)
        {
            AASEllipticalObjectElements elements = new AASEllipticalObjectElements { a = a, e = e, i = i, omega = omega, w = w, T = T, JDEquinox = JDEquinox };
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