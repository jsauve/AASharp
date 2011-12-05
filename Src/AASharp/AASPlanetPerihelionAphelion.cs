using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AASharp
{
    public static class AASPlanetPerihelionAphelion
    {
        public static long MercuryK(double Year)
        {
            return (long)(4.15201 * (Year - 2000.12));
        }

        public static double MercuryPerihelion(long k)
        {
            return 2451590.257 + 87.96934963 * k;
        }

        public static double MercuryAphelion(long k)
        {
            double kdash = k + 0.5;
            return 2451590.257 + 87.96934963 * kdash;
        }

        public static long VenusK(double Year)
        {
            return (long)(1.62549 * (Year - 2000.53));
        }

        public static double VenusPerihelion(long k)
        {
            double kdash = k;
            double ksquared = kdash * kdash;
            return 2451738.233 + 224.7008188 * kdash - 0.0000000327 * ksquared;
        }

        public static double VenusAphelion(long k)
        {
            double kdash = k + 0.5;
            double ksquared = kdash * kdash;
            return 2451738.233 + 224.7008188 * kdash - 0.0000000327 * ksquared;
        }

        public static long EarthK(double Year)
        {
            return (long)(0.99997 * (Year - 2000.01));
        }

        public static double EarthPerihelion(long k, bool bBarycentric)
        {
            double kdash = k;
            double ksquared = kdash * kdash;
            double JD = 2451547.507 + 365.2596358 * kdash + 0.0000000156 * ksquared;

            if (!bBarycentric)
            {
                //Apply the corrections
                double A1 = AASCoordinateTransformation.MapTo0To360Range(328.41 + 132.788585 * k);
                A1 = AASCoordinateTransformation.DegreesToRadians(A1);
                double A2 = AASCoordinateTransformation.MapTo0To360Range(316.13 + 584.903153 * k);
                A2 = AASCoordinateTransformation.DegreesToRadians(A2);
                double A3 = AASCoordinateTransformation.MapTo0To360Range(346.20 + 450.380738 * k);
                A3 = AASCoordinateTransformation.DegreesToRadians(A3);
                double A4 = AASCoordinateTransformation.MapTo0To360Range(136.95 + 659.306737 * k);
                A4 = AASCoordinateTransformation.DegreesToRadians(A4);
                double A5 = AASCoordinateTransformation.MapTo0To360Range(249.52 + 329.653368 * k);
                A5 = AASCoordinateTransformation.DegreesToRadians(A5);

                JD += 1.278 * Math.Sin(A1);
                JD -= 0.055 * Math.Sin(A2);
                JD -= 0.091 * Math.Sin(A3);
                JD -= 0.056 * Math.Sin(A4);
                JD -= 0.045 * Math.Sin(A5);
            }

            return JD;
        }

        public static double EarthAphelion(long k, bool bBarycentric)
        {
            double kdash = k + 0.5;
            double ksquared = kdash * kdash;
            double JD = 2451547.507 + 365.2596358 * kdash + 0.0000000156 * ksquared;

            if (!bBarycentric)
            {
                //Apply the corrections
                double A1 = AASCoordinateTransformation.MapTo0To360Range(328.41 + 132.788585 * k);
                A1 = AASCoordinateTransformation.DegreesToRadians(A1);
                double A2 = AASCoordinateTransformation.MapTo0To360Range(316.13 + 584.903153 * k);
                A2 = AASCoordinateTransformation.DegreesToRadians(A2);
                double A3 = AASCoordinateTransformation.MapTo0To360Range(346.20 + 450.380738 * k);
                A3 = AASCoordinateTransformation.DegreesToRadians(A3);
                double A4 = AASCoordinateTransformation.MapTo0To360Range(136.95 + 659.306737 * k);
                A4 = AASCoordinateTransformation.DegreesToRadians(A4);
                double A5 = AASCoordinateTransformation.MapTo0To360Range(249.52 + 329.653368 * k);
                A5 = AASCoordinateTransformation.DegreesToRadians(A5);

                JD -= 1.352 * Math.Sin(A1);
                JD += 0.061 * Math.Sin(A2);
                JD += 0.062 * Math.Sin(A3);
                JD += 0.029 * Math.Sin(A4);
                JD += 0.031 * Math.Sin(A5);
            }

            return JD;
        }

        public static long MarsK(double Year)
        {
            return (long)(0.53166 * (Year - 2001.78));
        }

        public static double MarsPerihelion(long k)
        {
            double kdash = k;
            double ksquared = kdash * kdash;
            return 2452195.026 + 686.9957857 * kdash - 0.0000001187 * ksquared;
        }

        public static double MarsAphelion(long k)
        {
            double kdash = k + 0.5;
            double ksquared = kdash * kdash;
            return 2452195.026 + 686.9957857 * kdash - 0.0000001187 * ksquared;
        }

        public static long JupiterK(double Year)
        {
            return (long)(0.08430 * (Year - 2011.20));
        }

        public static double JupiterPerihelion(long k)
        {
            double kdash = k;
            double ksquared = kdash * kdash;
            return 2455636.936 + 4332.897065 * kdash + 0.0001367 * ksquared;
        }

        public static double JupiterAphelion(long k)
        {
            double kdash = k + 0.5;
            double ksquared = kdash * kdash;
            return 2455636.936 + 4332.897065 * kdash + 0.0001367 * ksquared;
        }

        public static long SaturnK(double Year)
        {
            return (long)(0.03393 * (Year - 2003.52));
        }

        public static double SaturnPerihelion(long k)
        {
            double kdash = k;
            double ksquared = kdash * kdash;
            return 2452830.12 + 10764.21676 * kdash + 0.000827 * ksquared;
        }

        public static double SaturnAphelion(long k)
        {
            double kdash = k + 0.5;
            double ksquared = kdash * kdash;
            return 2452830.12 + 10764.21676 * kdash + 0.000827 * ksquared;
        }

        public static long UranusK(double Year)
        {
            return (long)(0.01190 * (Year - 2051.1));
        }

        public static double UranusPerihelion(long k)
        {
            double kdash = k;
            double ksquared = kdash * kdash;
            return 2470213.5 + 30694.8767 * kdash - 0.00541 * ksquared;
        }

        public static double UranusAphelion(long k)
        {
            double kdash = k + 0.5;
            double ksquared = kdash * kdash;
            return 2470213.5 + 30694.8767 * kdash - 0.00541 * ksquared;
        }

        public static long NeptuneK(double Year)
        {
            return (long)(0.00607 * (Year - 2047.5));
        }

        public static double NeptunePerihelion(long k)
        {
            double kdash = k;
            double ksquared = kdash * kdash;
            return 2468895.1 + 60190.33 * kdash + 0.03429 * ksquared;
        }

        public static double NeptuneAphelion(long k)
        {
            double kdash = k + 0.5;
            double ksquared = kdash * kdash;
            return 2468895.1 + 60190.33 * kdash + 0.03429 * ksquared;
        }
    }
}
