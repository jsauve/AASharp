using System;

namespace AASharp
{
    /// <summary>
    /// This class provides the algorithms to calculate the dates of the Equinoxes and Solstices. This refers to Chapter 27 in the book.
    /// </summary>
    public static class AASEquinoxesAndSolstices
    {
        /// <summary>
        /// Calculates the date of Spring Equinox.
        /// </summary>
        /// <param name="Year">The year to calculate the occurrence for. Note that this method refers to "Northward Equinox" instead of "Spring Equinox" to avoid a northern hemisphere-specific bias.</param>
        /// <param name="bHighPrecision">If true then use the full VSOP87 theory instead of the truncated version as provided in Meeus's book.</param>
        /// <returns>The date in Dynamical time when the sun crosses the equator in a northerly direction.</returns>
        public static double NorthwardEquinox(long Year, bool bHighPrecision)
        {
            //calculate the approximate date
            double JDE;
            if (Year <= 1000)
            {
                double Y = Year / 1000.0;
                double Ysquared = Y * Y;
                double Ycubed = Ysquared * Y;
                double Y4 = Ycubed * Y;
                JDE = 1721139.29189 + 365242.13740 * Y + 0.06134 * Ysquared + 0.00111 * Ycubed - 0.00071 * Y4;
            }
            else
            {
                double Y = (Year - 2000) / 1000.0;
                double Ysquared = Y * Y;
                double Ycubed = Ysquared * Y;
                double Y4 = Ycubed * Y;
                JDE = 2451623.80984 + 365242.37404 * Y + 0.05169 * Ysquared - 0.00411 * Ycubed - 0.00057 * Y4;
            }

            double Correction;
            do
            {
                double SunLongitude = AASSun.ApparentEclipticLongitude(JDE, bHighPrecision);
                Correction = 58 * Math.Sin(AASCoordinateTransformation.DegreesToRadians(-SunLongitude));
                JDE += Correction;
            }
            while (Math.Abs(Correction) > 0.00001); //Corresponds to an error of 0.86 of a second

            return JDE;
        }

        /// <summary>
        /// Calculates the date of Summer Solstice.
        /// </summary>
        /// <param name="Year">The year to calculate the occurrence for. Note that this method refers to "Northern Solstice" instead of "Summer Solstice" to avoid a northern hemisphere-specific bias.</param>
        /// <param name="bHighPrecision">If true then use the full VSOP87 theory instead of the truncated version as provided in Meeus's book.</param>
        /// <returns>The date in Dynamical time when the sun reaches its highest relative to the celestial equator and appears directly over the Tropic of Cancer.</returns>
        public static double NorthernSolstice(long Year, bool bHighPrecision)
        {
            //calculate the approximate date
            double JDE;
            if (Year <= 1000)
            {
                double Y = Year / 1000.0;
                double Ysquared = Y * Y;
                double Ycubed = Ysquared * Y;
                double Y4 = Ycubed * Y;
                JDE = 1721233.25401 + 365241.72562 * Y - 0.05323 * Ysquared + 0.00907 * Ycubed + 0.00025 * Y4;
            }
            else
            {
                double Y = (Year - 2000) / 1000.0;
                double Ysquared = Y * Y;
                double Ycubed = Ysquared * Y;
                double Y4 = Ycubed * Y;
                JDE = 2451716.56767 + 365241.62603 * Y + 0.00325 * Ysquared + 0.00888 * Ycubed - 0.00030 * Y4;
            }

            double Correction;
            do
            {
                double SunLongitude = AASSun.ApparentEclipticLongitude(JDE, bHighPrecision);
                Correction = 58 * Math.Sin(AASCoordinateTransformation.DegreesToRadians(90 - SunLongitude));
                JDE += Correction;
            }
            while (Math.Abs(Correction) > 0.00001); //Corresponds to an error of 0.86 of a second

            return JDE;
        }

        /// <summary>
        /// Calculates the date of Autumn (Fall) equinox.
        /// </summary>
        /// <param name="Year">The year to calculate the occurrence for. Note that this method refers to "Southward Equinox" instead of "Fall or Autumn equinox" to avoid a northern hemisphere-specific bias.</param>
        /// <param name="bHighPrecision">If true then use the full VSOP87 theory instead of the truncated version as provided in Meeus's book.</param>
        /// <returns>The date in Dynamical time when the Southward Equinox occurs.</returns>
        public static double SouthwardEquinox(long Year, bool bHighPrecision)
        {
            //calculate the approximate date
            double JDE;
            if (Year <= 1000)
            {
                double Y = Year / 1000.0;
                double Ysquared = Y * Y;
                double Ycubed = Ysquared * Y;
                double Y4 = Ycubed * Y;
                JDE = 1721325.70455 + 365242.49558 * Y - 0.11677 * Ysquared - 0.00297 * Ycubed + 0.00074 * Y4;
            }
            else
            {
                double Y = (Year - 2000) / 1000.0;
                double Ysquared = Y * Y;
                double Ycubed = Ysquared * Y;
                double Y4 = Ycubed * Y;
                JDE = 2451810.21715 + 365242.01767 * Y - 0.11575 * Ysquared + 0.00337 * Ycubed + 0.00078 * Y4;
            }

            double Correction;
            do
            {
                double SunLongitude = AASSun.ApparentEclipticLongitude(JDE, bHighPrecision);
                Correction = 58 * Math.Sin(AASCoordinateTransformation.DegreesToRadians(180 - SunLongitude));
                JDE += Correction;
            }
            while (Math.Abs(Correction) > 0.00001); //Corresponds to an error of 0.86 of a second

            return JDE;
        }

