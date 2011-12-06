using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AASharp;

namespace AASharpTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //Calculate the topocentric horizontal position of the Sun for Palomar Observatory on midnight UTC for the 21st of September 2007
            AASDate dateSunCalc = new AASDate(2007, 9, 21, true);
            double JDSun = dateSunCalc.Julian + AASDynamicalTime.DeltaT(dateSunCalc.Julian) / 86400.0;
            double SunLong = AASSun.ApparentEclipticLongitude(JDSun);
            double SunLat = AASSun.ApparentEclipticLatitude(JDSun);
            AAS2DCoordinate Equatorial = AASCoordinateTransformation.Ecliptic2Equatorial(SunLong, SunLat, AASNutation.TrueObliquityOfEcliptic(JDSun));
            double SunRad = AASEarth.RadiusVector(JDSun);
            double Longitude = AASCoordinateTransformation.DMSToDegrees(116, 51, 45); //West is considered positive
            double Latitude = AASCoordinateTransformation.DMSToDegrees(33, 21, 22);
            double Height = 1706;
            AAS2DCoordinate SunTopo = AASParallax.Equatorial2Topocentric(Equatorial.X, Equatorial.Y, SunRad, Longitude, Latitude, Height, JDSun);
            double AST = AASSidereal.ApparentGreenwichSiderealTime(dateSunCalc.Julian);
            double LongtitudeAsHourAngle = AASCoordinateTransformation.DegreesToHours(Longitude);
            double LocalHourAngle = AST - LongtitudeAsHourAngle - SunTopo.X;
            AAS2DCoordinate SunHorizontal = AASCoordinateTransformation.Equatorial2Horizontal(LocalHourAngle, SunTopo.Y, Latitude);
            SunHorizontal.Y += AASRefraction.RefractionFromTrue(SunHorizontal.Y, 1013, 10);

            //The result above should be that we have a setting Sun at 21 degrees above the horizon at azimuth 14 degrees south of the westerly horizon  


            //Calculate the topocentric horizontal position of the Moon for Palomar Observatory on midnight UTC for the 21st of September 2007
            AASDate dateMoonCalc = new AASDate(2007, 9, 21, true);
            double JDMoon = dateMoonCalc.Julian + AASDynamicalTime.DeltaT(dateMoonCalc.Julian) / 86400.0;
            double MoonLong = AASMoon.EclipticLongitude(JDMoon);
            double MoonLat = AASMoon.EclipticLatitude(JDMoon);
            Equatorial = AASCoordinateTransformation.Ecliptic2Equatorial(MoonLong, MoonLat, AASNutation.TrueObliquityOfEcliptic(JDMoon));
            double MoonRad = AASMoon.RadiusVector(JDMoon);
            MoonRad /= 149597870.691; //Convert KM to AU
            Longitude = AASCoordinateTransformation.DMSToDegrees(116, 51, 45); //West is considered positive
            Latitude = AASCoordinateTransformation.DMSToDegrees(33, 21, 22);
            Height = 1706;
            AAS2DCoordinate MoonTopo = AASParallax.Equatorial2Topocentric(Equatorial.X, Equatorial.Y, MoonRad, Longitude, Latitude, Height, JDMoon);
            AST = AASSidereal.ApparentGreenwichSiderealTime(dateMoonCalc.Julian);
            LongtitudeAsHourAngle = AASCoordinateTransformation.DegreesToHours(Longitude);
            LocalHourAngle = AST - LongtitudeAsHourAngle - MoonTopo.X;
            AAS2DCoordinate MoonHorizontal = AASCoordinateTransformation.Equatorial2Horizontal(LocalHourAngle, MoonTopo.Y, Latitude);
            MoonHorizontal.Y += AASRefraction.RefractionFromTrue(MoonHorizontal.Y, 1013, 10);

            //The result above should be that we have a rising Moon at 17 degrees above the horizon at azimuth 38 degrees east of the southern horizon  

            //Do a full round trip test on AASDate across a nice wide range. Note we should expect
            //some printfs to appear during this test (Specifically a monotonic error for 15 October 1582)
            double prevJulian = -1;
            for (int _YYYY = -4712; _YYYY < 5000; _YYYY++) //Change the end YYYY value if you would like to test a longer range
            {
                if ((_YYYY % 1000) == 0)
                    Console.Write(string.Format("Doing date tests on year {0}\n", _YYYY));
                for (int MMMM = 1; MMMM <= 12; MMMM++)
                {
                    bool _bLeap = AASDate.IsLeap(_YYYY, (_YYYY >= 1582));
                    for (int DDDD = 1; DDDD <= AASDate.DaysInMonth(MMMM, _bLeap); DDDD++)
                    {
                        bool bGregorian = AASDate.AfterPapalReform(_YYYY, MMMM, DDDD);
                        AASDate _date = new AASDate(_YYYY, MMMM, DDDD, 12, 0, 0, bGregorian);
                        if ((_date.Year != _YYYY) || (_date.Month != MMMM) || (_date.Day != DDDD))
                            Console.Write(string.Format("Round trip bug with date {0}/{1}/{2}\n", _YYYY, MMMM, DDDD));
                        double currentJulian = _date.Julian;
                        if ((prevJulian != -1) && ((prevJulian + 1) != currentJulian))
                            Console.Write(string.Format("Julian Day monotonic bug with date {0}/{1}/{2}\n", _YYYY, MMMM, DDDD));
                        prevJulian = currentJulian;

                        //Only do round trip tests between the Julian and Gregorian calendars after the papal 
                        //reform. This is because the AASDate class does not support the propalactic Gregorian 
                        //calendar, while it does fully support the propalactic Julian calendar.
                        if (bGregorian)
                        {
                            AASCalendarDate GregorianDate = AASDate.JulianToGregorian(_YYYY, MMMM, DDDD);
                            AASCalendarDate JulianDate = AASDate.GregorianToJulian(GregorianDate.Year, GregorianDate.Month, GregorianDate.Day);
                            if ((JulianDate.Year != _YYYY) || (JulianDate.Month != MMMM) || (JulianDate.Day != DDDD))
                                Console.Write(string.Format("Round trip bug with Julian -> Gregorian Calendar {0}/{1}/{2}\n", _YYYY, MMMM, DDDD));
                        }
                    }
                }
            }
            Console.Write(string.Format("Date tests completed\n"));

            //Test out the AADate class

            AASDate date = new AASDate();
            date.Set(2000, 1, 1, 12, 1, 2.3, true);
            long Year = 0;
            long Month = 0;
            long Day = 0;
            long Hour = 0;
            long Minute = 0;
            double Second = 0;
            date.Get(ref Year, ref Month, ref Day, ref Hour, ref Minute, ref Second);
            long DaysInMonth = date.DaysInMonth();
            long DaysInYear = date.DaysInYear();
            bool bLeap = date.Leap;
            double Julian = date.Julian;
            double FractionalYear = date.FractionalYear;
            double DayOfYear = date.DayOfYear();
            DAY_OF_WEEK dow = date.DayOfWeek;
            Year = date.Year;
            Month = date.Month;
            Day = date.Day;
            Hour = date.Hour;
            Minute = date.Minute;
            Second = date.Second;
            double Julian2 = date.Julian;

            date.Set(1978, 11, 14, 0, 0, 0, true);
            long DayNumber = (long)(date.DayOfYear());
            date.DayOfYearToDayAndMonth(DayNumber, date.Leap, ref Day, ref Month);
            Year = date.Year;

            //Test out the AAEaster class
            AASEasterDetails easterDetails = AASEaster.Calculate(1991, true);
            AASEasterDetails easterDetails2 = AASEaster.Calculate(1818, true);
            AASEasterDetails easterDetails3 = AASEaster.Calculate(179, false);

            //Test out the AADynamicalTime class
            date.Set(1977, 2, 18, 3, 37, 40, true);
            double DeltaT = AASDynamicalTime.DeltaT(date.Julian);
            date.Set(333, 2, 6, 6, 0, 0, false);
            DeltaT = AASDynamicalTime.DeltaT(date.Julian);

            //Test out the AAGlobe class
            double rhosintheta = AASGlobe.RhoSinThetaPrime(33.356111, 1706);
            double rhocostheta = AASGlobe.RhoCosThetaPrime(33.356111, 1706);
            double RadiusOfLatitude = AASGlobe.RadiusOfParallelOfLatitude(42);
            double RadiusOfCurvature = AASGlobe.RadiusOfCurvature(42);
            double Distance = AASGlobe.DistanceBetweenPoints(AASCoordinateTransformation.DMSToDegrees(48, 50, 11), AASCoordinateTransformation.DMSToDegrees(2, 20, 14, false), AASCoordinateTransformation.DMSToDegrees(38, 55, 17), AASCoordinateTransformation.DMSToDegrees(77, 3, 56));


            double Distance1 = AASGlobe.DistanceBetweenPoints(50, 0, 50, 60);
            double Distance2 = AASGlobe.DistanceBetweenPoints(50, 0, 50, 1);
            double Distance3 = AASGlobe.DistanceBetweenPoints(AASCoordinateTransformation.DMSToDegrees(89, 59, 0), 0, AASCoordinateTransformation.DMSToDegrees(89, 59, 0), 1);
            double Distance4 = AASGlobe.DistanceBetweenPoints(AASCoordinateTransformation.DMSToDegrees(89, 59, 0), 0, AASCoordinateTransformation.DMSToDegrees(89, 59, 0), 180);
            double Distance5 = AASGlobe.DistanceBetweenPoints(AASCoordinateTransformation.DMSToDegrees(89, 59, 0), 0, AASCoordinateTransformation.DMSToDegrees(89, 59, 0), 90);


            //Test out the AASidereal class
            date.Set(1987, 4, 10, 0, 0, 0, true);
            double MST = AASSidereal.MeanGreenwichSiderealTime(date.Julian);
            AST = AASSidereal.ApparentGreenwichSiderealTime(date.Julian);
            date.Set(1987, 4, 10, 19, 21, 0, true);
            MST = AASSidereal.MeanGreenwichSiderealTime(date.Julian);

            //Test out the AACoordinateTransformation class
            AAS2DCoordinate Ecliptic = AASCoordinateTransformation.Equatorial2Ecliptic(AASCoordinateTransformation.DMSToDegrees(7, 45, 18.946), AASCoordinateTransformation.DMSToDegrees(28, 01, 34.26), 23.4392911);
            Equatorial = AASCoordinateTransformation.Ecliptic2Equatorial(Ecliptic.X, Ecliptic.Y, 23.4392911);
            AAS2DCoordinate Galactic = AASCoordinateTransformation.Equatorial2Galactic(AASCoordinateTransformation.DMSToDegrees(17, 48, 59.74), AASCoordinateTransformation.DMSToDegrees(14, 43, 8.2, false));
            AAS2DCoordinate Equatorial2 = AASCoordinateTransformation.Galactic2Equatorial(Galactic.X, Galactic.Y);
            date.Set(1987, 4, 10, 19, 21, 0, true);
            AST = AASSidereal.ApparentGreenwichSiderealTime(date.Julian);
            LongtitudeAsHourAngle = AASCoordinateTransformation.DegreesToHours(AASCoordinateTransformation.DMSToDegrees(77, 3, 56));
            double Alpha = AASCoordinateTransformation.DMSToDegrees(23, 9, 16.641);
            LocalHourAngle = AST - LongtitudeAsHourAngle - Alpha;
            AAS2DCoordinate Horizontal = AASCoordinateTransformation.Equatorial2Horizontal(LocalHourAngle, AASCoordinateTransformation.DMSToDegrees(6, 43, 11.61, false), AASCoordinateTransformation.DMSToDegrees(38, 55, 17));
            AAS2DCoordinate Equatorial3 = AASCoordinateTransformation.Horizontal2Equatorial(Horizontal.X, Horizontal.Y, AASCoordinateTransformation.DMSToDegrees(38, 55, 17));
            double alpha2 = AASCoordinateTransformation.MapTo0To24Range(AST - Equatorial3.X - LongtitudeAsHourAngle);

            //Test out the CAANutation class (on its own)
            date.Set(1987, 4, 10, 0, 0, 0, true);
            double Obliquity = AASNutation.MeanObliquityOfEcliptic(date.Julian);
            double NutationInLongitude = AASNutation.NutationInLongitude(date.Julian);
            double NutationInEcliptic = AASNutation.NutationInObliquity(date.Julian);

            //Test out the CAAParallactic class
            double HourAngle = AASParallactic.ParallacticAngle(-3, 10, 20);
            double EclipticLongitude = AASParallactic.EclipticLongitudeOnHorizon(5, 23.44, 51);
            double EclipticAngle = AASParallactic.AngleBetweenEclipticAndHorizon(5, 23.44, 51);
            double Angle = AASParallactic.AngleBetweenNorthCelestialPoleAndNorthPoleOfEcliptic(90, 0, 23.44);

            //Test out the CAARefraction class
            double R1 = AASRefraction.RefractionFromApparent(0.5);
            double R2 = AASRefraction.RefractionFromTrue(0.5 - R1 + AASCoordinateTransformation.DMSToDegrees(0, 32, 0));
            double R3 = AASRefraction.RefractionFromApparent(90);

            //Test out the CAAAngularSeparation class
            double AngularSeparation = AASAngularSeparation.Separation(AASCoordinateTransformation.DMSToDegrees(14, 15, 39.7), AASCoordinateTransformation.DMSToDegrees(19, 10, 57),
                                                                        AASCoordinateTransformation.DMSToDegrees(13, 25, 11.6), AASCoordinateTransformation.DMSToDegrees(11, 9, 41, false));
            double AngularSeparation2 = AASAngularSeparation.Separation(AASCoordinateTransformation.DMSToDegrees(2, 0, 0), AASCoordinateTransformation.DMSToDegrees(0, 0, 0),
                                                                        AASCoordinateTransformation.DMSToDegrees(2, 0, 0), AASCoordinateTransformation.DMSToDegrees(0, 0, 0));
            double AngularSeparation3 = AASAngularSeparation.Separation(AASCoordinateTransformation.DMSToDegrees(2, 0, 0), AASCoordinateTransformation.DMSToDegrees(0, 0, 0),
                                                                        AASCoordinateTransformation.DMSToDegrees(14, 0, 0), AASCoordinateTransformation.DMSToDegrees(0, 0, 0));

            double PA0 = AASAngularSeparation.PositionAngle(AASCoordinateTransformation.DMSToDegrees(5, 32, 0.4), AASCoordinateTransformation.DMSToDegrees(0, 17, 56.9, false),
                                                                        AASCoordinateTransformation.DMSToDegrees(5, 36, 12.81), AASCoordinateTransformation.DMSToDegrees(1, 12, 7, false));

            double PA1 = AASAngularSeparation.PositionAngle(AASCoordinateTransformation.DMSToDegrees(5, 40, 45.52), AASCoordinateTransformation.DMSToDegrees(1, 56, 33.3, false),
                                                                        AASCoordinateTransformation.DMSToDegrees(5, 36, 12.81), AASCoordinateTransformation.DMSToDegrees(1, 12, 7, false));


            double distance = AASAngularSeparation.DistanceFromGreatArc(AASCoordinateTransformation.DMSToDegrees(5, 32, 0.4), AASCoordinateTransformation.DMSToDegrees(0, 17, 56.9, false),
                                                                        AASCoordinateTransformation.DMSToDegrees(5, 40, 45.52), AASCoordinateTransformation.DMSToDegrees(1, 56, 33.3, false),
                                                                        AASCoordinateTransformation.DMSToDegrees(5, 36, 12.81), AASCoordinateTransformation.DMSToDegrees(1, 12, 7, false));

            bool bType1 = false;
            double separation = AASAngularSeparation.SmallestCircle(AASCoordinateTransformation.DMSToDegrees(12, 41, 8.63), AASCoordinateTransformation.DMSToDegrees(5, 37, 54.2, false),
                                                                    AASCoordinateTransformation.DMSToDegrees(12, 52, 5.21), AASCoordinateTransformation.DMSToDegrees(4, 22, 26.2, false),
                                                                    AASCoordinateTransformation.DMSToDegrees(12, 39, 28.11), AASCoordinateTransformation.DMSToDegrees(1, 50, 3.7, false), ref bType1);

            separation = AASAngularSeparation.SmallestCircle(AASCoordinateTransformation.DMSToDegrees(9, 5, 41.44), AASCoordinateTransformation.DMSToDegrees(18, 30, 30),
                                                            AASCoordinateTransformation.DMSToDegrees(9, 9, 29), AASCoordinateTransformation.DMSToDegrees(17, 43, 56.7),
                                                            AASCoordinateTransformation.DMSToDegrees(8, 59, 47.14), AASCoordinateTransformation.DMSToDegrees(17, 49, 36.8), ref bType1);

            Alpha = AASCoordinateTransformation.DMSToDegrees(2, 44, 11.986);
            double Delta = AASCoordinateTransformation.DMSToDegrees(49, 13, 42.48);
            AAS2DCoordinate PA = AASPrecession.AdjustPositionUsingUniformProperMotion((2462088.69 - 2451545) / 365.25, Alpha, Delta, 0.03425, -0.0895);

            AAS2DCoordinate Precessed = AASPrecession.PrecessEquatorial(PA.X, PA.Y, 2451545, 2462088.69);

            Alpha = AASCoordinateTransformation.DMSToDegrees(2, 31, 48.704);
            Delta = AASCoordinateTransformation.DMSToDegrees(89, 15, 50.72);
            AAS2DCoordinate PA2 = AASPrecession.AdjustPositionUsingUniformProperMotion((2415020.3135 - 2451545) / 365.25, Alpha, Delta, 0.19877, -0.0152);
            //AAS2DCoordinate Precessed2 = AASPrecession.PrecessEquatorialFK4(PA2.X, PA2.Y, 2451545, 2415020.3135);

            AAS2DCoordinate PM = AASPrecession.EquatorialPMToEcliptic(0, 0, 0, 1, 1, 23);


            AAS2DCoordinate PA3 = AASPrecession.AdjustPositionUsingMotionInSpace(2.64, -7.6, -1000, AASCoordinateTransformation.DMSToDegrees(6, 45, 8.871), AASCoordinateTransformation.DMSToDegrees(16, 42, 57.99, false), -0.03847, -1.2053);
            AAS2DCoordinate PA4 = AASPrecession.AdjustPositionUsingUniformProperMotion(-1000, AASCoordinateTransformation.DMSToDegrees(6, 45, 8.871), AASCoordinateTransformation.DMSToDegrees(16, 42, 57.99, false), -0.03847, -1.2053);

            AAS2DCoordinate PA5 = AASPrecession.AdjustPositionUsingMotionInSpace(2.64, -7.6, -12000, AASCoordinateTransformation.DMSToDegrees(6, 45, 8.871), AASCoordinateTransformation.DMSToDegrees(16, 42, 57.99, false), -0.03847, -1.2053);
            AAS2DCoordinate PA6 = AASPrecession.AdjustPositionUsingUniformProperMotion(-12000, AASCoordinateTransformation.DMSToDegrees(6, 45, 8.871), AASCoordinateTransformation.DMSToDegrees(16, 42, 57.99, false), -0.03847, -1.2053);

            Alpha = AASCoordinateTransformation.DMSToDegrees(2, 44, 11.986);
            Delta = AASCoordinateTransformation.DMSToDegrees(49, 13, 42.48);
            AAS2DCoordinate PA7 = AASPrecession.AdjustPositionUsingUniformProperMotion((2462088.69 - 2451545) / 365.25, Alpha, Delta, 0.03425, -0.0895);
            AAS3DCoordinate EarthVelocity = AASAberration.EarthVelocity(2462088.69);
            AAS2DCoordinate Aberration = AASAberration.EquatorialAberration(PA7.X, PA7.Y, 2462088.69);
            PA7.X += Aberration.X;
            PA7.Y += Aberration.Y;
            PA7 = AASPrecession.PrecessEquatorial(PA7.X, PA7.Y, 2451545, 2462088.69);

            Obliquity = AASNutation.MeanObliquityOfEcliptic(2462088.69);
            NutationInLongitude = AASNutation.NutationInLongitude(2462088.69);
            NutationInEcliptic = AASNutation.NutationInObliquity(2462088.69);
            double AlphaNutation = AASNutation.NutationInRightAscension(PA7.X, PA7.Y, Obliquity, NutationInLongitude, NutationInEcliptic);
            double DeltaNutation = AASNutation.NutationInDeclination(PA7.X, Obliquity, NutationInLongitude, NutationInEcliptic);
            PA7.X += AASCoordinateTransformation.DMSToDegrees(0, 0, AlphaNutation / 15);
            PA7.Y += AASCoordinateTransformation.DMSToDegrees(0, 0, DeltaNutation);


            //Try out the AA kepler class
            double E0 = AASKepler.Calculate(5, 0.1, 100);
            double E02 = AASKepler.Calculate(5, 0.9, 100);
            //double E03 = AASKepler.Calculate(


            //Try out the binary star class
            AASBinaryStarDetails bsdetails = AASBinaryStar.Calculate(1980, 41.623, 1934.008, 0.2763, 0.907, 59.025, 23.717, 219.907);
            double ApparentE = AASBinaryStar.ApparentEccentricity(0.2763, 59.025, 219.907);


            //Test out the CAAStellarMagnitudes class
            double CombinedMag = AASStellarMagnitudes.CombinedMagnitude(1.96, 2.89);

            double[] mags = { 4.73, 5.22, 5.60 };
            double CombinedMag2 = AASStellarMagnitudes.CombinedMagnitude(3, mags);

            double BrightnessRatio = AASStellarMagnitudes.BrightnessRatio(0.14, 2.12);
            double MagDiff = AASStellarMagnitudes.MagnitudeDifference(BrightnessRatio);

            double MagDiff2 = AASStellarMagnitudes.MagnitudeDifference(500);


            //Test out the CAAVenus class
            double VenusLong = AASVenus.EclipticLongitude(2448976.5);
            double VenusLat = AASVenus.EclipticLatitude(2448976.5);
            double VenusRadius = AASVenus.RadiusVector(2448976.5);


            //Test out the CAAMercury class
            double MercuryLong = AASMercury.EclipticLongitude(2448976.5);
            double MercuryLat = AASMercury.EclipticLatitude(2448976.5);
            double MercuryRadius = AASMercury.RadiusVector(2448976.5);


            //Test out the CAAEarth class
            double EarthLong = AASEarth.EclipticLongitude(2448908.5);
            double EarthLat = AASEarth.EclipticLatitude(2448908.5);
            double EarthRadius = AASEarth.RadiusVector(2448908.5);

            double EarthLong2 = AASEarth.EclipticLongitudeJ2000(2448908.5);
            double EarthLat2 = AASEarth.EclipticLatitudeJ2000(2448908.5);


            //Test out the CAASun class
            SunLong = AASSun.GeometricEclipticLongitude(2448908.5);
            SunLat = AASSun.GeometricEclipticLatitude(2448908.5);

            double SunLongCorrection = AASFK5.CorrectionInLongitude(SunLong, SunLat, 2448908.5);
            double SunLatCorrection = AASFK5.CorrectionInLatitude(SunLong, 2448908.5);

            SunLong = AASSun.ApparentEclipticLongitude(2448908.5);
            SunLat = AASSun.ApparentEclipticLatitude(2448908.5);
            Equatorial = AASCoordinateTransformation.Ecliptic2Equatorial(SunLong, SunLat, AASNutation.TrueObliquityOfEcliptic(2448908.5));

            AAS3DCoordinate SunCoord = AASSun.EquatorialRectangularCoordinatesMeanEquinox(2448908.5);
            AAS3DCoordinate SunCoord2 = AASSun.EclipticRectangularCoordinatesJ2000(2448908.5);
            AAS3DCoordinate SunCoord3 = AASSun.EquatorialRectangularCoordinatesJ2000(2448908.5);
            AAS3DCoordinate SunCoord4 = AASSun.EquatorialRectangularCoordinatesB1950(2448908.5);
            AAS3DCoordinate SunCoord5 = AASSun.EquatorialRectangularCoordinatesAnyEquinox(2448908.5, 2467616.0);


            //Test out the CAAMars class
            double MarsLong = AASMars.EclipticLongitude(2448935.500683);
            double MarsLat = AASMars.EclipticLatitude(2448935.500683);
            double MarsRadius = AASMars.RadiusVector(2448935.500683);


            //Test out the CAAJupiter class
            double JupiterLong = AASJupiter.EclipticLongitude(2448972.50068);
            double JupiterLat = AASJupiter.EclipticLatitude(2448972.50068);
            double JupiterRadius = AASJupiter.RadiusVector(2448972.50068);


            //Test out the CAANeptune class
            double NeptuneLong = AASNeptune.EclipticLongitude(2448935.500683);
            double NeptuneLat = AASNeptune.EclipticLatitude(2448935.500683);
            double NeptuneRadius = AASNeptune.RadiusVector(2448935.500683);


            //Test out the CAAUranus class
            double UranusLong = AASUranus.EclipticLongitude(2448976.5);
            double UranusLat = AASUranus.EclipticLatitude(2448976.5);
            double UranusRadius = AASUranus.RadiusVector(2448976.5);


            //Test out the CAASaturn class
            double SaturnLong = AASSaturn.EclipticLongitude(2448972.50068);
            double SaturnLat = AASSaturn.EclipticLatitude(2448972.50068);
            double SaturnRadius = AASSaturn.RadiusVector(2448972.50068);


            //Test out the CAAPluto class
            double PlutoLong = AASPluto.EclipticLongitude(2448908.5);
            double PlutoLat = AASPluto.EclipticLatitude(2448908.5);
            double PlutoRadius = AASPluto.RadiusVector(2448908.5);


            //Test out the CAAMoon class
            MoonLong = AASMoon.EclipticLongitude(2448724.5);
            MoonLat = AASMoon.EclipticLatitude(2448724.5);
            double MoonRadius = AASMoon.RadiusVector(2448724.5);
            double MoonParallax = AASMoon.RadiusVectorToHorizontalParallax(MoonRadius);
            double MoonMeanAscendingNode = AASMoon.MeanLongitudeAscendingNode(2448724.5);
            double TrueMeanAscendingNode = AASMoon.TrueLongitudeAscendingNode(2448724.5);
            double MoonMeanPerigee = AASMoon.MeanLongitudePerigee(2448724.5);

            //Test out the CAAPlanetPerihelionAphelion class
            long VenusK = AASPlanetPerihelionAphelion.VenusK(1978.79);
            double VenusPerihelion = AASPlanetPerihelionAphelion.VenusPerihelion(VenusK);

            long MarsK = AASPlanetPerihelionAphelion.MarsK(2032);
            double MarsAphelion = AASPlanetPerihelionAphelion.MarsAphelion(MarsK);

            long SaturnK = AASPlanetPerihelionAphelion.SaturnK(1925);
            double SaturnAphelion = AASPlanetPerihelionAphelion.SaturnAphelion(SaturnK);
            SaturnK = AASPlanetPerihelionAphelion.SaturnK(1940);
            double SaturnPerihelion = AASPlanetPerihelionAphelion.SaturnPerihelion(SaturnK);

            long UranusK = AASPlanetPerihelionAphelion.UranusK(1750);
            double UranusAphelion = AASPlanetPerihelionAphelion.UranusAphelion(UranusK);
            UranusK = AASPlanetPerihelionAphelion.UranusK(1890);
            double UranusPerihelion = AASPlanetPerihelionAphelion.UranusPerihelion(UranusK);
            UranusK = AASPlanetPerihelionAphelion.UranusK(2060);
            UranusPerihelion = AASPlanetPerihelionAphelion.UranusPerihelion(UranusK);

            double EarthPerihelion = AASPlanetPerihelionAphelion.EarthPerihelion(-10, true);
            double EarthPerihelion2 = AASPlanetPerihelionAphelion.EarthPerihelion(-10, false);


            //Test out the CAAMoonPerigeeApogee
            double MoonK = AASMoonPerigeeApogee.K(1988.75);
            double MoonApogee = AASMoonPerigeeApogee.MeanApogee(-148.5);
            double MoonApogee2 = AASMoonPerigeeApogee.TrueApogee(-148.5);
            double MoonApogeeParallax = AASMoonPerigeeApogee.ApogeeParallax(-148.5);
            double MoonApogeeDistance = AASMoon.HorizontalParallaxToRadiusVector(MoonApogeeParallax);

            MoonK = AASMoonPerigeeApogee.K(1990.9);
            double MoonPerigee = AASMoonPerigeeApogee.MeanPerigee(-120);
            double MoonPerigee2 = AASMoonPerigeeApogee.TruePerigee(-120);
            MoonK = AASMoonPerigeeApogee.K(1930.0);
            double MoonPerigee3 = AASMoonPerigeeApogee.TruePerigee(-927);
            double MoonPerigeeParallax = AASMoonPerigeeApogee.PerigeeParallax(-927);
            double MoonRadiusVector = AASMoon.HorizontalParallaxToRadiusVector(MoonPerigeeParallax);
            double MoonRadiusVector2 = AASMoon.HorizontalParallaxToRadiusVector(0.991990);
            double MoonParallax2 = AASMoon.RadiusVectorToHorizontalParallax(MoonRadiusVector2);


            //Test out the CAAEclipticalElements class
            AASEclipticalElementDetails ed1 = AASEclipticalElements.Calculate(47.1220, 151.4486, 45.7481, 2358042.5305, 2433282.4235);
            AASEclipticalElementDetails ed2 = AASEclipticalElements.Calculate(11.93911, 186.24444, 334.04096, 2433282.4235, 2451545.0);
            AASEclipticalElementDetails ed3 = AASEclipticalElements.FK4B1950ToFK5J2000(11.93911, 186.24444, 334.04096);
            AASEclipticalElementDetails ed4 = AASEclipticalElements.FK4B1950ToFK5J2000(145, 186.24444, 334.04096);


            //Test out the CAAEquationOfTime class
            double E = AASEquationOfTime.Calculate(2448908.5);


            //Test out the CAAPhysicalSun class
            AASPhysicalSunDetails psd = AASPhysicalSun.Calculate(2448908.50068);
            double JED = AASPhysicalSun.TimeOfStartOfRotation(1699);


            //Test out the CAAEquinoxesAndSolstices class
            double JuneSolstice = AASEquinoxesAndSolstices.SummerSolstice(1962);


            double MarchEquinox2 = AASEquinoxesAndSolstices.SpringEquinox(1996);
            date.Set(MarchEquinox2, true);
            date.Get(ref Year, ref Month, ref Day, ref Hour, ref Minute, ref Second);
            double JuneSolstice2 = AASEquinoxesAndSolstices.SummerSolstice(1996);
            date.Set(JuneSolstice2, true);
            date.Get(ref Year, ref Month, ref Day, ref Hour, ref Minute, ref Second);
            double SeptemberEquinox2 = AASEquinoxesAndSolstices.AutumnEquinox(1996);
            date.Set(SeptemberEquinox2, true);
            date.Get(ref Year, ref Month, ref Day, ref Hour, ref Minute, ref Second);
            double DecemberSolstice2 = AASEquinoxesAndSolstices.WinterSolstice(1996);
            date.Set(DecemberSolstice2, true);
            date.Get(ref Year, ref Month, ref Day, ref Hour, ref Minute, ref Second);

            DecemberSolstice2 = AASEquinoxesAndSolstices.WinterSolstice(2000);
            date.Set(DecemberSolstice2, true);
            date.Get(ref Year, ref Month, ref Day, ref Hour, ref Minute, ref Second);

            DecemberSolstice2 = AASEquinoxesAndSolstices.WinterSolstice(1997);
            date.Set(DecemberSolstice2, true);
            date.Get(ref Year, ref Month, ref Day, ref Hour, ref Minute, ref Second);

            DecemberSolstice2 = AASEquinoxesAndSolstices.WinterSolstice(2003);
            date.Set(DecemberSolstice2, true);
            date.Get(ref Year, ref Month, ref Day, ref Hour, ref Minute, ref Second);

            JuneSolstice2 = AASEquinoxesAndSolstices.SummerSolstice(2003);
            date.Set(JuneSolstice2, true);
            date.Get(ref Year, ref Month, ref Day, ref Hour, ref Minute, ref Second);

            double SpringLength = AASEquinoxesAndSolstices.LengthOfSpring(2000);
            double SummerLength = AASEquinoxesAndSolstices.LengthOfSummer(2000);
            double AutumnLength = AASEquinoxesAndSolstices.LengthOfAutumn(2000);
            double WinterLength = AASEquinoxesAndSolstices.LengthOfWinter(2000);

            SpringLength = AASEquinoxesAndSolstices.LengthOfSpring(-2000);
            SummerLength = AASEquinoxesAndSolstices.LengthOfSummer(-2000);
            AutumnLength = AASEquinoxesAndSolstices.LengthOfAutumn(-2000);
            WinterLength = AASEquinoxesAndSolstices.LengthOfWinter(-2000);

            SpringLength = AASEquinoxesAndSolstices.LengthOfSpring(4000);
            SummerLength = AASEquinoxesAndSolstices.LengthOfSummer(4000);
            AutumnLength = AASEquinoxesAndSolstices.LengthOfAutumn(4000);
            WinterLength = AASEquinoxesAndSolstices.LengthOfWinter(4000);


            //Test out the CAAElementsPlanetaryOrbit class
            double Mer_L = AASElementsPlanetaryOrbit.MercuryMeanLongitude(2475460.5);
            double Mer_a = AASElementsPlanetaryOrbit.MercurySemimajorAxis();
            double Mer_e = AASElementsPlanetaryOrbit.MercuryEccentricity(2475460.5);
            double Mer_i = AASElementsPlanetaryOrbit.MercuryInclination(2475460.5);
            double Mer_omega = AASElementsPlanetaryOrbit.MercuryLongitudeAscendingNode(2475460.5);
            double Mer_pi = AASElementsPlanetaryOrbit.MercuryLongitudePerihelion(2475460.5);

            double Ven_L = AASElementsPlanetaryOrbit.VenusMeanLongitude(2475460.5);
            double Ven_a = AASElementsPlanetaryOrbit.VenusSemimajorAxis();
            double Ven_e = AASElementsPlanetaryOrbit.VenusEccentricity(2475460.5);
            double Ven_i = AASElementsPlanetaryOrbit.VenusInclination(2475460.5);
            double Ven_omega = AASElementsPlanetaryOrbit.VenusLongitudeAscendingNode(2475460.5);
            double Ven_pi = AASElementsPlanetaryOrbit.VenusLongitudePerihelion(2475460.5);

            double Ea_L = AASElementsPlanetaryOrbit.EarthMeanLongitude(2475460.5);
            double Ea_a = AASElementsPlanetaryOrbit.EarthSemimajorAxis();
            double Ea_e = AASElementsPlanetaryOrbit.EarthEccentricity(2475460.5);
            double Ea_i = AASElementsPlanetaryOrbit.EarthInclination();
            double Ea_pi = AASElementsPlanetaryOrbit.EarthLongitudePerihelion(2475460.5);

            double Mars_L = AASElementsPlanetaryOrbit.MarsMeanLongitude(2475460.5);
            double Mars_a = AASElementsPlanetaryOrbit.MarsSemimajorAxis();
            double Mars_e = AASElementsPlanetaryOrbit.MarsEccentricity(2475460.5);
            double Mars_i = AASElementsPlanetaryOrbit.MarsInclination(2475460.5);
            double Mars_omega = AASElementsPlanetaryOrbit.MarsLongitudeAscendingNode(2475460.5);
            double Mars_pi = AASElementsPlanetaryOrbit.MarsLongitudePerihelion(2475460.5);

            double Jup_L = AASElementsPlanetaryOrbit.JupiterMeanLongitude(2475460.5);
            double Jup_a = AASElementsPlanetaryOrbit.JupiterSemimajorAxis(2475460.5);
            double Jup_e = AASElementsPlanetaryOrbit.JupiterEccentricity(2475460.5);
            double Jup_i = AASElementsPlanetaryOrbit.JupiterInclination(2475460.5);
            double Jup_omega = AASElementsPlanetaryOrbit.JupiterLongitudeAscendingNode(2475460.5);
            double Jup_pi = AASElementsPlanetaryOrbit.JupiterLongitudePerihelion(2475460.5);

            double Sat_L = AASElementsPlanetaryOrbit.SaturnMeanLongitude(2475460.5);
            double Sat_a = AASElementsPlanetaryOrbit.SaturnSemimajorAxis(2475460.5);
            double Sat_e = AASElementsPlanetaryOrbit.SaturnEccentricity(2475460.5);
            double Sat_i = AASElementsPlanetaryOrbit.SaturnInclination(2475460.5);
            double Sat_omega = AASElementsPlanetaryOrbit.SaturnLongitudeAscendingNode(2475460.5);
            double Sat_pi = AASElementsPlanetaryOrbit.SaturnLongitudePerihelion(2475460.5);

            double Ura_L = AASElementsPlanetaryOrbit.UranusMeanLongitude(2475460.5);
            double Ura_a = AASElementsPlanetaryOrbit.UranusSemimajorAxis(2475460.5);
            double Ura_e = AASElementsPlanetaryOrbit.UranusEccentricity(2475460.5);
            double Ura_i = AASElementsPlanetaryOrbit.UranusInclination(2475460.5);
            double Ura_omega = AASElementsPlanetaryOrbit.UranusLongitudeAscendingNode(2475460.5);
            double Ura_pi = AASElementsPlanetaryOrbit.UranusLongitudePerihelion(2475460.5);

            double Nep_L = AASElementsPlanetaryOrbit.NeptuneMeanLongitude(2475460.5);
            double Nep_a = AASElementsPlanetaryOrbit.NeptuneSemimajorAxis(2475460.5);
            double Nep_e = AASElementsPlanetaryOrbit.NeptuneEccentricity(2475460.5);
            double Nep_i = AASElementsPlanetaryOrbit.NeptuneInclination(2475460.5);
            double Nep_omega = AASElementsPlanetaryOrbit.NeptuneLongitudeAscendingNode(2475460.5);
            double Nep_pi = AASElementsPlanetaryOrbit.NeptuneLongitudePerihelion(2475460.5);


            double Mer_L2 = AASElementsPlanetaryOrbit.MercuryMeanLongitudeJ2000(2475460.5);
            double Mer_i2 = AASElementsPlanetaryOrbit.MercuryInclinationJ2000(2475460.5);
            double Mer_omega2 = AASElementsPlanetaryOrbit.MercuryLongitudeAscendingNodeJ2000(2475460.5);
            double Mer_pi2 = AASElementsPlanetaryOrbit.MercuryLongitudePerihelionJ2000(2475460.5);

            double Ven_L2 = AASElementsPlanetaryOrbit.VenusMeanLongitudeJ2000(2475460.5);
            double Ven_i2 = AASElementsPlanetaryOrbit.VenusInclinationJ2000(2475460.5);
            double Ven_omega2 = AASElementsPlanetaryOrbit.VenusLongitudeAscendingNodeJ2000(2475460.5);
            double Ven_pi2 = AASElementsPlanetaryOrbit.VenusLongitudePerihelionJ2000(2475460.5);

            double Ea_L2 = AASElementsPlanetaryOrbit.EarthMeanLongitudeJ2000(2475460.5);
            double Ea_i2 = AASElementsPlanetaryOrbit.EarthInclinationJ2000(2475460.5);
            double Ea_omega2 = AASElementsPlanetaryOrbit.EarthLongitudeAscendingNodeJ2000(2475460.5);
            double Ea_pi2 = AASElementsPlanetaryOrbit.EarthLongitudePerihelionJ2000(2475460.5);

            double Mars_L2 = AASElementsPlanetaryOrbit.MarsMeanLongitudeJ2000(2475460.5);
            double Mars_i2 = AASElementsPlanetaryOrbit.MarsInclinationJ2000(2475460.5);
            double Mars_omega2 = AASElementsPlanetaryOrbit.MarsLongitudeAscendingNodeJ2000(2475460.5);
            double Mars_pi2 = AASElementsPlanetaryOrbit.MarsLongitudePerihelionJ2000(2475460.5);

            double Jup_L2 = AASElementsPlanetaryOrbit.JupiterMeanLongitudeJ2000(2475460.5);
            double Jup_i2 = AASElementsPlanetaryOrbit.JupiterInclinationJ2000(2475460.5);
            double Jup_omega2 = AASElementsPlanetaryOrbit.JupiterLongitudeAscendingNodeJ2000(2475460.5);
            double Jup_pi2 = AASElementsPlanetaryOrbit.JupiterLongitudePerihelionJ2000(2475460.5);

            double Sat_L2 = AASElementsPlanetaryOrbit.SaturnMeanLongitudeJ2000(2475460.5);
            double Sat_i2 = AASElementsPlanetaryOrbit.SaturnInclinationJ2000(2475460.5);
            double Sat_omega2 = AASElementsPlanetaryOrbit.SaturnLongitudeAscendingNodeJ2000(2475460.5);
            double Sat_pi2 = AASElementsPlanetaryOrbit.SaturnLongitudePerihelionJ2000(2475460.5);

            double Ura_L2 = AASElementsPlanetaryOrbit.UranusMeanLongitudeJ2000(2475460.5);
            double Ura_i2 = AASElementsPlanetaryOrbit.UranusInclinationJ2000(2475460.5);
            double Ura_omega2 = AASElementsPlanetaryOrbit.UranusLongitudeAscendingNodeJ2000(2475460.5);
            double Ura_pi2 = AASElementsPlanetaryOrbit.UranusLongitudePerihelionJ2000(2475460.5);

            double Nep_L2 = AASElementsPlanetaryOrbit.NeptuneMeanLongitudeJ2000(2475460.5);
            double Nep_i2 = AASElementsPlanetaryOrbit.NeptuneInclinationJ2000(2475460.5);
            double Nep_omega2 = AASElementsPlanetaryOrbit.NeptuneLongitudeAscendingNodeJ2000(2475460.5);
            double Nep_pi2 = AASElementsPlanetaryOrbit.NeptuneLongitudePerihelionJ2000(2475460.5);

            double MoonGeocentricElongation = AASMoonIlluminatedFraction.GeocentricElongation(8.97922, 13.7684, 1.377194, 8.6964);
            double MoonPhaseAngle = AASMoonIlluminatedFraction.PhaseAngle(MoonGeocentricElongation, 368410, 149971520);
            double MoonIlluminatedFraction = AASMoonIlluminatedFraction.IlluminatedFraction(MoonPhaseAngle);
            double MoonPositionAngle = AASMoonIlluminatedFraction.PositionAngle(AASCoordinateTransformation.DMSToDegrees(1, 22, 37.9), 8.6964, 134.6885 / 15, 13.7684);

            AASEllipticalPlanetaryDetails VenusDetails = AASElliptical.Calculate(2448976.5, AASEllipticalObject.VENUS);

            AASEllipticalPlanetaryDetails SunDetails = AASElliptical.Calculate(2453149.5, AASEllipticalObject.SUN);

            AASEllipticalObjectElements elements = new AASEllipticalObjectElements() { a = 2.2091404, e = 0.8502196, i = 11.94524, omega = 334.75006, w = 186.23352, T = 2448192.5 + 0.54502, JDEquinox = 2451544.5 };
            AASEllipticalObjectDetails details = AASElliptical.Calculate(2448170.5, ref elements);

            double Velocity1 = AASElliptical.InstantaneousVelocity(1, 17.9400782);
            double Velocity2 = AASElliptical.VelocityAtPerihelion(0.96727426, 17.9400782);
            double Velocity3 = AASElliptical.VelocityAtAphelion(0.96727426, 17.9400782);

            double Length = AASElliptical.LengthOfEllipse(0.96727426, 17.9400782);

            double Mag1 = AASElliptical.MinorPlanetMagnitude(3.34, 1.6906631928, 0.12, 2.6154983761, 120);
            double Mag2 = AASElliptical.CometMagnitude(5.5, 0.378, 10, 0.658);
            double Mag3 = AASElliptical.CometMagnitude(5.5, 1.1017, 10, 1.5228);

            AASParabolicObjectElements elements2 = new AASParabolicObjectElements { q = 1.48678, i = 104.668 /*J2000*/, omega = 222.103 /*J2000*/, w = 1.146 /*J2000*/, T = AASDate.DateToJD(1998, 4, 14.205, true), JDEquinox = 2451545.0 /*J2000*/ }; //Elements taken from http://www.cfa.harvard.edu/mpec/J98/J98H29.html
            AASParabolicObjectDetails details2 = AASParabolic.Calculate(2451030.5, ref elements2);

            AASEllipticalObjectElements elements3 = new AASEllipticalObjectElements { a = 17.9400782, e = 0.96727426, i = 0 /*Not required*/, omega = 0 /*Not required*/, w = 111.84644, T = 2446470.5 + 0.45891, JDEquinox = 0 /*Not required*/ };
            AASNodeObjectDetails nodedetails = AASNodes.PassageThroAscendingNode(ref elements3);
            AASNodeObjectDetails nodedetails2 = AASNodes.PassageThroDescendingNode(ref elements3);

            AASParabolicObjectElements elements4 = new AASParabolicObjectElements { q = 1.324502, i = 0 /*Not required*/, omega = 0 /*Not required*/, w = 154.9103, T = 2447758.5 + 0.2910, JDEquinox = 0 /*Not required*/ };
            AASNodeObjectDetails nodedetails3 = AASNodes.PassageThroAscendingNode(ref elements4);
            AASNodeObjectDetails nodedetails4 = AASNodes.PassageThroDescendingNode(ref elements4);


            AASEllipticalObjectElements elements5 = new AASEllipticalObjectElements { a = 0.723329820, e = 0.00678195, i = 0 /*Not required*/, omega = 0 /*Not required*/, w = 54.778485, T = 2443873.704, JDEquinox = 0 /*Not required*/ };
            AASNodeObjectDetails nodedetails5 = AASNodes.PassageThroAscendingNode(ref elements5);

            double MoonK2 = AASMoonNodes.K(1987.37);
            double MoonJD = AASMoonNodes.PassageThroNode(-170);


            double Y = AASInterpolate.Interpolate(0.18125, 0.884226, 0.877366, 0.870531);

            double NM = 0;
            double YM = AASInterpolate.Extremum(1.3814294, 1.3812213, 1.3812453, ref NM);

            double N0 = AASInterpolate.Zero(-1693.4, 406.3, 2303.2);

            double N02 = AASInterpolate.Zero2(-2, 3, 2);

            double Y2 = AASInterpolate.Interpolate(0.2777778, 36.125, 24.606, 15.486, 8.694, 4.133);

            double N03 = AASInterpolate.Zero(AASCoordinateTransformation.DMSToDegrees(1, 11, 21.23, false), AASCoordinateTransformation.DMSToDegrees(0, 28, 12.31, false), AASCoordinateTransformation.DMSToDegrees(0, 16, 7.02), AASCoordinateTransformation.DMSToDegrees(1, 1, 0.13), AASCoordinateTransformation.DMSToDegrees(1, 45, 46.33));

            double N04 = AASInterpolate.Zero(AASCoordinateTransformation.DMSToDegrees(0, 28, 12.31, false), AASCoordinateTransformation.DMSToDegrees(0, 16, 7.02), AASCoordinateTransformation.DMSToDegrees(1, 1, 0.13));

            double N05 = AASInterpolate.Zero2(-13, -2, 3, 2, -5);

            double Y3 = AASInterpolate.InterpolateToHalves(1128.732, 1402.835, 1677.247, 1951.983);

            double[] x1 = { 29.43, 30.97, 27.69, 28.11, 31.58, 33.05 };
            double[] y1 = { 0.4913598528, 0.5145891926, 0.4646875083, 0.4711658342, 0.5236885653, 0.5453707057 };
			
            double Y4 = AASInterpolate.LagrangeInterpolate(30, 6, x1, y1);
            double Y5 = AASInterpolate.LagrangeInterpolate(0, 6, x1, y1);
            double Y6 = AASInterpolate.LagrangeInterpolate(90, 6, x1, y1);
           
            double Alpha1 = AASCoordinateTransformation.DMSToDegrees(2, 42, 43.25);
            double Alpha2 = AASCoordinateTransformation.DMSToDegrees(2, 46, 55.51);
            double Alpha3 = AASCoordinateTransformation.DMSToDegrees(2, 51, 07.69);
            double Delta1 = AASCoordinateTransformation.DMSToDegrees(18, 02, 51.4);
            double Delta2 = AASCoordinateTransformation.DMSToDegrees(18, 26, 27.3);
            double Delta3 = AASCoordinateTransformation.DMSToDegrees(18, 49, 38.7);
            double JD2 = 2447240.5;
            Longitude = 71.0833;
            Latitude = 42.3333;
            AASRiseTransitSetDetails RiseTransitSetTime = AASRiseTransitSet.Calculate(JD2, Alpha1, Delta1, Alpha2, Delta2, Alpha3, Delta3, Longitude, Latitude, -0.5667);

            AASDate rtsDate = null;

            if (RiseTransitSetTime.bRiseValid)
            {
                double riseJD = (JD2 + (RiseTransitSetTime.Rise / 24.00));
                rtsDate = new AASDate(riseJD, true);
                long _Hours = 0;
                long _Minutes = 0;
                double _Sec = 0;
                rtsDate.Get(ref Year, ref Month, ref Day, ref _Hours, ref _Minutes, ref _Sec);
                Console.Write(string.Format("Venus rise for Boston for UTC {0}/{1}/{2} occurs at {3}:{4}:{5}\n", (int)(Year), (int)(Month), (int)(Day), String.Format("{0,2:00}", (int)(_Hours)), String.Format("{0,2:00}", (int)(_Minutes)), String.Format("{0,2:00}", (int)(_Sec))));
            }
            else
            {
                rtsDate = new AASDate(JD2, true);
                long _Hours = 0;
                long _Minutes = 0;
                double _Sec = 0;
                rtsDate.Get(ref Year, ref Month, ref Day, ref _Hours, ref _Minutes, ref _Sec);
                Console.Write(string.Format("Venus does not rise for Boston for UTC {0}/{1}/{2}\n", (int)(Year), (int)(Month), (int)(Day)));
            }
            double transitJD = (JD2 + (RiseTransitSetTime.Transit / 24.00));
            rtsDate = new AASDate(transitJD, true);
            long Hours = 0;
            long Minutes = 0;
            double Sec = 0;
            rtsDate.Get(ref Year, ref Month, ref Day, ref Hours, ref Minutes, ref Sec);
            if (RiseTransitSetTime.bTransitAboveHorizon)
                Console.Write(string.Format("Venus transit for Boston for UTC {0}/{1}/{2} occurs at {3}:{4}:{5}\n", (int)(Year), (int)(Month), (int)(Day), String.Format("{0,2:00}", (int)(Hours)), String.Format("{0,2:00}", (int)(Minutes)), String.Format("{0,2:00}", (int)(Sec))));
            else
                Console.Write(string.Format("Venus transit for Boston (below horizon) for UTC {0}/{1}/{2} occurs at {3}:{4}:{5}\n", (int)(Year), (int)(Month), (int)(Day), String.Format("{0,2:00}", (int)(Hours)), String.Format("{0,2:00}", (int)(Minutes)), String.Format("{0,2:00}", (int)(Sec))));
            if (RiseTransitSetTime.bSetValid)
            {
                double setJD = (JD2 + (RiseTransitSetTime.Set / 24.00));
                rtsDate = new AASDate(setJD, true);
                rtsDate.Get(ref Year, ref Month, ref Day, ref Hours, ref Minutes, ref Sec);
                Console.Write(string.Format("Venus set for Boston UTC {0}/{1}/{2} occurs at {3}:{4}:{5}\n", (int)(Year), (int)(Month), (int)(Day), String.Format("{0,2:00}", (int)(Hours)), String.Format("{0,2:00}", (int)(Minutes)), String.Format("{0,2:00}", (int)(Sec))));
            }
            else
            {
                rtsDate = new AASDate(JD2, true);
                rtsDate.Get(ref Year, ref Month, ref Day, ref Hours, ref Minutes, ref Sec);
                Console.Write(string.Format("Venus does not set for Boston for UTC {0}/{1}/{2}\n", (int)(Year), (int)(Month), (int)(Day)));
            }

            //Calculate the time of moon set for 11th of August 2009 UTC for Palomar Observatory 
            int YYYY = 2011;
            int MM = 8;
            int DD = 10;
            AASDate CalcDate = new AASDate(YYYY, MM, DD, true);
            JD2 = CalcDate.Julian;
            LunarRaDec(JD2 - 1, ref Alpha1, ref Delta1);
            LunarRaDec(JD2, ref Alpha2, ref Delta2);
            LunarRaDec(JD2 + 1, ref Alpha3, ref Delta3);
            Longitude = AASCoordinateTransformation.DMSToDegrees(116, 51, 45); //West is considered positive
            Latitude = AASCoordinateTransformation.DMSToDegrees(33, 21, 22);
            RiseTransitSetTime = AASRiseTransitSet.Calculate(JD2, Alpha1, Delta1, Alpha2, Delta2, Alpha3, Delta3, Longitude, Latitude, 0.125);
            if (RiseTransitSetTime.bRiseValid)
            {
                double riseJD = (JD2 + (RiseTransitSetTime.Rise / 24.00));
                rtsDate = new AASDate(riseJD, true);
                rtsDate.Get(ref Year, ref Month, ref Day, ref Hours, ref Minutes, ref Sec);
                Console.Write(string.Format("Moon rise for Palomar Observatory for UTC {0}/{1}/{2} occurs at {3}:{4}:{5}\n", (int)(Year), (int)(Month), (int)(Day), String.Format("{0,2:00}", (int)(Hours)), String.Format("{0,2:00}", (int)(Minutes)), String.Format("{0,2:00}", (int)(Sec))));
            }
            else
            {
                rtsDate = new AASDate(JD2, true);
                rtsDate.Get(ref Year, ref Month, ref Day, ref Hours, ref Minutes, ref Sec);
                Console.Write(string.Format("Moon does not rise for Palomar Observatory for UTC {0}/{1}/{2}\n", (int)(Year), (int)(Month), (int)(Day)));
            }
            transitJD = (JD2 + (RiseTransitSetTime.Transit / 24.00));
            rtsDate = new AASDate(transitJD, true);
            rtsDate.Get(ref Year, ref Month, ref Day, ref Hours, ref Minutes, ref Sec);
            if (RiseTransitSetTime.bTransitAboveHorizon)
                Console.Write(string.Format("Moon transit for Palomar Observatory for UTC {0}/{1}/{2} occurs at {3}:{4}:{5}\n", (int)(Year), (int)(Month), (int)(Day), String.Format("{0,2:00}", (int)(Hours)), String.Format("{0,2:00}", (int)(Minutes)), String.Format("{0,2:00}", (int)(Sec))));
            else
                Console.Write(string.Format("Moon transit for Palomar Observatory (below horizon) for UTC {0}/{1}/{2} occurs at {3}:{4}:{5}\n", (int)(Year), (int)(Month), (int)(Day), String.Format("{0,2:00}", (int)(Hours)), String.Format("{0,2:00}", (int)(Minutes)), String.Format("{0,2:00}", (int)(Sec))));
            if (RiseTransitSetTime.bSetValid)
            {
                double setJD = (JD2 + (RiseTransitSetTime.Set / 24.00));
                rtsDate = new AASDate(setJD, true);
                rtsDate.Get(ref Year, ref Month, ref Day, ref Hours, ref Minutes, ref Sec);
                Console.Write(string.Format("Moon set for Palomar Observatory for UTC {0}/{1}/{2} occurs at {3}:{4}:{5}\n", (int)(Year), (int)(Month), (int)(Day), String.Format("{0,2:00}", (int)(Hours)), String.Format("{0,2:00}", (int)(Minutes)), String.Format("{0,2:00}", (int)(Sec))));
            }
            else
            {
                rtsDate = new AASDate(JD2, true);
                rtsDate.Get(ref Year, ref Month, ref Day, ref Hours, ref Minutes, ref Sec);
                Console.Write(string.Format("Moon does not set for Palomar Observatory for UTC {0}/{1}/{2} \n", (int)(Year), (int)(Month), (int)(Day)));
            }

            double Kpp = AASPlanetaryPhenomena.K(1993.75, PlanetaryObject.MERCURY, EventType.INFERIOR_CONJUNCTION);
            double MercuryInferiorConjunction = AASPlanetaryPhenomena.Mean(Kpp, PlanetaryObject.MERCURY, EventType.INFERIOR_CONJUNCTION);
            double MercuryInferiorConjunction2 = AASPlanetaryPhenomena.True(Kpp, PlanetaryObject.MERCURY, EventType.INFERIOR_CONJUNCTION);

            double Kpp2 = AASPlanetaryPhenomena.K(2125.5, PlanetaryObject.SATURN, EventType.CONJUNCTION);
            double SaturnConjunction = AASPlanetaryPhenomena.Mean(Kpp2, PlanetaryObject.SATURN, EventType.CONJUNCTION);
            double SaturnConjunction2 = AASPlanetaryPhenomena.True(Kpp2, PlanetaryObject.SATURN, EventType.CONJUNCTION);

            double MercuryWesternElongation = AASPlanetaryPhenomena.True(Kpp, PlanetaryObject.MERCURY, EventType.WESTERN_ELONGATION);
            double MercuryWesternElongationValue = AASPlanetaryPhenomena.ElongationValue(Kpp, PlanetaryObject.MERCURY, false);

            double MarsStation2 = AASPlanetaryPhenomena.True(-2, PlanetaryObject.MARS, EventType.STATION2);

            double MercuryK = AASPlanetaryPhenomena.K(1631.8, PlanetaryObject.MERCURY, EventType.INFERIOR_CONJUNCTION);
            double MercuryIC = AASPlanetaryPhenomena.True(MercuryK, PlanetaryObject.MERCURY, EventType.INFERIOR_CONJUNCTION);

            double VenusKpp = AASPlanetaryPhenomena.K(1882.9, PlanetaryObject.VENUS, EventType.INFERIOR_CONJUNCTION);
            double VenusIC = AASPlanetaryPhenomena.True(VenusKpp, PlanetaryObject.VENUS, EventType.INFERIOR_CONJUNCTION);

            double MarsKpp = AASPlanetaryPhenomena.K(2729.65, PlanetaryObject.MARS, EventType.OPPOSITION);
            double MarsOP = AASPlanetaryPhenomena.True(MarsKpp, PlanetaryObject.MARS, EventType.OPPOSITION);

            double JupiterKpp = AASPlanetaryPhenomena.K(-5, PlanetaryObject.JUPITER, EventType.OPPOSITION);
            double JupiterOP = AASPlanetaryPhenomena.True(JupiterKpp, PlanetaryObject.JUPITER, EventType.OPPOSITION);

            double SaturnKpp = AASPlanetaryPhenomena.K(-5, PlanetaryObject.SATURN, EventType.OPPOSITION);
            double SaturnOP = AASPlanetaryPhenomena.True(SaturnKpp, PlanetaryObject.SATURN, EventType.OPPOSITION);

            double UranusKpp = AASPlanetaryPhenomena.K(1780.6, PlanetaryObject.URANUS, EventType.OPPOSITION);
            double UranusOP = AASPlanetaryPhenomena.True(UranusKpp, PlanetaryObject.URANUS, EventType.OPPOSITION);

            double NeptuneKpp = AASPlanetaryPhenomena.K(1846.5, PlanetaryObject.NEPTUNE, EventType.OPPOSITION);
            double NeptuneOP = AASPlanetaryPhenomena.True(NeptuneKpp, PlanetaryObject.NEPTUNE, EventType.OPPOSITION);

            AAS2DCoordinate TopocentricDelta = AASParallax.Equatorial2TopocentricDelta(AASCoordinateTransformation.DMSToDegrees(22, 38, 7.25), -15.771083, 0.37276, AASCoordinateTransformation.DMSToDegrees(7, 47, 27) * 15, AASCoordinateTransformation.DMSToDegrees(33, 21, 22), 1706, 2452879.63681);
            AAS2DCoordinate Topocentric = AASParallax.Equatorial2Topocentric(AASCoordinateTransformation.DMSToDegrees(22, 38, 7.25), -15.771083, 0.37276, AASCoordinateTransformation.DMSToDegrees(7, 47, 27) * 15, AASCoordinateTransformation.DMSToDegrees(33, 21, 22), 1706, 2452879.63681);


            double distance2 = AASParallax.ParallaxToDistance(AASCoordinateTransformation.DMSToDegrees(0, 59, 27.7));
            double parallax2 = AASParallax.DistanceToParallax(distance2);

            AASTopocentricEclipticDetails TopocentricDetails = AASParallax.Ecliptic2Topocentric(AASCoordinateTransformation.DMSToDegrees(181, 46, 22.5), AASCoordinateTransformation.DMSToDegrees(2, 17, 26.2),
                                                                                                 AASCoordinateTransformation.DMSToDegrees(0, 16, 15.5), AASParallax.ParallaxToDistance(AASCoordinateTransformation.DMSToDegrees(0, 59, 27.7)), AASCoordinateTransformation.DMSToDegrees(23, 28, 0.8),
                                                                                                 AASCoordinateTransformation.DMSToDegrees(50, 5, 7.8), 0, 2452879.150858);

            double k = AASIlluminatedFraction.IlluminatedFraction(0.724604, 0.983824, 0.910947);
            double pa1 = AASIlluminatedFraction.PhaseAngle(0.724604, 0.983824, 0.910947);
            double pa = AASIlluminatedFraction.PhaseAngle(0.724604, 0.983824, -2.62070, 26.11428, 88.35704, 0.910947);
            double k2 = AASIlluminatedFraction.IlluminatedFraction(pa);
            double pa2 = AASIlluminatedFraction.PhaseAngleRectangular(0.621746, -0.664810, -0.033134, -2.62070, 26.11428, 0.910947);
            double k3 = AASIlluminatedFraction.IlluminatedFraction(pa2);

            double VenusMag = AASIlluminatedFraction.VenusMagnitudeMuller(0.724604, 0.910947, 72.96);
            double VenusMag2 = AASIlluminatedFraction.VenusMagnitudeAA(0.724604, 0.910947, 72.96);

            double SaturnMag = AASIlluminatedFraction.SaturnMagnitudeMuller(9.867882, 10.464606, 4.198, 16.442);
            double SaturnMag2 = AASIlluminatedFraction.SaturnMagnitudeAA(9.867882, 10.464606, 4.198, 16.442);


            CAAPhysicalMarsDetails MarsDetails = AASPhysicalMars.Calculate(2448935.500683);

            CAAPhysicalJupiterDetails JupiterDetails = AASPhysicalJupiter.Calculate(2448972.50068);

            //The example as given in the book
            AASGalileanMoonsDetails GalileanDetails = AASGalileanMoons.Calculate(2448972.50068);

            //Calculate the Eclipse Disappearance of Satellite 1 on February 1 2004 at 13:32 UCT
            double JD = 2453037.05903;
            int i;
            for (i = 0; i < 10; i++)
            {
                AASGalileanMoonsDetails GalileanDetails1 = AASGalileanMoons.Calculate(JD);
                JD += (1.0 / 1440);
            }

            //Calculate the Shadow Egress of Satellite 1 on February 2  2004 at 13:07 UT
            JD = 2453038.04236;
            for (i = 0; i < 10; i++)
            {
                AASGalileanMoonsDetails GalileanDetails1 = AASGalileanMoons.Calculate(JD);
                JD += (1.0 / 1440);
            }

            //Calculate the Shadow Ingress of Satellite 4 on February 6 2004 at 22:59 UCT
            JD = 2453042.45486;
            for (i = 0; i < 10; i++)
            {
                AASGalileanMoonsDetails GalileanDetails1 = AASGalileanMoons.Calculate(JD);
                JD += (1.0 / 1440);
            }

            //Calculate the Shadow Egress of Satellite 4 on February 7 2004 at 2:41 UCT
            JD = 2453042.61042;
            for (i = 0; i < 10; i++)
            {
                AASGalileanMoonsDetails GalileanDetails1 = AASGalileanMoons.Calculate(JD);
                JD += (1.0 / 1440);
            }

            //Calculate the Transit Ingress of Satellite 4 on February 7 2004 at 5:07 UCT
            JD = 2453042.71181;
            for (i = 0; i < 10; i++)
            {
                AASGalileanMoonsDetails GalileanDetails1 = AASGalileanMoons.Calculate(JD);
                JD += (1.0 / 1440);
            }

            //Calculate the Transit Egress of Satellite 4 on February 7 2004 at 7:46 UT
            JD = 2453042.82222;
            for (i = 0; i < 10; i++)
            {
                AASGalileanMoonsDetails GalileanDetails1 = AASGalileanMoons.Calculate(JD);
                JD += (1.0 / 1440);
            }

            AASSaturnRingDetails saturnrings = AASSaturnRings.Calculate(2448972.50068);

            AASSaturnMoonsDetails saturnMoons = AASSaturnMoons.Calculate(2451439.50074);

            double ApproxK = AASMoonPhases.K(1977.13);
            double NewMoonJD = AASMoonPhases.TruePhase(-283);

            double ApproxK2 = AASMoonPhases.K(2044);
            double LastQuarterJD = AASMoonPhases.TruePhase(544.75);

            double MoonDeclinationK = AASMoonMaxDeclinations.K(1988.95);

            double MoonNorthDec = AASMoonMaxDeclinations.TrueGreatestDeclination(-148, true);
            double MoonNorthDecValue = AASMoonMaxDeclinations.TrueGreatestDeclinationValue(-148, true);

            double MoonSouthDec = AASMoonMaxDeclinations.TrueGreatestDeclination(659, false);
            double MoonSouthDecValue = AASMoonMaxDeclinations.TrueGreatestDeclinationValue(659, false);

            double MoonNorthDec2 = AASMoonMaxDeclinations.TrueGreatestDeclination(-26788, true);
            double MoonNorthDecValue2 = AASMoonMaxDeclinations.TrueGreatestDeclinationValue(-26788, true);

            double sd1 = AASDiameters.SunSemidiameterA(1);
            double sd2 = AASDiameters.SunSemidiameterA(2);

            double sd3 = AASDiameters.VenusSemidiameterA(1);
            double sd4 = AASDiameters.VenusSemidiameterA(2);
            double sd5 = AASDiameters.VenusSemidiameterB(1);
            double sd6 = AASDiameters.VenusSemidiameterB(2);

            double sd11 = AASDiameters.MarsSemidiameterA(1);
            double sd12 = AASDiameters.MarsSemidiameterA(2);
            double sd13 = AASDiameters.MarsSemidiameterB(1);
            double sd14 = AASDiameters.MarsSemidiameterB(2);

            double sd15 = AASDiameters.JupiterEquatorialSemidiameterA(1);
            double sd16 = AASDiameters.JupiterEquatorialSemidiameterA(2);
            double sd17 = AASDiameters.JupiterEquatorialSemidiameterB(1);
            double sd18 = AASDiameters.JupiterEquatorialSemidiameterB(2);

            double sd19 = AASDiameters.JupiterPolarSemidiameterA(1);
            double sd20 = AASDiameters.JupiterPolarSemidiameterA(2);
            double sd21 = AASDiameters.JupiterPolarSemidiameterB(1);
            double sd22 = AASDiameters.JupiterPolarSemidiameterB(2);

            double sd23 = AASDiameters.SaturnEquatorialSemidiameterA(1);
            double sd24 = AASDiameters.SaturnEquatorialSemidiameterA(2);
            double sd25 = AASDiameters.SaturnEquatorialSemidiameterB(1);
            double sd26 = AASDiameters.SaturnEquatorialSemidiameterB(2);

            double sd27 = AASDiameters.SaturnPolarSemidiameterA(1);
            double sd28 = AASDiameters.SaturnPolarSemidiameterA(2);
            double sd29 = AASDiameters.SaturnPolarSemidiameterB(1);
            double sd30 = AASDiameters.SaturnPolarSemidiameterB(2);

            double sd31 = AASDiameters.ApparentSaturnPolarSemidiameterA(1, 16.442);
            double sd32 = AASDiameters.ApparentSaturnPolarSemidiameterA(2, 16.442);

            double sd33 = AASDiameters.UranusSemidiameterA(1);
            double sd34 = AASDiameters.UranusSemidiameterA(2);
            double sd35 = AASDiameters.UranusSemidiameterB(1);
            double sd36 = AASDiameters.UranusSemidiameterB(2);

            double sd37 = AASDiameters.NeptuneSemidiameterA(1);
            double sd38 = AASDiameters.NeptuneSemidiameterA(2);
            double sd39 = AASDiameters.NeptuneSemidiameterB(1);
            double sd40 = AASDiameters.NeptuneSemidiameterB(2);

            double sd41 = AASDiameters.PlutoSemidiameterB(1);
            double sd42 = AASDiameters.PlutoSemidiameterB(2);
            double sd43 = AASDiameters.GeocentricMoonSemidiameter(368407.9);
            double sd44 = AASDiameters.GeocentricMoonSemidiameter(368407.9 - 10000);

            double sd45 = AASDiameters.TopocentricMoonSemidiameter(368407.9, 5, 0, 33.356111, 1706);
            double sd46 = AASDiameters.TopocentricMoonSemidiameter(368407.9, 5, 6, 33.356111, 1706);
            double sd47 = AASDiameters.TopocentricMoonSemidiameter(368407.9 - 10000, 5, 0, 33.356111, 1706);
            double sd48 = AASDiameters.TopocentricMoonSemidiameter(368407.9 - 10000, 5, 6, 33.356111, 1706);

            double sd49 = AASDiameters.AsteroidDiameter(4, 0.04);
            double sd50 = AASDiameters.AsteroidDiameter(4, 0.08);
            double sd51 = AASDiameters.AsteroidDiameter(6, 0.04);
            double sd53 = AASDiameters.AsteroidDiameter(6, 0.08);
            double sd54 = AASDiameters.ApparentAsteroidDiameter(1, 250);
            double sd55 = AASDiameters.ApparentAsteroidDiameter(1, 1000);

            AASPhysicalMoonDetails MoonDetails = AASPhysicalMoon.CalculateGeocentric(2448724.5);
            AASPhysicalMoonDetails MoonDetail2 = AASPhysicalMoon.CalculateTopocentric(2448724.5, 10, 52);
            AASSelenographicMoonDetails AASSelenographicMoonDetails = AASPhysicalMoon.CalculateSelenographicPositionOfSun(2448724.5);

            double AltitudeOfSun = AASPhysicalMoon.AltitudeOfSun(2448724.5, -20, 9.7);
            double TimeOfSunrise = AASPhysicalMoon.TimeOfSunrise(2448724.5, -20, 9.7);
            double TimeOfSunset = AASPhysicalMoon.TimeOfSunset(2448724.5, -20, 9.7);

            AASSolarEclipseDetails EclipseDetails = AASEclipses.CalculateSolar(-82);
            AASSolarEclipseDetails EclipseDetails2 = AASEclipses.CalculateSolar(118);
            AASLunarEclipseDetails EclipseDetails3 = AASEclipses.CalculateLunar(-328.5);
            AASLunarEclipseDetails EclipseDetails4 = AASEclipses.CalculateLunar(-30.5); //No lunar eclipse
            EclipseDetails4 = AASEclipses.CalculateLunar(-29.5); //No lunar eclipse
            EclipseDetails4 = AASEclipses.CalculateLunar(-28.5); //Aha, found you!

            //AASCalendarDate JulianDate = AASMoslemCalendar.MoslemToJulian(1421, 1, 1);
            //AASCalendarDate GregorianDate = AASDate.JulianToGregorian(JulianDate.Year, JulianDate.Month, JulianDate.Day);
            //AASCalendarDate JulianDate2 = AASDate.GregorianToJulian(GregorianDate.Year, GregorianDate.Month, GregorianDate.Day);
            //AASCalendarDate MoslemDate = AASMoslemCalendar.JulianToMoslem(JulianDate2.Year, JulianDate2.Month, JulianDate2.Day);
            //bLeap = AASMoslemCalendar.IsLeap(1421);

            //MoslemDate = AASMoslemCalendar.JulianToMoslem(2006, 12, 31);
            //AASCalendarDate OriginalMoslemDate = AASMoslemCalendar.MoslemToJulian(MoslemDate.Year, MoslemDate.Month, MoslemDate.Day);
            //MoslemDate = AASMoslemCalendar.JulianToMoslem(2007, 1, 1);
            //OriginalMoslemDate = AASMoslemCalendar.MoslemToJulian(MoslemDate.Year, MoslemDate.Month, MoslemDate.Day);

            //AASCalendarDate JulianDate3 = AASDate.GregorianToJulian(1991, 8, 13);
            //AASCalendarDate MoslemDate2 = AASMoslemCalendar.JulianToMoslem(JulianDate3.Year, JulianDate3.Month, JulianDate3.Day);
            //AASCalendarDate JulianDate4 = AASMoslemCalendar.MoslemToJulian(MoslemDate2.Year, MoslemDate2.Month, MoslemDate2.Day);
            //AASCalendarDate GregorianDate2 = AASDate.JulianToGregorian(JulianDate4.Year, JulianDate4.Month, JulianDate4.Day);

            //AASCalendarDate JewishDate = AASJewishCalendar.DateOfPesach(1990);
            //bLeap = AASJewishCalendar.IsLeap(JewishDate.Year);
            //bLeap = AASJewishCalendar.IsLeap(5751);
            //long DaysInJewishYear = AASJewishCalendar.DaysInYear(JewishDate.Year);
            //DaysInJewishYear = AASJewishCalendar.DaysInYear(5751);


            AASNearParabolicObjectElements elements6 = new AASNearParabolicObjectElements { q = 0.921326, e = 1, i = 0 /*unknown*/, omega = 0 /*unknown*/, w = 0 /*unknown*/, T = 0, JDEquinox = 0 };
            AASNearParabolicObjectDetails details3 = AASNearParabolic.Calculate(138.4783, ref elements6);

            elements6.q = 0.1;
            elements6.e = 0.987;
            details3 = AASNearParabolic.Calculate(254.9, ref elements6);

            elements6.q = 0.123456;
            elements6.e = 0.99997;
            details3 = AASNearParabolic.Calculate(-30.47, ref elements6);

            elements6.q = 3.363943;
            elements6.e = 1.05731;
            details3 = AASNearParabolic.Calculate(1237.1, ref elements6);

            elements6.q = 0.5871018;
            elements6.e = 0.9672746;
            details3 = AASNearParabolic.Calculate(20, ref elements6);

            details3 = AASNearParabolic.Calculate(0, ref elements6);

            AASEclipticalElementDetails ed5 = AASEclipticalElements.Calculate(131.5856, 242.6797, 138.6637, 2433282.4235, 2448188.500000 + 0.6954 - 63.6954);
            AASEclipticalElementDetails ed6 = AASEclipticalElements.Calculate(131.5856, 242.6797, 138.6637, 2433282.4235, 2433282.4235);
            AASEclipticalElementDetails ed7 = AASEclipticalElements.FK4B1950ToFK5J2000(131.5856, 242.6797, 138.6637);

            elements6.q = 0.93858;
            elements6.e = 1.000270;
            elements6.i = ed5.i;
            elements6.omega = ed5.omega;
            elements6.w = ed5.w;
            elements6.T = 2448188.500000 + 0.6954;
            elements6.JDEquinox = elements6.T;
            AASNearParabolicObjectDetails details4 = AASNearParabolic.Calculate(elements6.T - 63.6954, ref elements6);

            Console.ReadLine();
            return;
        }

        static void LunarRaDec(double JD, ref double RA, ref double Dec)
        {
            double Lambda = AASMoon.EclipticLongitude(JD);
            double Beta = AASMoon.EclipticLatitude(JD);
            double Epsilon = AASNutation.TrueObliquityOfEcliptic(JD);
            AAS2DCoordinate Lunarcoord = AASCoordinateTransformation.Ecliptic2Equatorial(Lambda, Beta, Epsilon);

            RA = Lunarcoord.X;
            Dec = Lunarcoord.Y;
        }
    }
}
