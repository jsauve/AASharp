using System;

namespace AASharp
{
    /// <summary>
    /// This class provides algorithms for the Moon's elongation, phase angle and illuminated fraction. This refers to Chapter 48 in the book.
    /// </summary>
    public static class AASMoonIlluminatedFraction
    {
        /// <param name="ObjectAlpha">The geocentric right ascension of the object (e.g. the Moon) expressed as an hour angle.</param>
        /// <param name="ObjectDelta">The geocentric declination of the object (e.g. the Moon) in degrees.</param>
        /// <param name="SunAlpha">The geocentric right ascension of the Sun expressed as an hour angle.</param>
        /// <param name="SunDelta">The geocentric declination of the Sun in degrees.</param>
        /// <returns>the elongation of the object from the Sun</returns>
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

        /// <param name="GeocentricElongation">The geocentric elongation in degrees.</param>
        /// <param name="EarthObjectDistance">The distance in astronomical units between the Earth and the object (the Moon)</param>
        /// <param name="EarthSunDistance">The distance in astronomical units between the Earth and the Sun</param>
        /// <returns>the phase angle in degrees.</returns>
        public static double PhaseAngle(double GeocentricElongation, double EarthObjectDistance, double EarthSunDistance)
        {
            //Convert from degrees to radians
            GeocentricElongation = AASCoordinateTransformation.DegreesToRadians(GeocentricElongation);

            //Return the result
            return AASCoordinateTransformation.MapTo0To360Range(AASCoordinateTransformation.RadiansToDegrees(Math.Atan2(EarthSunDistance * Math.Sin(GeocentricElongation), EarthObjectDistance - EarthSunDistance * Math.Cos(GeocentricElongation))));
        }

        /// <param name="PhaseAngle">The phase angle in degrees.</param>
        /// <returns>the illuminated fraction (a value form 0 to 1).</returns>
        public static double IlluminatedFraction(double PhaseAngle)
        {
            //Convert from degrees to radians
            PhaseAngle = AASCoordinateTransformation.DegreesToRadians(PhaseAngle);

            //Return the result
            return (1 + Math.Cos(PhaseAngle)) / 2;
        }

        /// <param name="Alpha0">The geocentric right ascension of the Sun expressed as an hour angle.</param>
        /// <param name="Delta0">The geocentric declination of the Sun in degrees.</param>
        /// <param name="Alpha">The geocentric right ascension of the object (e.g. the Moon) expressed as an hour angle.</param>
        /// <param name="Delta">The geocentric declination of the object (e.g. the Moon) in degrees.</param>
        /// <returns>the position angle of the midpoint of the illuminated limb of the object (the Moon) in degrees.</returns>
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
