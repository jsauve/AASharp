using Xunit;

namespace AASharp.Tests
{
    public class TopocentricHorizontalPositionTest
    {
        /// <summary>
        /// Calculate the topocentric horizontal position of the Sun for Palomar Observatory on midnight UTC for the 21st of September 2007
        /// </summary>
        [Theory]
        [InlineData(76.304730598257535, 21.426598735582861, false)]
        public void SunTopocentricHorizontalPosition(double expectedX, double expectedY, bool highPrecision)
        {
            bool bHighPrecision = highPrecision;

            AASDate dateSunCalc = new AASDate(2007, 9, 21, true);
            double JDSun = dateSunCalc.Julian + AASDynamicalTime.DeltaT(dateSunCalc.Julian) / 86400.0;
            double SunLong = AASSun.ApparentEclipticLongitude(JDSun, bHighPrecision);
            double SunLat = AASSun.ApparentEclipticLatitude(JDSun, bHighPrecision);
            AAS2DCoordinate Equatorial =
                AASCoordinateTransformation.Ecliptic2Equatorial(SunLong, SunLat,
                    AASNutation.TrueObliquityOfEcliptic(JDSun));
            double SunRad = AASEarth.RadiusVector(JDSun, bHighPrecision);
            double Longitude = AASCoordinateTransformation.DMSToDegrees(116, 51, 45); //West is considered positive
            double Latitude = AASCoordinateTransformation.DMSToDegrees(33, 21, 22);
            double Height = 1706;
            AAS2DCoordinate SunTopo = AASParallax.Equatorial2Topocentric(Equatorial.X, Equatorial.Y, SunRad, Longitude,
                Latitude, Height, JDSun);
            double AST = AASSidereal.ApparentGreenwichSiderealTime(dateSunCalc.Julian);
            double LongtitudeAsHourAngle = AASCoordinateTransformation.DegreesToHours(Longitude);
            double LocalHourAngle = AST - LongtitudeAsHourAngle - SunTopo.X;
            AAS2DCoordinate SunHorizontal =
                AASCoordinateTransformation.Equatorial2Horizontal(LocalHourAngle, SunTopo.Y, Latitude);
            SunHorizontal.Y += AASRefraction.RefractionFromTrue(SunHorizontal.Y, 1013, 10);


            Assert.Equal(expectedX, SunHorizontal.X);
            Assert.Equal(expectedY, SunHorizontal.Y);

            //The result above should be that we have a setting Sun at 21 degrees above the horizon at azimuth 14 degrees south of the westerly horizon  
        }




        /// <summary>
        /// Calculate the topocentric horizontal position of the Moon for Palomar Observatory on midnight UTC for the 21st of September 2007
        /// </summary>
        [Fact]
        public void MoonTopocentricHorizontalPosition()
        {
            AASDate dateMoonCalc = new AASDate(2007, 9, 21, true);
            double JDMoon = dateMoonCalc.Julian + AASDynamicalTime.DeltaT(dateMoonCalc.Julian) / 86400.0;
            double MoonLong = AASMoon.EclipticLongitude(JDMoon);
            double MoonLat = AASMoon.EclipticLatitude(JDMoon);
            AAS2DCoordinate Equatorial =
                AASCoordinateTransformation.Ecliptic2Equatorial(MoonLong, MoonLat,
                    AASNutation.TrueObliquityOfEcliptic(JDMoon));
            double MoonRad = AASMoon.RadiusVector(JDMoon);
            MoonRad /= 149597870.691; //Convert KM to AU
            double Longitude = AASCoordinateTransformation.DMSToDegrees(116, 51, 45); //West is considered positive
            double Latitude = AASCoordinateTransformation.DMSToDegrees(33, 21, 22);
            double Height = 1706;
            AAS2DCoordinate MoonTopo = AASParallax.Equatorial2Topocentric(Equatorial.X, Equatorial.Y, MoonRad,
                Longitude, Latitude, Height, JDMoon);
            double AST = AASSidereal.ApparentGreenwichSiderealTime(dateMoonCalc.Julian);
            double LongtitudeAsHourAngle = AASCoordinateTransformation.DegreesToHours(Longitude);
            double LocalHourAngle = AST - LongtitudeAsHourAngle - MoonTopo.X;
            AAS2DCoordinate MoonHorizontal =
                AASCoordinateTransformation.Equatorial2Horizontal(LocalHourAngle, MoonTopo.Y, Latitude);
            MoonHorizontal.Y += AASRefraction.RefractionFromTrue(MoonHorizontal.Y, 1013, 10);

            Assert.Equal(321.7048971933051, MoonHorizontal.X);
            Assert.Equal(17.008629385005097, MoonHorizontal.Y);

            //The result above should be that we have a rising Moon at 17 degrees above the horizon at azimuth 38 degrees east of the southern horizon
        }
    }
}
