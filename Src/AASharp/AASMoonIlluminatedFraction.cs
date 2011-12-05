using System;
using System.Collections.Generic;
using System.Linq;

namespace AASharp
{
    public static class AASMoonIlluminatedFraction
    {
        public static double GeocentricElongation(double ObjectAlpha, double ObjectDelta, double SunAlpha, double SunDelta)
        {
            //Convert the RA's to radians
            ObjectAlpha = AASCoordinateTransformation.DegreesToRadians(ObjectAlpha * 15);
            SunAlpha = AASCoordinateTransformation.DegreesToRadians(SunAlpha * 15);

            //Convert the declinations to radians
            ObjectDelta = AASCoordinateTransformation.DegreesToRadians(ObjectDelta);
            SunDelta = AASCoordinateTransformation.DegreesToRadians(SunDelta);

            //Return the result
            return AASCoordinateTransformation.RadiansToDegrees(Math.Acos(Math.Sin(SunDelta) * Math.Sin(ObjectDelta) + Math.Cos(SunDelta) * Math.Cos(ObjectDelta) * Math.Cos(SunAlpha - ObjectAlpha)));
        }

        public static double PhaseAngle(double GeocentricElongation, double EarthObjectDistance, double EarthSunDistance)
        {
            //Convert from degrees to radians
            GeocentricElongation = AASCoordinateTransformation.DegreesToRadians(GeocentricElongation);

            //Return the result
            return AASCoordinateTransformation.MapTo0To360Range(AASCoordinateTransformation.RadiansToDegrees(Math.Atan2(EarthSunDistance * Math.Sin(GeocentricElongation), EarthObjectDistance - EarthSunDistance * Math.Cos(GeocentricElongation))));
        }

        public static double IlluminatedFraction(double PhaseAngle)
        {
            //Convert from degrees to radians
            PhaseAngle = AASCoordinateTransformation.DegreesToRadians(PhaseAngle);

            //Return the result
            return (1 + Math.Cos(PhaseAngle)) / 2;
        }

        public static double PositionAngle(double Alpha0, double Delta0, double Alpha, double Delta)
        {
            //Convert to radians
            Alpha0 = AASCoordinateTransformation.HoursToRadians(Alpha0);
            Alpha = AASCoordinateTransformation.HoursToRadians(Alpha);
            Delta0 = AASCoordinateTransformation.DegreesToRadians(Delta0);
            Delta = AASCoordinateTransformation.DegreesToRadians(Delta);

            return AASCoordinateTransformation.MapTo0To360Range(AASCoordinateTransformation.RadiansToDegrees(Math.Atan2(Math.Cos(Delta0) * Math.Sin(Alpha0 - Alpha), Math.Sin(Delta0) * Math.Cos(Delta) - Math.Cos(Delta0) * Math.Sin(Delta) * Math.Cos(Alpha0 - Alpha))));
        }
    }
}
