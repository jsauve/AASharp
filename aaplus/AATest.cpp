#include "stdafx.h"
#include "AA+.h"
#include <cstdio>
using namespace std;


void LunarRaDec(double JD, double& RA, double& Dec) 
{
  double Lambda = CAAMoon::EclipticLongitude(JD); 
  double Beta = CAAMoon::EclipticLatitude(JD); 
  double Epsilon = CAANutation::TrueObliquityOfEcliptic(JD);
  CAA2DCoordinate Lunarcoord = CAACoordinateTransformation::Ecliptic2Equatorial(Lambda, Beta, Epsilon);

  RA = Lunarcoord.X;
  Dec = Lunarcoord.Y;
}

int main()
{
  //Calculate the topocentric horizontal position of the Sun for Palomar Observatory on midnight UTC for the 21st of September 2007
  CAADate dateSunCalc(2007, 9, 21, true);
  double JDSun = dateSunCalc.Julian() + CAADynamicalTime::DeltaT(dateSunCalc.Julian()) / 86400.0;  
  double SunLong = CAASun::ApparentEclipticLongitude(JDSun);
  double SunLat = CAASun::ApparentEclipticLatitude(JDSun);
  CAA2DCoordinate Equatorial = CAACoordinateTransformation::Ecliptic2Equatorial(SunLong, SunLat, CAANutation::TrueObliquityOfEcliptic(JDSun));
  double SunRad = CAAEarth::RadiusVector(JDSun);
  double Longitude = CAACoordinateTransformation::DMSToDegrees(116, 51, 45); //West is considered positive
  double Latitude = CAACoordinateTransformation::DMSToDegrees(33, 21, 22);
  double Height = 1706;
  CAA2DCoordinate SunTopo = CAAParallax::Equatorial2Topocentric(Equatorial.X, Equatorial.Y, SunRad, Longitude, Latitude, Height, JDSun);
  double AST = CAASidereal::ApparentGreenwichSiderealTime(dateSunCalc.Julian());
  double LongtitudeAsHourAngle = CAACoordinateTransformation::DegreesToHours(Longitude);
  double LocalHourAngle = AST - LongtitudeAsHourAngle - SunTopo.X;
  CAA2DCoordinate SunHorizontal = CAACoordinateTransformation::Equatorial2Horizontal(LocalHourAngle, SunTopo.Y, Latitude);
  SunHorizontal.Y += CAARefraction::RefractionFromTrue(SunHorizontal.Y, 1013, 10);
  
  //The result above should be that we have a setting Sun at 21 degrees above the horizon at azimuth 14 degrees south of the westerly horizon  


  //Calculate the topocentric horizontal position of the Moon for Palomar Observatory on midnight UTC for the 21st of September 2007
  CAADate dateMoonCalc(2007, 9, 21, true);
  double JDMoon = dateMoonCalc.Julian() + CAADynamicalTime::DeltaT(dateMoonCalc.Julian()) / 86400.0;  
  double MoonLong = CAAMoon::EclipticLongitude(JDMoon);
  double MoonLat = CAAMoon::EclipticLatitude(JDMoon);
  Equatorial = CAACoordinateTransformation::Ecliptic2Equatorial(MoonLong, MoonLat, CAANutation::TrueObliquityOfEcliptic(JDMoon));
  double MoonRad = CAAMoon::RadiusVector(JDMoon);
  MoonRad /= 149597870.691; //Convert KM to AU
  Longitude = CAACoordinateTransformation::DMSToDegrees(116, 51, 45); //West is considered positive
  Latitude = CAACoordinateTransformation::DMSToDegrees(33, 21, 22);
  Height = 1706;
  CAA2DCoordinate MoonTopo = CAAParallax::Equatorial2Topocentric(Equatorial.X, Equatorial.Y, MoonRad, Longitude, Latitude, Height, JDMoon);
  AST = CAASidereal::ApparentGreenwichSiderealTime(dateMoonCalc.Julian());
  LongtitudeAsHourAngle = CAACoordinateTransformation::DegreesToHours(Longitude);
  LocalHourAngle = AST - LongtitudeAsHourAngle - MoonTopo.X;
  CAA2DCoordinate MoonHorizontal = CAACoordinateTransformation::Equatorial2Horizontal(LocalHourAngle, MoonTopo.Y, Latitude);
  MoonHorizontal.Y += CAARefraction::RefractionFromTrue(MoonHorizontal.Y, 1013, 10);
  
  //The result above should be that we have a rising Moon at 17 degrees above the horizon at azimuth 38 degrees east of the southern horizon  




  //Do a full round trip test on CAADate across a nice wide range. Note we should expect
  //some printfs to appear during this test (Specifically a monotonic error for 15 October 1582)
  double prevJulian = -1;
  for (int YYYY=-4712; YYYY<5000; YYYY++) //Change the end YYYY value if you would like to test a longer range
  {
    if ((YYYY % 1000) == 0)
      printf("Doing date tests on year %d\n", YYYY);
    for (int MMMM=1; MMMM<=12; MMMM++)
    {
      bool bLeap = CAADate::IsLeap(YYYY, (YYYY >= 1582));
      for (int DDDD=1; DDDD<=CAADate::DaysInMonth(MMMM, bLeap); DDDD++)
      {
        bool bGregorian = CAADate::AfterPapalReform(YYYY, MMMM, DDDD);
        CAADate date(YYYY, MMMM, DDDD, 12, 0, 0, bGregorian);
        if ((date.Year() != YYYY) || (date.Month() != MMMM)|| (date.Day() != DDDD))
          printf("Round trip bug with date %d/%d/%d\n", YYYY, MMMM, DDDD);
        double currentJulian = date.Julian();
        if ((prevJulian != -1) && ((prevJulian + 1) != currentJulian))
          printf("Julian Day monotonic bug with date %d/%d/%d\n", YYYY, MMMM, DDDD);
        prevJulian = currentJulian;
        
        //Only do round trip tests between the Julian and Gregorian calendars after the papal 
        //reform. This is because the CAADate class does not support the propalactic Gregorian 
        //calendar, while it does fully support the propalactic Julian calendar.
        if (bGregorian)
        {
          CAACalendarDate GregorianDate(CAADate::JulianToGregorian(YYYY, MMMM, DDDD));
          CAACalendarDate JulianDate(CAADate::GregorianToJulian(GregorianDate.Year, GregorianDate.Month, GregorianDate.Day));
          if ((JulianDate.Year != YYYY) || (JulianDate.Month != MMMM)|| (JulianDate.Day != DDDD))
            printf("Round trip bug with Julian -> Gregorian Calendar %d/%d/%d\n", YYYY, MMMM, DDDD);
        }
      }
    }
  }
  printf("Date tests completed\n");
  
  //Test out the AADate class
  CAADate date;
  date.Set(2000, 1, 1, 12, 1, 2.3, true);
  long Year = 0;
  long Month = 0;
  long Day= 0;
  long Hour = 0;
  long Minute = 0;
  double Second = 0;
  date.Get(Year, Month, Day, Hour, Minute, Second);
  long DaysInMonth = date.DaysInMonth();
  DaysInMonth;
  long DaysInYear = date.DaysInYear();
  DaysInYear;
  bool bLeap = date.Leap();
  bLeap;
  double Julian = date.Julian();
  Julian;
  double FractionalYear = date.FractionalYear();
  FractionalYear;
  double DayOfYear = date.DayOfYear();
  DayOfYear;
  CAADate::DAY_OF_WEEK dow = date.DayOfWeek();
  dow;
  Year = date.Year();
  Month = date.Month();
  Day = date.Day();
  Hour = date.Hour();
  Minute = date.Minute();
  Second = date.Second();
  double Julian2 = date;
  Julian2;

  date.Set(1978, 11, 14, 0, 0, 0, true);
  long DayNumber = static_cast<long>(date.DayOfYear());
  date.DayOfYearToDayAndMonth(DayNumber, date.Leap(), Day, Month);
  Year = date.Year();

  //Test out the AAEaster class
  CAAEasterDetails easterDetails = CAAEaster::Calculate(1991, true);
  CAAEasterDetails easterDetails2 = CAAEaster::Calculate(1818, true);
  CAAEasterDetails easterDetails3 = CAAEaster::Calculate(179, false);

  //Test out the AADynamicalTime class
  date.Set(1977, 2, 18, 3, 37, 40, true);
  double DeltaT = CAADynamicalTime::DeltaT(date.Julian());
  date.Set(333, 2, 6, 6, 0, 0, false);
  DeltaT = CAADynamicalTime::DeltaT(date.Julian());
  DeltaT;

  //Test out the AAGlobe class
  double rhosintheta = CAAGlobe::RhoSinThetaPrime(33.356111, 1706);
  rhosintheta;
  double rhocostheta = CAAGlobe::RhoCosThetaPrime(33.356111, 1706);
  rhocostheta;
  double RadiusOfLatitude = CAAGlobe::RadiusOfParallelOfLatitude(42);
  RadiusOfLatitude;
  double RadiusOfCurvature = CAAGlobe::RadiusOfCurvature(42);
  RadiusOfCurvature;
  double Distance = CAAGlobe::DistanceBetweenPoints(CAACoordinateTransformation::DMSToDegrees(48, 50, 11), CAACoordinateTransformation::DMSToDegrees(2, 20, 14, false),
                                                    CAACoordinateTransformation::DMSToDegrees(38, 55, 17), CAACoordinateTransformation::DMSToDegrees(77, 3, 56));
  Distance;


  double Distance1 = CAAGlobe::DistanceBetweenPoints(50, 0, 50, 60);
  Distance1;
  double Distance2 = CAAGlobe::DistanceBetweenPoints(50, 0, 50, 1);
  Distance2;
  double Distance3 = CAAGlobe::DistanceBetweenPoints(CAACoordinateTransformation::DMSToDegrees(89, 59, 0), 0, CAACoordinateTransformation::DMSToDegrees(89, 59, 0), 1);
  Distance3;
  double Distance4 = CAAGlobe::DistanceBetweenPoints(CAACoordinateTransformation::DMSToDegrees(89, 59, 0), 0, CAACoordinateTransformation::DMSToDegrees(89, 59, 0), 180);
  Distance4;
  double Distance5 = CAAGlobe::DistanceBetweenPoints(CAACoordinateTransformation::DMSToDegrees(89, 59, 0), 0, CAACoordinateTransformation::DMSToDegrees(89, 59, 0), 90);
  Distance5;


  //Test out the AASidereal class
  date.Set(1987, 4, 10, 0, 0, 0, true);
  double MST = CAASidereal::MeanGreenwichSiderealTime(date.Julian());
  AST = CAASidereal::ApparentGreenwichSiderealTime(date.Julian());
  AST;
  date.Set(1987, 4, 10, 19, 21, 0, true);
  MST = CAASidereal::MeanGreenwichSiderealTime(date.Julian());
  MST;

  //Test out the AACoordinateTransformation class
  CAA2DCoordinate Ecliptic = CAACoordinateTransformation::Equatorial2Ecliptic(CAACoordinateTransformation::DMSToDegrees(7, 45, 18.946), CAACoordinateTransformation::DMSToDegrees(28, 01, 34.26), 23.4392911);
  Equatorial = CAACoordinateTransformation::Ecliptic2Equatorial(Ecliptic.X, Ecliptic.Y, 23.4392911);
  CAA2DCoordinate Galactic = CAACoordinateTransformation::Equatorial2Galactic(CAACoordinateTransformation::DMSToDegrees(17, 48, 59.74), CAACoordinateTransformation::DMSToDegrees(14, 43, 8.2, false));
  CAA2DCoordinate Equatorial2 = CAACoordinateTransformation::Galactic2Equatorial(Galactic.X, Galactic.Y);
  date.Set(1987, 4, 10, 19, 21, 0, true);
  AST = CAASidereal::ApparentGreenwichSiderealTime(date.Julian());
  LongtitudeAsHourAngle = CAACoordinateTransformation::DegreesToHours(CAACoordinateTransformation::DMSToDegrees(77, 3, 56));
  double Alpha = CAACoordinateTransformation::DMSToDegrees(23, 9, 16.641);
  LocalHourAngle = AST - LongtitudeAsHourAngle - Alpha;
  CAA2DCoordinate Horizontal = CAACoordinateTransformation::Equatorial2Horizontal(LocalHourAngle, CAACoordinateTransformation::DMSToDegrees(6, 43, 11.61, false), CAACoordinateTransformation::DMSToDegrees(38, 55, 17));
  CAA2DCoordinate Equatorial3 = CAACoordinateTransformation::Horizontal2Equatorial(Horizontal.X, Horizontal.Y, CAACoordinateTransformation::DMSToDegrees(38, 55, 17));
  double alpha2 = CAACoordinateTransformation::MapTo0To24Range(AST - Equatorial3.X - LongtitudeAsHourAngle);
  alpha2;

  //Test out the CAANutation class (on its own)
  date.Set(1987, 4, 10, 0, 0, 0, true);
  double Obliquity = CAANutation::MeanObliquityOfEcliptic(date.Julian());
  Obliquity;
  double NutationInLongitude = CAANutation::NutationInLongitude(date.Julian());
  NutationInLongitude;
	double NutationInEcliptic = CAANutation::NutationInObliquity(date.Julian());
  NutationInEcliptic;

  //Test out the CAAParallactic class
  double HourAngle = CAAParallactic::ParallacticAngle(-3, 10, 20);
  HourAngle;
  double EclipticLongitude = CAAParallactic::EclipticLongitudeOnHorizon(5, 23.44, 51);
  EclipticLongitude;
  double EclipticAngle = CAAParallactic::AngleBetweenEclipticAndHorizon(5, 23.44, 51);
  EclipticAngle;
  double Angle = CAAParallactic::AngleBetweenNorthCelestialPoleAndNorthPoleOfEcliptic(90, 0, 23.44);
  Angle;

  //Test out the CAARefraction class
  double R1 = CAARefraction::RefractionFromApparent(0.5);
  double R2 = CAARefraction::RefractionFromTrue(0.5 - R1 + CAACoordinateTransformation::DMSToDegrees(0, 32, 0));
  R2;
  double R3 = CAARefraction::RefractionFromApparent(90);
  R3;

  //Test out the CAAAngularSeparation class
  double AngularSeparation = CAAAngularSeparation::Separation(CAACoordinateTransformation::DMSToDegrees(14, 15, 39.7), CAACoordinateTransformation::DMSToDegrees(19, 10, 57),
                                                              CAACoordinateTransformation::DMSToDegrees(13, 25, 11.6), CAACoordinateTransformation::DMSToDegrees(11, 9, 41, false));
  AngularSeparation;
  double AngularSeparation2 = CAAAngularSeparation::Separation(CAACoordinateTransformation::DMSToDegrees(2, 0, 0), CAACoordinateTransformation::DMSToDegrees(0, 0, 0),
                                                               CAACoordinateTransformation::DMSToDegrees(2, 0, 0), CAACoordinateTransformation::DMSToDegrees(0, 0, 0));
  AngularSeparation2;
  double AngularSeparation3 = CAAAngularSeparation::Separation(CAACoordinateTransformation::DMSToDegrees(2, 0, 0), CAACoordinateTransformation::DMSToDegrees(0, 0, 0),
                                                               CAACoordinateTransformation::DMSToDegrees(14, 0, 0), CAACoordinateTransformation::DMSToDegrees(0, 0, 0));
  AngularSeparation3;

  double PA0 = CAAAngularSeparation::PositionAngle(CAACoordinateTransformation::DMSToDegrees(5, 32, 0.4), CAACoordinateTransformation::DMSToDegrees(0, 17, 56.9, false),
                                                               CAACoordinateTransformation::DMSToDegrees(5, 36, 12.81), CAACoordinateTransformation::DMSToDegrees(1, 12, 7, false));
  PA0;

  double PA1 = CAAAngularSeparation::PositionAngle(CAACoordinateTransformation::DMSToDegrees(5, 40, 45.52), CAACoordinateTransformation::DMSToDegrees(1, 56, 33.3, false),
                                                               CAACoordinateTransformation::DMSToDegrees(5, 36, 12.81), CAACoordinateTransformation::DMSToDegrees(1, 12, 7, false));
  PA1;


  double distance = CAAAngularSeparation::DistanceFromGreatArc(CAACoordinateTransformation::DMSToDegrees(5, 32, 0.4), CAACoordinateTransformation::DMSToDegrees(0, 17, 56.9, false), 
                                                               CAACoordinateTransformation::DMSToDegrees(5, 40, 45.52), CAACoordinateTransformation::DMSToDegrees(1, 56, 33.3, false),
                                                               CAACoordinateTransformation::DMSToDegrees(5, 36, 12.81), CAACoordinateTransformation::DMSToDegrees(1, 12, 7, false));
  distance;

  bool bType1;
  double separation = CAAAngularSeparation::SmallestCircle(CAACoordinateTransformation::DMSToDegrees(12, 41, 8.63), CAACoordinateTransformation::DMSToDegrees(5, 37, 54.2, false), 
                                                           CAACoordinateTransformation::DMSToDegrees(12, 52, 5.21), CAACoordinateTransformation::DMSToDegrees(4, 22, 26.2, false),
                                                           CAACoordinateTransformation::DMSToDegrees(12, 39, 28.11), CAACoordinateTransformation::DMSToDegrees(1, 50, 3.7, false), bType1);

  separation = CAAAngularSeparation::SmallestCircle(CAACoordinateTransformation::DMSToDegrees(9, 5, 41.44), CAACoordinateTransformation::DMSToDegrees(18, 30, 30), 
                                                    CAACoordinateTransformation::DMSToDegrees(9, 9, 29), CAACoordinateTransformation::DMSToDegrees(17, 43, 56.7),
                                                    CAACoordinateTransformation::DMSToDegrees(8, 59, 47.14), CAACoordinateTransformation::DMSToDegrees(17, 49, 36.8), bType1);
  separation;

  Alpha = CAACoordinateTransformation::DMSToDegrees(2, 44, 11.986);
  double Delta = CAACoordinateTransformation::DMSToDegrees(49, 13, 42.48);
  CAA2DCoordinate PA = CAAPrecession::AdjustPositionUsingUniformProperMotion((2462088.69-2451545)/365.25, Alpha, Delta, 0.03425, -0.0895);

  CAA2DCoordinate Precessed = CAAPrecession::PrecessEquatorial(PA.X, PA.Y, 2451545, 2462088.69);

  Alpha = CAACoordinateTransformation::DMSToDegrees(2, 31, 48.704);
  Delta = CAACoordinateTransformation::DMSToDegrees(89, 15, 50.72);
  CAA2DCoordinate PA2 = CAAPrecession::AdjustPositionUsingUniformProperMotion((2415020.3135-2451545)/365.25, Alpha, Delta, 0.19877, -0.0152);
  //CAA2DCoordinate Precessed2 = CAAPrecession::PrecessEquatorialFK4(PA2.X, PA2.Y, 2451545, 2415020.3135);

  CAA2DCoordinate PM = CAAPrecession::EquatorialPMToEcliptic(0, 0, 0, 1, 1, 23);


  CAA2DCoordinate PA3 = CAAPrecession::AdjustPositionUsingMotionInSpace(2.64, -7.6, -1000, CAACoordinateTransformation::DMSToDegrees(6, 45, 8.871), CAACoordinateTransformation::DMSToDegrees(16, 42, 57.99, false), -0.03847, -1.2053);
  CAA2DCoordinate PA4 = CAAPrecession::AdjustPositionUsingUniformProperMotion(-1000, CAACoordinateTransformation::DMSToDegrees(6, 45, 8.871), CAACoordinateTransformation::DMSToDegrees(16, 42, 57.99, false), -0.03847, -1.2053);

  CAA2DCoordinate PA5 = CAAPrecession::AdjustPositionUsingMotionInSpace(2.64, -7.6, -12000, CAACoordinateTransformation::DMSToDegrees(6, 45, 8.871), CAACoordinateTransformation::DMSToDegrees(16, 42, 57.99, false), -0.03847, -1.2053);
  CAA2DCoordinate PA6 = CAAPrecession::AdjustPositionUsingUniformProperMotion(-12000, CAACoordinateTransformation::DMSToDegrees(6, 45, 8.871), CAACoordinateTransformation::DMSToDegrees(16, 42, 57.99, false), -0.03847, -1.2053);

  Alpha = CAACoordinateTransformation::DMSToDegrees(2, 44, 11.986);
  Delta = CAACoordinateTransformation::DMSToDegrees(49, 13, 42.48);
  CAA2DCoordinate PA7 = CAAPrecession::AdjustPositionUsingUniformProperMotion((2462088.69-2451545)/365.25, Alpha, Delta, 0.03425, -0.0895);
  CAA3DCoordinate EarthVelocity = CAAAberration::EarthVelocity(2462088.69);
  CAA2DCoordinate Aberration = CAAAberration::EquatorialAberration(PA7.X, PA7.Y, 2462088.69);
  PA7.X += Aberration.X;
  PA7.Y += Aberration.Y;
  PA7 = CAAPrecession::PrecessEquatorial(PA7.X, PA7.Y, 2451545, 2462088.69);

  Obliquity = CAANutation::MeanObliquityOfEcliptic(2462088.69);
  NutationInLongitude = CAANutation::NutationInLongitude(2462088.69);
	NutationInEcliptic = CAANutation::NutationInObliquity(2462088.69);
  double AlphaNutation = CAANutation::NutationInRightAscension(PA7.X, PA7.Y, Obliquity, NutationInLongitude, NutationInEcliptic);
  double DeltaNutation = CAANutation::NutationInDeclination(PA7.X, Obliquity, NutationInLongitude, NutationInEcliptic);
  PA7.X += CAACoordinateTransformation::DMSToDegrees(0, 0, AlphaNutation/15);
  PA7.Y += CAACoordinateTransformation::DMSToDegrees(0, 0, DeltaNutation);


  //Try out the AA kepler class
  double E0 = CAAKepler::Calculate(5, 0.1, 100);
  E0;
  double E02 = CAAKepler::Calculate(5, 0.9, 100);
  E02;
  //double E03 = CAAKepler::Calculate(


  //Try out the binary star class
  CAABinaryStarDetails bsdetails = CAABinaryStar::Calculate(1980, 41.623, 1934.008, 0.2763, 0.907, 59.025, 23.717, 219.907);
  double ApparentE = CAABinaryStar::ApparentEccentricity(0.2763, 59.025, 219.907);
  ApparentE;


  //Test out the CAAStellarMagnitudes class
  double CombinedMag = CAAStellarMagnitudes::CombinedMagnitude(1.96, 2.89);
  CombinedMag;
  double Mags[] = { 4.73, 5.22, 5.60 };
  double CombinedMag2 = CAAStellarMagnitudes::CombinedMagnitude(3, Mags);
  CombinedMag2;
  double BrightnessRatio = CAAStellarMagnitudes::BrightnessRatio(0.14, 2.12);
  double MagDiff = CAAStellarMagnitudes::MagnitudeDifference(BrightnessRatio);
  MagDiff;
  double MagDiff2 = CAAStellarMagnitudes::MagnitudeDifference(500);
  MagDiff2;
  

  //Test out the CAAVenus class
  double VenusLong = CAAVenus::EclipticLongitude(2448976.5);
  VenusLong;
  double VenusLat = CAAVenus::EclipticLatitude(2448976.5);
  VenusLat;
  double VenusRadius = CAAVenus::RadiusVector(2448976.5);
  VenusRadius;
  

  //Test out the CAAMercury class
  double MercuryLong = CAAMercury::EclipticLongitude(2448976.5);
  MercuryLong;
  double MercuryLat = CAAMercury::EclipticLatitude(2448976.5);
  MercuryLat;
  double MercuryRadius = CAAMercury::RadiusVector(2448976.5);
  MercuryRadius;


  //Test out the CAAEarth class
  double EarthLong = CAAEarth::EclipticLongitude(2448908.5);
  EarthLong;
  double EarthLat = CAAEarth::EclipticLatitude(2448908.5);
  EarthLat;
  double EarthRadius = CAAEarth::RadiusVector(2448908.5);
  EarthRadius;

  double EarthLong2 = CAAEarth::EclipticLongitudeJ2000(2448908.5);
  EarthLong2;
  double EarthLat2 = CAAEarth::EclipticLatitudeJ2000(2448908.5);
  EarthLat2;


  //Test out the CAASun class
  SunLong = CAASun::GeometricEclipticLongitude(2448908.5);
  SunLat = CAASun::GeometricEclipticLatitude(2448908.5);

  double SunLongCorrection = CAAFK5::CorrectionInLongitude(SunLong, SunLat, 2448908.5);
  SunLongCorrection;
  double SunLatCorrection = CAAFK5::CorrectionInLatitude(SunLong, 2448908.5);
  SunLatCorrection;

  SunLong = CAASun::ApparentEclipticLongitude(2448908.5);
  SunLat = CAASun::ApparentEclipticLatitude(2448908.5);
  Equatorial = CAACoordinateTransformation::Ecliptic2Equatorial(SunLong, SunLat, CAANutation::TrueObliquityOfEcliptic(2448908.5));

  CAA3DCoordinate SunCoord = CAASun::EquatorialRectangularCoordinatesMeanEquinox(2448908.5);
  CAA3DCoordinate SunCoord2 = CAASun::EclipticRectangularCoordinatesJ2000(2448908.5);
  CAA3DCoordinate SunCoord3 = CAASun::EquatorialRectangularCoordinatesJ2000(2448908.5);
  CAA3DCoordinate SunCoord4 = CAASun::EquatorialRectangularCoordinatesB1950(2448908.5);
  CAA3DCoordinate SunCoord5 = CAASun::EquatorialRectangularCoordinatesAnyEquinox(2448908.5, 2467616.0);


  //Test out the CAAMars class
  double MarsLong = CAAMars::EclipticLongitude(2448935.500683);
  MarsLong;
  double MarsLat = CAAMars::EclipticLatitude(2448935.500683);
  MarsLat;
  double MarsRadius = CAAMars::RadiusVector(2448935.500683);
  MarsRadius;


  //Test out the CAAJupiter class
  double JupiterLong = CAAJupiter::EclipticLongitude(2448972.50068);
  JupiterLong;
  double JupiterLat = CAAJupiter::EclipticLatitude(2448972.50068);
  JupiterLat;
  double JupiterRadius = CAAJupiter::RadiusVector(2448972.50068);
  JupiterRadius;


  //Test out the CAANeptune class
  double NeptuneLong = CAANeptune::EclipticLongitude(2448935.500683);
  NeptuneLong;
  double NeptuneLat = CAANeptune::EclipticLatitude(2448935.500683);
  NeptuneLat;
  double NeptuneRadius = CAANeptune::RadiusVector(2448935.500683);
  NeptuneRadius;


  //Test out the CAAUranus class
  double UranusLong = CAAUranus::EclipticLongitude(2448976.5);
  UranusLong;
  double UranusLat = CAAUranus::EclipticLatitude(2448976.5);
  UranusLat;
  double UranusRadius = CAAUranus::RadiusVector(2448976.5);
  UranusRadius;


  //Test out the CAASaturn class
  double SaturnLong = CAASaturn::EclipticLongitude(2448972.50068);
  SaturnLong;
  double SaturnLat = CAASaturn::EclipticLatitude(2448972.50068);
  SaturnLat;
  double SaturnRadius = CAASaturn::RadiusVector(2448972.50068);
  SaturnRadius;


  //Test out the CAAPluto class
  double PlutoLong = CAAPluto::EclipticLongitude(2448908.5);
  PlutoLong;
  double PlutoLat = CAAPluto::EclipticLatitude(2448908.5);
  PlutoLat;
  double PlutoRadius = CAAPluto::RadiusVector(2448908.5);
  PlutoRadius;


  //Test out the CAAMoon class
  MoonLong = CAAMoon::EclipticLongitude(2448724.5);
  MoonLat = CAAMoon::EclipticLatitude(2448724.5);
  double MoonRadius = CAAMoon::RadiusVector(2448724.5);
  double MoonParallax = CAAMoon::RadiusVectorToHorizontalParallax(MoonRadius);
  MoonParallax;
  double MoonMeanAscendingNode = CAAMoon::MeanLongitudeAscendingNode(2448724.5);
  MoonMeanAscendingNode;
  double TrueMeanAscendingNode = CAAMoon::TrueLongitudeAscendingNode(2448724.5);
  TrueMeanAscendingNode;
  double MoonMeanPerigee = CAAMoon::MeanLongitudePerigee(2448724.5);
  MoonMeanPerigee;

  //Test out the CAAPlanetPerihelionAphelion class
  long VenusK = CAAPlanetPerihelionAphelion::VenusK(1978.79);
  double VenusPerihelion = CAAPlanetPerihelionAphelion::VenusPerihelion(VenusK);
  VenusPerihelion;

  long MarsK = CAAPlanetPerihelionAphelion::MarsK(2032);
  double MarsAphelion = CAAPlanetPerihelionAphelion::MarsAphelion(MarsK);
  MarsAphelion;

  long SaturnK = CAAPlanetPerihelionAphelion::SaturnK(1925);
  double SaturnAphelion = CAAPlanetPerihelionAphelion::SaturnAphelion(SaturnK);
  SaturnAphelion;
  SaturnK = CAAPlanetPerihelionAphelion::SaturnK(1940);
  double SaturnPerihelion = CAAPlanetPerihelionAphelion::SaturnPerihelion(SaturnK);
  SaturnPerihelion;

  long UranusK = CAAPlanetPerihelionAphelion::UranusK(1750);
  double UranusAphelion = CAAPlanetPerihelionAphelion::UranusAphelion(UranusK);
  UranusAphelion;
  UranusK = CAAPlanetPerihelionAphelion::UranusK(1890);
  double UranusPerihelion = CAAPlanetPerihelionAphelion::UranusPerihelion(UranusK);
  UranusK = CAAPlanetPerihelionAphelion::UranusK(2060);
  UranusPerihelion = CAAPlanetPerihelionAphelion::UranusPerihelion(UranusK);
  UranusPerihelion;

  double EarthPerihelion = CAAPlanetPerihelionAphelion::EarthPerihelion(-10, true);
  EarthPerihelion;
  double EarthPerihelion2 = CAAPlanetPerihelionAphelion::EarthPerihelion(-10, false);
  EarthPerihelion2;


  //Test out the CAAMoonPerigeeApogee
  double MoonK = CAAMoonPerigeeApogee::K(1988.75);
  double MoonApogee = CAAMoonPerigeeApogee::MeanApogee(-148.5);
  MoonApogee;
  double MoonApogee2 = CAAMoonPerigeeApogee::TrueApogee(-148.5);
  MoonApogee2;
  double MoonApogeeParallax = CAAMoonPerigeeApogee::ApogeeParallax(-148.5);
  double MoonApogeeDistance = CAAMoon::HorizontalParallaxToRadiusVector(MoonApogeeParallax);
  MoonApogeeDistance;

  MoonK = CAAMoonPerigeeApogee::K(1990.9);
  double MoonPerigee = CAAMoonPerigeeApogee::MeanPerigee(-120);
  MoonPerigee;
  double MoonPerigee2 = CAAMoonPerigeeApogee::TruePerigee(-120);
  MoonPerigee2;
  MoonK = CAAMoonPerigeeApogee::K(1930.0);
  MoonK;
  double MoonPerigee3 = CAAMoonPerigeeApogee::TruePerigee(-927);
  MoonPerigee3;
  double MoonPerigeeParallax = CAAMoonPerigeeApogee::PerigeeParallax(-927);
  double MoonRadiusVector = CAAMoon::HorizontalParallaxToRadiusVector(MoonPerigeeParallax);
  MoonRadiusVector;
  double MoonRadiusVector2 = CAAMoon::HorizontalParallaxToRadiusVector(0.991990);
  double MoonParallax2 = CAAMoon::RadiusVectorToHorizontalParallax(MoonRadiusVector2);
  MoonParallax2;


  //Test out the CAAEclipticalElements class
  CAAEclipticalElementDetails ed1 = CAAEclipticalElements::Calculate(47.1220, 151.4486, 45.7481, 2358042.5305, 2433282.4235);
  CAAEclipticalElementDetails ed2 = CAAEclipticalElements::Calculate(11.93911, 186.24444, 334.04096, 2433282.4235, 2451545.0);
  CAAEclipticalElementDetails ed3 = CAAEclipticalElements::FK4B1950ToFK5J2000(11.93911, 186.24444, 334.04096);
  CAAEclipticalElementDetails ed4 = CAAEclipticalElements::FK4B1950ToFK5J2000(145, 186.24444, 334.04096);


  //Test out the CAAEquationOfTime class
  double E = CAAEquationOfTime::Calculate(2448908.5);
  E;


  //Test out the CAAPhysicalSun class
  CAAPhysicalSunDetails psd = CAAPhysicalSun::Calculate(2448908.50068);
  double JED = CAAPhysicalSun::TimeOfStartOfRotation(1699);
  JED;


  //Test out the CAAEquinoxesAndSolstices class
  double JuneSolstice = CAAEquinoxesAndSolstices::SummerSolstice(1962);
  JuneSolstice;


  double MarchEquinox2 = CAAEquinoxesAndSolstices::SpringEquinox(1996);
  date.Set(MarchEquinox2, true);
  date.Get(Year, Month, Day, Hour, Minute, Second);
  double JuneSolstice2 = CAAEquinoxesAndSolstices::SummerSolstice(1996);
  date.Set(JuneSolstice2, true);
  date.Get(Year, Month, Day, Hour, Minute, Second);
  double SeptemberEquinox2 = CAAEquinoxesAndSolstices::AutumnEquinox(1996);
  date.Set(SeptemberEquinox2, true);
  date.Get(Year, Month, Day, Hour, Minute, Second);
  double DecemberSolstice2 = CAAEquinoxesAndSolstices::WinterSolstice(1996);
  date.Set(DecemberSolstice2, true);
  date.Get(Year, Month, Day, Hour, Minute, Second);

  DecemberSolstice2 = CAAEquinoxesAndSolstices::WinterSolstice(2000);
  date.Set(DecemberSolstice2, true);
  date.Get(Year, Month, Day, Hour, Minute, Second);

  DecemberSolstice2 = CAAEquinoxesAndSolstices::WinterSolstice(1997);
  date.Set(DecemberSolstice2, true);
  date.Get(Year, Month, Day, Hour, Minute, Second);

  DecemberSolstice2 = CAAEquinoxesAndSolstices::WinterSolstice(2003);
  date.Set(DecemberSolstice2, true);
  date.Get(Year, Month, Day, Hour, Minute, Second);

  JuneSolstice2 = CAAEquinoxesAndSolstices::SummerSolstice(2003);
  date.Set(JuneSolstice2, true);
  date.Get(Year, Month, Day, Hour, Minute, Second);

  double SpringLength = CAAEquinoxesAndSolstices::LengthOfSpring(2000);
  double SummerLength = CAAEquinoxesAndSolstices::LengthOfSummer(2000);
  double AutumnLength = CAAEquinoxesAndSolstices::LengthOfAutumn(2000);
  double WinterLength = CAAEquinoxesAndSolstices::LengthOfWinter(2000);

  SpringLength = CAAEquinoxesAndSolstices::LengthOfSpring(-2000);
  SummerLength = CAAEquinoxesAndSolstices::LengthOfSummer(-2000);
  AutumnLength = CAAEquinoxesAndSolstices::LengthOfAutumn(-2000);
  WinterLength = CAAEquinoxesAndSolstices::LengthOfWinter(-2000);

  SpringLength = CAAEquinoxesAndSolstices::LengthOfSpring(4000);
  SpringLength;
  SummerLength = CAAEquinoxesAndSolstices::LengthOfSummer(4000);
  SummerLength;
  AutumnLength = CAAEquinoxesAndSolstices::LengthOfAutumn(4000);
  AutumnLength;
  WinterLength = CAAEquinoxesAndSolstices::LengthOfWinter(4000);
  WinterLength;


  //Test out the CAAElementsPlanetaryOrbit class
  double Mer_L = CAAElementsPlanetaryOrbit::MercuryMeanLongitude(2475460.5);
  Mer_L;
  double Mer_a = CAAElementsPlanetaryOrbit::MercurySemimajorAxis(2475460.5);
  Mer_a;
  double Mer_e = CAAElementsPlanetaryOrbit::MercuryEccentricity(2475460.5);
  Mer_e;
  double Mer_i = CAAElementsPlanetaryOrbit::MercuryInclination(2475460.5);
  Mer_i;
  double Mer_omega = CAAElementsPlanetaryOrbit::MercuryLongitudeAscendingNode(2475460.5);
  Mer_omega;
  double Mer_pi = CAAElementsPlanetaryOrbit::MercuryLongitudePerihelion(2475460.5);
  Mer_pi;

  double Ven_L = CAAElementsPlanetaryOrbit::VenusMeanLongitude(2475460.5);
  Ven_L;
  double Ven_a = CAAElementsPlanetaryOrbit::VenusSemimajorAxis(2475460.5);
  Ven_a;
  double Ven_e = CAAElementsPlanetaryOrbit::VenusEccentricity(2475460.5);
  Ven_e;
  double Ven_i = CAAElementsPlanetaryOrbit::VenusInclination(2475460.5);
  Ven_i;
  double Ven_omega = CAAElementsPlanetaryOrbit::VenusLongitudeAscendingNode(2475460.5);
  Ven_omega;
  double Ven_pi = CAAElementsPlanetaryOrbit::VenusLongitudePerihelion(2475460.5);
  Ven_pi;

  double Ea_L = CAAElementsPlanetaryOrbit::EarthMeanLongitude(2475460.5);
  Ea_L;
  double Ea_a = CAAElementsPlanetaryOrbit::EarthSemimajorAxis(2475460.5);
  Ea_a;
  double Ea_e = CAAElementsPlanetaryOrbit::EarthEccentricity(2475460.5);
  Ea_e;
  double Ea_i = CAAElementsPlanetaryOrbit::EarthInclination(2475460.5);
  Ea_i;
  double Ea_pi = CAAElementsPlanetaryOrbit::EarthLongitudePerihelion(2475460.5);
  Ea_pi;

  double Mars_L = CAAElementsPlanetaryOrbit::MarsMeanLongitude(2475460.5);
  Mars_L;
  double Mars_a = CAAElementsPlanetaryOrbit::MarsSemimajorAxis(2475460.5);
  Mars_a;
  double Mars_e = CAAElementsPlanetaryOrbit::MarsEccentricity(2475460.5);
  Mars_e;
  double Mars_i = CAAElementsPlanetaryOrbit::MarsInclination(2475460.5);
  Mars_i;
  double Mars_omega = CAAElementsPlanetaryOrbit::MarsLongitudeAscendingNode(2475460.5);
  Mars_omega;
  double Mars_pi = CAAElementsPlanetaryOrbit::MarsLongitudePerihelion(2475460.5);
  Mars_pi;

  double Jup_L = CAAElementsPlanetaryOrbit::JupiterMeanLongitude(2475460.5);
  Jup_L;
  double Jup_a = CAAElementsPlanetaryOrbit::JupiterSemimajorAxis(2475460.5);
  Jup_a;
  double Jup_e = CAAElementsPlanetaryOrbit::JupiterEccentricity(2475460.5);
  Jup_e;
  double Jup_i = CAAElementsPlanetaryOrbit::JupiterInclination(2475460.5);
  Jup_i;
  double Jup_omega = CAAElementsPlanetaryOrbit::JupiterLongitudeAscendingNode(2475460.5);
  Jup_omega;
  double Jup_pi = CAAElementsPlanetaryOrbit::JupiterLongitudePerihelion(2475460.5);
  Jup_pi;

  double Sat_L = CAAElementsPlanetaryOrbit::SaturnMeanLongitude(2475460.5);
  Sat_L;
  double Sat_a = CAAElementsPlanetaryOrbit::SaturnSemimajorAxis(2475460.5);
  Sat_a;
  double Sat_e = CAAElementsPlanetaryOrbit::SaturnEccentricity(2475460.5);
  Sat_e;
  double Sat_i = CAAElementsPlanetaryOrbit::SaturnInclination(2475460.5);
  Sat_i;
  double Sat_omega = CAAElementsPlanetaryOrbit::SaturnLongitudeAscendingNode(2475460.5);
  Sat_omega;
  double Sat_pi = CAAElementsPlanetaryOrbit::SaturnLongitudePerihelion(2475460.5);
  Sat_pi;

  double Ura_L = CAAElementsPlanetaryOrbit::UranusMeanLongitude(2475460.5);
  Ura_L;
  double Ura_a = CAAElementsPlanetaryOrbit::UranusSemimajorAxis(2475460.5);
  Ura_a;
  double Ura_e = CAAElementsPlanetaryOrbit::UranusEccentricity(2475460.5);
  Ura_e;
  double Ura_i = CAAElementsPlanetaryOrbit::UranusInclination(2475460.5);
  Ura_i;
  double Ura_omega = CAAElementsPlanetaryOrbit::UranusLongitudeAscendingNode(2475460.5);
  Ura_omega;
  double Ura_pi = CAAElementsPlanetaryOrbit::UranusLongitudePerihelion(2475460.5);
  Ura_pi;

  double Nep_L = CAAElementsPlanetaryOrbit::NeptuneMeanLongitude(2475460.5);
  Nep_L;
  double Nep_a = CAAElementsPlanetaryOrbit::NeptuneSemimajorAxis(2475460.5);
  Nep_a;
  double Nep_e = CAAElementsPlanetaryOrbit::NeptuneEccentricity(2475460.5);
  Nep_e;
  double Nep_i = CAAElementsPlanetaryOrbit::NeptuneInclination(2475460.5);
  Nep_i;
  double Nep_omega = CAAElementsPlanetaryOrbit::NeptuneLongitudeAscendingNode(2475460.5);
  Nep_omega;
  double Nep_pi = CAAElementsPlanetaryOrbit::NeptuneLongitudePerihelion(2475460.5);
  Nep_pi;


  double Mer_L2 = CAAElementsPlanetaryOrbit::MercuryMeanLongitudeJ2000(2475460.5);
  Mer_L2;
  double Mer_i2 = CAAElementsPlanetaryOrbit::MercuryInclinationJ2000(2475460.5);
  Mer_i2;
  double Mer_omega2 = CAAElementsPlanetaryOrbit::MercuryLongitudeAscendingNodeJ2000(2475460.5);
  Mer_omega2;
  double Mer_pi2 = CAAElementsPlanetaryOrbit::MercuryLongitudePerihelionJ2000(2475460.5);
  Mer_pi2;

  double Ven_L2 = CAAElementsPlanetaryOrbit::VenusMeanLongitudeJ2000(2475460.5);
  Ven_L2;
  double Ven_i2 = CAAElementsPlanetaryOrbit::VenusInclinationJ2000(2475460.5);
  Ven_i2;
  double Ven_omega2 = CAAElementsPlanetaryOrbit::VenusLongitudeAscendingNodeJ2000(2475460.5);
  Ven_omega2;
  double Ven_pi2 = CAAElementsPlanetaryOrbit::VenusLongitudePerihelionJ2000(2475460.5);
  Ven_pi2;

  double Ea_L2 = CAAElementsPlanetaryOrbit::EarthMeanLongitudeJ2000(2475460.5);
  Ea_L2;
  double Ea_i2 = CAAElementsPlanetaryOrbit::EarthInclinationJ2000(2475460.5);
  Ea_i2;
  double Ea_omega2 = CAAElementsPlanetaryOrbit::EarthLongitudeAscendingNodeJ2000(2475460.5);
  Ea_omega2;
  double Ea_pi2 = CAAElementsPlanetaryOrbit::EarthLongitudePerihelionJ2000(2475460.5);
  Ea_pi2;

  double Mars_L2 = CAAElementsPlanetaryOrbit::MarsMeanLongitudeJ2000(2475460.5);
  Mars_L2;
  double Mars_i2 = CAAElementsPlanetaryOrbit::MarsInclinationJ2000(2475460.5);
  Mars_i2;
  double Mars_omega2 = CAAElementsPlanetaryOrbit::MarsLongitudeAscendingNodeJ2000(2475460.5);
  Mars_omega2;
  double Mars_pi2 = CAAElementsPlanetaryOrbit::MarsLongitudePerihelionJ2000(2475460.5);
  Mars_pi2;

  double Jup_L2 = CAAElementsPlanetaryOrbit::JupiterMeanLongitudeJ2000(2475460.5);
  Jup_L2;
  double Jup_i2 = CAAElementsPlanetaryOrbit::JupiterInclinationJ2000(2475460.5);
  Jup_i2;
  double Jup_omega2 = CAAElementsPlanetaryOrbit::JupiterLongitudeAscendingNodeJ2000(2475460.5);
  Jup_omega2;
  double Jup_pi2 = CAAElementsPlanetaryOrbit::JupiterLongitudePerihelionJ2000(2475460.5);
  Jup_pi2;

  double Sat_L2 = CAAElementsPlanetaryOrbit::SaturnMeanLongitudeJ2000(2475460.5);
  Sat_L2;
  double Sat_i2 = CAAElementsPlanetaryOrbit::SaturnInclinationJ2000(2475460.5);
  Sat_i2;
  double Sat_omega2 = CAAElementsPlanetaryOrbit::SaturnLongitudeAscendingNodeJ2000(2475460.5);
  Sat_omega2;
  double Sat_pi2 = CAAElementsPlanetaryOrbit::SaturnLongitudePerihelionJ2000(2475460.5);
  Sat_pi2;

  double Ura_L2 = CAAElementsPlanetaryOrbit::UranusMeanLongitudeJ2000(2475460.5);
  Ura_L2;
  double Ura_i2 = CAAElementsPlanetaryOrbit::UranusInclinationJ2000(2475460.5);
  Ura_i2;
  double Ura_omega2 = CAAElementsPlanetaryOrbit::UranusLongitudeAscendingNodeJ2000(2475460.5);
  Ura_omega2;
  double Ura_pi2 = CAAElementsPlanetaryOrbit::UranusLongitudePerihelionJ2000(2475460.5);
  Ura_pi2;

  double Nep_L2 = CAAElementsPlanetaryOrbit::NeptuneMeanLongitudeJ2000(2475460.5);
  Nep_L2;
  double Nep_i2 = CAAElementsPlanetaryOrbit::NeptuneInclinationJ2000(2475460.5);
  Nep_i2;
  double Nep_omega2 = CAAElementsPlanetaryOrbit::NeptuneLongitudeAscendingNodeJ2000(2475460.5);
  Nep_omega2;
  double Nep_pi2 = CAAElementsPlanetaryOrbit::NeptuneLongitudePerihelionJ2000(2475460.5);
  Nep_pi2;

  double MoonGeocentricElongation = CAAMoonIlluminatedFraction::GeocentricElongation(8.97922, 13.7684, 1.377194, 8.6964);
  double MoonPhaseAngle = CAAMoonIlluminatedFraction::PhaseAngle(MoonGeocentricElongation, 368410, 149971520);
  double MoonIlluminatedFraction = CAAMoonIlluminatedFraction::IlluminatedFraction(MoonPhaseAngle);
  MoonIlluminatedFraction;
  double MoonPositionAngle = CAAMoonIlluminatedFraction::PositionAngle(CAACoordinateTransformation::DMSToDegrees(1, 22, 37.9), 8.6964, 134.6885/15, 13.7684);
  MoonPositionAngle;

  CAAEllipticalPlanetaryDetails VenusDetails = CAAElliptical::Calculate(2448976.5, CAAElliptical::VENUS);

  CAAEllipticalPlanetaryDetails SunDetails = CAAElliptical::Calculate(2453149.5, CAAElliptical::SUN);

  CAAEllipticalObjectElements elements;
  elements.a = 2.2091404;
  elements.e = 0.8502196;
  elements.i = 11.94524;
  elements.omega = 334.75006;
  elements.w = 186.23352;
  elements.T = 2448192.5 + 0.54502;
  elements.JDEquinox = 2451544.5;
  CAAEllipticalObjectDetails details = CAAElliptical::Calculate(2448170.5, elements);

  double Velocity1 = CAAElliptical::InstantaneousVelocity(1, 17.9400782);
  Velocity1;
  double Velocity2 = CAAElliptical::VelocityAtPerihelion(0.96727426, 17.9400782);
  Velocity2;
  double Velocity3 = CAAElliptical::VelocityAtAphelion(0.96727426, 17.9400782);
  Velocity3;

  double Length = CAAElliptical::LengthOfEllipse(0.96727426, 17.9400782);
  Length;

  double Mag1 = CAAElliptical::MinorPlanetMagnitude(3.34, 1.6906631928, 0.12, 2.6154983761, 120);  
  Mag1;
  double Mag2 = CAAElliptical::CometMagnitude(5.5, 0.378, 10, 0.658);
  Mag2;
  double Mag3 = CAAElliptical::CometMagnitude(5.5, 1.1017, 10, 1.5228);
  Mag3;

  CAAParabolicObjectElements elements2; //Elements taken from http://www.cfa.harvard.edu/mpec/J98/J98H29.html
  elements2.q = 1.48678;
  elements2.i = 104.668; //J2000
  elements2.omega = 222.103; //J2000
  elements2.w = 1.146; //J2000
  elements2.T = CAADate::DateToJD(1998, 4, 14.205, true);
  elements2.JDEquinox = 2451545.0; //J2000
  CAAParabolicObjectDetails details2 = CAAParabolic::Calculate(2451030.5, elements2);

  CAAEllipticalObjectElements elements3;
  elements3.a = 17.9400782;
  elements3.e = 0.96727426;
  elements3.i = 0; //Not required
  elements3.omega = 0; //Not required
  elements3.w = 111.84644;
  elements3.T = 2446470.5 + 0.45891;
  elements3.JDEquinox = 0; //Not required
  CAANodeObjectDetails nodedetails = CAANodes::PassageThroAscendingNode(elements3);
  CAANodeObjectDetails nodedetails2 = CAANodes::PassageThroDescendingNode(elements3);

  CAAParabolicObjectElements elements4;
  elements4.q = 1.324502;
  elements4.i = 0; //Not required
  elements4.omega = 0; //Not required
  elements4.w = 154.9103;
  elements4.T = 2447758.5 + 0.2910;
  elements4.JDEquinox = 0; //Not required
  CAANodeObjectDetails nodedetails3 = CAANodes::PassageThroAscendingNode(elements4);
  CAANodeObjectDetails nodedetails4 = CAANodes::PassageThroDescendingNode(elements4);


  CAAEllipticalObjectElements elements5;
  elements5.a = 0.723329820;
  elements5.e = 0.00678195;
  elements5.i = 0; //Not required
  elements5.omega = 0; //Not required
  elements5.w = 54.778485;
  elements5.T = 2443873.704;
  elements5.JDEquinox = 0; //Not required
  CAANodeObjectDetails nodedetails5 = CAANodes::PassageThroAscendingNode(elements5);
  
  double MoonK2 = CAAMoonNodes::K(1987.37);
  MoonK2;
  double MoonJD = CAAMoonNodes::PassageThroNode(-170);
  MoonJD;


  double Y = CAAInterpolate::Interpolate(0.18125, 0.884226, 0.877366, 0.870531);
  Y;

  double NM;
  double YM = CAAInterpolate::Extremum(1.3814294, 1.3812213, 1.3812453, NM);
  YM;

  double N0 = CAAInterpolate::Zero(-1693.4, 406.3, 2303.2);
  N0;

  double N02 = CAAInterpolate::Zero2(-2, 3, 2);
  N02;

  double Y2 = CAAInterpolate::Interpolate(0.2777778, 36.125, 24.606, 15.486, 8.694, 4.133);
  Y2;

  double N03 = CAAInterpolate::Zero(CAACoordinateTransformation::DMSToDegrees(1, 11, 21.23, false), CAACoordinateTransformation::DMSToDegrees(0, 28, 12.31, false), CAACoordinateTransformation::DMSToDegrees(0, 16, 7.02), CAACoordinateTransformation::DMSToDegrees(1, 1, 0.13), CAACoordinateTransformation::DMSToDegrees(1, 45, 46.33));
  N03;

  double N04 = CAAInterpolate::Zero(CAACoordinateTransformation::DMSToDegrees(0, 28, 12.31, false), CAACoordinateTransformation::DMSToDegrees(0, 16, 7.02), CAACoordinateTransformation::DMSToDegrees(1, 1, 0.13));
  N04;

  double N05 = CAAInterpolate::Zero2(-13, -2, 3, 2, -5);
  N05;

  double Y3 = CAAInterpolate::InterpolateToHalves(1128.732, 1402.835, 1677.247, 1951.983);
  Y3;

  double X1[] = { 29.43, 30.97, 27.69, 28.11, 31.58, 33.05 };
  double Y1[] = { 0.4913598528, 0.5145891926, 0.4646875083, 0.4711658342, 0.5236885653, 0.5453707057 };
  double Y4 = CAAInterpolate::LagrangeInterpolate(30, 6, X1, Y1);
  Y4;
  double Y5 = CAAInterpolate::LagrangeInterpolate(0, 6, X1, Y1);
  Y5;
  double Y6 = CAAInterpolate::LagrangeInterpolate(90, 6, X1, Y1);
  Y6;

  double Alpha1 = CAACoordinateTransformation::DMSToDegrees(2, 42, 43.25);
  double Alpha2 = CAACoordinateTransformation::DMSToDegrees(2, 46, 55.51);
  double Alpha3 = CAACoordinateTransformation::DMSToDegrees(2, 51, 07.69);
  double Delta1 = CAACoordinateTransformation::DMSToDegrees(18, 02, 51.4);
  double Delta2 = CAACoordinateTransformation::DMSToDegrees(18, 26, 27.3);
  double Delta3 = CAACoordinateTransformation::DMSToDegrees(18, 49, 38.7);
  double JD2 = 2447240.5;  
  Longitude = 71.0833;
  Latitude = 42.3333;
  CAARiseTransitSetDetails RiseTransitSetTime = CAARiseTransitSet::Calculate(JD2, Alpha1, Delta1, Alpha2, Delta2, Alpha3, Delta3, Longitude, Latitude, -0.5667);
  if (RiseTransitSetTime.bRiseValid)
  {
    double riseJD = (JD2 + (RiseTransitSetTime.Rise / 24.00));
    CAADate rtsDate(riseJD, true);
    long Hours;
    long Minutes;
    double Sec;
    rtsDate.Get(Year, Month, Day, Hours, Minutes, Sec);
    printf("Venus rise for Boston for UTC %d/%d/%d occurs at %02d:%02d:%02d\n", static_cast<int>(Year), static_cast<int>(Month), static_cast<int>(Day), static_cast<int>(Hours), static_cast<int>(Minutes), static_cast<int>(Sec));
  }
  else
  {
    CAADate rtsDate(JD2, true);
    long Hours;
    long Minutes;
    double Sec;
    rtsDate.Get(Year, Month, Day, Hours, Minutes, Sec);
    printf("Venus does not rise for Boston for UTC %d/%d/%d\n", static_cast<int>(Year), static_cast<int>(Month), static_cast<int>(Day));
  }
  double transitJD = (JD2 + (RiseTransitSetTime.Transit / 24.00));
  CAADate rtsDate(transitJD, true);
  long Hours;
  long Minutes;
  double Sec;
  rtsDate.Get(Year, Month, Day, Hours, Minutes, Sec);
  if (RiseTransitSetTime.bTransitAboveHorizon)
    printf("Venus transit for Boston for UTC %d/%d/%d occurs at %02d:%02d:%02d\n", static_cast<int>(Year), static_cast<int>(Month), static_cast<int>(Day), static_cast<int>(Hours), static_cast<int>(Minutes), static_cast<int>(Sec));
  else
    printf("Venus transit for Boston (below horizon) for UTC %d/%d/%d occurs at %02d:%02d:%02d\n", static_cast<int>(Year), static_cast<int>(Month), static_cast<int>(Day), static_cast<int>(Hours), static_cast<int>(Minutes), static_cast<int>(Sec));    
  if (RiseTransitSetTime.bSetValid)
  {
    double setJD = (JD2 + (RiseTransitSetTime.Set / 24.00));
    rtsDate = CAADate(setJD, true);
    rtsDate.Get(Year, Month, Day, Hours, Minutes, Sec);
    printf("Venus set for Boston UTC %d/%d/%d occurs at %02d:%02d:%02d\n", static_cast<int>(Year), static_cast<int>(Month), static_cast<int>(Day), static_cast<int>(Hours), static_cast<int>(Minutes), static_cast<int>(Sec));
  }
  else
  {
    rtsDate = CAADate(JD2, true);
    rtsDate.Get(Year, Month, Day, Hours, Minutes, Sec);
    printf("Venus does not set for Boston for UTC %d/%d/%d\n", static_cast<int>(Year), static_cast<int>(Month), static_cast<int>(Day));
  }
  
  //Calculate the time of moon set for 11th of August 2009 UTC for Palomar Observatory 
  int YYYY = 2011;
  int MM = 8;
  int DD = 10;
  CAADate CalcDate(YYYY, MM, DD, true);
  JD2 = CalcDate.Julian();  
  LunarRaDec(JD2 - 1, Alpha1, Delta1);
  LunarRaDec(JD2, Alpha2, Delta2);
  LunarRaDec(JD2 + 1, Alpha3, Delta3);
  Longitude = CAACoordinateTransformation::DMSToDegrees(116, 51, 45); //West is considered positive
  Latitude = CAACoordinateTransformation::DMSToDegrees(33, 21, 22);
  RiseTransitSetTime = CAARiseTransitSet::Calculate(JD2, Alpha1, Delta1, Alpha2, Delta2, Alpha3, Delta3, Longitude, Latitude, 0.125);
  if (RiseTransitSetTime.bRiseValid)
  {
    double riseJD = (JD2 + (RiseTransitSetTime.Rise / 24.00));
    rtsDate = CAADate(riseJD, true);
    rtsDate.Get(Year, Month, Day, Hours, Minutes, Sec);
    printf("Moon rise for Palomar Observatory for UTC %d/%d/%d occurs at %02d:%02d:%02d\n", static_cast<int>(Year), static_cast<int>(Month), static_cast<int>(Day), static_cast<int>(Hours), static_cast<int>(Minutes), static_cast<int>(Sec));
  }
  else
  {
    rtsDate = CAADate(JD2, true);
    rtsDate.Get(Year, Month, Day, Hours, Minutes, Sec);
    printf("Moon does not rise for Palomar Observatory for UTC %d/%d/%d\n", static_cast<int>(Year), static_cast<int>(Month), static_cast<int>(Day));
  }
  transitJD = (JD2 + (RiseTransitSetTime.Transit / 24.00));
  rtsDate = CAADate(transitJD, true);
  rtsDate.Get(Year, Month, Day, Hours, Minutes, Sec);
  if (RiseTransitSetTime.bTransitAboveHorizon)
    printf("Moon transit for Palomar Observatory for UTC %d/%d/%d occurs at %02d:%02d:%02d\n", static_cast<int>(Year), static_cast<int>(Month), static_cast<int>(Day), static_cast<int>(Hours), static_cast<int>(Minutes), static_cast<int>(Sec));
  else
    printf("Moon transit for Palomar Observatory (below horizon) for UTC %d/%d/%d occurs at %02d:%02d:%02d\n", static_cast<int>(Year), static_cast<int>(Month), static_cast<int>(Day), static_cast<int>(Hours), static_cast<int>(Minutes), static_cast<int>(Sec));
  if (RiseTransitSetTime.bSetValid)
  {
    double setJD = (JD2 + (RiseTransitSetTime.Set / 24.00));
    rtsDate = CAADate(setJD, true);
    rtsDate.Get(Year, Month, Day, Hours, Minutes, Sec);
    printf("Moon set for Palomar Observatory for UTC %d/%d/%d occurs at %02d:%02d:%02d\n", static_cast<int>(Year), static_cast<int>(Month), static_cast<int>(Day), static_cast<int>(Hours), static_cast<int>(Minutes), static_cast<int>(Sec));
  }
  else
  {
    rtsDate = CAADate(JD2, true);
    rtsDate.Get(Year, Month, Day, Hours, Minutes, Sec);
    printf("Moon does not set for Palomar Observatory for UTC %d/%d/%d\n", static_cast<int>(Year), static_cast<int>(Month), static_cast<int>(Day));
  }

  double Kpp = CAAPlanetaryPhenomena::K(1993.75, CAAPlanetaryPhenomena::MERCURY, CAAPlanetaryPhenomena::INFERIOR_CONJUNCTION);
  double MercuryInferiorConjunction = CAAPlanetaryPhenomena::Mean(Kpp, CAAPlanetaryPhenomena::MERCURY, CAAPlanetaryPhenomena::INFERIOR_CONJUNCTION);
  MercuryInferiorConjunction;
  double MercuryInferiorConjunction2 = CAAPlanetaryPhenomena::True(Kpp, CAAPlanetaryPhenomena::MERCURY, CAAPlanetaryPhenomena::INFERIOR_CONJUNCTION);
  MercuryInferiorConjunction2;

  double Kpp2 = CAAPlanetaryPhenomena::K(2125.5, CAAPlanetaryPhenomena::SATURN, CAAPlanetaryPhenomena::CONJUNCTION);
  double SaturnConjunction = CAAPlanetaryPhenomena::Mean(Kpp2, CAAPlanetaryPhenomena::SATURN, CAAPlanetaryPhenomena::CONJUNCTION);
  SaturnConjunction;
  double SaturnConjunction2 = CAAPlanetaryPhenomena::True(Kpp2, CAAPlanetaryPhenomena::SATURN, CAAPlanetaryPhenomena::CONJUNCTION);
  SaturnConjunction2;

  double MercuryWesternElongation = CAAPlanetaryPhenomena::True(Kpp, CAAPlanetaryPhenomena::MERCURY, CAAPlanetaryPhenomena::WESTERN_ELONGATION);
  MercuryWesternElongation;
  double MercuryWesternElongationValue = CAAPlanetaryPhenomena::ElongationValue(Kpp, CAAPlanetaryPhenomena::MERCURY, false);
  MercuryWesternElongationValue;

  double MarsStation2 = CAAPlanetaryPhenomena::True(-2, CAAPlanetaryPhenomena::MARS, CAAPlanetaryPhenomena::STATION2);
  MarsStation2;

  double MercuryK = CAAPlanetaryPhenomena::K(1631.8, CAAPlanetaryPhenomena::MERCURY, CAAPlanetaryPhenomena::INFERIOR_CONJUNCTION);
  double MercuryIC = CAAPlanetaryPhenomena::True(MercuryK, CAAPlanetaryPhenomena::MERCURY, CAAPlanetaryPhenomena::INFERIOR_CONJUNCTION);
  MercuryIC;

  double VenusKpp = CAAPlanetaryPhenomena::K(1882.9, CAAPlanetaryPhenomena::VENUS, CAAPlanetaryPhenomena::INFERIOR_CONJUNCTION);
  double VenusIC = CAAPlanetaryPhenomena::True(VenusKpp, CAAPlanetaryPhenomena::VENUS, CAAPlanetaryPhenomena::INFERIOR_CONJUNCTION);
  VenusIC;

  double MarsKpp = CAAPlanetaryPhenomena::K(2729.65, CAAPlanetaryPhenomena::MARS, CAAPlanetaryPhenomena::OPPOSITION);
  double MarsOP = CAAPlanetaryPhenomena::True(MarsKpp, CAAPlanetaryPhenomena::MARS, CAAPlanetaryPhenomena::OPPOSITION);
  MarsOP;

  double JupiterKpp = CAAPlanetaryPhenomena::K(-5, CAAPlanetaryPhenomena::JUPITER, CAAPlanetaryPhenomena::OPPOSITION);
  double JupiterOP = CAAPlanetaryPhenomena::True(JupiterKpp, CAAPlanetaryPhenomena::JUPITER, CAAPlanetaryPhenomena::OPPOSITION);
  JupiterOP;

  double SaturnKpp = CAAPlanetaryPhenomena::K(-5, CAAPlanetaryPhenomena::SATURN, CAAPlanetaryPhenomena::OPPOSITION);
  double SaturnOP = CAAPlanetaryPhenomena::True(SaturnKpp, CAAPlanetaryPhenomena::SATURN, CAAPlanetaryPhenomena::OPPOSITION);
  SaturnOP;

  double UranusKpp = CAAPlanetaryPhenomena::K(1780.6, CAAPlanetaryPhenomena::URANUS, CAAPlanetaryPhenomena::OPPOSITION);
  double UranusOP = CAAPlanetaryPhenomena::True(UranusKpp, CAAPlanetaryPhenomena::URANUS, CAAPlanetaryPhenomena::OPPOSITION);
  UranusOP;

  double NeptuneKpp = CAAPlanetaryPhenomena::K(1846.5, CAAPlanetaryPhenomena::NEPTUNE, CAAPlanetaryPhenomena::OPPOSITION);
  double NeptuneOP = CAAPlanetaryPhenomena::True(NeptuneKpp, CAAPlanetaryPhenomena::NEPTUNE, CAAPlanetaryPhenomena::OPPOSITION);
  NeptuneOP;

  CAA2DCoordinate TopocentricDelta = CAAParallax::Equatorial2TopocentricDelta(CAACoordinateTransformation::DMSToDegrees(22, 38, 7.25), -15.771083, 0.37276, CAACoordinateTransformation::DMSToDegrees(7, 47, 27)*15, CAACoordinateTransformation::DMSToDegrees(33, 21, 22), 1706, 2452879.63681);
  CAA2DCoordinate Topocentric = CAAParallax::Equatorial2Topocentric(CAACoordinateTransformation::DMSToDegrees(22, 38, 7.25), -15.771083, 0.37276, CAACoordinateTransformation::DMSToDegrees(7, 47, 27)*15, CAACoordinateTransformation::DMSToDegrees(33, 21, 22), 1706, 2452879.63681);


  double distance2 = CAAParallax::ParallaxToDistance(CAACoordinateTransformation::DMSToDegrees(0, 59, 27.7));
  double parallax2 = CAAParallax::DistanceToParallax(distance2);
  parallax2;

  CAATopocentricEclipticDetails TopocentricDetails = CAAParallax::Ecliptic2Topocentric(CAACoordinateTransformation::DMSToDegrees(181, 46, 22.5), CAACoordinateTransformation::DMSToDegrees(2, 17, 26.2), 
                                                                                       CAACoordinateTransformation::DMSToDegrees(0, 16, 15.5), CAAParallax::ParallaxToDistance(CAACoordinateTransformation::DMSToDegrees(0, 59, 27.7)), CAACoordinateTransformation::DMSToDegrees(23, 28, 0.8), 
                                                                                       CAACoordinateTransformation::DMSToDegrees(50, 5, 7.8), 0, 2452879.150858);

  double k = CAAIlluminatedFraction::IlluminatedFraction(0.724604, 0.983824, 0.910947);
  k;
  double pa1 = CAAIlluminatedFraction::PhaseAngle(0.724604, 0.983824, 0.910947);
  pa1;
  double pa = CAAIlluminatedFraction::PhaseAngle(0.724604, 0.983824, -2.62070, 26.11428, 88.35704, 0.910947);
  double k2 = CAAIlluminatedFraction::IlluminatedFraction(pa);
  k2;
  double pa2 = CAAIlluminatedFraction::PhaseAngleRectangular(0.621746, -0.664810, -0.033134, -2.62070, 26.11428, 0.910947);
  double k3 = CAAIlluminatedFraction::IlluminatedFraction(pa2);
  k3;

  double VenusMag = CAAIlluminatedFraction::VenusMagnitudeMuller(0.724604, 0.910947, 72.96);
  VenusMag;
  double VenusMag2 = CAAIlluminatedFraction::VenusMagnitudeAA(0.724604, 0.910947, 72.96);
  VenusMag2;

  double SaturnMag = CAAIlluminatedFraction::SaturnMagnitudeMuller(9.867882, 10.464606, 4.198, 16.442);
  SaturnMag;
  double SaturnMag2 = CAAIlluminatedFraction::SaturnMagnitudeAA(9.867882, 10.464606, 4.198, 16.442);
  SaturnMag2;


  CAAPhysicalMarsDetails MarsDetails = CAAPhysicalMars::Calculate(2448935.500683);

  CAAPhysicalJupiterDetails JupiterDetails = CAAPhysicalJupiter::Calculate(2448972.50068);

  //The example as given in the book
  CAAGalileanMoonsDetails GalileanDetails = CAAGalileanMoons::Calculate(2448972.50068);

  //Calculate the Eclipse Disappearance of Satellite 1 on February 1 2004 at 13:32 UCT
  double JD = 2453037.05903;
  int i;
  for (i=0; i<10; i++)
  {
    CAAGalileanMoonsDetails GalileanDetails1 = CAAGalileanMoons::Calculate(JD);
    JD += (1.0/1440);
  }

  //Calculate the Shadow Egress of Satellite 1 on February 2  2004 at 13:07 UT
  JD = 2453038.04236;
  for (i=0; i<10; i++)
  {
    CAAGalileanMoonsDetails GalileanDetails1 = CAAGalileanMoons::Calculate(JD);
    JD += (1.0/1440);
  }

  //Calculate the Shadow Ingress of Satellite 4 on February 6 2004 at 22:59 UCT
  JD = 2453042.45486;
  for (i=0; i<10; i++)
  {
    CAAGalileanMoonsDetails GalileanDetails1 = CAAGalileanMoons::Calculate(JD);
    JD += (1.0/1440);
  }

  //Calculate the Shadow Egress of Satellite 4 on February 7 2004 at 2:41 UCT
  JD = 2453042.61042;
  for (i=0; i<10; i++)
  {
    CAAGalileanMoonsDetails GalileanDetails1 = CAAGalileanMoons::Calculate(JD);
    JD += (1.0/1440);
  }

  //Calculate the Transit Ingress of Satellite 4 on February 7 2004 at 5:07 UCT
  JD = 2453042.71181;
  for (i=0; i<10; i++)
  {
    CAAGalileanMoonsDetails GalileanDetails1 = CAAGalileanMoons::Calculate(JD);
    JD += (1.0/1440);
  }

  //Calculate the Transit Egress of Satellite 4 on February 7 2004 at 7:46 UT
  JD = 2453042.82222;
  for (i=0; i<10; i++)
  {
    CAAGalileanMoonsDetails GalileanDetails1 = CAAGalileanMoons::Calculate(JD);
    JD += (1.0/1440);
  }

  CAASaturnRingDetails saturnrings = CAASaturnRings::Calculate(2448972.50068);

  CAASaturnMoonsDetails saturnMoons = CAASaturnMoons::Calculate(2451439.50074);

  double ApproxK = CAAMoonPhases::K(1977.13);
  ApproxK;
  double NewMoonJD = CAAMoonPhases::TruePhase(-283);
  NewMoonJD;

  double ApproxK2 = CAAMoonPhases::K(2044);
  ApproxK2;
  double LastQuarterJD = CAAMoonPhases::TruePhase(544.75);
  LastQuarterJD;

  double MoonDeclinationK = CAAMoonMaxDeclinations::K(1988.95);
  MoonDeclinationK;

  double MoonNorthDec = CAAMoonMaxDeclinations::TrueGreatestDeclination(-148, true);
  MoonNorthDec;
  double MoonNorthDecValue = CAAMoonMaxDeclinations::TrueGreatestDeclinationValue(-148, true);
  MoonNorthDecValue;

  double MoonSouthDec = CAAMoonMaxDeclinations::TrueGreatestDeclination(659, false);
  MoonSouthDec;
  double MoonSouthDecValue = CAAMoonMaxDeclinations::TrueGreatestDeclinationValue(659, false);
  MoonSouthDecValue;

  double MoonNorthDec2 = CAAMoonMaxDeclinations::TrueGreatestDeclination(-26788, true);
  MoonNorthDec2;
  double MoonNorthDecValue2 = CAAMoonMaxDeclinations::TrueGreatestDeclinationValue(-26788, true);
  MoonNorthDecValue2;

  double sd1 = CAADiameters::SunSemidiameterA(1);
  sd1;
  double sd2 = CAADiameters::SunSemidiameterA(2);
  sd2;

  double sd3 = CAADiameters::VenusSemidiameterA(1);
  sd3;
  double sd4 = CAADiameters::VenusSemidiameterA(2);
  sd4;
  double sd5 = CAADiameters::VenusSemidiameterB(1);
  sd5;
  double sd6 = CAADiameters::VenusSemidiameterB(2);
  sd6;

  double sd11 = CAADiameters::MarsSemidiameterA(1);
  sd11;
  double sd12 = CAADiameters::MarsSemidiameterA(2);
  sd12;
  double sd13 = CAADiameters::MarsSemidiameterB(1);
  sd13;
  double sd14 = CAADiameters::MarsSemidiameterB(2);
  sd14;

  double sd15 = CAADiameters::JupiterEquatorialSemidiameterA(1);
  sd15;
  double sd16 = CAADiameters::JupiterEquatorialSemidiameterA(2);
  sd16;
  double sd17 = CAADiameters::JupiterEquatorialSemidiameterB(1);
  sd17;
  double sd18 = CAADiameters::JupiterEquatorialSemidiameterB(2);
  sd18;

  double sd19 = CAADiameters::JupiterPolarSemidiameterA(1);
  sd19;
  double sd20 = CAADiameters::JupiterPolarSemidiameterA(2);
  sd20;
  double sd21 = CAADiameters::JupiterPolarSemidiameterB(1);
  sd21;
  double sd22 = CAADiameters::JupiterPolarSemidiameterB(2);
  sd22;

  double sd23 = CAADiameters::SaturnEquatorialSemidiameterA(1);
  sd23;
  double sd24 = CAADiameters::SaturnEquatorialSemidiameterA(2);
  sd24;
  double sd25 = CAADiameters::SaturnEquatorialSemidiameterB(1);
  sd25;
  double sd26 = CAADiameters::SaturnEquatorialSemidiameterB(2);
  sd26;

  double sd27 = CAADiameters::SaturnPolarSemidiameterA(1);
  sd27;
  double sd28 = CAADiameters::SaturnPolarSemidiameterA(2);
  sd28;
  double sd29 = CAADiameters::SaturnPolarSemidiameterB(1);
  sd29;
  double sd30 = CAADiameters::SaturnPolarSemidiameterB(2);
  sd30;

  double sd31 = CAADiameters::ApparentSaturnPolarSemidiameterA(1, 16.442);
  sd31;
  double sd32 = CAADiameters::ApparentSaturnPolarSemidiameterA(2, 16.442);
  sd32;

  double sd33 = CAADiameters::UranusSemidiameterA(1);
  sd33;
  double sd34 = CAADiameters::UranusSemidiameterA(2);
  sd34;
  double sd35 = CAADiameters::UranusSemidiameterB(1);
  sd35;
  double sd36 = CAADiameters::UranusSemidiameterB(2);
  sd36;

  double sd37 = CAADiameters::NeptuneSemidiameterA(1);
  sd37;
  double sd38 = CAADiameters::NeptuneSemidiameterA(2);
  sd38;
  double sd39 = CAADiameters::NeptuneSemidiameterB(1);
  sd39;
  double sd40 = CAADiameters::NeptuneSemidiameterB(2);
  sd40;

  double sd41 = CAADiameters::PlutoSemidiameterB(1);
  sd41;
  double sd42 = CAADiameters::PlutoSemidiameterB(2);
  sd42;
  double sd43 = CAADiameters::GeocentricMoonSemidiameter(368407.9);
  sd43;
  double sd44 = CAADiameters::GeocentricMoonSemidiameter(368407.9 - 10000);
  sd44;

  double sd45 = CAADiameters::TopocentricMoonSemidiameter(368407.9, 5, 0, 33.356111, 1706);
  sd45;
  double sd46 = CAADiameters::TopocentricMoonSemidiameter(368407.9, 5, 6, 33.356111, 1706);
  sd46;
  double sd47 = CAADiameters::TopocentricMoonSemidiameter(368407.9 - 10000, 5, 0, 33.356111, 1706);
  sd47;
  double sd48 = CAADiameters::TopocentricMoonSemidiameter(368407.9 - 10000, 5, 6, 33.356111, 1706);
  sd48;

  double sd49 = CAADiameters::AsteroidDiameter(4, 0.04); 
  sd49;
  double sd50 = CAADiameters::AsteroidDiameter(4, 0.08); 
  sd50;
  double sd51 = CAADiameters::AsteroidDiameter(6, 0.04); 
  sd51;
  double sd53 = CAADiameters::AsteroidDiameter(6, 0.08); 
  sd53;
  double sd54 = CAADiameters::ApparentAsteroidDiameter(1, 250);
  sd54;
  double sd55 = CAADiameters::ApparentAsteroidDiameter(1, 1000);
  sd55;

  CAAPhysicalMoonDetails MoonDetails = CAAPhysicalMoon::CalculateGeocentric(2448724.5);
  CAAPhysicalMoonDetails MoonDetail2 = CAAPhysicalMoon::CalculateTopocentric(2448724.5, 10, 52);
  CAASelenographicMoonDetails CAASelenographicMoonDetails = CAAPhysicalMoon::CalculateSelenographicPositionOfSun(2448724.5);

  double AltitudeOfSun = CAAPhysicalMoon::AltitudeOfSun(2448724.5, -20, 9.7);
  AltitudeOfSun;
  double TimeOfSunrise = CAAPhysicalMoon::TimeOfSunrise(2448724.5, -20, 9.7);
  TimeOfSunrise;
  double TimeOfSunset = CAAPhysicalMoon::TimeOfSunset(2448724.5, -20, 9.7);
  TimeOfSunset;

  CAASolarEclipseDetails EclipseDetails = CAAEclipses::CalculateSolar(-82);
  CAASolarEclipseDetails EclipseDetails2 = CAAEclipses::CalculateSolar(118);
  CAALunarEclipseDetails EclipseDetails3 = CAAEclipses::CalculateLunar(-328.5);
  CAALunarEclipseDetails EclipseDetails4 = CAAEclipses::CalculateLunar(-30.5); //No lunar eclipse
  EclipseDetails4 = CAAEclipses::CalculateLunar(-29.5); //No lunar eclipse
  EclipseDetails4 = CAAEclipses::CalculateLunar(-28.5); //Aha, found you!

  CAACalendarDate JulianDate = CAAMoslemCalendar::MoslemToJulian(1421, 1, 1);
  CAACalendarDate GregorianDate = CAADate::JulianToGregorian(JulianDate.Year, JulianDate.Month, JulianDate.Day);
  CAACalendarDate JulianDate2 = CAADate::GregorianToJulian(GregorianDate.Year, GregorianDate.Month, GregorianDate.Day);
  CAACalendarDate MoslemDate = CAAMoslemCalendar::JulianToMoslem(JulianDate2.Year, JulianDate2.Month, JulianDate2.Day);
  bLeap = CAAMoslemCalendar::IsLeap(1421);
  bLeap;

  MoslemDate = CAAMoslemCalendar::JulianToMoslem(2006, 12, 31);
  CAACalendarDate OriginalMoslemDate = CAAMoslemCalendar::MoslemToJulian(MoslemDate.Year, MoslemDate.Month, MoslemDate.Day);
  MoslemDate = CAAMoslemCalendar::JulianToMoslem(2007, 1, 1);
  OriginalMoslemDate = CAAMoslemCalendar::MoslemToJulian(MoslemDate.Year, MoslemDate.Month, MoslemDate.Day);

  CAACalendarDate JulianDate3 = CAADate::GregorianToJulian(1991, 8, 13);
  CAACalendarDate MoslemDate2 = CAAMoslemCalendar::JulianToMoslem(JulianDate3.Year, JulianDate3.Month, JulianDate3.Day);
  CAACalendarDate JulianDate4 = CAAMoslemCalendar::MoslemToJulian(MoslemDate2.Year, MoslemDate2.Month, MoslemDate2.Day);
  CAACalendarDate GregorianDate2 = CAADate::JulianToGregorian(JulianDate4.Year, JulianDate4.Month, JulianDate4.Day);

  CAACalendarDate JewishDate = CAAJewishCalendar::DateOfPesach(1990);
  bLeap = CAAJewishCalendar::IsLeap(JewishDate.Year);
  bLeap;
  bLeap = CAAJewishCalendar::IsLeap(5751);
  bLeap;
  long DaysInJewishYear = CAAJewishCalendar::DaysInYear(JewishDate.Year);
  DaysInJewishYear = CAAJewishCalendar::DaysInYear(5751);
  DaysInJewishYear;


  CAANearParabolicObjectElements elements6;
  elements6.q = 0.921326;
  elements6.e = 1;
  elements6.i = 0; //unknown
  elements6.omega = 0; //unknown
  elements6.w = 0; //unknown
  elements6.T = 0;
  elements6.JDEquinox = 0;
  CAANearParabolicObjectDetails details3 = CAANearParabolic::Calculate(138.4783, elements6);

  elements6.q = 0.1;
  elements6.e = 0.987;
  details3 = CAANearParabolic::Calculate(254.9, elements6);

  elements6.q = 0.123456;
  elements6.e = 0.99997;
  details3 = CAANearParabolic::Calculate(-30.47, elements6);

  elements6.q = 3.363943;
  elements6.e = 1.05731;
  details3 = CAANearParabolic::Calculate(1237.1, elements6);

  elements6.q = 0.5871018;
  elements6.e = 0.9672746;
  details3 = CAANearParabolic::Calculate(20, elements6);

  details3 = CAANearParabolic::Calculate(0, elements6);

  CAAEclipticalElementDetails ed5 = CAAEclipticalElements::Calculate(131.5856, 242.6797, 138.6637, 2433282.4235, 2448188.500000 + 0.6954-63.6954);
  CAAEclipticalElementDetails ed6 = CAAEclipticalElements::Calculate(131.5856, 242.6797, 138.6637, 2433282.4235, 2433282.4235);
  CAAEclipticalElementDetails ed7 = CAAEclipticalElements::FK4B1950ToFK5J2000(131.5856, 242.6797, 138.6637);

  elements6.q = 0.93858;
  elements6.e = 1.000270;
  elements6.i = ed5.i;
  elements6.omega = ed5.omega;
  elements6.w = ed5.w;
  elements6.T = 2448188.500000 + 0.6954;
  elements6.JDEquinox = elements6.T;
  CAANearParabolicObjectDetails details4 = CAANearParabolic::Calculate(elements6.T-63.6954, elements6);

  std::getchar();
  return 0;
}
