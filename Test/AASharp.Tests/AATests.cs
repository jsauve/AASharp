using System;
using Xunit;

namespace AASharp.Tests
{
    public class AATests
    {
        /// <summary>
        /// Calculate the topocentric horizontal position of the Sun for Palomar Observatory on midnight UTC for the 21st of September 2007
        /// </summary>
        [Fact]
        public void TopocentricHorizontalPosition()
        {
            bool bHighPrecision = false;
            
            AASDate dateSunCalc = new AASDate(2007, 9, 21, true);
            double JDSun = dateSunCalc.Julian + AASDynamicalTime.DeltaT(dateSunCalc.Julian) / 86400.0;
            double SunLong = AASSun.ApparentEclipticLongitude(JDSun, bHighPrecision);
            double SunLat = AASSun.ApparentEclipticLatitude(JDSun, bHighPrecision);
            AAS2DCoordinate Equatorial = AASCoordinateTransformation.Ecliptic2Equatorial(SunLong, SunLat, AASNutation.TrueObliquityOfEcliptic(JDSun));
            double SunRad = AASEarth.RadiusVector(JDSun, bHighPrecision);
            double Longitude = AASCoordinateTransformation.DMSToDegrees(116, 51, 45); //West is considered positive
            double Latitude = AASCoordinateTransformation.DMSToDegrees(33, 21, 22);
            double Height = 1706;
            AAS2DCoordinate SunTopo = AASParallax.Equatorial2Topocentric(Equatorial.X, Equatorial.Y, SunRad, Longitude, Latitude, Height, JDSun);
            double AST = AASSidereal.ApparentGreenwichSiderealTime(dateSunCalc.Julian);
            double LongtitudeAsHourAngle = AASCoordinateTransformation.DegreesToHours(Longitude);
            double LocalHourAngle = AST - LongtitudeAsHourAngle - SunTopo.X;
            AAS2DCoordinate SunHorizontal = AASCoordinateTransformation.Equatorial2Horizontal(LocalHourAngle, SunTopo.Y, Latitude);
            SunHorizontal.Y += AASRefraction.RefractionFromTrue(SunHorizontal.Y, 1013, 10);


            Assert.Equal(21.426598735582861, SunHorizontal.Y);
            Assert.Equal(76.304730598257535, SunHorizontal.X);

            //The result above should be that we have a setting Sun at 21 degrees above the horizon at azimuth 14 degrees south of the westerly horizon  

        }
    }
}