        /// <summary>
        /// Calculates the date of Winter Solstice.
        /// </summary>
        /// <param name="Year">The year to calculate the occurrence for. Note that this method refers to "Southern Solstice" instead of "Winter Solstice" to avoid a northern hemisphere-specific bias.</param>
        /// <param name="bHighPrecision">If true then use the full VSOP87 theory instead of the truncated version as provided in Meeus's book.</param>
        /// <returns>The date in Dynamical time when the sun reaches its lowest relative to the celestial equator and appears directly over the Tropic of Capricorn.</returns>
        public static double SouthernSolstice(long Year, bool bHighPrecision)
        {
            //calculate the approximate date
            double JDE;
            if (Year <= 1000)
            {
                double Y = Year / 1000.0;
                double Ysquared = Y * Y;
                double Ycubed = Ysquared * Y;
                double Y4 = Ycubed * Y;
                JDE = 1721414.39987 + 365242.88257 * Y - 0.00769 * Ysquared - 0.00933 * Ycubed - 0.00006 * Y4;
            }
            else
            {
                double Y = (Year - 2000) / 1000.0;
                double Ysquared = Y * Y;
                double Ycubed = Ysquared * Y;
                double Y4 = Ycubed * Y;
                JDE = 2451900.05952 + 365242.74049 * Y - 0.06223 * Ysquared - 0.00823 * Ycubed + 0.00032 * Y4;
            }

            double Correction;
            do
            {
                double SunLongitude = AASSun.ApparentEclipticLongitude(JDE, bHighPrecision);
                Correction = 58 * Math.Sin(AASCoordinateTransformation.DegreesToRadians(270 - SunLongitude));
                JDE += Correction;
            }
            while (Math.Abs(Correction) > 0.00001); //Corresponds to an error of 0.86 of a second

            return JDE;
        }

        /// <param name="Year">The year to calculate for.</param>
        /// <param name="bNorthernHemisphere">true to indicate the observer is in the northern hemisphere, while false means the southern hemisphere.</param>
        /// <param name="bHighPrecision">If true then use the full VSOP87 theory instead of the truncated version as provided in Meeus's book.</param>
        /// <returns>The length of the astronomical Spring season in days.</returns>
        public static double LengthOfSpring(long Year, bool bNorthernHemisphere, bool bHighPrecision)
        {
            if (bNorthernHemisphere)
                return NorthernSolstice(Year, bHighPrecision) - NorthwardEquinox(Year, bHighPrecision);
            else
                return SouthernSolstice(Year, bHighPrecision) - SouthwardEquinox(Year, bHighPrecision);
        }

        /// <param name="Year">The year to calculate for.</param>
        /// <param name="bNorthernHemisphere">true to indicate the observer is in the northern hemisphere, while false means the southern hemisphere.</param>
        /// <param name="bHighPrecision">If true then use the full VSOP87 theory instead of the truncated version as provided in Meeus's book.</param>
        /// <returns>The length of the astronomical Summer season in days.</returns>
        public static double LengthOfSummer(long Year, bool bNorthernHemisphere, bool bHighPrecision)
        {
            if (bNorthernHemisphere)
                return SouthwardEquinox(Year, bHighPrecision) - NorthernSolstice(Year, bHighPrecision);
            else
            {
                //The Summer season wraps around into the following year for the southern hemisphere
                return NorthwardEquinox(Year + 1, bHighPrecision) - SouthernSolstice(Year, bHighPrecision);
            } 
        }

        /// <param name="Year">The year to calculate for.</param>
        /// <param name="bNorthernHemisphere">true to indicate the observer is in the northern hemisphere, while false means the southern hemisphere.</param>
        /// <param name="bHighPrecision">If true then use the full VSOP87 theory instead of the truncated version as provided in Meeus's book.</param>
        /// <returns>The length of the astronomical Autumn season in days.</returns>
        public static double LengthOfAutumn(long Year, bool bNorthernHemisphere, bool bHighPrecision)
        {
            if (bNorthernHemisphere)
                return SouthernSolstice(Year, bHighPrecision) - SouthwardEquinox(Year, bHighPrecision);
            else
                return NorthernSolstice(Year, bHighPrecision) - NorthwardEquinox(Year, bHighPrecision);
        }

        /// <param name="Year">The year to calculate for.</param>
        /// <param name="bNorthernHemisphere">true to indicate the observer is in the northern hemisphere, while false means the southern hemisphere.</param>
        /// <param name="bHighPrecision">If true then use the full VSOP87 theory instead of the truncated version as provided in Meeus's book.</param>
        /// <returns>The length of the astronomical Winter season in days.</returns>
        public static double LengthOfWinter(long Year, bool bNorthernHemisphere, bool bHighPrecision)
        {
            if (bNorthernHemisphere)
            {
                //The Winter season wraps around into the following year for the nothern hemisphere
                return NorthwardEquinox(Year + 1, bHighPrecision) - SouthernSolstice(Year, bHighPrecision);
            }
            else
                return SouthwardEquinox(Year, bHighPrecision) - NorthernSolstice(Year, bHighPrecision);
        }
    }
}
