using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AASharp
{
    public static class AASParallactic
    {
        public static double ParallacticAngle(double HourAngle, double Latitude, double delta)
        {
            HourAngle = AASCoordinateTransformation.HoursToRadians(HourAngle);
            Latitude = AASCoordinateTransformation.DegreesToRadians(Latitude);
            delta = AASCoordinateTransformation.DegreesToRadians(delta);

            return AASCoordinateTransformation.RadiansToDegrees(Math.Atan2(Math.Sin(HourAngle), Math.Tan(Latitude) * Math.Cos(delta) - Math.Sin(delta) * Math.Cos(HourAngle)));
        }

        public static double EclipticLongitudeOnHorizon(double LocalSiderealTime, double ObliquityOfEcliptic, double Latitude)
        {
            LocalSiderealTime = AASCoordinateTransformation.HoursToRadians(LocalSiderealTime);
            Latitude = AASCoordinateTransformation.DegreesToRadians(Latitude);
            ObliquityOfEcliptic = AASCoordinateTransformation.DegreesToRadians(ObliquityOfEcliptic);

            double value = AASCoordinateTransformation.RadiansToDegrees(Math.Atan2(-Math.Cos(LocalSiderealTime), Math.Sin(ObliquityOfEcliptic) * Math.Tan(Latitude) + Math.Cos(ObliquityOfEcliptic) * Math.Sin(LocalSiderealTime)));
            return AASCoordinateTransformation.MapTo0To360Range(value);
        }

        public static double AngleBetweenEclipticAndHorizon(double LocalSiderealTime, double ObliquityOfEcliptic, double Latitude)
        {
            LocalSiderealTime = AASCoordinateTransformation.HoursToRadians(LocalSiderealTime);
            Latitude = AASCoordinateTransformation.DegreesToRadians(Latitude);
            ObliquityOfEcliptic = AASCoordinateTransformation.DegreesToRadians(ObliquityOfEcliptic);

            double value = AASCoordinateTransformation.RadiansToDegrees(Math.Acos(Math.Cos(ObliquityOfEcliptic) * Math.Sin(Latitude) - Math.Sin(ObliquityOfEcliptic) * Math.Cos(Latitude) * Math.Sin(LocalSiderealTime)));
            return AASCoordinateTransformation.MapTo0To360Range(value);
        }

        public static double AngleBetweenNorthCelestialPoleAndNorthPoleOfEcliptic(double Lambda, double Beta, double ObliquityOfEcliptic)
        {
            Lambda = AASCoordinateTransformation.DegreesToRadians(Lambda);
            Beta = AASCoordinateTransformation.DegreesToRadians(Beta);
            ObliquityOfEcliptic = AASCoordinateTransformation.DegreesToRadians(ObliquityOfEcliptic);

            double value = AASCoordinateTransformation.RadiansToDegrees(Math.Atan2(Math.Cos(Lambda) * Math.Tan(ObliquityOfEcliptic), Math.Sin(Beta) * Math.Sin(Lambda) * Math.Tan(ObliquityOfEcliptic) - Math.Cos(Beta)));
            return AASCoordinateTransformation.MapTo0To360Range(value);
        }
    }
}
