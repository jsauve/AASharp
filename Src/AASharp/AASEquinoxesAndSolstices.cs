using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AASharp
{
    public static class AASEquinoxesAndSolstices
    {
        public static double SpringEquinox(long Year)
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
                double SunLongitude = AASSun.ApparentEclipticLongitude(JDE);
                Correction = 58 * Math.Sin(AASCoordinateTransformation.DegreesToRadians(-SunLongitude));
                JDE += Correction;
            }
            while (Math.Abs(Correction) > 0.00001); //Corresponds to an error of 0.86 of a second

            return JDE;
        }

        public static double SummerSolstice(long Year)
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
                double SunLongitude = AASSun.ApparentEclipticLongitude(JDE);
                Correction = 58 * Math.Sin(AASCoordinateTransformation.DegreesToRadians(90 - SunLongitude));
                JDE += Correction;
            }
            while (Math.Abs(Correction) > 0.00001); //Corresponds to an error of 0.86 of a second

            return JDE;
        }

        public static double AutumnEquinox(long Year)
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
                double SunLongitude = AASSun.ApparentEclipticLongitude(JDE);
                Correction = 58 * Math.Sin(AASCoordinateTransformation.DegreesToRadians(180 - SunLongitude));
                JDE += Correction;
            }
            while (Math.Abs(Correction) > 0.00001); //Corresponds to an error of 0.86 of a second

            return JDE;
        }

        public static double WinterSolstice(long Year)
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
                double SunLongitude = AASSun.ApparentEclipticLongitude(JDE);
                Correction = 58 * Math.Sin(AASCoordinateTransformation.DegreesToRadians(270 - SunLongitude));
                JDE += Correction;
            }
            while (Math.Abs(Correction) > 0.00001); //Corresponds to an error of 0.86 of a second

            return JDE;
        }

        public static double LengthOfSpring(long Year)
        {
            return SummerSolstice(Year) - SpringEquinox(Year);
        }

        public static double LengthOfSummer(long Year)
        {
            return AutumnEquinox(Year) - SummerSolstice(Year);
        }

        public static double LengthOfAutumn(long Year)
        {
            return WinterSolstice(Year) - AutumnEquinox(Year);
        }

        public static double LengthOfWinter(long Year)
        {
            //The winter season wraps around into the following Year
            return SpringEquinox(Year + 1) - WinterSolstice(Year);
        }
    }
}
