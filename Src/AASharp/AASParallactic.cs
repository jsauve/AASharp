using System;

namespace AASharp
{
    /// <summary>
    /// This class provides for measurement of various angles on the celestial globe. This refers to Chapter 14 in the book.
    /// </summary>
    public static class AASParallactic
    {
        /// <summary>
        /// This refers to algorithm 14.1 on page 98.
        /// </summary>
        /// <param name="HourAngle">The hour angle.</param>
        /// <param name="Latitude">The latitude of the position in degrees.</param>
        /// <param name="delta">The declination in degrees.</param>
        /// <returns>Returns the parallactic angle (the ZCN angle) and is generally designated by q.</returns>
        public static double ParallacticAngle(double HourAngle, double Latitude, double delta)
        {
            HourAngle = AASCoordinateTransformation.HoursToRadians(HourAngle);
            Latitude = AASCoordinateTransformation.DegreesToRadians(Latitude);
            delta = AASCoordinateTransformation.DegreesToRadians(delta);

            return AASCoordinateTransformation.RadiansToDegrees(Math.Atan2(Math.Sin(HourAngle), Math.Tan(Latitude) * Math.Cos(delta) - Math.Sin(delta) * Math.Cos(HourAngle)));
        }

        /// <summary>
        /// This refers to algorithm 14.2 on page 99.
        /// </summary>
        /// <param name="LocalSiderealTime">The local sidereal time measured in hours.</param>
        /// <param name="ObliquityOfEcliptic">The obliquity of the ecliptic in degrees.</param>
        /// <param name="Latitude">The latitude of the position in degrees.</param>
        /// <returns>Returns the ecliptic longitude of two points which are (180 degrees apart) on the horizon.</returns>
        public static double EclipticLongitudeOnHorizon(double LocalSiderealTime, double ObliquityOfEcliptic, double Latitude)
        {
            LocalSiderealTime = AASCoordinateTransformation.HoursToRadians(LocalSiderealTime);
            Latitude = AASCoordinateTransformation.DegreesToRadians(Latitude);
            ObliquityOfEcliptic = AASCoordinateTransformation.DegreesToRadians(ObliquityOfEcliptic);

            double value = AASCoordinateTransformation.RadiansToDegrees(Math.Atan2(-Math.Cos(LocalSiderealTime), Math.Sin(ObliquityOfEcliptic) * Math.Tan(Latitude) + Math.Cos(ObliquityOfEcliptic) * Math.Sin(LocalSiderealTime)));
            return AASCoordinateTransformation.MapTo0To360Range(value);
        }

        /// <summary>
        /// This refers to algorithm at the top of page 100.
        /// </summary>
        /// <param name="LocalSiderealTime">The local sidereal time measured in hours.</param>
        /// <param name="ObliquityOfEcliptic">The obliquity of the ecliptic in degrees.</param>
        /// <param name="Latitude">The latitude of the position in degrees.</param>
        /// <returns>Returns the angle in degrees of the diurnal path of a celestial body (not the ecliptic) relative to the horizon at the time of its rising or setting.</returns>
        public static double AngleBetweenEclipticAndHorizon(double LocalSiderealTime, double ObliquityOfEcliptic, double Latitude)
        {
            LocalSiderealTime = AASCoordinateTransformation.HoursToRadians(LocalSiderealTime);
            Latitude = AASCoordinateTransformation.DegreesToRadians(Latitude);
            ObliquityOfEcliptic = AASCoordinateTransformation.DegreesToRadians(ObliquityOfEcliptic);

            double value = AASCoordinateTransformation.RadiansToDegrees(Math.Acos(Math.Cos(ObliquityOfEcliptic) * Math.Sin(Latitude) - Math.Sin(ObliquityOfEcliptic) * Math.Cos(Latitude) * Math.Sin(LocalSiderealTime)));
            return AASCoordinateTransformation.MapTo0To360Range(value);
        }

        /// <summary>
        /// This refers to algorithm at the top of page 100.
        /// </summary>
        /// <param name="Lambda">The ecliptical longitude in degrees.</param>
        /// <param name="Beta">The ecliptical latitude of the star in degrees.</param>
        /// <param name="ObliquityOfEcliptic">The obliquity of the ecliptic in degrees.</param>
        /// <returns>Return the angle in degrees between the direction of the northern celestial pole and the direction of the north pole of the ecliptic, at the star.</returns>
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
