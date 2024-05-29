using System;

namespace AASharp
{
    /// <summary>
    /// This class provides the algorithms to calculate a planet's phase angle, illuminated fraction and magnitude. This refers to Chapter 41 in the book.
    /// </summary>
    public static class AASIlluminatedFraction
    {
        /// <param name="r">The planet's distance to the Sun in astronomical units.</param>
        /// <param name="R">The distance of the Sun from the Earth in astronomical units.</param>
        /// <param name="Delta">The planet's distance from the Earth in astronomical units.</param>
        /// <returns>The phase angle in degrees.</returns>
        public static double PhaseAngle(double r, double R, double Delta)
        {
            //Return the result
            return AASCoordinateTransformation.MapTo0To360Range(AASCoordinateTransformation.RadiansToDegrees(Math.Acos((r * r + Delta * Delta - R * R) / (2 * r * Delta))));
        }

        /// <param name="R">The planet's distance to the Sun in astronomical units.</param>
        /// <param name="R0">The distance of the Sun from the Earth in astronomical units.</param>
        /// <param name="B">The planet's heliocentric latitude in degrees.</param>
        /// <param name="L">The planet's heliocentric longitude in degrees.</param>
        /// <param name="L0">The heliocentric latitude of the Earth in degrees.</param>
        /// <param name="Delta">The planet's distance from the Earth in astronomical units.</param>
        /// <returns>The phase angle in degrees.</returns>
        public static double PhaseAngle(double R, double R0, double B, double L, double L0, double Delta)
        {
            //Convert from degrees to radians
            B = AASCoordinateTransformation.DegreesToRadians(B);
            L = AASCoordinateTransformation.DegreesToRadians(L);
            L0 = AASCoordinateTransformation.DegreesToRadians(L0);

            //Return the result
            return AASCoordinateTransformation.MapTo0To360Range(AASCoordinateTransformation.RadiansToDegrees(Math.Acos((R - R0 * Math.Cos(B) * Math.Cos(L - L0)) / Delta)));
        }

        /// <param name="x">The geocentric rectangular ecliptical X coordinate of the object.</param>
        /// <param name="y">The geocentric rectangular ecliptical Y coordinate of the object.</param>
        /// <param name="z">The geocentric rectangular ecliptical Z coordinate of the object.</param>
        /// <param name="B">The planet's heliocentric latitude in degrees.</param>
        /// <param name="L">The planet's heliocentric longitude in degrees.</param>
        /// <param name="Delta">The planet's distance from the Earth in astronomical units.</param>
        /// <returns>The phase angle in degrees.</returns>
        public static double PhaseAngleRectangular(double x, double y, double z, double B, double L, double Delta)
        {
            //Convert from degrees to radians
            B = AASCoordinateTransformation.DegreesToRadians(B);
            L = AASCoordinateTransformation.DegreesToRadians(L);
            double cosB = Math.Cos(B);

            //Return the result
            return AASCoordinateTransformation.MapTo0To360Range(AASCoordinateTransformation.RadiansToDegrees(Math.Acos((x * cosB * Math.Cos(L) + y * cosB * Math.Sin(L) + z * Math.Sin(B)) / Delta)));
        }

        /// <param name="PhaseAngle">The planet's phase angle in degrees.</param>
        /// <returns>The phase angle in degrees.</returns>
        public static double IlluminatedFraction(double PhaseAngle)
        {
            //Convert from degrees to radians
            PhaseAngle = AASCoordinateTransformation.DegreesToRadians(PhaseAngle);

            //Return the result
            return (1 + Math.Cos(PhaseAngle)) / 2;
        }

        /// <param name="r">The planet's distance to the Sun in astronomical units.</param>
        /// <param name="R">The distance of the Sun from the Earth in astronomical units.</param>
        /// <param name="Delta">The planet's distance from the Earth in astronomical units.</param>
        /// <returns>The phase angle in degrees.</returns>
        public static double IlluminatedFraction(double r, double R, double Delta)
        {
            return (((r + Delta) * (r + Delta) - R * R) / (4 * r * Delta));
        }

        /// <summary>
        /// Uses the formula to calculate the magnitude as provided by G. Muller.
        /// </summary>
        /// <param name="r">The planet's distance to the Sun in astronomical units.</param>
        /// <param name="Delta">The planet's distance from the Earth in astronomical units.</param>
        /// <param name="i">The planet's phase angle in degrees.</param>
        /// <returns>The magnitude of the planet.</returns>
        public static double MercuryMagnitudeMuller(double r, double Delta, double i)
        {
            double I_50 = i - 50;
            return 1.16 + 5 * Math.Log10(r * Delta) + 0.02838 * I_50 + 0.0001023 * I_50 * I_50;
        }

