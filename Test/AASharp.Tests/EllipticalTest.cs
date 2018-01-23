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

        [Theory]
        [InlineData(2448170.5, 2.2091404, 0.8502196, 11.94524, 334.75006, 186.23352, 2448192.5 + 0.54502, 2451544.5, false, 
            0.25080662090393591, 0.48491755634342543, 0.35733729658153013, 0.25080662090393574, 0.58704377348938708, 0.13496143147439146, 66.866050257498955, 11.937328624923349, 10.570976697892744, 19.154435241867631, 0.82437067376481921, 0.0047611679123120429, 10.570616116199949, 19.159048593591574, 0.82428284103181093, 0.0047606606327552153, 40.507275061114285, 84.362414223484478)]
        public void CalculateWithObjectElementsTest(
                                double JD, double a, double e, double i, double omega, double w, double T, double JDEquinox, bool bHighPrecision,
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
            AASEllipticalObjectElements elements = new AASEllipticalObjectElements { a = a, e = e, i = i, omega = omega, w = w, T = T, JDEquinox = JDEquinox };
            AASEllipticalObjectDetails details = AASElliptical.Calculate(JD, ref elements, bHighPrecision);

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
            Assert.Equal(expectedAstrometricGeocentricRA, details.AstrometricGeocentricRA);
            Assert.Equal(expectedAstrometricGeocentricDeclination, details.AstrometricGeocentricDeclination);
            Assert.Equal(expectedAstrometricGeocentricDistance, details.AstrometricGeocentricDistance);
            Assert.Equal(expectedAstrometricGeocentricLightTime, details.AstrometricGeocentricLightTime);
            Assert.Equal(expectedElongation, details.Elongation);
            Assert.Equal(expectedPhaseAngle, details.PhaseAngle);
        }
    }
}