        /// <summary>
        /// Uses the formula to calculate the magnitude as provided by G. Muller.
        /// </summary>
        /// <param name="r">The planet's distance to the Sun in astronomical units.</param>
        /// <param name="Delta">The planet's distance from the Earth in astronomical units.</param>
        /// <param name="i">The planet's phase angle in degrees.</param>
        /// <returns>The magnitude of the planet.</returns>
        public static double VenusMagnitudeMuller(double r, double Delta, double i)
        {
            return -4.00 + 5 * Math.Log10(r * Delta) + 0.01322 * i + 0.0000004247 * i * i * i;
        }

        /// <summary>
        /// Uses the formula to calculate the magnitude as provided by G. Muller.
        /// </summary>
        /// <param name="r">The planet's distance to the Sun in astronomical units.</param>
        /// <param name="Delta">The planet's distance from the Earth in astronomical units.</param>
        /// <param name="i">The planet's phase angle in degrees.</param>
        /// <returns>The magnitude of the planet.</returns>
        public static double MarsMagnitudeMuller(double r, double Delta, double i)
        {
            return -1.3 + 5 * Math.Log10(r * Delta) + 0.01486 * i;
        }

        /// <summary>
        /// Uses the formula to calculate the magnitude as provided by G. Muller.
        /// </summary>
        /// <param name="r">The planet's distance to the Sun in astronomical units.</param>
        /// <param name="Delta">The planet's distance from the Earth in astronomical units.</param>
        /// <returns>The magnitude of the planet.</returns>
        public static double JupiterMagnitudeMuller(double r, double Delta)
        {
            return -8.93 + 5 * Math.Log10(r * Delta);
        }

        /// <summary>
        /// Uses the formula to calculate the magnitude as provided by G. Muller.
        /// </summary>
        /// <param name="r">The planet's distance to the Sun in astronomical units.</param>
        /// <param name="Delta">The planet's distance from the Earth in astronomical units.</param>
        /// <param name="DeltaU">The difference between the Saturnicentric longitudes of the Sun and the Earth, measured in the plane o the ring in degrees.</param>
        /// <param name="B">The Saturnicentric latitude of the Earth referred to the plane of the ring in degrees</param>
        /// <returns>The magnitude of the planet.</returns>
        public static double SaturnMagnitudeMuller(double r, double Delta, double DeltaU, double B)
        {
            //Convert from degrees to radians
            B = AASCoordinateTransformation.DegreesToRadians(B);
            double sinB = Math.Sin(B);

            return -8.68 + 5 * Math.Log10(r * Delta) + 0.044 * Math.Abs(DeltaU) - 2.60 * Math.Sin(Math.Abs(B)) + 1.25 * sinB * sinB;
        }

        /// <summary>
        /// Uses the formula to calculate the magnitude as provided by G. Muller.
        /// </summary>
        /// <param name="r">The planet's distance to the Sun in astronomical units.</param>
        /// <param name="Delta">The planet's distance from the Earth in astronomical units.</param>
        /// <returns>The magnitude of the planet.</returns>
        public static double UranusMagnitudeMuller(double r, double Delta)
        {
            return -6.85 + 5 * Math.Log10(r * Delta);
        }

        /// <summary>
        /// Uses the formula to calculate the magnitude as provided by G. Muller.
        /// </summary>
        /// <param name="r">The planet's distance to the Sun in astronomical units.</param>
        /// <param name="Delta">The planet's distance from the Earth in astronomical units.</param>
        /// <returns>The magnitude of the planet.</returns>
        public static double NeptuneMagnitudeMuller(double r, double Delta)
        {
            return -7.05 + 5 * Math.Log10(r * Delta);
        }

        /// <summary>
        /// Uses the formula to calculate the magnitude as provided in the Astronomical Almanac.
        /// </summary>
        /// <param name="r">The planet's distance to the Sun in astronomical units.</param>
        /// <param name="Delta">The planet's distance from the Earth in astronomical units.</param>
        /// <param name="i">The planet's phase angle in degrees.</param>
        /// <returns>The magnitude of the planet.</returns>
        public static double MercuryMagnitudeAA(double r, double Delta, double i)
        {
            double i2 = i * i;
            double i3 = i2 * i;

            return -0.42 + 5 * Math.Log10(r * Delta) + 0.0380 * i - 0.000273 * i2 + 0.000002 * i3;
        }

        /// <summary>
        /// Uses the formula to calculate the magnitude as provided in the Astronomical Almanac.
        /// </summary>
        /// <param name="r">The planet's distance to the Sun in astronomical units.</param>
        /// <param name="Delta">The planet's distance from the Earth in astronomical units.</param>
        /// <param name="i">The planet's phase angle in degrees.</param>
        /// <returns>The magnitude of the planet.</returns>
        public static double VenusMagnitudeAA(double r, double Delta, double i)
        {
            double i2 = i * i;
            double i3 = i2 * i;

            return -4.40 + 5 * Math.Log10(r * Delta) + 0.0009 * i + 0.000239 * i2 - 0.00000065 * i3;
        }

        /// <summary>
        /// Uses the formula to calculate the magnitude as provided in the Astronomical Almanac.
        /// </summary>
        /// <param name="r">The planet's distance to the Sun in astronomical units.</param>
        /// <param name="Delta">The planet's distance from the Earth in astronomical units.</param>
        /// <param name="i">The planet's phase angle in degrees.</param>
        /// <returns>The magnitude of the planet.</returns>
        public static double MarsMagnitudeAA(double r, double Delta, double i)
        {
            return -1.52 + 5 * Math.Log10(r * Delta) + 0.016 * i;
        }

        /// <summary>
        /// Uses the formula to calculate the magnitude as provided in the Astronomical Almanac.
        /// </summary>
        /// <param name="r">The planet's distance to the Sun in astronomical units.</param>
        /// <param name="Delta">The planet's distance from the Earth in astronomical units.</param>
        /// <param name="i">The planet's phase angle in degrees.</param>
        /// <returns>The magnitude of the planet.</returns>
        public static double JupiterMagnitudeAA(double r, double Delta, double i)
        {
            return -9.40 + 5 * Math.Log10(r * Delta) + 0.005 * i;
        }

        /// <summary>
        /// Uses the formula to calculate the magnitude as provided in the Astronomical Almanac.
        /// </summary>
        /// <param name="r">The planet's distance to the Sun in astronomical units.</param>
        /// <param name="Delta">The planet's distance from the Earth in astronomical units.</param>
        /// <param name="DeltaU">The difference between the Saturnicentric longitudes of the Sun and the Earth, measured in the plane o the ring in degrees.</param>
        /// <param name="B">The Saturnicentric latitude of the Earth referred to the plane of the ring in degrees</param>
        /// <returns>The magnitude of the planet.</returns>
        public static double SaturnMagnitudeAA(double r, double Delta, double DeltaU, double B)
        {
            //Convert from degrees to radians
            B = AASCoordinateTransformation.DegreesToRadians(B);
            double sinB = Math.Sin(B);

            return -8.88 + 5 * Math.Log10(r * Delta) + 0.044 * Math.Abs(DeltaU) - 2.60 * Math.Sin(Math.Abs(B)) + 1.25 * sinB * sinB;
        }

        /// <summary>
        /// Uses the formula to calculate the magnitude as provided in the Astronomical Almanac.
        /// </summary>
        /// <param name="r">The planet's distance to the Sun in astronomical units.</param>
        /// <param name="Delta">The planet's distance from the Earth in astronomical units.</param>
        /// <returns>The magnitude of the planet.</returns>
        public static double UranusMagnitudeAA(double r, double Delta)
        {
            return -7.19 + 5 * Math.Log10(r * Delta);
        }

        /// <summary>
        /// Uses the formula to calculate the magnitude as provided in the Astronomical Almanac.
        /// </summary>
        /// <param name="r">The planet's distance to the Sun in astronomical units.</param>
        /// <param name="Delta">The planet's distance from the Earth in astronomical units.</param>
        /// <returns>The magnitude of the planet.</returns>
        public static double NeptuneMagnitudeAA(double r, double Delta)
        {
            return -6.87 + 5 * Math.Log10(r * Delta);
        }

        /// <summary>
        /// Uses the formula to calculate the magnitude as provided in the Astronomical Almanac.
        /// </summary>
        /// <param name="r">The planet's distance to the Sun in astronomical units.</param>
        /// <param name="Delta">The planet's distance from the Earth in astronomical units.</param>
        /// <returns>The magnitude of the planet.</returns>
        public static double PlutoMagnitudeAA(double r, double Delta)
        {
            return -1.00 + 5 * Math.Log10(r * Delta);
        }
    }
}
